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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT EmployeeID, FirstName, LastName, Department, Position, Status FROM Employees", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployee.DataSource = dt;
            }

        }

        private void addEmpBtn_Click(object sender, EventArgs e)
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

        private void editBtn1_Click(object sender, EventArgs e)
        {
            if (dgvEmployee.CurrentRow == null) return;

            int employeeId = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["EmployeeID"].Value);

            using (var form = new EmployeeDetailsForm(
                dgvEmployee.CurrentRow.Cells["FirstName"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["LastName"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["Department"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["Position"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["Status"].Value.ToString()
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

        private void deleteBtn1_Click(object sender, EventArgs e)
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
}
