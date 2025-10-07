using Microsoft.Data.SqlClient;
using Microsoft.VisualBasic.ApplicationServices;
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
    public partial class LoginForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        private string username;
        private string password;
        public LoginForm()
        {
            InitializeComponent();
            ClearField();
        }

        private void loginBtn_Click(object sender, EventArgs e)
        {
            username = usernameTxt.Text.Trim();
            password = passwordTxt.Text.Trim();

            int userId, empId;
            string role;
            if (AuthenticateUser(username, password, out role, out userId, out empId))
            {
                if (role == "admin")
                {
                    MessageBox.Show("Login successful! Welcome, Admin.");
                    MainForm adminForm = new MainForm();
                    adminForm.Show();
                    this.Hide();
                }
                else if (role == "employee")
                {
                    MessageBox.Show("Login successful! Welcome, Employee.");
                    Employee.EmployeeMainForm employeeForm = new Employee.EmployeeMainForm(userId, empId);
                    employeeForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Login successful! Role not recognized.");
                }
            }
            else
            {
                MessageBox.Show("Invalid username or password.");
            }

        }

        private bool AuthenticateUser(string username, string password, out string role, out int userId, out int empId)
        {
            role = string.Empty;
            userId = 0;
            empId = 0;

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                    SELECT ua.user_id, e.employeeid, ua.is_admin, ua.is_employee, ua.status
                    FROM usersaccount ua
                    LEFT JOIN Employees e ON ua.user_id = e.userid
                    WHERE ua.username = @Username 
                      AND ua.password = @Password 
                      AND ua.status = 'active'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Username", username);
                        command.Parameters.AddWithValue("@Password", password);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.HasRows)
                            {
                                reader.Read();

                                bool isAdmin = reader.GetByte(reader.GetOrdinal("is_admin")) == 1;
                                bool isEmployee = reader.GetByte(reader.GetOrdinal("is_employee")) == 1;

                                if (isAdmin)
                                {
                                    role = "admin";
                                }
                                else if (isEmployee)
                                {
                                    role = "employee";
                                    userId = reader.GetInt32(reader.GetOrdinal("user_id"));
                                    empId = reader.GetInt32(reader.GetOrdinal("employeeid"));
                                }
                                else
                                {
                                    role = "unknown";
                                }

                                return true;
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }

            return false;

        }

        private void ClearField()
        {
            if (usernameTxt != null) usernameTxt.Text = string.Empty;
            if (passwordTxt != null) passwordTxt.Text = string.Empty;
            if (usernameTxt != null) usernameTxt.Focus();
        }
    }
}
