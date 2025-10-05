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
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public PayrollBatchForm()
        {
            InitializeComponent();
            this.Text = "Payroll Batches";
            this.Size = new Size(1000, 600);
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            dtpPeriodFrom.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
            dtpPeriodTo.Value = dtpPeriodFrom.Value.AddMonths(1).AddDays(-1);
            dtpPayment.Value = DateTime.Now.Date;
            LoadBatches();
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

            dgvPayrollBatch.DataSource = dt;

            // Hide internal id column if present (we'll use it when viewing)
            if (dgvPayrollBatch.Columns.Contains("batch_id"))
                dgvPayrollBatch.Columns["batch_id"].Visible = false;

            // nicer headers
            if (dgvPayrollBatch.Columns.Contains("pay_period_start"))
                dgvPayrollBatch.Columns["pay_period_start"].HeaderText = "Period Start";
            if (dgvPayrollBatch.Columns.Contains("pay_period_end"))
                dgvPayrollBatch.Columns["pay_period_end"].HeaderText = "Period End";
            if (dgvPayrollBatch.Columns.Contains("payment_date"))
                dgvPayrollBatch.Columns["payment_date"].HeaderText = "Payment Date";
            if (dgvPayrollBatch.Columns.Contains("total_employees"))
                dgvPayrollBatch.Columns["total_employees"].HeaderText = "Total Employees";
            if (dgvPayrollBatch.Columns.Contains("total_net_pay"))
                dgvPayrollBatch.Columns["total_net_pay"].HeaderText = "Total Net Pay";
        }

        private (int absences, int halfdays, int lates) GetAttendanceSummary(int empId, DateTime start, DateTime end, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"SELECT status, COUNT(*) as cnt
                   FROM Attendance
                   WHERE employeeID = @empId 
                   AND date BETWEEN @start AND @end
                   GROUP BY status";

            int absences = 0, halfdays = 0, lates = 0;

            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string status = reader.GetString(0);
                        int count = reader.GetInt32(1);

                        switch (status)
                        {
                            case "Absent": absences = count; break;
                            case "Halfday": halfdays = count; break;
                            case "Late": lates = count; break;
                        }
                    }
                }
            }

            return (absences, halfdays, lates);
        }


        private int GetUnpaidLeaveDays(int empId, DateTime start, DateTime end, SqlConnection conn, SqlTransaction tx)
        {
            string sql = @"SELECT ISNULL(SUM(DATEDIFF(DAY, start_date, end_date) + 1),0)
                   FROM Leave_Record
                   WHERE employee_id = @empId
                   AND leave_type = 'Unpaid'
                   AND status = 'Approved'
                   AND ((start_date BETWEEN @start AND @end) OR (end_date BETWEEN @start AND @end))";

            using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
            {
                cmd.Parameters.AddWithValue("@empId", empId);
                cmd.Parameters.AddWithValue("@start", start);
                cmd.Parameters.AddWithValue("@end", end);
                return Convert.ToInt32(cmd.ExecuteScalar());
            }
        }

        private void gendraftBtn_Click(object sender, EventArgs e)
        {
            DateTime periodStart = dtpPeriodFrom.Value.Date;
            DateTime periodEnd = dtpPeriodTo.Value.Date;
            DateTime paymentDate = dtpPayment.Value.Date;

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
                    // 1) Insert batch row
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
                        batchId = Convert.ToInt32(cmd.ExecuteScalar());
                    }

                    // 2) Query employees
                    string selectEmployees = @"
                SELECT e.EmployeeID, e.FirstName, e.LastName, ISNULL(s.GrossSalary, 0) AS GrossSalary
                FROM Employees e
                LEFT JOIN Salaries s ON e.EmployeeID = s.EmployeeID
                ORDER BY e.LastName, e.FirstName;";

                    DataTable employees = new DataTable();
                    using (SqlCommand cmd = new SqlCommand(selectEmployees, conn, tx))
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                    {
                        da.Fill(employees);
                    }

                    decimal runningTotalNetPay = 0m;

                    // 3) Process each employee
                    foreach (DataRow r in employees.Rows)
                    {
                        int empId = Convert.ToInt32(r["EmployeeID"]);
                        decimal gross = Convert.ToDecimal(r["GrossSalary"]);
                        decimal basePay = gross;

                        // daily/hourly rates
                        decimal dailyRate = gross / 22m;   // assume 22 working days
                        decimal hourlyRate = dailyRate / 8m;

                        // --- Attendance summary ---
                        var (absences, halfdays, lates) = GetAttendanceSummary(empId, periodStart, periodEnd, conn, tx);

                        // --- Unpaid leave days ---
                        int unpaidLeaves = GetUnpaidLeaveDays(empId, periodStart, periodEnd, conn, tx);

                        // --- Deduction calculation ---
                        decimal absenceDeduction = absences * dailyRate;
                        decimal halfdayDeduction = halfdays * (dailyRate / 2);
                        decimal lateDeduction = lates * hourlyRate; // or flat penalty
                        decimal leaveDeduction = unpaidLeaves * dailyRate;

                        decimal deductions = absenceDeduction + halfdayDeduction + lateDeduction + leaveDeduction;

                        // Bonus placeholder
                        decimal bonus = 0m;

                        // Net pay
                        decimal net = basePay - deductions + bonus;
                        runningTotalNetPay += net;

                        // 4) Insert payroll record and get its ID
                        string insertRecordSql = @"
                    INSERT INTO Payroll_Record
                        (batch_id, employee_id, gross_salary, base_pay, deductions_total, bonus_amount, net_pay)
                    VALUES
                        (@batch, @emp, @gross, @base, @deductions, @bonus, @net);
                    SELECT CAST(SCOPE_IDENTITY() AS INT);";

                        int recordId;
                        using (SqlCommand cmd = new SqlCommand(insertRecordSql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@batch", batchId);
                            cmd.Parameters.AddWithValue("@emp", empId);
                            cmd.Parameters.AddWithValue("@gross", gross);
                            cmd.Parameters.AddWithValue("@base", basePay);
                            cmd.Parameters.AddWithValue("@deductions", deductions);
                            cmd.Parameters.AddWithValue("@bonus", bonus);
                            cmd.Parameters.AddWithValue("@net", net);
                            recordId = Convert.ToInt32(cmd.ExecuteScalar());
                        }

                        // 5) Insert deduction breakdown rows
                        string insertDeductionSql = "INSERT INTO Deduction_Record (payroll_record_id, deduction_type, amount) VALUES (@rec, @type, @amt)";
                        using (SqlCommand cmdDed = new SqlCommand(insertDeductionSql, conn, tx))
                        {
                            cmdDed.Parameters.Add("@rec", SqlDbType.Int).Value = recordId;
                            cmdDed.Parameters.Add("@type", SqlDbType.VarChar);
                            cmdDed.Parameters.Add("@amt", SqlDbType.Decimal).Precision = 18;
                            cmdDed.Parameters["@amt"].Scale = 2;

                            if (absenceDeduction > 0)
                            {
                                cmdDed.Parameters["@type"].Value = "Absences";
                                cmdDed.Parameters["@amt"].Value = absenceDeduction;
                                cmdDed.ExecuteNonQuery();
                            }
                            if (halfdayDeduction > 0)
                            {
                                cmdDed.Parameters["@type"].Value = "Halfday";
                                cmdDed.Parameters["@amt"].Value = halfdayDeduction;
                                cmdDed.ExecuteNonQuery();
                            }
                            if (lateDeduction > 0)
                            {
                                cmdDed.Parameters["@type"].Value = "Late";
                                cmdDed.Parameters["@amt"].Value = lateDeduction;
                                cmdDed.ExecuteNonQuery();
                            }
                            if (leaveDeduction > 0)
                            {
                                cmdDed.Parameters["@type"].Value = "Unpaid Leave";
                                cmdDed.Parameters["@amt"].Value = leaveDeduction;
                                cmdDed.ExecuteNonQuery();
                            }
                        }
                    }

                    // 6) Update batch totals
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
                    try { tx.Rollback(); } catch { }
                    MessageBox.Show("Failed to generate batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void refreshBtn_Click(object sender, EventArgs e)
        {
            LoadBatches();
        }

        private void viewbatchBtn_Click(object sender, EventArgs e)
        {
            if (dgvPayrollBatch.SelectedRows.Count == 0)
            {
                MessageBox.Show("Select a batch row first.", "View Batch", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPayrollBatch.SelectedRows[0];
            if (!dgvPayrollBatch.Columns.Contains("batch_id"))
            {
                MessageBox.Show("Batch ID not found in grid.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }


            int batchId = Convert.ToInt32(row.Cells["batch_id"].Value);
            string status = row.Cells["status"].Value.ToString();

            // Open details form (we'll implement this form next)
            var details = new PayrollBatchDetailsForm(batchId, status);
            details.ShowDialog();

            // refresh after potential edits
            LoadBatches();
        }
    }
}
