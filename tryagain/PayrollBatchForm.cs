using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class PayrollBatchForm : Form
    {

        private DateTimePicker dtpPayPeriodStart;
        private DateTimePicker dtpPayPeriodEnd;
        private DateTimePicker dtpPaymentDate;
        private DataGridView dgvBatches;
        private Button btnGenerateBatch;
        private Button btnViewBatch;
        private Button btnRefresh;

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public PayrollBatchForm()
        {
            this.Text = "Payroll Batches";
            this.Size = new Size(1000, 600);
            InitializePayrollBatchUI();
            Load += PayrollBatchForm_Load;
        }

        private void PayrollBatchForm_Load(object sender, EventArgs e)
        {
            // sensible defaults
            dtpPayPeriodStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpPayPeriodEnd.Value = dtpPayPeriodStart.Value.AddMonths(1).AddDays(-1);
            dtpPaymentDate.Value = DateTime.Now.Date;
            LoadBatches();
        }

        private void InitializePayrollBatchUI()
        {
            // Labels + date pickers
            Label lblPeriod = new Label { Text = "Pay Period Start:", Location = new Point(10, 14), AutoSize = true };
            this.Controls.Add(lblPeriod);

            dtpPayPeriodStart = new DateTimePicker { Location = new Point(120, 10), Width = 150, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpPayPeriodStart);

            Label lblPeriodEnd = new Label { Text = "End:", Location = new Point(280, 14), AutoSize = true };
            this.Controls.Add(lblPeriodEnd);

            dtpPayPeriodEnd = new DateTimePicker { Location = new Point(315, 10), Width = 150, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpPayPeriodEnd);

            Label lblPayment = new Label { Text = "Payment Date:", Location = new Point(480, 14), AutoSize = true };
            this.Controls.Add(lblPayment);

            dtpPaymentDate = new DateTimePicker { Location = new Point(560, 10), Width = 150, Format = DateTimePickerFormat.Short };
            this.Controls.Add(dtpPaymentDate);

            // Buttons
            btnGenerateBatch = new Button { Text = "Generate Draft Batch", Location = new Point(730, 8), Width = 150 };
            btnGenerateBatch.Click += BtnGenerateBatch_Click;
            this.Controls.Add(btnGenerateBatch);

            btnRefresh = new Button { Text = "Refresh", Location = new Point(890, 8), Width = 75 };
            btnRefresh.Click += (s, e) => LoadBatches();
            this.Controls.Add(btnRefresh);

            // DataGridView for batches (auto-generate columns from DataSource)
            dgvBatches = new DataGridView
            {
                Location = new Point(10, 50),
                Size = new Size(960, 490),
                ReadOnly = true,
                AllowUserToAddRows = false,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            this.Controls.Add(dgvBatches);

            // Right-click or button to view batch details
            btnViewBatch = new Button { Text = "View Selected Batch", Location = new Point(10, 540), Width = 160 };
            btnViewBatch.Click += BtnViewBatch_Click;
            this.Controls.Add(btnViewBatch);

            dgvBatches.DoubleClick += (s, e) => BtnViewBatch_Click(s, e);
        }

        private void LoadBatches()
        {
            const string sql = @"
                SELECT 
                    * FROM 
                    dbo.vw_PayrollBatchSummary
                ORDER BY 
                    [Payment Date] DESC, [batch_id] DESC;";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            using (SqlDataAdapter da = new SqlDataAdapter(cmd))
            {
                da.Fill(dt);
            }

            dgvBatches.DataSource = dt;

            // Hide internal id column if present (we'll use it when viewing)
            if (dgvBatches.Columns.Contains("batch_id"))
                dgvBatches.Columns["batch_id"].Visible = false;

            // nicer headers
            if (dgvBatches.Columns.Contains("pay_period_start"))
                dgvBatches.Columns["pay_period_start"].HeaderText = "Period Start";
            if (dgvBatches.Columns.Contains("pay_period_end"))
                dgvBatches.Columns["pay_period_end"].HeaderText = "Period End";
            if (dgvBatches.Columns.Contains("payment_date"))
                dgvBatches.Columns["payment_date"].HeaderText = "Payment Date";
            if (dgvBatches.Columns.Contains("total_employees"))
                dgvBatches.Columns["total_employees"].HeaderText = "Total Employees";
            if (dgvBatches.Columns.Contains("total_net_pay"))
                dgvBatches.Columns["total_net_pay"].HeaderText = "Total Net Pay";
        }

        private void BtnGenerateBatch_Click(object sender, EventArgs e)
        {
            DateTime periodStart = dtpPayPeriodStart.Value.Date;
            DateTime periodEnd = dtpPayPeriodEnd.Value.Date;
            DateTime paymentDate = dtpPaymentDate.Value.Date;

            // basic validation
            if (periodEnd < periodStart)
            {
                MessageBox.Show("Pay period end must be on/after start date.", "Invalid period", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ask for confirmation
            var confirm = MessageBox.Show(
                $"Generate draft payroll batch for period {periodStart:d} - {periodEnd:d} with payment date {paymentDate:d}?",
                "Confirm Generate",
                MessageBoxButtons.YesNo,
                MessageBoxIcon.Question);

            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // 1) Insert batch row (status Pending)
                    string insertBatchSql = @"
                            INSERT INTO Payroll_Batch (pay_period_start, pay_period_end, payment_date, status, total_net_pay)
                            VALUES (@start, @end, @payment, @status, 0);
                            SELECT CAST(SCOPE_IDENTITY() AS INT);";

                    int batchId;
                    using (SqlCommand cmd = new SqlCommand(insertBatchSql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@start", periodStart);
                        cmd.Parameters.AddWithValue("@end", periodEnd);
                        cmd.Parameters.AddWithValue("@payment", paymentDate);
                        cmd.Parameters.AddWithValue("@status", "Pending");
                        object idObj = cmd.ExecuteScalar();
                        batchId = Convert.ToInt32(idObj);
                    }

                    // 2) Query employees and their salaries (you can tweak filter e.g. only active employees)
                    string selectEmployees = @"
                            SELECT e.EmployeeID, e.FirstName, e.LastName, ISNULL(s.GrossSalary, 0) AS GrossSalary
                            FROM Employees e
                            LEFT JOIN Salaries s ON e.EmployeeID = s.EmployeeID
                            -- optionally filter active employees, e.g. WHERE e.Status = 'Active'
                            ORDER BY e.LastName, e.FirstName;";

                    DataTable employees = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(selectEmployees, conn, tx))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(employees);
                    }

                    // 3) Insert Payroll_Record per employee using simple placeholder calculations
                    string insertRecordSql = @"
                        INSERT INTO Payroll_Record
                            (batch_id, employee_id, gross_salary, base_pay, deductions_total, bonus_amount, net_pay)
                        VALUES
                            (@batch, @emp, @gross, @base, @deductions, @bonus, @net);";

                    decimal runningTotalNetPay = 0m;
                    using (SqlCommand cmdInsert = new SqlCommand(insertRecordSql, conn, tx))
                    {
                        cmdInsert.Parameters.Add("@batch", SqlDbType.Int);
                        cmdInsert.Parameters.Add("@emp", SqlDbType.Int);
                        cmdInsert.Parameters.Add("@gross", SqlDbType.Decimal);
                        cmdInsert.Parameters.Add("@base", SqlDbType.Decimal);
                        cmdInsert.Parameters.Add("@deductions", SqlDbType.Decimal);
                        cmdInsert.Parameters.Add("@bonus", SqlDbType.Decimal);
                        cmdInsert.Parameters.Add("@net", SqlDbType.Decimal);

                        // set precision/scale for decimal parameters if needed
                        cmdInsert.Parameters["@gross"].Precision = 18; cmdInsert.Parameters["@gross"].Scale = 2;
                        cmdInsert.Parameters["@base"].Precision = 18; cmdInsert.Parameters["@base"].Scale = 2;
                        cmdInsert.Parameters["@deductions"].Precision = 18; cmdInsert.Parameters["@deductions"].Scale = 2;
                        cmdInsert.Parameters["@bonus"].Precision = 18; cmdInsert.Parameters["@bonus"].Scale = 2;
                        cmdInsert.Parameters["@net"].Precision = 18; cmdInsert.Parameters["@net"].Scale = 2;

                        foreach (DataRow r in employees.Rows)
                        {
                            int empId = Convert.ToInt32(r["EmployeeID"]);
                            decimal gross = Convert.ToDecimal(r["GrossSalary"]);

                            // ---- PLACEHOLDER CALCULATIONS (replace with your real logic) ----
                            decimal basePay = gross;                       // base pay (or pro-rate if partial period)
                            decimal deductions = 0m;                       // default deductions (use attendance/taxes later)
                            decimal bonus = 0m;                            // default bonus (pulled from approvals later)
                            // Example: simple absence deduction (uncomment & adapt if Attendance exists)
                            // int absences = GetAbsences(empId, periodStart, periodEnd, conn, tx);
                            // decimal dailyRate = gross / 22m;
                            // deductions += dailyRate * absences;
                            // -----------------------------------------------------------------

                            decimal net = basePay - deductions + bonus;
                            runningTotalNetPay += net;

                            cmdInsert.Parameters["@batch"].Value = batchId;
                            cmdInsert.Parameters["@emp"].Value = empId;
                            cmdInsert.Parameters["@gross"].Value = gross;
                            cmdInsert.Parameters["@base"].Value = basePay;
                            cmdInsert.Parameters["@deductions"].Value = deductions;
                            cmdInsert.Parameters["@bonus"].Value = bonus;
                            cmdInsert.Parameters["@net"].Value = net;

                            cmdInsert.ExecuteNonQuery();
                        }
                    }

                    // 4) Update batch total_net_pay and commit
                    string updateBatchTotalSql = @"
                            UPDATE Payroll_Batch
                            SET total_net_pay = @total
                            WHERE batch_id = @batchId;";

                    using (SqlCommand cmd = new SqlCommand(updateBatchTotalSql, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@total", runningTotalNetPay);
                        cmd.Parameters.AddWithValue("@batchId", batchId);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();

                    MessageBox.Show($"Draft batch #{batchId} created with {employees.Rows.Count} employee records.\nTotal Net Pay: {runningTotalNetPay:C2}", "Batch Created", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // refresh grid
                    LoadBatches();
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { /* ignore */ }
                    MessageBox.Show("Failed to generate batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void BtnViewBatch_Click(object sender, EventArgs e)
        {
            if (dgvBatches.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a batch row first.", "View Batch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvBatches.SelectedRows[0];
            if (!dgvBatches.Columns.Contains("batch_id"))
            {
                MessageBox.Show("Batch ID not found in grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int batchId = Convert.ToInt32(row.Cells["batch_id"].Value);

            // Open details form (we'll implement this form next)
            var details = new PayrollBatchDetailsForm(batchId);
            details.ShowDialog();

            // refresh after potential edits
            LoadBatches();
        }




    }
}
