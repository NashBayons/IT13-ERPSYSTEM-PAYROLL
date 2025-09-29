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
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private string mode = "add";
        private int? payrollId = null;
        private bool isEditMode = false;
        public PayrollEntryForm()
        {
            InitializeComponent();
            mode = "add";
            datePicker.Value = DateTime.Today;
            LoadEmployees();
            LoadStatusOptions();
        }

        public PayrollEntryForm(int payrollIdToEdit)
        {
            InitializeComponent();
            isEditMode = true;
            payrollId = payrollIdToEdit;
            LoadEmployees();
            LoadStatusOptions();
            LoadPayrollDetails(payrollId.Value);
        }

        private void LoadEmployees()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "SELECT employeeID, (firstname + ' ' + lastname) AS fullName FROM Employees";
                    SqlDataAdapter adapter = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    employeeCmb.DataSource = dt;
                    employeeCmb.DisplayMember = "fullName";
                    employeeCmb.ValueMember = "employeeID";
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load employees: " + ex.Message);
            }
        }

        private void LoadStatusOptions()
        {
            statusCmb.Items.Add("Pending");
            statusCmb.Items.Add("Finalized");
            statusCmb.Items.Add("Paid");
            statusCmb.SelectedIndex = 0;
        }

        private void LoadPayrollDetails(int id)
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = "SELECT employeeID, date, GrossSalary, deductions, bonus, status FROM Payroll WHERE id = @id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@id", id);
                        SqlDataReader reader = cmd.ExecuteReader();

                        if (reader.Read())
                        {
                            employeeCmb.SelectedValue = reader["employeeID"];
                            datePicker.Value = Convert.ToDateTime(reader["date"]);
                            grossSalaryTxt.Text = reader["GrossSalary"].ToString();
                            deductionsTxt.Text = reader["deductions"].ToString();
                            bonusTxt.Text = reader["bonus"].ToString();
                            statusCmb.SelectedItem = reader["status"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Payroll record not found.");
                            this.Close();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Failed to load payroll: " + ex.Message);
            }
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            if (employeeCmb.SelectedIndex == -1 || string.IsNullOrWhiteSpace(grossSalaryTxt.Text))
            {
                MessageBox.Show("Please fill all required fields.");
                return;
            }

            try
            {
                int empID = Convert.ToInt32(employeeCmb.SelectedValue);
                decimal grossSalary = decimal.Parse(grossSalaryTxt.Text);
                decimal deductions = string.IsNullOrWhiteSpace(deductionsTxt.Text) ? 0 : decimal.Parse(deductionsTxt.Text);
                decimal bonus = string.IsNullOrWhiteSpace(bonusTxt.Text) ? 0 : decimal.Parse(bonusTxt.Text);
                string status = statusCmb.SelectedItem.ToString();
                DateTime payrollDate = datePicker.Value;

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = "INSERT INTO Payroll (employeeID, date, GrossSalary, deductions, bonus, status) " +
                                   "VALUES (@empID, @date, @gross, @deductions, @bonus, @status)";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@empID", empID);
                        cmd.Parameters.AddWithValue("@date", payrollDate);
                        cmd.Parameters.AddWithValue("@gross", grossSalary);
                        cmd.Parameters.AddWithValue("@deductions", deductions);
                        cmd.Parameters.AddWithValue("@bonus", bonus);
                        cmd.Parameters.AddWithValue("@status", status);

                        cmd.ExecuteNonQuery();
                    }
                }

                MessageBox.Show("Payroll entry saved successfully.");
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error saving payroll: " + ex.Message);
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
