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
    public partial class Employee_Profile : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        private int _empId;
        public Employee_Profile( int empId)
        {
            InitializeComponent();
            _empId = empId;
            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            LoadEmployeeProfile();
        }
    
        private void LoadEmployeeProfile()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                SELECT 
                    e.employeeid, e.firstname, e.lastname, e.department, e.position, e.hire_date,
                    d.email, d.date_of_birth, d.address,
                    c.contact_name, c.relationship, c.phone_number
                FROM Employees e
                LEFT JOIN EmployeeDetails d ON e.employeeid = d.employeeid
                LEFT JOIN EmergencyContact c ON e.employeeid = c.employeeid
                WHERE e.employeeid = @EmpId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpId", _empId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Employee core
                                empidTxt.Text = reader["employeeid"].ToString();
                                fullnameTxt.Text = $"{reader["firstname"]} {reader["lastname"]}";
                                departmentTxt.Text = reader["department"].ToString();
                                positionTxt.Text = reader["position"].ToString();
                                hiredateTxt.Text = Convert.ToDateTime(reader["hire_date"]).ToShortDateString();

                                // EmployeeDetails
                                emailaddTxt.Text = reader["email"].ToString();
                                dobTxt.Text = reader["date_of_birth"] == DBNull.Value ? "" : Convert.ToDateTime(reader["date_of_birth"]).ToShortDateString();
                                addressTxt.Text = reader["address"].ToString();

                                // EmergencyContact (just first one here)
                                emerconNameTxt.Text = reader["contact_name"].ToString();
                                emerconRelationshipTxt.Text = reader["relationship"].ToString();
                                emerconPhoneTxt.Text = reader["phone_number"].ToString();
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
                MessageBox.Show($"Error loading employee profile: {ex.Message}");
            }
        }

    }
}
