using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class PayrollEntryForm : Form
    {
        private DateTimePicker dtpPeriodStart;
        private DataGridView dgvPayrollPreview;
        private Button btnLoad;
        private Button btnSavePayroll;

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public PayrollEntryForm()
        {
            InitializeComponent();
            PayrollUI();
        }

        private void PayrollUI()
        {
            // === Date Pickers ===
            Label lblStart = new Label
            {
                Text = "Payroll Period:",
                Location = new System.Drawing.Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(lblStart);

            dtpPeriodStart = new DateTimePicker
            {
                Name = "dtpPeriodStart",
                Location = new System.Drawing.Point(120, 15),
                Width = 200,
                Format = DateTimePickerFormat.Short
            };
            this.Controls.Add(dtpPeriodStart);

            // === Buttons ===
            btnLoad = new Button
            {
                Name = "btnLoad",
                Text = "Load Payroll",
                Location = new System.Drawing.Point(670, 15),
                Width = 120,
                Height = 30
            };
            btnLoad.Click += btnLoad_Click;
            this.Controls.Add(btnLoad);

            btnSavePayroll = new Button
            {
                Name = "btnSavePayroll",
                Text = "Save Payroll",
                Location = new System.Drawing.Point(800, 15),
                Width = 120,
                Height = 30
            };
            btnSavePayroll.Click += btnSavePayroll_Click;
            this.Controls.Add(btnSavePayroll);

            // === DataGridView ===
            dgvPayrollPreview = new DataGridView
            {
                Name = "dgvPayrollPreview",
                Location = new System.Drawing.Point(20, 60),
                Width = 900,
                Height = 400,
                AllowUserToAddRows = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };
            dgvPayrollPreview.CellEndEdit += dgvPayrollPreview_CellEndEdit;
            this.Controls.Add(dgvPayrollPreview);
        }


        private void PayrollProcessForm_Load(object sender, EventArgs e)
        {
            // Default to current month
            dtpPeriodStart.Value = new DateTime(DateTime.Now.Year, DateTime.Now.Month, 1);
        }

        private void btnLoad_Click(object sender, EventArgs e)
        {
            DateTime periodStart = dtpPeriodStart.Value.Date;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                string query = @"
                    SELECT e.EmployeeID,
                           e.FirstName + ' ' + e.LastName AS EmployeeName,
                           e.Department,
                           e.Position,
                           s.GrossSalary
                    FROM Employees e
                    JOIN Salaries s ON e.EmployeeID = s.EmployeeID";

                SqlDataAdapter da = new SqlDataAdapter(query, connection);
                DataTable dt = new DataTable();
                da.Fill(dt);

                // Add extra columns
                dt.Columns.Add("Deductions", typeof(decimal));
                dt.Columns.Add("Bonus", typeof(decimal));
                dt.Columns.Add("NetPay", typeof(decimal));

                foreach (DataRow row in dt.Rows)
                {
                    decimal gross = Convert.ToDecimal(row["GrossSalary"]);

                    // placeholders for now
                    decimal deductions = 1000;
                    decimal bonus = 500;
                    decimal netpay = gross - deductions + bonus;

                    row["Deductions"] = deductions;
                    row["Bonus"] = bonus;
                    row["NetPay"] = netpay;
                }

                dgvPayrollPreview.DataSource = dt;

                // Hide EmployeeID
                dgvPayrollPreview.Columns["EmployeeID"].Visible = false;

                // Make deductions & bonus editable
                dgvPayrollPreview.Columns["Deductions"].ReadOnly = false;
                dgvPayrollPreview.Columns["Bonus"].ReadOnly = false;
                dgvPayrollPreview.Columns["NetPay"].ReadOnly = true;
            }
        }

        private void dgvPayrollPreview_CellEndEdit(object sender, DataGridViewCellEventArgs e)
        {
            if (e.ColumnIndex == dgvPayrollPreview.Columns["Deductions"].Index ||
                e.ColumnIndex == dgvPayrollPreview.Columns["Bonus"].Index)
            {
                DataGridViewRow row = dgvPayrollPreview.Rows[e.RowIndex];
                decimal gross = Convert.ToDecimal(row.Cells["GrossSalary"].Value);
                decimal deductions = Convert.ToDecimal(row.Cells["Deductions"].Value);
                decimal bonus = Convert.ToDecimal(row.Cells["Bonus"].Value);
                row.Cells["NetPay"].Value = gross - deductions + bonus;
            }
        }


        private void btnSavePayroll_Click(object sender, EventArgs e)
        {
            DateTime payrollDate = dtpPeriodStart.Value.Date;

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                foreach (DataGridViewRow row in dgvPayrollPreview.Rows)
                {
                    if (row.IsNewRow) continue;

                    int employeeId = Convert.ToInt32(row.Cells["EmployeeID"].Value);
                    decimal gross = Convert.ToDecimal(row.Cells["GrossSalary"].Value);
                    decimal deductions = Convert.ToDecimal(row.Cells["Deductions"].Value);
                    decimal bonus = Convert.ToDecimal(row.Cells["Bonus"].Value);

                    string insertQuery = @"
                        INSERT INTO Payroll (EmployeeID, Date, GrossSalary, Deductions, Bonus, Status)
                        VALUES (@EmployeeID, @Date, @GrossSalary, @Deductions, @Bonus, @Status)";

                    using (SqlCommand cmd = new SqlCommand(insertQuery, connection))
                    {
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmd.Parameters.AddWithValue("@Date", payrollDate);
                        cmd.Parameters.AddWithValue("@GrossSalary", gross);
                        cmd.Parameters.AddWithValue("@Deductions", deductions);
                        cmd.Parameters.AddWithValue("@Bonus", bonus);
                        cmd.Parameters.AddWithValue("@Status", "Pending");
                        cmd.ExecuteNonQuery();
                    }
                }
            }

            MessageBox.Show("Payroll processed and saved successfully!");
            this.Close();
        }


    }
}
