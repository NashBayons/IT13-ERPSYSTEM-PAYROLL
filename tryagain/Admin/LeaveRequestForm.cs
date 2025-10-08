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
    public partial class LeaveRequestForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _userId;
        public LeaveRequestForm(int userId)
        {
            _userId = userId;
            InitializeComponent();
            LoadPendingRequest();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            cmbLeaveType.Items.Clear();
            cmbLeaveType.Items.Add("All");
            cmbLeaveType.Items.Add("Sick");
            cmbLeaveType.Items.Add("Vacation");
            cmbLeaveType.Items.Add("Unpaid");
            cmbLeaveType.Items.Add("Emergency");
            cmbLeaveType.SelectedIndex = 0;

            dtpFrom.Value = DateTime.Now.AddMonths(-1); // default: last month
            dtpTo.Value = DateTime.Now;
        }

        private void LoadPendingRequest()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                string query = @"SELECT lr.leave_id, 
                                e.FirstName + ' ' + e.LastName AS EmployeeName,
                                lr.leave_type, 
                                lr.start_date, 
                                lr.end_date, 
                                lr.status,
                                lr.remarks
                         FROM Leave_Record lr
                         INNER JOIN Employees e ON lr.employee_id = e.EmployeeID
                         WHERE lr.status = 'Pending'";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLeaveRequests.DataSource = dt;
            }
        }

        private void loadreqBtn_Click(object sender, EventArgs e)
        {
            LoadPendingRequest();
        }

        private void approveBtn_Click(object sender, EventArgs e)
        {
            // ... (Existing code for selecting and getting leaveId)
            if (dgvLeaveRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a leave request to approve.");
                return;
            }

            object raw = dgvLeaveRequests.SelectedRows[0].Cells["leave_id"]?.Value
                         ?? dgvLeaveRequests.SelectedRows[0].Cells[0].Value;

            if (!int.TryParse(raw?.ToString(), out int leaveId))
            {
                MessageBox.Show("Could not determine the selected leave request ID.");
                return;
            }

            if (MessageBox.Show("Approve this leave request?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Question) != DialogResult.Yes)
                return;

            // Variables to hold leave details
            int employeeId = 0;
            DateTime startDate = DateTime.MinValue;
            DateTime endDate = DateTime.MinValue;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    // Start a transaction
                    SqlTransaction transaction = conn.BeginTransaction();

                    try
                    {
                        // 1. SELECT: Get Leave Details (Employee ID and Dates)
                        string selectQuery = @"
                    SELECT employee_id, start_date, end_date
                    FROM leave_record
                    WHERE leave_id = @leaveId AND status = 'Pending';";

                        using (SqlCommand selectCmd = new SqlCommand(selectQuery, conn, transaction))
                        {
                            selectCmd.Parameters.AddWithValue("@leaveId", leaveId);

                            using (SqlDataReader reader = selectCmd.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    employeeId = Convert.ToInt32(reader["employee_id"]);
                                    startDate = Convert.ToDateTime(reader["start_date"]);
                                    endDate = Convert.ToDateTime(reader["end_date"]);
                                }
                                else
                                {
                                    // Close the reader before rolling back or committing
                                    reader.Close();
                                    MessageBox.Show("No pending leave request found (it may have been processed already).");
                                    transaction.Rollback(); // Rollback is technically not needed here but good practice
                                    return;
                                }
                            }
                        }

                        // 2. UPDATE: Approve the Leave Request
                        string updateQuery = @"
                    UPDATE leave_record
                    SET status = @status,
                        approved_by = @userId,
                        remarks = @remarks
                    WHERE leave_id = @leaveId;";
                        // We rely on the SELECT check above for 'Pending' status

                        using (SqlCommand updateCmd = new SqlCommand(updateQuery, conn, transaction))
                        {
                            updateCmd.Parameters.AddWithValue("@status", "Approved");
                            updateCmd.Parameters.AddWithValue("@userId", _userId);
                            updateCmd.Parameters.AddWithValue("@remarks", DBNull.Value);
                            updateCmd.Parameters.AddWithValue("@leaveId", leaveId);

                            int rowsUpdated = updateCmd.ExecuteNonQuery();

                            if (rowsUpdated > 0)
                            {
                                // 3. INSERT: Add Records to Attendance Table
                                string insertQuery = @"
                                    INSERT INTO Attendance (employeeid, date, status)
                                    VALUES (@employeeId, @date, @status);";

                                using (SqlCommand insertCmd = new SqlCommand(insertQuery, conn, transaction))
                                {
                                    insertCmd.Parameters.Add("@employeeId", System.Data.SqlDbType.Int).Value = employeeId;
                                    insertCmd.Parameters.Add("@status", System.Data.SqlDbType.VarChar).Value = "Leave";

                                    // Iterate from start_date to end_date (inclusive)
                                    for (DateTime date = startDate.Date; date <= endDate.Date; date = date.AddDays(1))
                                    {
                                        // IMPORTANT: Exclude weekend days if necessary for your logic
                                        // if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday) 
                                        // {
                                        insertCmd.Parameters.Add("@date", System.Data.SqlDbType.Date).Value = date;
                                        insertCmd.ExecuteNonQuery();
                                        insertCmd.Parameters.RemoveAt("@date"); // Remove for the next loop iteration
                                                                                // }
                                    }
                                }

                                // All steps successful, COMMIT the transaction
                                transaction.Commit();
                                LoadPendingRequest();
                                MessageBox.Show("Leave request approved and attendance recorded.");
                            }
                            else
                            {
                                // Should not happen if SELECT was successful, but just in case
                                transaction.Rollback();
                                MessageBox.Show("No pending leave request found (it may have been processed already).");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        // Rollback if any part of the transaction failed
                        transaction.Rollback();
                        throw new Exception("Transaction failed. Details: " + ex.Message);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error approving leave request: " + ex.Message);
            }
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a leave request to reject.");
                return;
            }

            object raw = dgvLeaveRequests.SelectedRows[0].Cells["leave_id"]?.Value
                         ?? dgvLeaveRequests.SelectedRows[0].Cells[0].Value;

            if (!int.TryParse(raw?.ToString(), out int leaveId))
            {
                MessageBox.Show("Could not determine the selected leave request ID.");
                return;
            }

            if (MessageBox.Show("Reject this leave request?", "Confirm", MessageBoxButtons.YesNo, MessageBoxIcon.Warning) != DialogResult.Yes)
                return;

            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                UPDATE leave_record
                SET status = @status,
                    approved_by = @userId,
                    remarks = @remarks
                WHERE leave_id = @leaveId
                  AND status = 'Pending';
            ";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@status", "Rejected"); // or "Denied" if you prefer
                        cmd.Parameters.AddWithValue("@userId", _userId);
                        // you can prompt the admin for a rejection reason and put it here
                        cmd.Parameters.AddWithValue("@remarks", DBNull.Value);
                        cmd.Parameters.AddWithValue("@leaveId", leaveId);

                        int rows = cmd.ExecuteNonQuery();
                        if (rows > 0)
                        {
                            LoadPendingRequest();
                            MessageBox.Show("Leave request rejected.");
                        }
                        else
                        {
                            MessageBox.Show("No pending leave request found (it may have been processed already).");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error rejecting leave request: " + ex.Message);
            }
        }

        private void LoadFilter()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Base query
                string query = @"SELECT lr.leave_id, 
                                e.FirstName + ' ' + e.LastName AS EmployeeName,
                                lr.leave_type, 
                                lr.start_date, 
                                lr.end_date, 
                                lr.status,
                                lr.remarks
                         FROM Leave_Record lr
                         INNER JOIN Employees e ON lr.employee_id = e.EmployeeID
                         WHERE 1=1";

                // Build filter conditions dynamically
                if (!string.IsNullOrWhiteSpace(txtEmployeeName.Text))
                {
                    query += " AND (e.FirstName + ' ' + e.LastName LIKE @empName)";
                }

                if (cmbLeaveType.SelectedIndex > 0) // skip if "All"
                {
                    query += " AND lr.leave_type = @leaveType";
                }

                query += " AND lr.start_date >= @fromDate AND lr.end_date <= @toDate";

                SqlCommand cmd = new SqlCommand(query, conn);

                // Add parameters only if used
                if (!string.IsNullOrWhiteSpace(txtEmployeeName.Text))
                    cmd.Parameters.AddWithValue("@empName", "%" + txtEmployeeName.Text + "%");

                if (cmbLeaveType.SelectedIndex > 0)
                    cmd.Parameters.AddWithValue("@leaveType", cmbLeaveType.SelectedItem.ToString());

                cmd.Parameters.AddWithValue("@fromDate", dtpFrom.Value.Date);
                cmd.Parameters.AddWithValue("@toDate", dtpTo.Value.Date);

                SqlDataAdapter da = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvLeaveRequests.DataSource = dt;
            }
        }
        private void filterBtn_Click(object sender, EventArgs e)
        {
            LoadFilter();
        }


    }
}
