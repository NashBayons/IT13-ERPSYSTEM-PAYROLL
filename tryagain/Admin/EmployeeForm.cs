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

                        using (SqlTransaction transaction = conn.BeginTransaction())
                        {
                            try
                            {
                                // 1) Insert into usersaccount
                                SqlCommand cmdUser = new SqlCommand(@"
                            INSERT INTO usersaccount (username, password, is_admin, is_employee, status)
                            VALUES (@Username, @Password, 0, 1, 'active');
                            SELECT SCOPE_IDENTITY();", conn, transaction);

                                cmdUser.Parameters.AddWithValue("@Username", form.Username);
                                cmdUser.Parameters.AddWithValue("@Password", form.Password); // ⚠ hash in real app!

                                int newUserId = Convert.ToInt32(cmdUser.ExecuteScalar());

                                // 2) Insert into Employee
                                SqlCommand cmdEmp = new SqlCommand(@"
                            INSERT INTO Employees (userid, firstname, lastname, department, position, status, hire_date)
                            VALUES (@UserId, @FirstName, @LastName, @Department, @Position, @Status, @HireDate);
                            SELECT SCOPE_IDENTITY();", conn, transaction);

                                cmdEmp.Parameters.AddWithValue("@UserId", newUserId);
                                cmdEmp.Parameters.AddWithValue("@FirstName", form.FirstName);
                                cmdEmp.Parameters.AddWithValue("@LastName", form.LastName);
                                cmdEmp.Parameters.AddWithValue("@Department", form.Department);
                                cmdEmp.Parameters.AddWithValue("@Position", form.Position);
                                cmdEmp.Parameters.AddWithValue("@Status", form.Status);
                                cmdEmp.Parameters.AddWithValue("@HireDate", form.HireDate);

                                int newEmpId = Convert.ToInt32(cmdEmp.ExecuteScalar());

                                // 3) Insert into EmployeeDetails
                                SqlCommand cmdDetails = new SqlCommand(@"
                            INSERT INTO EmployeeDetails (employeeid, email, date_of_birth, address)
                            VALUES (@EmpId, @Email, @DOB, @Address);", conn, transaction);

                                cmdDetails.Parameters.AddWithValue("@EmpId", newEmpId);
                                cmdDetails.Parameters.AddWithValue("@Email", form.Email);
                                cmdDetails.Parameters.AddWithValue("@DOB", (object)form.DateOfBirth ?? DBNull.Value);
                                cmdDetails.Parameters.AddWithValue("@Address", form.Address);

                                cmdDetails.ExecuteNonQuery();

                                // 4) Insert into EmergencyContact
                                SqlCommand cmdContact = new SqlCommand(@"
                            INSERT INTO EmergencyContact (employeeid, contact_name, relationship, phone_number)
                            VALUES (@EmpId, @ContactName, @Relationship, @PhoneNumber);", conn, transaction);

                                cmdContact.Parameters.AddWithValue("@EmpId", newEmpId);
                                cmdContact.Parameters.AddWithValue("@ContactName", form.ContactName);
                                cmdContact.Parameters.AddWithValue("@Relationship", form.Relationship);
                                cmdContact.Parameters.AddWithValue("@PhoneNumber", form.ContactPhone);

                                cmdContact.ExecuteNonQuery();

                                // ✅ Commit transaction
                                transaction.Commit();

                                MessageBox.Show("Employee and user account created successfully!");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error adding employee: " + ex.Message);
                            }
                        }
                    }

                    LoadEmployees(); // refresh your DataGrid or list
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
