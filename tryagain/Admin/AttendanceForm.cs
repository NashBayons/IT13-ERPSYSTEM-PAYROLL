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
    public partial class AttendanceForm : Form
    {
        private DataGridView dgvAttendance1;
        private DateTimePicker dtpFrom, dtpTo1;
        private ComboBox cmbStatus1;
        private TextBox txtSearch1;

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public AttendanceForm()
        {
            InitializeComponent();

            DateTime today = DateTime.Today;
            dtpFrom.Value = new DateTime(today.Year, today.Month, 1);
            dtpTo1.Value = today;

            cmbStatus1.Items.AddRange(new[] { "All", "Present", "Late", "Absent", "Leave" });
            cmbStatus1.SelectedIndex = 0;

            LoadAttendanceData();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            LoadAttendanceData();
        }


        private void LoadAttendanceData()
        {

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from vw_attendancereport", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAttendance1.DataSource = dt;
            }

        }

        private void btnFilter11_Click(object sender, EventArgs e)
        {
            if (dgvAttendance1.DataSource is DataTable dt)
            {
                string filter = "1=1";


                DateTime from = dtpFrom.Value.Date;
                DateTime to = dtpTo1.Value.Date;
                filter += $" AND Date >= #{from:yyyy-MM-dd}# AND Date <= #{to:yyyy-MM-dd}#";


                string status = cmbStatus1.SelectedItem.ToString();
                if (status != "All")
                {
                    filter += $" AND Status = '{status}'";
                }


                string search = txtSearch.Text.Trim();
                if (!string.IsNullOrEmpty(search))
                {
                    filter += $" AND Convert(EmployeeName, 'System.String') LIKE '%{search}%'";
                }

                dt.DefaultView.RowFilter = filter;
            }
        }
    }
}
