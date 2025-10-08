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
    public partial class LeaveForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _empId;
        public LeaveForm(int empId)
        {
            _empId = empId;
            InitializeComponent();
            LoadLeaveHistory();
        }

        private void submitBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    INSERT INTO leave_record (employee_id, leave_type, start_date, end_date, status, created_at)
                    VALUES (@EmpId, @LeaveType, @StartDate, @EndDate, 'Pending', GETDATE());", conn);

                cmd.Parameters.AddWithValue("@EmpId", _empId);
                cmd.Parameters.AddWithValue("@LeaveType", leavetypeCmb.Text);
                cmd.Parameters.AddWithValue("@StartDate", dateFrom.Value.Date);
                cmd.Parameters.AddWithValue("@EndDate", dateTo.Value.Date);

                cmd.ExecuteNonQuery();

                MessageBox.Show("Leave request submitted successfully!");
                LoadLeaveHistory();
            }
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            leavetypeCmb.SelectedIndex = -1;  // no selection

            // Reset date pickers to today
            dateFrom.Value = DateTime.Today;
            dateTo.Value = DateTime.Today;

            // Clear reason textbox
            reasonTxt.Text = "";

            MessageBox.Show("Form cleared.");
        }

        private void LoadLeaveHistory()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                SqlCommand cmd = new SqlCommand(@"
                    SELECT leave_id, leave_type, start_date, end_date, status
                    FROM leave_record
                    WHERE employee_id = @EmpId
                    ORDER BY created_at DESC", conn);

                cmd.Parameters.AddWithValue("@EmpId", _empId);

                SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                DataTable dt = new DataTable();
                adapter.Fill(dt);

                leaveDgv.DataSource = dt; // bind to DataGridView
            }
        }
    }
}
