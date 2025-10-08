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
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tryagain.Employee
{
    public partial class AccountEmployee : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _userId;
        private int _empId;
        public AccountEmployee(int userId, int empId)
        {
            _userId = userId;
            _empId = empId;
            InitializeComponent();
            LoadCurrentCredential();
        }

        private void LoadCurrentCredential()
        {
            try 
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @" Select username, password
                                    FROM usersAccount
                                    Where user_id = @userid
                                        ";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@userid", _userId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                curUsernameTxt.Text = reader["username"].ToString();
                                curPasswordTxt.Text = reader["password"].ToString();

                            }
                            else
                            {
                                MessageBox.Show("Employee not found.");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee credential: {ex.Message}");
            }
        }
        
        private void saveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(newUsernameTxt.Text) &&
        string.IsNullOrWhiteSpace(newPasswordTxt.Text))
            {
                MessageBox.Show("No changes to save.");
                return;
            }

            if (!string.IsNullOrWhiteSpace(newPasswordTxt.Text))
            {
                if (newPasswordTxt.Text != newConfirmPasswordTxt.Text)
                {
                    MessageBox.Show("New password and confirmation do not match.");
                    return;
                }
            }

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlTransaction transaction = conn.BeginTransaction();

                try
                {
                    // Update username if provided
                    if (!string.IsNullOrWhiteSpace(newUsernameTxt.Text))
                    {
                        SqlCommand cmdUsername = new SqlCommand(@"
                    UPDATE usersaccount
                    SET username = @NewUsername
                    WHERE user_id = @UserId", conn, transaction);

                        cmdUsername.Parameters.AddWithValue("@NewUsername", newUsernameTxt.Text.Trim());
                        cmdUsername.Parameters.AddWithValue("@UserId", _userId);

                        cmdUsername.ExecuteNonQuery();
                    }

                    // Update password if provided
                    if (!string.IsNullOrWhiteSpace(newPasswordTxt.Text))
                    {
                        // ⚠️ Ideally hash before storing:
                        // string hashed = ComputeSha256Hash(txtNewPassword.Text);
                        string newPass = newPasswordTxt.Text;

                        SqlCommand cmdPassword = new SqlCommand(@"
                    UPDATE usersaccount
                    SET password = @NewPassword
                    WHERE user_id = @UserId", conn, transaction);

                        cmdPassword.Parameters.AddWithValue("@NewPassword", newPass);
                        cmdPassword.Parameters.AddWithValue("@UserId", _userId);

                        cmdPassword.ExecuteNonQuery();
                    }

                    transaction.Commit();
                    MessageBox.Show("Account settings updated successfully.");
                }
                catch (Exception ex)
                {
                    transaction.Rollback();
                    MessageBox.Show("Error updating account settings: " + ex.Message);
                }
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            // Clear reason textbox
            newUsernameTxt.Text = "";
            newPasswordTxt.Text = "";
            newConfirmPasswordTxt.Text = "";

            MessageBox.Show("Form cleared.");
        }
    }
}
