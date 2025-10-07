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
    public partial class dashboardForm : Form
    {
        private List<string> employees = new List<string> { "EMP001", "EMP002", "EMP003" };
        private Color textColor = Color.Black;
        private Color primaryColor = Color.FromArgb(63, 81, 181);

        public dashboardForm()
        {
            InitializeComponent();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;

            ShowDashboard();
        }

        private void ShowDashboard()
        {
            this.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "Dashboard",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            int cardY = 100;
            int cardWidth = Math.Max(200, (this.Width - 100) / 4);
            CreateDashboardCard("Total Employees", employees.Count.ToString(), "👥", new Point(20, cardY), cardWidth);
            CreateDashboardCard("Present Today", GetTodayPresentCount().ToString(), "✅", new Point(20 + cardWidth + 20, cardY), cardWidth);
            CreateDashboardCard("Late Today", GetTodayLateCount().ToString(), "⏰", new Point(20 + (cardWidth + 20) * 2, cardY), cardWidth);
            CreateDashboardCard("Absent Today", GetTodayAbsentCount().ToString(), "❌", new Point(20 + (cardWidth + 20) * 3, cardY), cardWidth);

            int panelY = cardY + 120;
            int panelWidth = Math.Max(300, (this.Width - 60) / 2);
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

            this.Controls.AddRange(new[] { activitiesPanel, quickActionsPanel });
        }

        private void CreateDashboardCard(string title, string value, string icon, Point location, int width)
        {
            Panel card = new Panel
            {
                Location = location,
                Size = new Size(width, 100),
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
                Font = new Font("Segoe UI Emoji", 24F),
                Location = new Point(15, 20),
                AutoSize = true
            };
            card.Controls.Add(iconLabel);

            Label titleLabel = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 10F, FontStyle.Bold),
                ForeColor = textColor,
                Location = new Point(70, 20),
                AutoSize = true
            };
            card.Controls.Add(titleLabel);

            Label valueLabel = new Label
            {
                Text = value,
                Font = new Font("Segoe UI", 16F, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(70, 50),
                AutoSize = true
            };
            card.Controls.Add(valueLabel);

            this.Controls.Add(card);
        }

        private int GetTodayPresentCount() => 5;
        private int GetTodayLateCount() => 2;
        private int GetTodayAbsentCount() => 1;
    }
}
