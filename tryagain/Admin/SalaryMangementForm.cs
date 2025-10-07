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
    public partial class SalaryMangementForm : Form
    {
        private DataGridView dgvSalaries;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public SalaryMangementForm()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            LoadSalaries();
        }
        private void LoadSalaries()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(@"
                    SELECT s.SalaryID,
                           e.FirstName + ' ' + e.LastName AS EmployeeName,
                           e.Department,
                           e.Position,
                           s.GrossSalary
                    FROM Salaries s
                    JOIN Employees e ON s.EmployeeID = e.EmployeeID", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvSalaryGrid.DataSource = dt;
            }
        }

        private int GetEmployeeIDFromSalary(int salaryId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmployeeID FROM Salaries WHERE SalaryID = @id", conn);
                cmd.Parameters.AddWithValue("@id", salaryId);
                return (int)cmd.ExecuteScalar();
            }
        }

        private void addSalaryBtn_Click(object sender, EventArgs e)
        {
            using (SalaryDetailsForm details = new SalaryDetailsForm())
            {
                if (details.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Salaries (EmployeeID, GrossSalary) VALUES (@empId, @gross)", conn);
                        cmd.Parameters.AddWithValue("@empId", details.EmployeeID);
                        cmd.Parameters.AddWithValue("@gross", details.GrossSalary);
                        cmd.ExecuteNonQuery();
                    }
                    LoadSalaries();
                }
            }
        }

        private void editSalaryBtn_Click(object sender, EventArgs e)
        {
            if (dgvSalaryGrid.SelectedRows.Count > 0)
            {
                int salaryId = Convert.ToInt32(dgvSalaryGrid.SelectedRows[0].Cells["SalaryID"].Value);
                int empId = GetEmployeeIDFromSalary(salaryId);
                decimal currentGross = Convert.ToDecimal(dgvSalaryGrid.SelectedRows[0].Cells["GrossSalary"].Value);

                using (SalaryDetailsForm details = new SalaryDetailsForm())
                {
                    details.EmployeeID = empId;
                    details.GrossSalary = Convert.ToDecimal(dgvSalaryGrid.SelectedRows[0].Cells["GrossSalary"].Value);

                    if (details.ShowDialog() == DialogResult.OK)
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            conn.Open();
                            SqlCommand cmd = new SqlCommand(
                                "UPDATE Salaries SET GrossSalary = @gross WHERE SalaryID = @id", conn);
                            cmd.Parameters.AddWithValue("@gross", details.GrossSalary);
                            cmd.Parameters.AddWithValue("@id", salaryId);
                            cmd.ExecuteNonQuery();
                        }
                        LoadSalaries();
                    }
                }
            }
        }
    }
}
