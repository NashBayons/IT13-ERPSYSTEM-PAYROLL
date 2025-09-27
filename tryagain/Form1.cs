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
    public partial class Form1 : Form
    {
        private Panel sidebarPanel;
        private Panel contentPanel;
        private Button currentActiveButton;

        // Updated color scheme - Modern professional palette
        private Color primaryColor = Color.FromArgb(63, 81, 181);  // Deep Indigo
        private Color secondaryColor = Color.FromArgb(245, 246, 250);  // Light Slate
        private Color accentColor = Color.FromArgb(239, 83, 80);  // Coral Red
        private Color textColor = Color.FromArgb(33, 33, 33);  // Dark Gray for text

        // Static data
        private List<Employee> employees;
        private List<AttendanceRecord> attendanceRecords;
        private List<PayrollRecord> payrollRecords;

        public Form1()
        {
            InitializeComponent();
            InitializeStaticData();
            SetupForm();
            CreateSidebar();
            CreateContentPanel();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            contentPanel.Width = this.ClientSize.Width - 220;
            contentPanel.Height = this.ClientSize.Height;
            ShowDashboard();
        }

        private void SetupForm()
        {
            this.Text = "BPO Payroll Management System";
            this.WindowState = FormWindowState.Maximized;
            this.StartPosition = FormStartPosition.CenterScreen;
            this.MinimumSize = new Size(800, 600);
            this.BackColor = secondaryColor;
            this.Font = new Font("Segoe UI", 10F, FontStyle.Regular);

            this.Resize += (s, e) =>
            {
                if (contentPanel != null)
                {
                    contentPanel.Width = this.ClientSize.Width - 220;
                    contentPanel.Height = this.ClientSize.Height;
                    if (currentActiveButton != null)
                    {
                        SidebarButton_Click(currentActiveButton, EventArgs.Empty);
                    }
                }
            };
        }

        private void CreateSidebar()
        {
            sidebarPanel = new Panel
            {
                Dock = DockStyle.Left,
                Width = 220,
                BackColor = primaryColor,
                Padding = new Padding(10)
            };

            Panel logoPanel = new Panel
            {
                Height = 100,
                Dock = DockStyle.Top,
                BackColor = Color.FromArgb(55, 71, 161)
            };

            Label logoLabel = new Label
            {
                Text = "BPO PAYROLL",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14F, FontStyle.Bold),
                Dock = DockStyle.Fill,
                TextAlign = ContentAlignment.MiddleCenter
            };
            logoPanel.Controls.Add(logoLabel);
            sidebarPanel.Controls.Add(logoPanel);

            string[] menuItems = { "Dashboard", "Employees", "Attendance", "Payroll", "Reports" };
            string[] menuIcons = { "📊", "👥", "🕐", "💰", "📄" };

            for (int i = 0; i < menuItems.Length; i++)
            {
                Button btn = CreateSidebarButton(menuItems[i], menuIcons[i]);
                btn.Top = 110 + (i * 60);
                if (i == 0)
                {
                    SetActiveButton(btn);
                    currentActiveButton = btn;
                }
                sidebarPanel.Controls.Add(btn);
            }

            Button logoutBtn = new Button
            {
                Text = "🚪 Logout",
                Width = 200,
                Height = 50,
                Left = 10,
                BackColor = accentColor,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Bold),
                FlatStyle = FlatStyle.Flat,
                Cursor = Cursors.Hand,
                Anchor = AnchorStyles.Bottom | AnchorStyles.Left
            };
            logoutBtn.FlatAppearance.BorderSize = 0;
            logoutBtn.FlatAppearance.MouseOverBackColor = Color.FromArgb(229, 73, 70);
            logoutBtn.Click += (s, e) =>
            {
                if (MessageBox.Show("Are you sure you want to logout?", "Confirm Logout",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    Application.Exit();
                }
            };
            sidebarPanel.Controls.Add(logoutBtn);

            this.Controls.Add(sidebarPanel);
            sidebarPanel.BringToFront();
        }

        private Button CreateSidebarButton(string text, string icon)
        {
            Button btn = new Button
            {
                Text = $"{icon} {text}",
                Width = 200,
                Height = 50,
                Left = 10,
                BackColor = Color.Transparent,
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 11F, FontStyle.Regular),
                FlatStyle = FlatStyle.Flat,
                TextAlign = ContentAlignment.MiddleLeft,
                Padding = new Padding(20, 0, 0, 0),
                Cursor = Cursors.Hand,
                Tag = text
            };

            btn.FlatAppearance.BorderSize = 0;
            btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(80, 100, 190);
            btn.Click += SidebarButton_Click;

            return btn;
        }

        private void SidebarButton_Click(object sender, EventArgs e)
        {
            Button clickedButton = (Button)sender;
            SetActiveButton(clickedButton);

            string buttonText = clickedButton.Tag.ToString();

            switch (buttonText)
            {
                case "Dashboard":
                    ShowDashboard();
                    break;
                case "Employees":
                    ShowEmployees();
                    break;
                case "Attendance":
                    ShowAttendance();
                    break;
                case "Payroll":
                    ShowPayroll();
                    break;
                case "Reports":
                    ShowReports();
                    break;
            }
        }

        private void SetActiveButton(Button activeButton)
        {
            if (currentActiveButton != null)
            {
                currentActiveButton.BackColor = Color.Transparent;
                currentActiveButton.Font = new Font("Segoe UI", 11F, FontStyle.Regular);
            }

            activeButton.BackColor = Color.FromArgb(40, 255, 255, 255);
            activeButton.Font = new Font("Segoe UI", 11F, FontStyle.Bold);
            currentActiveButton = activeButton;
        }

        private void CreateContentPanel()
        {
            contentPanel = new Panel
            {
                Left = 220,
                Top = 0,
                Width = this.ClientSize.Width - 220,
                Height = this.ClientSize.Height,
                BackColor = secondaryColor,
                Padding = new Padding(20),
                Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom
            };

            this.Controls.Add(contentPanel);
        }

        private void ShowDashboard()
        {
            ClearContentPanel();

            Label titleLabel = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            contentPanel.Controls.Add(titleLabel);

            int cardY = 100;
            int cardWidth = Math.Max(200, (contentPanel.Width - 100) / 4);
            CreateDashboardCard("Total Employees", employees.Count.ToString(), "👥", new Point(20, cardY), cardWidth);
            CreateDashboardCard("Present Today", GetTodayPresentCount().ToString(), "✅", new Point(20 + cardWidth + 20, cardY), cardWidth);
            CreateDashboardCard("Late Today", GetTodayLateCount().ToString(), "⏰", new Point(20 + (cardWidth + 20) * 2, cardY), cardWidth);
            CreateDashboardCard("Absent Today", GetTodayAbsentCount().ToString(), "❌", new Point(20 + (cardWidth + 20) * 3, cardY), cardWidth);

            int panelY = cardY + 120;
            int panelWidth = Math.Max(300, (contentPanel.Width - 60) / 2);
            Panel activitiesPanel = new Panel
            {
                Location = new Point(20, panelY),
                Size = new Size(panelWidth, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            activitiesPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, activitiesPanel.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            Label activitiesTitle = new Label
            {
                Text = "Recent Activities",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(15, 15),
                AutoSize = true
            };
            activitiesPanel.Controls.Add(activitiesTitle);

            string[] activities = {
                "John Doe clocked in at 8:30 AM",
                "Jane Smith submitted timesheet",
                "Payroll processed for March 2024",
                "New employee Mike Johnson added",
                "Sarah Wilson clocked out at 5:00 PM"
            };

            for (int i = 0; i < activities.Length; i++)
            {
                Label activityLabel = new Label
                {
                    Text = $"• {activities[i]}",
                    Location = new Point(15, 50 + (i * 35)),
                    Size = new Size(panelWidth - 30, 30),
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = textColor
                };
                activitiesPanel.Controls.Add(activityLabel);
            }

            Panel quickActionsPanel = new Panel
            {
                Location = new Point(20 + panelWidth + 20, panelY),
                Size = new Size(panelWidth, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            quickActionsPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, quickActionsPanel.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            Label quickActionsTitle = new Label
            {
                Text = "Quick Actions",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(15, 15),
                AutoSize = true
            };
            quickActionsPanel.Controls.Add(quickActionsTitle);

            int buttonWidth = (panelWidth - 60) / 2;
            Button[] quickButtons = {
                new Button { Text = "Add Employee", Size = new Size(buttonWidth, 40), Location = new Point(20, 60) },
                new Button { Text = "Process Payroll", Size = new Size(buttonWidth, 40), Location = new Point(20 + buttonWidth + 20, 60) },
                new Button { Text = "Generate Report", Size = new Size(buttonWidth, 40), Location = new Point(20, 120) },
                new Button { Text = "View Attendance", Size = new Size(buttonWidth, 40), Location = new Point(20 + buttonWidth + 20, 120) }
            };

            foreach (Button btn in quickButtons)
            {
                btn.BackColor = primaryColor;
                btn.ForeColor = Color.White;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 0;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 71, 171);
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Cursor = Cursors.Hand;
                quickActionsPanel.Controls.Add(btn);
            }

            contentPanel.Controls.AddRange(new[] { activitiesPanel, quickActionsPanel });
        }

        private void CreateDashboardCard(string title, string value, string icon, Point location, int width)
        {
            Panel card = new Panel
            {
                Size = new Size(width, 100),
                Location = location,
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            card.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, card.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            Label iconLabel = new Label
            {
                Text = icon,
                Font = new Font("Segoe UI", 20F),
                Location = new Point(15, 15),
                AutoSize = true
            };

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 18F, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(50, 15),
                AutoSize = true
            };

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Regular),
                ForeColor = Color.FromArgb(100, 100, 100),
                Location = new Point(15, 60),
                Size = new Size(width - 30, 30),
                TextAlign = ContentAlignment.MiddleLeft
            };

            card.Controls.AddRange(new Control[] { iconLabel, valueLabel, titleLabel });
            contentPanel.Controls.Add(card);
        }

        private void ShowEmployees()
        {
            ClearContentPanel();

            Label titleLabel = new Label
            {
                Text = "Employee Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            contentPanel.Controls.Add(titleLabel);

            Button addButton = new Button
            {
                Text = "➕ Employee",
                Location = new Point(20, 120),
                Size = new Size(130, 40),
                BackColor = primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            addButton.FlatAppearance.BorderSize = 0;
            addButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 71, 171);
            contentPanel.Controls.Add(addButton);

            TextBox searchBox = new TextBox
            {
                Location = new Point(30, 70),
                Size = new Size(250, 70),
                Font = new Font("Segoe UI", 10F),
                Text = "Search employees...",
                ForeColor = Color.FromArgb(150, 150, 150)
            };
            searchBox.Enter += (s, e) =>
            {
                if (searchBox.Text == "Search employees...")
                {
                    searchBox.Text = "";
                    searchBox.ForeColor = textColor;
                }
            };
            searchBox.Leave += (s, e) =>
            {
                if (string.IsNullOrWhiteSpace(searchBox.Text))
                {
                    searchBox.Text = "Search employees...";
                    searchBox.ForeColor = Color.FromArgb(150, 150, 150);
                }
            };
            contentPanel.Controls.Add(searchBox);

            Button searchButton = new Button
            {
                Text = "🔍Search",
                Location = new Point(300, 70),
                Size = new Size(110, 30),
                BackColor = primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            searchButton.FlatAppearance.BorderSize = 0;
            searchButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 71, 171);
            searchButton.Click += (s, e) =>
            {
                MessageBox.Show("Searching for employees...", "Search", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            contentPanel.Controls.Add(searchButton);

            int gridWidth = Math.Max(500, contentPanel.Width - 360);
            DataGridView employeesGrid = new DataGridView
            {
                Location = new Point(20, 170),
                Size = new Size(gridWidth, contentPanel.Height - 140),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            employeesGrid.Columns.Add("ID", "Employee ID");
            employeesGrid.Columns.Add("Name", "Full Name");
            employeesGrid.Columns.Add("Department", "Department");
            employeesGrid.Columns.Add("Position", "Position");
            employeesGrid.Columns.Add("HireDate", "Hire Date");
            employeesGrid.Columns.Add("Salary", "Salary");
            employeesGrid.Columns.Add("Status", "Status");

            foreach (var emp in employees)
            {
                employeesGrid.Rows.Add(emp.ID, emp.FullName, emp.Department, emp.Position,
                    emp.HireDate.ToShortDateString(), emp.Salary.ToString("C"), emp.Status);
            }

            employeesGrid.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            employeesGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            employeesGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            employeesGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            employeesGrid.DefaultCellStyle.ForeColor = textColor;

            contentPanel.Controls.Add(employeesGrid);

            Panel statsPanel = new Panel
            {
                Location = new Point(gridWidth + 40, 120),
                Size = new Size(300, contentPanel.Height - 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            statsPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, statsPanel.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            Label statsTitle = new Label
            {
                Text = "Employee Statistics",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(15, 15),
                AutoSize = true
            };
            statsPanel.Controls.Add(statsTitle);

            var deptGroups = employees.GroupBy(e => e.Department);
            int y = 50;
            foreach (var group in deptGroups)
            {
                Label deptLabel = new Label
                {
                    Text = $"{group.Key}: {group.Count()} employees",
                    Location = new Point(15, y),
                    Size = new Size(270, 25),
                    Font = new Font("Segoe UI", 10F),
                    ForeColor = textColor
                };
                statsPanel.Controls.Add(deptLabel);
                y += 30;
            }

            contentPanel.Controls.Add(statsPanel);
        }

        private void ShowAttendance()
        {
            ClearContentPanel();

            Label titleLabel = new Label
            {
                Text = "Attendance Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            contentPanel.Controls.Add(titleLabel);

            Label dateLabel = new Label
            {
                Text = "Filter by Date:",
                Location = new Point(20, 75),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(dateLabel);

            DateTimePicker fromDate = new DateTimePicker
            {
                Location = new Point(150, 70),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };
            contentPanel.Controls.Add(fromDate);

            Label toLabel = new Label
            {
                Text = "to",
                Location = new Point(310, 75),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(toLabel);

            DateTimePicker toDate = new DateTimePicker
            {
                Location = new Point(340, 70),
                Size = new Size(150, 30),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };
            contentPanel.Controls.Add(toDate);

            RadioButton dailyView = new RadioButton
            {
                Text = "Daily",
                Location = new Point(520, 70),
                Size = new Size(100, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(dailyView);

            RadioButton weeklyView = new RadioButton
            {
                Text = "Weekly",
                Location = new Point(620, 70),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(weeklyView);

            RadioButton monthlyView = new RadioButton
            {
                Text = "Monthly",
                Location = new Point(720, 70),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(monthlyView);

            int cardWidth = Math.Max(200, (contentPanel.Width - 100) / 4);
            CreateDashboardCard("Present", GetTodayPresentCount().ToString(), "✅", new Point(20, 120), cardWidth);
            CreateDashboardCard("Late", GetTodayLateCount().ToString(), "⏰", new Point(20 + cardWidth + 20, 120), cardWidth);
            CreateDashboardCard("Absent", GetTodayAbsentCount().ToString(), "❌", new Point(20 + (cardWidth + 20) * 2, 120), cardWidth);
            CreateDashboardCard("On Leave", "2", "🏖️", new Point(20 + (cardWidth + 20) * 3, 120), cardWidth);

            DataGridView attendanceGrid = new DataGridView
            {
                Location = new Point(20, 240),
                Size = new Size(contentPanel.Width - 40, contentPanel.Height - 360),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            attendanceGrid.Columns.Add("EmployeeID", "Employee ID");
            attendanceGrid.Columns.Add("EmployeeName", "Employee Name");
            attendanceGrid.Columns.Add("Date", "Date");
            attendanceGrid.Columns.Add("TimeIn", "Time In");
            attendanceGrid.Columns.Add("TimeOut", "Time Out");
            attendanceGrid.Columns.Add("WorkHours", "Work Hours");
            attendanceGrid.Columns.Add("Status", "Status");

            foreach (var record in attendanceRecords.Take(20))
            {
                var employee = employees.FirstOrDefault(e => e.ID == record.EmployeeID);
                attendanceGrid.Rows.Add(
                    record.EmployeeID,
                    employee?.FullName ?? "Unknown",
                    record.Date.ToShortDateString(),
                    record.TimeIn?.ToString("HH:mm") ?? "-",
                    record.TimeOut?.ToString("HH:mm") ?? "-",
                    record.WorkHours.ToString("F2") + " hrs",
                    record.Status
                );
            }

            attendanceGrid.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            attendanceGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            attendanceGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            attendanceGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            attendanceGrid.DefaultCellStyle.ForeColor = textColor;

            foreach (DataGridViewRow row in attendanceGrid.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                switch (status)
                {
                    case "Present":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(200, 230, 201);
                        break;
                    case "Late":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(255, 224, 178);
                        break;
                    case "Absent":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(255, 205, 210);
                        break;
                }
            }

            contentPanel.Controls.Add(attendanceGrid);
        }

        private void ShowPayroll()
        {
            ClearContentPanel();

            Label titleLabel = new Label
            {
                Text = "Payroll Management",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            contentPanel.Controls.Add(titleLabel);

            Label periodLabel = new Label
            {
                Text = "Payroll Period:",
                Location = new Point(20, 80),
                AutoSize = true,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };
            contentPanel.Controls.Add(periodLabel);

            ComboBox periodCombo = new ComboBox
            {
                Location = new Point(150, 75),
                Size = new Size(150, 30),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 10F)
            };
            periodCombo.Items.AddRange(new string[] {
                "March 2024", "February 2024", "January 2024", "December 2023"
            });
            periodCombo.SelectedIndex = 0;
            contentPanel.Controls.Add(periodCombo);

            Button processButton = new Button
            {
                Text = "💰 Process Payroll",
                Location = new Point(320, 70),
                Size = new Size(170, 40),
                BackColor = primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            processButton.FlatAppearance.BorderSize = 0;
            processButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 71, 171);
            contentPanel.Controls.Add(processButton);

            Button payslipButton = new Button
            {
                Text = "📄 Generate Payslips",
                Location = new Point(505, 70),
                Size = new Size(190, 40),
                BackColor = Color.FromArgb(46, 125, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            payslipButton.FlatAppearance.BorderSize = 0;
            payslipButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(36, 115, 40);
            contentPanel.Controls.Add(payslipButton);

            int cardWidth = Math.Max(200, (contentPanel.Width - 100) / 4);
            decimal totalPayroll = payrollRecords.Sum(p => p.NetPay);
            CreateDashboardCard("Total Payroll", totalPayroll.ToString("C"), "💰", new Point(20, 130), cardWidth);
            CreateDashboardCard("Processed", payrollRecords.Count(p => p.Status == "Processed").ToString(), "✅", new Point(20 + cardWidth + 20, 130), cardWidth);
            CreateDashboardCard("Pending", payrollRecords.Count(p => p.Status == "Pending").ToString(), "⏳", new Point(20 + (cardWidth + 20) * 2, 130), cardWidth);
            CreateDashboardCard("Hold", payrollRecords.Count(p => p.Status == "Hold").ToString(), "⚠️", new Point(20 + (cardWidth + 20) * 3, 130), cardWidth);

            DataGridView payrollGrid = new DataGridView
            {
                Location = new Point(20, 260),
                Size = new Size(contentPanel.Width - 40, contentPanel.Height - 280),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                Font = new Font("Segoe UI", 10F)
            };

            payrollGrid.Columns.Add("EmployeeID", "Employee ID");
            payrollGrid.Columns.Add("EmployeeName", "Employee Name");
            payrollGrid.Columns.Add("Position", "Position");
            payrollGrid.Columns.Add("BasicSalary", "Basic Salary");
            payrollGrid.Columns.Add("Overtime", "Overtime");
            payrollGrid.Columns.Add("Allowances", "Allowances");
            payrollGrid.Columns.Add("Deductions", "Deductions");
            payrollGrid.Columns.Add("NetPay", "Net Pay");
            payrollGrid.Columns.Add("Status", "Status");

            foreach (var record in payrollRecords)
            {
                var employee = employees.FirstOrDefault(e => e.ID == record.EmployeeID);
                payrollGrid.Rows.Add(
                    record.EmployeeID,
                    employee?.FullName ?? "Unknown",
                    employee?.Position ?? "Unknown",
                    record.BasicSalary.ToString("C"),
                    record.OvertimePay.ToString("C"),
                    record.Allowances.ToString("C"),
                    record.Deductions.ToString("C"),
                    record.NetPay.ToString("C"),
                    record.Status
                );
            }

            payrollGrid.ColumnHeadersDefaultCellStyle.BackColor = primaryColor;
            payrollGrid.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            payrollGrid.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
            payrollGrid.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(250, 250, 250);
            payrollGrid.DefaultCellStyle.ForeColor = textColor;

            foreach (DataGridViewRow row in payrollGrid.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();
                switch (status)
                {
                    case "Processed":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(200, 230, 201);
                        break;
                    case "Pending":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(255, 245, 157);
                        break;
                    case "Hold":
                        row.Cells["Status"].Style.BackColor = Color.FromArgb(255, 205, 210);
                        break;
                }
            }

            contentPanel.Controls.Add(payrollGrid);
        }

        private void ShowReports()
        {
            ClearContentPanel();

            Label titleLabel = new Label
            {
                Text = "Reports & Analytics",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            contentPanel.Controls.Add(titleLabel);

            int groupWidth = Math.Max(250, (contentPanel.Width - 80) / 3);
            GroupBox reportTypeGroup = new GroupBox
            {
                Text = "Report Type",
                Location = new Point(20, 70),
                Size = new Size(groupWidth, 160),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };

            RadioButton attendanceReport = new RadioButton
            {
                Text = "📊 Attendance Report",
                Location = new Point(15, 30),
                Size = new Size(groupWidth - 30, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton payrollReport = new RadioButton
            {
                Text = "💰 Payroll Report",
                Location = new Point(15, 60),
                Size = new Size(groupWidth - 30, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton employeeReport = new RadioButton
            {
                Text = "👥 Employee Report",
                Location = new Point(15, 90),
                Size = new Size(groupWidth - 30, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton summaryReport = new RadioButton
            {
                Text = "📈 Summary Report",
                Location = new Point(15, 120),
                Size = new Size(groupWidth - 30, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };

            reportTypeGroup.Controls.AddRange(new Control[] {
                attendanceReport, payrollReport, employeeReport, summaryReport
            });
            contentPanel.Controls.Add(reportTypeGroup);

            GroupBox dateRangeGroup = new GroupBox
            {
                Text = "Date Range",
                Location = new Point(20 + groupWidth + 20, 70),
                Size = new Size(groupWidth, 160),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };

            RadioButton dailyRange = new RadioButton
            {
                Text = "Daily",
                Location = new Point(15, 30),
                Size = new Size(100, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton weeklyRange = new RadioButton
            {
                Text = "Weekly",
                Location = new Point(120, 30),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton monthlyRange = new RadioButton
            {
                Text = "Monthly",
                Location = new Point(15, 60),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            RadioButton yearlyRange = new RadioButton
            {
                Text = "Yearly",
                Location = new Point(120, 60),
                Size = new Size(100, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };

            Label fromDateLabel = new Label
            {
                Text = "From:",
                Location = new Point(15, 95),
                AutoSize = true,
                ForeColor = textColor
            };
            DateTimePicker fromDatePicker = new DateTimePicker
            {
                Location = new Point(75, 90),
                Size = new Size(120, 30),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };

            Label toDateLabel = new Label
            {
                Text = "To:",
                Location = new Point(200, 95),
                AutoSize = true,
                ForeColor = textColor
            };
            DateTimePicker toDatePicker = new DateTimePicker
            {
                Location = new Point(235, 90),
                Size = new Size(120, 30),
                Format = DateTimePickerFormat.Short,
                Font = new Font("Segoe UI", 10F)
            };

            dateRangeGroup.Controls.AddRange(new Control[] {
                dailyRange, weeklyRange, monthlyRange, yearlyRange,
                fromDateLabel, fromDatePicker, toDateLabel, toDatePicker
            });
            contentPanel.Controls.Add(dateRangeGroup);

            GroupBox exportGroup = new GroupBox
            {
                Text = "Export Options",
                Location = new Point(20 + (groupWidth + 20) * 2, 70),
                Size = new Size(groupWidth, 160),
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor
            };

            CheckBox includePDF = new CheckBox
            {
                Text = "📄 PDF Format",
                Location = new Point(15, 30),
                Size = new Size(150, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            CheckBox includeExcel = new CheckBox
            {
                Text = "📊 Excel Format",
                Location = new Point(15, 60),
                Size = new Size(150, 25),
                Checked = true,
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };
            CheckBox includeCSV = new CheckBox
            {
                Text = "📋 CSV Format",
                Location = new Point(15, 90),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 10F),
                ForeColor = textColor
            };

            exportGroup.Controls.AddRange(new Control[] { includePDF, includeExcel, includeCSV });
            contentPanel.Controls.Add(exportGroup);

            Button generateButton = new Button
            {
                Text = "📊 Generate Report",
                Location = new Point(20, 250),
                Size = new Size(180, 40),
                BackColor = primaryColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            generateButton.FlatAppearance.BorderSize = 0;
            generateButton.FlatAppearance.MouseOverBackColor = Color.FromArgb(53, 71, 171);
            generateButton.Click += (s, e) =>
            {
                MessageBox.Show("Report generation started! You will be notified when complete.",
                    "Report Generation", MessageBoxButtons.OK, MessageBoxIcon.Information);
            };
            contentPanel.Controls.Add(generateButton);

            Label quickReportsLabel = new Label
            {
                Text = "Quick Reports",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 310),
                AutoSize = true
            };
            contentPanel.Controls.Add(quickReportsLabel);

            int buttonWidth = Math.Max(150, (contentPanel.Width - 100) / 4);
            Button[] quickReportButtons = {
                new Button { Text = "📊 Today's Attendance", Location = new Point(20, 350), Size = new Size(buttonWidth, 40) },
                new Button { Text = "💰 This Month's Payroll", Location = new Point(20 + buttonWidth + 20, 350), Size = new Size(buttonWidth, 40) },
                new Button { Text = "👥 Active Employees", Location = new Point(20 + (buttonWidth + 20) * 2, 350), Size = new Size(buttonWidth, 40) },
                new Button { Text = "⏰ Late Arrivals Report", Location = new Point(20 + (buttonWidth + 20) * 3, 350), Size = new Size(buttonWidth, 40) },
                new Button { Text = "📈 Overtime Summary", Location = new Point(20, 400), Size = new Size(buttonWidth, 40) },
                new Button { Text = "💸 Deductions Report", Location = new Point(20 + buttonWidth + 20, 400), Size = new Size(buttonWidth, 40) },
                new Button { Text = "🏖️ Leave Balance", Location = new Point(20 + (buttonWidth + 20) * 2, 400), Size = new Size(buttonWidth, 40) },
                new Button { Text = "📋 Compliance Report", Location = new Point(20 + (buttonWidth + 20) * 3, 400), Size = new Size(buttonWidth, 40) }
            };

            foreach (Button btn in quickReportButtons)
            {
                btn.BackColor = Color.White;
                btn.ForeColor = primaryColor;
                btn.FlatStyle = FlatStyle.Flat;
                btn.FlatAppearance.BorderSize = 1;
                btn.FlatAppearance.BorderColor = primaryColor;
                btn.FlatAppearance.MouseOverBackColor = Color.FromArgb(240, 242, 245);
                btn.Cursor = Cursors.Hand;
                btn.Font = new Font("Segoe UI", 10F, FontStyle.Bold);
                btn.Click += (s, e) =>
                {
                    Button clickedBtn = (Button)s;
                    MessageBox.Show($"Generating {clickedBtn.Text}...", "Quick Report",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                contentPanel.Controls.Add(btn);
            }

            Panel recentReportsPanel = new Panel
            {
                Location = new Point(20, 460),
                Size = new Size(contentPanel.Width - 40, contentPanel.Height - 480),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };
            recentReportsPanel.Paint += (s, e) =>
            {
                ControlPaint.DrawBorder(e.Graphics, recentReportsPanel.ClientRectangle, Color.FromArgb(200, 200, 200), ButtonBorderStyle.Solid);
            };

            Label recentReportsTitle = new Label
            {
                Text = "Recent Reports",
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(15, 5),
                AutoSize = true
            };
            recentReportsPanel.Controls.Add(recentReportsTitle);

            string[] recentReports = {
                "📊 Attendance Report - March 2024 (Generated: 3/15/2024)",
                "💰 Payroll Summary - February 2024 (Generated: 3/1/2024)",
                "👥 Employee Status Report (Generated: 2/28/2024)",
                "⏰ Monthly Late Arrivals - February 2024 (Generated: 2/25/2024)",
                "📈 Overtime Analysis - Q1 2024 (Generated: 2/20/2024)"
            };

            for (int i = 0; i < recentReports.Length; i++)
            {
                Label reportLabel = new Label
                {
                    Text = recentReports[i],
                    Location = new Point(15, 45 + (i * 35)),
                    Size = new Size(contentPanel.Width - 70, 30),
                    Font = new Font("Segoe UI", 10F),
                    Cursor = Cursors.Hand,
                    ForeColor = primaryColor
                };
                reportLabel.Click += (s, e) =>
                {
                    MessageBox.Show("Opening report...", "Report Access",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                };
                recentReportsPanel.Controls.Add(reportLabel);
            }

            contentPanel.Controls.Add(recentReportsPanel);
        }

        private void ClearContentPanel()
        {
            contentPanel.Controls.Clear();
        }

        private void InitializeStaticData()
        {
            employees = new List<Employee>
            {
                new Employee { ID = "EMP001", FullName = "John Doe", Department = "Customer Service", Position = "Call Center Agent",
                    HireDate = DateTime.Parse("2023-01-15"), Salary = 25000, Status = "Active" },
                new Employee { ID = "EMP002", FullName = "Jane Smith", Department = "Technical Support", Position = "Senior Agent",
                    HireDate = DateTime.Parse("2022-06-20"), Salary = 32000, Status = "Active" },
                new Employee { ID = "EMP003", FullName = "Mike Johnson", Department = "Sales", Position = "Sales Representative",
                    HireDate = DateTime.Parse("2023-03-10"), Salary = 28000, Status = "Active" },
                new Employee { ID = "EMP004", FullName = "Sarah Wilson", Department = "Human Resources", Position = "HR Manager",
                    HireDate = DateTime.Parse("2021-11-05"), Salary = 45000, Status = "Active" },
                new Employee { ID = "EMP005", FullName = "David Brown", Department = "Customer Service", Position = "Team Leader",
                    HireDate = DateTime.Parse("2022-08-12"), Salary = 38000, Status = "Active" },
                new Employee { ID = "EMP006", FullName = "Lisa Garcia", Department = "Quality Assurance", Position = "QA Analyst",
                    HireDate = DateTime.Parse("2023-02-28"), Salary = 30000, Status = "Active" },
                new Employee { ID = "EMP007", FullName = "Robert Lee", Department = "IT Support", Position = "IT Specialist",
                    HireDate = DateTime.Parse("2022-12-01"), Salary = 40000, Status = "Active" },
                new Employee { ID = "EMP008", FullName = "Emily Davis", Department = "Training", Position = "Training Coordinator",
                    HireDate = DateTime.Parse("2023-04-15"), Salary = 35000, Status = "Active" },
                new Employee { ID = "EMP009", FullName = "Chris Martinez", Department = "Customer Service", Position = "Call Center Agent",
                    HireDate = DateTime.Parse("2023-05-20"), Salary = 25000, Status = "On Leave" },
                new Employee { ID = "EMP010", FullName = "Amanda Taylor", Department = "Sales", Position = "Sales Manager",
                    HireDate = DateTime.Parse("2021-09-18"), Salary = 50000, Status = "Active" }
            };

            attendanceRecords = new List<AttendanceRecord>();
            Random random = new Random();
            DateTime baseDate = DateTime.Today.AddDays(-30);

            foreach (var employee in employees)
            {
                for (int i = 0; i < 30; i++)
                {
                    DateTime date = baseDate.AddDays(i);
                    if (date.DayOfWeek != DayOfWeek.Saturday && date.DayOfWeek != DayOfWeek.Sunday)
                    {
                        var record = new AttendanceRecord
                        {
                            EmployeeID = employee.ID,
                            Date = date
                        };

                        int scenario = random.Next(1, 11);
                        if (scenario <= 7)
                        {
                            int minutesLate = random.Next(0, 60);
                            record.TimeIn = DateTime.Today.AddHours(8).AddMinutes(minutesLate);
                            record.TimeOut = DateTime.Today.AddHours(17).AddMinutes(random.Next(-30, 30));
                            record.WorkHours = (record.TimeOut - record.TimeIn).Value.TotalHours - 1;
                            record.Status = minutesLate > 15 ? "Late" : "Present";
                        }
                        else if (scenario <= 9)
                        {
                            int minutesLate = random.Next(16, 120);
                            record.TimeIn = DateTime.Today.AddHours(8).AddMinutes(minutesLate);
                            record.TimeOut = DateTime.Today.AddHours(17).AddMinutes(random.Next(-30, 30));
                            record.WorkHours = (record.TimeOut - record.TimeIn).Value.TotalHours - 1;
                            record.Status = "Late";
                        }
                        else
                        {
                            record.Status = "Absent";
                            record.WorkHours = 0;
                        }

                        attendanceRecords.Add(record);
                    }
                }
            }

            payrollRecords = new List<PayrollRecord>();
            foreach (var employee in employees)
            {
                var record = new PayrollRecord
                {
                    EmployeeID = employee.ID,
                    PayPeriod = "March 2024",
                    BasicSalary = employee.Salary,
                    OvertimePay = (decimal)(random.NextDouble() * 5000),
                    Allowances = 2000,
                    Deductions = employee.Salary * 0.15m,
                    Status = random.Next(1, 11) > 2 ? "Processed" : "Pending"
                };
                record.NetPay = record.BasicSalary + record.OvertimePay + record.Allowances - record.Deductions;
                payrollRecords.Add(record);
            }
        }

        private int GetTodayPresentCount()
        {
            return attendanceRecords.Count(a => a.Date.Date == DateTime.Today && a.Status == "Present");
        }

        private int GetTodayLateCount()
        {
            return attendanceRecords.Count(a => a.Date.Date == DateTime.Today && a.Status == "Late");
        }

        private int GetTodayAbsentCount()
        {
            return attendanceRecords.Count(a => a.Date.Date == DateTime.Today && a.Status == "Absent");
        }
    }

    public class Employee1
    {
        public string ID { get; set; }
        public string FullName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public DateTime HireDate { get; set; }
        public decimal Salary { get; set; }
        public string Status { get; set; }
    }

    public class AttendanceRecord1
    {
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public double WorkHours { get; set; }
        public string Status { get; set; }
    }

    public class PayrollRecord1
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