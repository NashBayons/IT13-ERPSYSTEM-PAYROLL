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

namespace tryagain.Employee
{
    public partial class Payroll_System : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _empId;
        public Payroll_System(int empId)
        {
            InitializeComponent();
            _empId = empId;

            LoadPayrollHistory();
        }

        private void LoadPayrollHistory()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    pr.payroll_record_id,
                    pb.pay_period_start,
                    pb.pay_period_end,
                    pb.payment_date,
                    pr.base_pay,
                    pr.gross_salary,
                    pr.deductions_total,
                    pr.bonus_amount,
                    pr.net_pay
                FROM Payroll_Record pr
                INNER JOIN Payroll_Batch pb ON pr.batch_id = pb.batch_id
                WHERE pr.employee_id = @EmpId
                ORDER BY pb.pay_period_start DESC;";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpId", _empId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // 🟢 Current payroll (first row is the latest period)
                                MonthYearLabel.Text = $"{Convert.ToDateTime(reader["pay_period_start"]).ToShortDateString()} - {Convert.ToDateTime(reader["pay_period_end"]).ToShortDateString()}";
                                paymentdateLabel.Text = Convert.ToDateTime(reader["payment_date"]).ToShortDateString();
                                basepayValueLabel.Text = $"₱{reader["base_pay"]:N2}";
                                grossSalaryValueLabel.Text = $"₱{reader["gross_salary"]:N2}";
                                deductionsValueLabel.Text = $"₱{reader["deductions_total"]:N2}";
                                bonusesValueLabel.Text = $"₱{reader["bonus_amount"]:N2}";
                                netpayValueLabel.Text = $"₱{reader["net_pay"]:N2}";
                            }

                            // Move reader back to start for full history
                            reader.Close();

                            // 🟡 Payroll history (fill DataGridView)
                            SqlDataAdapter adapter = new SqlDataAdapter(command);
                            DataTable dt = new DataTable();
                            adapter.Fill(dt);

                            payrollDvg.DataSource = dt;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payroll: {ex.Message}");
            }
        }
    }
}
