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
        public LeaveRequestForm()
        {
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
            if (dgvLeaveRequests.SelectedRows.Count > 0)
            {
                int leaveId = Convert.ToInt32(dgvLeaveRequests.SelectedRows[0].Cells["leave_id"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Leave_Record 
                             SET status = 'Approved', 
                                 approved_by = @userId
                             WHERE leave_id = @leaveId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@userId", loggedInUserId);
                    cmd.Parameters.AddWithValue("@leaveId", leaveId);
                    cmd.ExecuteNonQuery();
                }

                LoadPendingRequest();
                MessageBox.Show("Leave request approved.");
            }
        }

        private void rejectBtn_Click(object sender, EventArgs e)
        {
            if (dgvLeaveRequests.SelectedRows.Count > 0)
            {
                int leaveId = Convert.ToInt32(dgvLeaveRequests.SelectedRows[0].Cells["leave_id"].Value);

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string query = @"UPDATE Leave_Record 
                             SET status = 'Rejected', 
                                 approved_by = @userId
                             WHERE leave_id = @leaveId";

                    SqlCommand cmd = new SqlCommand(query, conn);
                    //cmd.Parameters.AddWithValue("@userId", loggedInUserId);
                    cmd.Parameters.AddWithValue("@leaveId", leaveId);
                    cmd.ExecuteNonQuery();
                }

                LoadPendingRequest();
                MessageBox.Show("Leave request rejected.");
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
