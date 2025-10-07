using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class ReportsForm : Form
    {
        private DataGridView dgvReports;
        private DateTimePicker dtpFrom, dtpTo;
        private ComboBox cmbReportType;
        private TextBox txtSearch;
        public ReportsForm()
        {
            InitializeComponent();
            ShowReports();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
     
        private void ShowReports()
        {
            this.Controls.Clear();

            // Title
            Label titleLabel = new Label
            {
                Text = "Reports",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 10),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(titleLabel);

            // Report Type Selector
            Label lblReportType = new Label
            {
                Text = "Report Type:",
                Location = new Point(20, 70),
                AutoSize = true
            };
            this.Controls.Add(lblReportType);

            cmbReportType = new ComboBox
            {
                Location = new Point(110, 65),
                Width = 200,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbReportType.Items.AddRange(new[] { "Attendance Report", "Payroll Report", "Employee Report" });
            cmbReportType.SelectedIndex = 0;
            this.Controls.Add(cmbReportType);

            // Generate Report Button
            Button btnGenerate = new Button
            {
                Text = "Generate Report",
                Location = new Point(330, 63),
                Size = new Size(140, 30),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(btnGenerate);

            // Export Report Button
            Button btnExport = new Button
            {
                Text = "Export",
                Location = new Point(480, 63),
                Size = new Size(100, 30),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(btnExport);

            // DataGridView for reports
            dgvReports = new DataGridView
            {
                Location = new Point(20, 120),
                Size = new Size(950, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Mock columns
            dgvReports.Columns.Add("Column1", "Column 1");
            dgvReports.Columns.Add("Column2", "Column 2");
            dgvReports.Columns.Add("Column3", "Column 3");

            // Mock data
            dgvReports.Rows.Add("Sample A", "Data 1", "More Info");
            dgvReports.Rows.Add("Sample B", "Data 2", "More Info");

            this.Controls.Add(dgvReports);

            // Filter Panel (below table)
            Panel filterPanel = new Panel
            {
                Location = new Point(20, 490),
                Size = new Size(950, 60),
                BackColor = Color.WhiteSmoke
            };

            Label lblFrom = new Label { Text = "From:", Location = new Point(10, 20), AutoSize = true };
            dtpFrom = new DateTimePicker { Location = new Point(60, 15), Width = 120 };

            Label lblTo = new Label { Text = "To:", Location = new Point(200, 20), AutoSize = true };
            dtpTo = new DateTimePicker { Location = new Point(230, 15), Width = 120 };

            Label lblSearch = new Label { Text = "Employee:", Location = new Point(380, 20), AutoSize = true };
            txtSearch = new TextBox { Location = new Point(460, 15), Width = 150 };

            Button btnFilter = new Button
            {
                Text = "Filter",
                Location = new Point(630, 12),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };

            filterPanel.Controls.AddRange(new Control[] { lblFrom, dtpFrom, lblTo, dtpTo, lblSearch, txtSearch, btnFilter });
            this.Controls.Add(filterPanel);
        }
    }
    public class ReportItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

