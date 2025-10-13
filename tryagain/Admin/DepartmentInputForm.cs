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

namespace tryagain.Admin
{
    public partial class DepartmentInputForm : Form
    {
        private string _mode = "";
        private DataRow _departmentDataRow;
        private DataRow _positionDataRow;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public DepartmentInputForm(string mode, DataRow dataRow = null)
        {
            _mode = mode;
            InitializeComponent();
            if (_mode == "Department")
                _departmentDataRow = dataRow;
            else if (_mode == "Position")
                _positionDataRow = dataRow;

            LoadUI();
        }

        private void LoadUI()
        {
            try
            {
                switch (_mode)
                {
                    case "Department":
                        InputLabel.Text = "Department Input Form";
                        PositionCmb.Visible = false;
                        if (_departmentDataRow != null)
                        {
                            inputTxt.Text = _departmentDataRow["name"].ToString();
                        }
                        break;
                    case "Position":
                        InputLabel.Text = "Position Input Form";
                        PositionCmb.Visible = true;
                        LoadDepartmentsToComboBox();

                        if (_positionDataRow != null)
                        {
                            inputTxt.Text = _positionDataRow["name"].ToString();
                            int deptId = Convert.ToInt32(_positionDataRow["dept_id"]);
                            PositionCmb.SelectedValue = deptId;
                        }
                        break;
                    default:
                        throw new ArgumentException($"Invalid mode: {_mode}");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading UI: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(inputTxt.Text))
            {
                MessageBox.Show("Input field cannot be empty.", "Validation Error");
                return;
            }
            string inputValue = inputTxt.Text.Trim();
            string deptvalue = PositionCmb.Text.Trim();

            try
            {
                switch (_mode)
                {
                    case "Department":
                        if (string.IsNullOrWhiteSpace(inputValue))
                        {
                            MessageBox.Show("Please enter a department name.", "Validation Error");
                            return;
                        }
                        if (_departmentDataRow != null)
                        {
                            // If editing an existing department
                            string updateQuery = "UPDATE Department SET name = @name, status = @status WHERE dept_id = @dept_id";
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", inputValue);
                                cmd.Parameters.AddWithValue("@status", 1);  // Assuming active status
                                cmd.Parameters.AddWithValue("@dept_id", _departmentDataRow["dept_id"]);

                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Department updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No changes were made. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            // Insert new department if in "Create" mode
                            string insertQuery = "INSERT INTO Department (name, status) VALUES (@name, @status)";
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", inputValue);
                                cmd.Parameters.AddWithValue("@status", 1);  // default active status

                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();
                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Department saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("No rows inserted. Please try again.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        break;
                    case "Position":
                        if (PositionCmb.SelectedValue == null)
                        {
                            MessageBox.Show("Please select a department.", "Validation Error");
                            return;
                        }

                        int deptId = Convert.ToInt32(PositionCmb.SelectedValue);
                        if (_positionDataRow != null)
                        {
                            // UPDATE existing position
                            string updateQuery = "UPDATE Position SET name = @name, dept_id = @dept_id, status = @status WHERE position_id = @position_id";
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand(updateQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@name", inputValue);
                                cmd.Parameters.AddWithValue("@dept_id", deptId);
                                cmd.Parameters.AddWithValue("@status", 1);
                                cmd.Parameters.AddWithValue("@position_id", _positionDataRow["position_id"]);

                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Position updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                                else
                                {
                                    MessageBox.Show("Update failed. No rows affected.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                                }
                            }
                        }
                        else
                        {
                            // INSERT new position
                            string insertQuery = "INSERT INTO Position (dept_id, name, status) VALUES (@dept_id, @name, @status)";
                            using (SqlConnection conn = new SqlConnection(connectionString))
                            using (SqlCommand cmd = new SqlCommand(insertQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@dept_id", deptId);
                                cmd.Parameters.AddWithValue("@name", inputValue);
                                cmd.Parameters.AddWithValue("@status", 1);

                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Position saved successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    this.DialogResult = DialogResult.OK;
                                    this.Close();
                                }
                            }
                        }
                        break;
                    default:
                        MessageBox.Show("Invalid form mode.", "Error");
                        return;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"An error occurred while saving: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void LoadDepartmentsToComboBox()
        {
            try
            {
                string query = "SELECT dept_id, name FROM Department WHERE status = 1";

                using (SqlConnection conn = new SqlConnection(connectionString))
                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    conn.Open();
                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        DataTable dt = new DataTable();
                        dt.Load(reader);

                        PositionCmb.DataSource = dt;
                        PositionCmb.DisplayMember = "name"; // what the user sees
                        PositionCmb.ValueMember = "dept_id"; // actual value (foreign key)
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

}
