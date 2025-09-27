using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class EmployeeForm : Form
    {
        private DataGridView dgvEmployees;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public EmployeeForm()
        {
            InitializeComponent();
            LoadEmployees();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }

        private void LoadEmployees()
        {
            this.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "Employees123",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            dgvEmployees = new DataGridView
            {
                Name = "dgvEmployees", // give it a name so we can reuse later
                Location = new Point(20, 80),
                Size = new Size(800, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvEmployees);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName, Department, Position, Status FROM Employees", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployees.DataSource = dt;
            }

            Button btnAdd = new Button
            {
                Text = "Add Employee",
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

            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(260, 500),
                Size = new Size(80, 40),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);
        }

        private void BtnAdd_Click(object sender, EventArgs e)
        {
            using (var form = new EmployeeDetailsForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "INSERT INTO Employees (FirstName, LastName, Department, Position, Status) VALUES (@FirstName, @LastName, @Department, @Position, @Status)", conn);

                        cmd.Parameters.AddWithValue("@FirstName", form.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", form.LastName);
                        cmd.Parameters.AddWithValue("@Department", form.Department);
                        cmd.Parameters.AddWithValue("@Position", form.Position);
                        cmd.Parameters.AddWithValue("@Status", form.Status);

                        cmd.ExecuteNonQuery();
                    }
                   
                    LoadEmployees();
                }
            }
        }

        private void BtnEdit_Click(object sender, EventArgs e)
        {
            if (dgvEmployees.CurrentRow == null) return;

            int employeeId = Convert.ToInt32(dgvEmployees.CurrentRow.Cells["EmployeeID"].Value);

            using (var form = new EmployeeDetailsForm(
                dgvEmployees.CurrentRow.Cells["FirstName"].Value.ToString(),
                dgvEmployees.CurrentRow.Cells["LastName"].Value.ToString(),
                dgvEmployees.CurrentRow.Cells["Department"].Value.ToString(),
                dgvEmployees.CurrentRow.Cells["Position"].Value.ToString(),
                dgvEmployees.CurrentRow.Cells["Status"].Value.ToString()
            ))
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();
                        SqlCommand cmd = new SqlCommand(
                            "UPDATE Employees SET FirstName=@FirstName, LastName=@LastName, Department=@Department, Position=@Position, Status=@Status WHERE EmployeeID=@EmployeeID", conn);

                        cmd.Parameters.AddWithValue("@FirstName", form.FirstName);
                        cmd.Parameters.AddWithValue("@LastName", form.LastName);
                        cmd.Parameters.AddWithValue("@Department", form.Department);
                        cmd.Parameters.AddWithValue("@Position", form.Position);
                        cmd.Parameters.AddWithValue("@Status", form.Status);
                        cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                        cmd.ExecuteNonQuery();
                    }
                    LoadEmployees();
                }
            }
        }

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.Controls["dgvEmployees"] as DataGridView;
            if (dgv.CurrentRow == null) return;

            int employeeId = Convert.ToInt32(dgv.CurrentRow.Cells["EmployeeID"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this employee?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Employees WHERE EmployeeID=@EmployeeID", conn);
                    cmd.Parameters.AddWithValue("@EmployeeID", employeeId);
                    cmd.ExecuteNonQuery();
                }

                LoadEmployees(); // refresh grid
            }
        }
    }
    public class Employee
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
    }
}
