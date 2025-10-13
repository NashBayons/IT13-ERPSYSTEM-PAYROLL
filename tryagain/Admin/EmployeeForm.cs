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
                string query = @"
                        SELECT 
                            e.EmployeeID,
                            e.FirstName,
                            e.LastName,
                            e.DepartmentID,
                            d.Name AS DepartmentName,
                            e.PositionID,
                            p.Name AS PositionName,
                            e.Status
                        FROM Employees e
                        LEFT JOIN Department d ON e.DepartmentID = d.Dept_ID
                        LEFT JOIN Position p ON e.PositionID = p.Position_ID
                        WHERE e.Status = 'Active';
                                                    ";
                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvEmployee.DataSource = dt;
                if (dgvEmployee.Columns.Contains("DepartmentID"))
                    dgvEmployee.Columns["DepartmentID"].Visible = false;

                if (dgvEmployee.Columns.Contains("PositionID"))
                    dgvEmployee.Columns["PositionID"].Visible = false;

                // Optional: make displayed columns more readable
                dgvEmployee.Columns["DepartmentName"].HeaderText = "Department";
                dgvEmployee.Columns["PositionName"].HeaderText = "Position";
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
                                SqlCommand checkUser = new SqlCommand(
                            "SELECT COUNT(*) FROM usersaccount WHERE username = @Username",
                            conn, transaction);
                                checkUser.Parameters.AddWithValue("@Username", form.Username);

                                int exists = (int)checkUser.ExecuteScalar();
                                if (exists > 0)
                                {
                                    throw new Exception("Username already exists. Please choose a different one.");
                                }
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
                            INSERT INTO Employees (userid, firstname, lastname, departmentID, positionID, status, hire_date)
                            VALUES (@UserId, @FirstName, @LastName, @DepartmentID, @PositionID, @Status, @HireDate);
                            SELECT SCOPE_IDENTITY();", conn, transaction);

                                cmdEmp.Parameters.AddWithValue("@UserId", newUserId);
                                cmdEmp.Parameters.AddWithValue("@FirstName", form.FirstName);
                                cmdEmp.Parameters.AddWithValue("@LastName", form.LastName);
                                cmdEmp.Parameters.AddWithValue("@DepartmentID", form.DepartmentId);
                                cmdEmp.Parameters.AddWithValue("@PositionID", form.PositionId);
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

            // Get details + contact info
            var details = GetExtraDetails(employeeId);

            using (var form = new EmployeeDetailsForm(
                dgvEmployee.CurrentRow.Cells["FirstName"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["LastName"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["DepartmentID"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["PositionID"].Value.ToString(),
                dgvEmployee.CurrentRow.Cells["Status"].Value.ToString(),
                details.email,
                details.dob,
                details.address,
                details.contactName,
                details.relationship,
                details.phone,
                isEditMode: true // hide user account
            ))
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
                                // Update Employees
                                SqlCommand cmdEmp = new SqlCommand(@"
                            UPDATE Employees
                            SET FirstName=@FirstName, LastName=@LastName,
                                DepartmentID=@DepartmentID, PositionID=@PositionID, Status=@Status
                            WHERE EmployeeID=@EmployeeID", conn, transaction);

                                cmdEmp.Parameters.AddWithValue("@FirstName", form.FirstName);
                                cmdEmp.Parameters.AddWithValue("@LastName", form.LastName);
                                cmdEmp.Parameters.AddWithValue("@DepartmentID", form.DepartmentId);
                                cmdEmp.Parameters.AddWithValue("@PositionID", form.PositionId);
                                cmdEmp.Parameters.AddWithValue("@Status", form.Status);
                                cmdEmp.Parameters.AddWithValue("@EmployeeID", employeeId);
                                cmdEmp.ExecuteNonQuery();

                                // Update EmployeeDetails
                                SqlCommand cmdDetails = new SqlCommand(@"
                            UPDATE EmployeeDetails
                            SET Email=@Email, Date_of_Birth=@DOB, Address=@Address
                            WHERE EmployeeID=@EmployeeID", conn, transaction);

                                cmdDetails.Parameters.AddWithValue("@Email", form.Email);
                                cmdDetails.Parameters.AddWithValue("@DOB", (object)form.DateOfBirth ?? DBNull.Value);
                                cmdDetails.Parameters.AddWithValue("@Address", form.Address);
                                cmdDetails.Parameters.AddWithValue("@EmployeeID", employeeId);
                                cmdDetails.ExecuteNonQuery();

                                // Update EmergencyContact
                                SqlCommand cmdContact = new SqlCommand(@"
                            UPDATE EmergencyContact
                            SET Contact_Name=@ContactName, Relationship=@Relationship, Phone_Number=@PhoneNumber
                            WHERE EmployeeID=@EmployeeID", conn, transaction);

                                cmdContact.Parameters.AddWithValue("@ContactName", form.ContactName);
                                cmdContact.Parameters.AddWithValue("@Relationship", form.Relationship);
                                cmdContact.Parameters.AddWithValue("@PhoneNumber", form.ContactPhone);
                                cmdContact.Parameters.AddWithValue("@EmployeeID", employeeId);
                                cmdContact.ExecuteNonQuery();

                                // ✅ Commit transaction
                                transaction.Commit();
                                MessageBox.Show("Employee updated successfully!");
                            }
                            catch (Exception ex)
                            {
                                transaction.Rollback();
                                MessageBox.Show("Error updating employee: " + ex.Message);
                            }
                        }
                    }
                    LoadEmployees();
                }
            }
        }

        private void deleteBtn1_Click(object sender, EventArgs e)
        {
            if (dgvEmployee == null || dgvEmployee.CurrentRow == null)
                return;

            int employeeId = Convert.ToInt32(dgvEmployee.CurrentRow.Cells["EmployeeID"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this employee?",
                                          "Confirm Delete",
                                          MessageBoxButtons.YesNo,
                                          MessageBoxIcon.Warning);

            if (confirm == DialogResult.Yes)
            {
                int userId = 0;

                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        conn.Open();

                        // 1. GET THE USERID: Query the Employees table for the associated user ID
                        SqlCommand cmdGetUserId = new SqlCommand(
                            "SELECT userid FROM Employees WHERE EmployeeID = @EmployeeID", conn);
                        cmdGetUserId.Parameters.AddWithValue("@EmployeeID", employeeId);

                        object result = cmdGetUserId.ExecuteScalar();

                        if (result == null || result == DBNull.Value)
                        {
                            MessageBox.Show("Error: Could not find associated user account (userid). Deletion halted.", "Data Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }

                        userId = Convert.ToInt32(result);

                        // --- Begin Soft Deletion ---

                        // 2. Mark the Employee as Inactive (Soft Delete)
                        SqlCommand cmdEmployee = new SqlCommand(
                            "UPDATE Employees SET Status = 'Inactive' WHERE EmployeeID = @EmployeeID", conn);
                        cmdEmployee.Parameters.AddWithValue("@EmployeeID", employeeId);
                        cmdEmployee.ExecuteNonQuery();

                        // 3. Mark the corresponding User Account as Inactive
                        SqlCommand cmdUserAccount = new SqlCommand(
                            "UPDATE UsersAccount SET Status = 'Inactive' WHERE user_id = @UserID", conn);

                        // We now use the reliable userId from the query above
                        cmdUserAccount.Parameters.AddWithValue("@UserID", userId);
                        cmdUserAccount.ExecuteNonQuery();
                    }

                    MessageBox.Show("Employee and associated user account marked as Inactive.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    LoadEmployees(); // refresh grid

                }
                catch (Exception ex)
                {
                    MessageBox.Show($"An error occurred during deletion: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private (string email, DateTime? dob, string address, string contactName, string relationship, string phone) GetExtraDetails(int employeeId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT d.Email, d.Date_of_Birth, d.Address,
                   c.Contact_Name, c.Relationship, c.Phone_Number
            FROM EmployeeDetails d
            LEFT JOIN EmergencyContact c ON d.EmployeeID = c.EmployeeID
            WHERE d.EmployeeID = @EmployeeID", conn);

                cmd.Parameters.AddWithValue("@EmployeeID", employeeId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        return (
                            reader["Email"].ToString(),
                            reader["Date_of_Birth"] == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(reader["Date_of_Birth"]),
                            reader["Address"].ToString(),
                            reader["Contact_Name"].ToString(),
                            reader["Relationship"].ToString(),
                            reader["Phone_Number"].ToString()
                        );
                    }
                }
            }
            return (null, null, null, null, null, null);
        }
    }
}
