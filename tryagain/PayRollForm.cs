using System;
using System.Collections.Generic;
using System.ComponentModel;
using Microsoft.Data.SqlClient;
using System.Configuration;
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
        private DataTable payrollTable;
        private DateTimePicker dtpPeriod, dtpFrom, dtpTo;
        private ComboBox cmbStatus;
        private TextBox txtSearch;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
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
            btnProcess.Click += BtnProcess_Click;

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

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("select * from vw_payrollreport", conn);
                payrollTable = new DataTable();
                da.Fill(payrollTable);
                dgvPayroll.DataSource = payrollTable;
            }

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

        private void BtnProcess_Click(object sender, EventArgs e)
        {
            using (PayrollEntryForm form = new PayrollEntryForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    ShowPayroll(); // Optional: refresh your grid or data after processing
                }
            }
        }

        private void BtnFilter_Click(object sender, EventArgs e)
        {
            if (payrollTable == null) return;

            string filter = "1=1";

            // Date range filter
            DateTime from = dtpFrom.Value.Date;
            DateTime to = dtpTo.Value.Date;
            filter += $" AND [Date] >= #{from:yyyy-MM-dd}# AND [Date] <= #{to:yyyy-MM-dd}#";

            // Status filter
            string status = cmbStatus.SelectedItem.ToString();
            if (status != "All")
            {
                filter += $" AND [Status] = '{status}'";
            }

            // Employee search (case-insensitive)
            string search = txtSearch.Text.Trim();
            if (!string.IsNullOrEmpty(search))
            {
                filter += $" AND Convert([EmployeeName], 'System.String') LIKE '%{search}%'";
            }

            payrollTable.DefaultView.RowFilter = filter;
        }

    }
}
