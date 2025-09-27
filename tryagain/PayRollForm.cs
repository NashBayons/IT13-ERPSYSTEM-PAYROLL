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
    public partial class PayRollForm : Form
    {
        private DataGridView dgvPayroll;
        private DateTimePicker dtpPeriod, dtpFrom, dtpTo;
        private ComboBox cmbStatus;
        private TextBox txtSearch;
        public PayRollForm()
        {
            InitializeComponent();
            ShowPayroll();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        private void ShowPayroll()
        {
            this.Controls.Clear();

            // Title
            Label titleLabel = new Label
            {
                Text = "Payroll Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 15),
                AutoSize = true,
                BackColor = Color.Transparent
            };
            this.Controls.Add(titleLabel);

            // Payroll Period Selector
            Label lblPeriod = new Label
            {
                Text = "Payroll Period:",
                Location = new Point(20, 70),
                AutoSize = true
            };
            this.Controls.Add(lblPeriod);

            dtpPeriod = new DateTimePicker
            {
                Location = new Point(130, 65),
                Width = 180,  // wider to fit long month names
                Format = DateTimePickerFormat.Custom,
                CustomFormat = "MMMM yyyy", // "September 2025"
                ShowUpDown = true, // spin control instead of full calendar
                Font = new Font("Segoe UI", 10F, FontStyle.Bold)
            };
            this.Controls.Add(dtpPeriod);

            // Process Payroll Button
            Button btnProcess = new Button
            {
                Text = "Process Payroll",
                Location = new Point(320, 63),
                Size = new Size(130, 30),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(btnProcess);

            // Generate Payslip Button
            Button btnPayslip = new Button
            {
                Text = "Generate Payslip",
                Location = new Point(460, 63),
                Size = new Size(140, 30),
                BackColor = Color.FromArgb(0, 150, 136),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            this.Controls.Add(btnPayslip);

            // Payroll DataGridView
            dgvPayroll = new DataGridView
            {
                Location = new Point(20, 110),
                Size = new Size(950, 350),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };

            // Define columns
            dgvPayroll.Columns.Add("PayrollID", "Payroll ID");
            dgvPayroll.Columns.Add("EmployeeName", "Employee");
            dgvPayroll.Columns.Add("Date", "Date");
            dgvPayroll.Columns.Add("GrossSalary", "Gross Salary");
            dgvPayroll.Columns.Add("Deductions", "Deductions");
            dgvPayroll.Columns.Add("Bonus", "Bonus");
            dgvPayroll.Columns.Add("Status", "Status");

            // Mock rows
            dgvPayroll.Rows.Add("1", "Juan Dela Cruz", "2025-09-23", "30,000", "1,000", "2,000", "Paid");
            dgvPayroll.Rows.Add("2", "Maria Santos", "2025-09-23", "45,000", "500", "1,500", "Pending");

            this.Controls.Add(dgvPayroll);

            // Filter Panel (moved below table)
            Panel filterPanel = new Panel
            {
                Location = new Point(20, 480),
                Size = new Size(950, 60),
                BackColor = Color.WhiteSmoke
            };

            Label lblFrom = new Label { Text = "From:", Location = new Point(10, 20), AutoSize = true };
            dtpFrom = new DateTimePicker { Location = new Point(60, 15), Width = 120 };

            Label lblTo = new Label { Text = "To:", Location = new Point(200, 20), AutoSize = true };
            dtpTo = new DateTimePicker { Location = new Point(230, 15), Width = 120 };

            Label lblStatus = new Label { Text = "Status:", Location = new Point(380, 20), AutoSize = true };
            cmbStatus = new ComboBox { Location = new Point(440, 15), Width = 100, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus.Items.AddRange(new[] { "All", "Paid", "Unpaid", "Pending" });
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
        }



        private void BtnFilter_Click(object sender, EventArgs e)
        {
            string status = cmbStatus.SelectedItem.ToString();
            string search = txtSearch.Text.Trim().ToLower();
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;

            foreach (DataGridViewRow row in dgvPayroll.Rows)
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
    public class PayrollRecord
    {
        public string EmployeeID { get; set; }
        public string PayPeriod { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OvertimePay { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
        public string Status { get; set; }
    }
}
