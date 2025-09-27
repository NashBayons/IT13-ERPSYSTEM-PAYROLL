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
        private DataGridView dgvAttendance;
        private DateTimePicker dtpFrom, dtpTo;
        private ComboBox cmbStatus;
        private TextBox txtSearch;

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        
        private Color primaryColor = Color.FromArgb(63, 81, 181);  // Deep Indigo
        private Color secondaryColor = Color.FromArgb(245, 246, 250);  // Light Slate
        private Color accentColor = Color.FromArgb(239, 83, 80);  // Coral Red
        private Color textColor = Color.FromArgb(33, 33, 33);  // Dark Gray for text
        public AttendanceForm()
        {
            InitializeComponent();
            LoadAttendance();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            LoadAttendance();
        }
     

        private void LoadAttendance()
        {
            this.Controls.Clear();

            // Title
            Label titleLabel = new Label
            {
                Text = "Attendance Records",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            // Filter Panel
            Panel filterPanel = new Panel
            {
                Location = new Point(20, 70),
                Size = new Size(950, 60),
                BackColor = Color.WhiteSmoke
            };

            Label lblFrom = new Label { Text = "From:", Location = new Point(10, 20), AutoSize = true };
            dtpFrom = new DateTimePicker { Location = new Point(60, 15), Width = 120 };

            Label lblTo = new Label { Text = "To:", Location = new Point(200, 20), AutoSize = true };
            dtpTo = new DateTimePicker { Location = new Point(230, 15), Width = 120 };

            Label lblStatus = new Label { Text = "Status:", Location = new Point(380, 20), AutoSize = true };
            cmbStatus = new ComboBox { Location = new Point(440, 15), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new[] { "All", "Present", "Late", "Absent" });
            cmbStatus.SelectedIndex = 0;

            Label lblSearch = new Label { Text = "Employee:", Location = new Point(570, 20), AutoSize = true };
            txtSearch = new TextBox { Location = new Point(650, 15), Width = 150 };

            Button btnFilter = new Button
            {
                Text = "Filter",
                Location = new Point(820, 12),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnFilter.Click += BtnFilter_Click;

            filterPanel.Controls.AddRange(new Control[] { lblFrom, dtpFrom, lblTo, dtpTo, lblStatus, cmbStatus, lblSearch, txtSearch, btnFilter });
            this.Controls.Add(filterPanel);

            // Attendance DataGridView
            dgvAttendance = new DataGridView
            {
                Location = new Point(20, 150),
                Size = new Size(950, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            dgvAttendance.Columns.Add("EmployeeName", "Employee");
            dgvAttendance.Columns.Add("Date", "Date");
            dgvAttendance.Columns.Add("TimeIn", "Time In");
            dgvAttendance.Columns.Add("TimeOut", "Time Out");
            dgvAttendance.Columns.Add("WorkHours", "Work Hours");
            dgvAttendance.Columns.Add("Status", "Status");

            // Add mock data
            dgvAttendance.Rows.Add("Juan Dela Cruz", "2025-09-23", "09:00 AM", "05:00 PM", "8", "Present");
            dgvAttendance.Rows.Add("Maria Santos", "2025-09-23", "09:30 AM", "05:00 PM", "7.5", "Late");
            dgvAttendance.Rows.Add("Pedro Reyes", "2025-09-23", "—", "—", "0", "Absent");

            this.Controls.Add(dgvAttendance);
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.SelectedItem.ToString();
            string search = txtSearch.Text.Trim().ToLower();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            foreach (DataGridViewRow row in dgvAttendance.Rows)
            {
                bool visible = true;

                DateTime rowDate = DateTime.Parse(row.Cells["Date"].Value.ToString());

                if (rowDate < from || rowDate > to) visible = false;
                if (status != "All" && row.Cells["Status"].Value.ToString() != status) visible = false;
                if (!string.IsNullOrEmpty(search) && !row.Cells["EmployeeName"].Value.ToString().ToLower().Contains(search))
                    visible = false;

                row.Visible = visible;
            }
        }
    }




    public class AttendanceRecord
    {
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public double WorkHours { get; set; }
        public string Status { get; set; }
    }
}
