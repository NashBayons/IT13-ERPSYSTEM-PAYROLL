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
        public Employee_Profile(int empId)
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
                            e.employeeid, e.firstname, e.lastname, e.hire_date,
                            d.name AS DepartmentName,
                            p.name AS PositionName,
                            ed.email, ed.date_of_birth, ed.address,
                            ec.contact_name, ec.relationship, ec.phone_number
                        FROM Employees e
                        LEFT JOIN Department d ON e.departmentid = d.dept_id
                        LEFT JOIN Position p ON e.positionid = p.position_id
                        LEFT JOIN EmployeeDetails ed ON e.employeeid = ed.employeeid
                        LEFT JOIN EmergencyContact ec ON e.employeeid = ec.employeeid
                        WHERE e.employeeid = @EmpId";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@EmpId", _empId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Basic Info
                                empidTxt.Text = reader["employeeid"].ToString();
                                fullnameTxt.Text = $"{reader["firstname"]} {reader["lastname"]}";
                                departmentTxt.Text = reader["DepartmentName"]?.ToString() ?? "N/A";
                                positionTxt.Text = reader["PositionName"]?.ToString() ?? "N/A";
                                hiredateTxt.Text = reader["hire_date"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["hire_date"]).ToShortDateString()
                                    : "N/A";

                                // Details
                                emailaddTxt.Text = reader["email"]?.ToString() ?? "";
                                dobTxt.Text = reader["date_of_birth"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["date_of_birth"]).ToShortDateString()
                                    : "";
                                addressTxt.Text = reader["address"]?.ToString() ?? "";

                                // Emergency Contact
                                emerconNameTxt.Text = reader["contact_name"]?.ToString() ?? "";
                                emerconRelationshipTxt.Text = reader["relationship"]?.ToString() ?? "";
                                emerconPhoneTxt.Text = reader["phone_number"]?.ToString() ?? "";
                            }
                            else
                            {
                                MessageBox.Show("Employee not found.", "Not Found", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading employee profile: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void Employee_Profile_Load(object sender, EventArgs e)
        {

        }
    }
}
