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

            SalaryForm();
            LoadSalaries();
        }

        private void SalaryForm()
        {
            Label titleLabel = new Label
            {
                Text = "Salary Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            dgvSalaries = new DataGridView
            {
                Location = new Point(20, 80),
                Size = new Size(900, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvSalaries);

            Button btnAdd = new Button
            {
                Text = "Set Salary",
                Location = new Point(20, 500),
                Size = new Size(120, 40),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(160, 500),
                Size = new Size(80, 40),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(btnEdit);
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
                dgvSalaries.DataSource = dt;
            }
        }

        private void BtnAdd_Click(object sender, EventArgs e)
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

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvSalaries.SelectedRows.Count > 0)
            {
                int salaryId = Convert.ToInt32(dgvSalaries.SelectedRows[0].Cells["SalaryID"].Value);
                int empId = GetEmployeeIDFromSalary(salaryId);
                decimal currentGross = Convert.ToDecimal(dgvSalaries.SelectedRows[0].Cells["GrossSalary"].Value);

                using (SalaryDetailsForm details = new SalaryDetailsForm())
                {
                    // prefill employee & gross salary (optional, you can extend this)
                    details.EmployeeID = empId;
                    details.GrossSalary = Convert.ToDecimal(dgvSalaries.SelectedRows[0].Cells["GrossSalary"].Value);

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


    }
}
