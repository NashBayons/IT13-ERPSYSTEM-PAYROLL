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
    public partial class DepartmentForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public string _currentMode = "";
        public DepartmentForm()
        {
            InitializeComponent();
            this.Load += LoadDeptPositionData;
        }

        private void LoadDeptPositionData(object sender, EventArgs e)
        {
            LoadDepartment();
            LoadDepartmentsFilter();
            LoadPosition();
        }

        private void LoadDepartment()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"
                            SELECT 
                                dept_id, 
                                name,
                                CASE 
                                    WHEN status = 1 THEN 'Active'
                                    ELSE 'Inactive'
                                END AS Status
                            FROM Department
                            WHERE status = 1";
                    SqlDataAdapter da = new SqlDataAdapter(query, conn);
                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    DepartmentGrid.DataSource = dt;
                    DepartmentGrid.Columns["dept_id"].Visible = false;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading Department list: {ex.Message}");
            }

        }

        private void LoadPosition(int deptId = 0) // 0 means all
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    string query = @"
                            SELECT 
                                P.position_id, 
                                P.name, 
                                P.dept_id,
                                D.name AS Department,
                                CASE WHEN P.status = 1 THEN 'Active' ELSE 'Inactive' END AS Status
                            FROM Position P
                            INNER JOIN Department D ON P.dept_id = D.dept_id
                            WHERE P.status = 1";

                    if (deptId != 0)
                        query += " AND P.dept_id = @dept_id";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        if (deptId != 0)
                            cmd.Parameters.AddWithValue("@dept_id", deptId);

                        conn.Open();

                        SqlDataAdapter da = new SqlDataAdapter(cmd);
                        DataTable dt = new DataTable();
                        da.Fill(dt);

                        PositionGrid.DataSource = dt;
                        PositionGrid.Columns["dept_id"].Visible = false;
                        PositionGrid.Columns["position_id"].Visible = false;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading positions: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void DeptAddBtn_Click(object sender, EventArgs e)
        {
            _currentMode = "Department";
            using (DepartmentInputForm deptInput = new DepartmentInputForm(_currentMode))
            {
                DialogResult result = deptInput.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadDepartment();
                }
            }

        }

        private void DeptEditBtn_Click(object sender, EventArgs e)
        {
            if (DepartmentGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Get the selected department
            var selectedDept = DepartmentGrid.SelectedRows[0].DataBoundItem as DataRowView;
            if (selectedDept != null)
            {
                // Pass the department data (DataRow) to the input form for editing
                _currentMode = "Department";
                using (DepartmentInputForm deptInput = new DepartmentInputForm(_currentMode, selectedDept.Row))
                {
                    DialogResult result = deptInput.ShowDialog();

                    if (result == DialogResult.OK)
                    {
                        LoadDepartment();  // Refresh the department list after the edit
                    }
                }
            }
        }

        private void DeptDelBtn_Click(object sender, EventArgs e)
        {
            if (DepartmentGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a department to delete.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedDept = DepartmentGrid.SelectedRows[0].DataBoundItem as DataRowView;
            if (selectedDept != null)
            {
                var departmentId = selectedDept.Row["dept_id"];
                DialogResult result = MessageBox.Show("Are you sure you want to delete this department?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection conn = new SqlConnection(connectionString))
                        {
                            string softDeleteQuery = "UPDATE Department SET status = 0 WHERE dept_id = @dept_id";
                            using (SqlCommand cmd = new SqlCommand(softDeleteQuery, conn))
                            {
                                cmd.Parameters.AddWithValue("@dept_id", departmentId);
                                conn.Open();
                                int rowsAffected = cmd.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Department deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                    LoadDepartment();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to archive department.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error archiving department: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void PosAddBtn_Click(object sender, EventArgs e)
        {
            _currentMode = "Position";
            using (DepartmentInputForm deptInput = new DepartmentInputForm(_currentMode))
            {
                DialogResult result = deptInput.ShowDialog();

                if (result == DialogResult.OK)
                {
                    LoadPosition();
                }
            }
        }

        private void PosEditBtn_Click(object sender, EventArgs e)
        {
            if (PositionGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to edit.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var selectedPos = PositionGrid.SelectedRows[0].DataBoundItem as DataRowView;
            if (selectedPos != null)
            {
                _currentMode = "Position";
                using (DepartmentInputForm inputForm = new DepartmentInputForm(_currentMode, selectedPos.Row))
                {
                    DialogResult result = inputForm.ShowDialog();
                    if (result == DialogResult.OK)
                    {
                        LoadPosition(); // Refresh the grid after editing
                    }
                }
            }
        }

        private void PosDelBtn_Click(object sender, EventArgs e)
        {
            if (PositionGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a position to delete.", "Warning", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            DataGridViewRow selectedPos = PositionGrid.SelectedRows[0];
            int posId = Convert.ToInt32(selectedPos.Cells["position_id"].Value);

            var confirmResult = MessageBox.Show("Are you sure you want to delete this position?", "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question);

            if (confirmResult == DialogResult.Yes)
            {
                try
                {
                    using (SqlConnection conn = new SqlConnection(connectionString))
                    {
                        string query = "UPDATE Position SET status = 0 WHERE position_id = @position_id";
                        using (SqlCommand cmd = new SqlCommand(query, conn))
                        {
                            cmd.Parameters.AddWithValue("@position_id", posId);
                            conn.Open();
                            int rowsAffected = cmd.ExecuteNonQuery();

                            if (rowsAffected > 0)
                            {
                                MessageBox.Show("Position deleted (soft delete) successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadPosition();
                            }
                            else
                            {
                                MessageBox.Show("Failed to delete position.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error deleting position: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void LoadDepartmentsFilter()
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

                        // Add "All Departments" option
                        DataRow allRow = dt.NewRow();
                        allRow["dept_id"] = 0;
                        allRow["name"] = "All Departments";
                        dt.Rows.InsertAt(allRow, 0);

                        PositionFilterCmb.DataSource = dt;
                        PositionFilterCmb.DisplayMember = "name";
                        PositionFilterCmb.ValueMember = "dept_id";
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading departments for filter: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void PositionFilterCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (PositionFilterCmb.SelectedValue != null && int.TryParse(PositionFilterCmb.SelectedValue.ToString(), out int selectedDeptId))
            {
                LoadPosition(selectedDeptId);
            }
        }
    }
}
