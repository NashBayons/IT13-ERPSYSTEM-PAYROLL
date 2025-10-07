namespace tryagain
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            logoutBtn = new Button();
            leaveBtn = new Button();
            salaryBtn = new Button();
            reportsBtn = new Button();
            payrollBtn = new Button();
            attendanceBtn = new Button();
            employeeBtn = new Button();
            dashboardBtn = new Button();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.DarkGray;
            sidebarPanel.Controls.Add(logoutBtn);
            sidebarPanel.Controls.Add(leaveBtn);
            sidebarPanel.Controls.Add(salaryBtn);
            sidebarPanel.Controls.Add(reportsBtn);
            sidebarPanel.Controls.Add(payrollBtn);
            sidebarPanel.Controls.Add(attendanceBtn);
            sidebarPanel.Controls.Add(employeeBtn);
            sidebarPanel.Controls.Add(dashboardBtn);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 753);
            sidebarPanel.TabIndex = 4;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(54, 712);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(94, 29);
            logoutBtn.TabIndex = 7;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // leaveBtn
            // 
            leaveBtn.Location = new Point(54, 180);
            leaveBtn.Name = "leaveBtn";
            leaveBtn.Size = new Size(94, 29);
            leaveBtn.TabIndex = 6;
            leaveBtn.Text = "Leave";
            leaveBtn.UseVisualStyleBackColor = true;
            leaveBtn.Click += leaveBtn_Click;
            // 
            // salaryBtn
            // 
            salaryBtn.Location = new Point(54, 260);
            salaryBtn.Name = "salaryBtn";
            salaryBtn.Size = new Size(94, 29);
            salaryBtn.TabIndex = 5;
            salaryBtn.Text = "Salary Man.";
            salaryBtn.UseVisualStyleBackColor = true;
            salaryBtn.Click += salaryBtn_Click;
            // 
            // reportsBtn
            // 
            reportsBtn.Location = new Point(54, 300);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(94, 29);
            reportsBtn.TabIndex = 4;
            reportsBtn.Text = "Reports";
            reportsBtn.UseVisualStyleBackColor = true;
            reportsBtn.Click += reportsBtn_Click;
            // 
            // payrollBtn
            // 
            payrollBtn.Location = new Point(54, 220);
            payrollBtn.Name = "payrollBtn";
            payrollBtn.Size = new Size(94, 29);
            payrollBtn.TabIndex = 3;
            payrollBtn.Text = "Payroll";
            payrollBtn.UseVisualStyleBackColor = true;
            payrollBtn.Click += payrollBtn_Click;
            // 
            // attendanceBtn
            // 
            attendanceBtn.Location = new Point(54, 140);
            attendanceBtn.Name = "attendanceBtn";
            attendanceBtn.Size = new Size(94, 29);
            attendanceBtn.TabIndex = 2;
            attendanceBtn.Text = "Attendance";
            attendanceBtn.UseVisualStyleBackColor = true;
            attendanceBtn.Click += attendanceBtn_Click;
            // 
            // employeeBtn
            // 
            employeeBtn.Location = new Point(54, 100);
            employeeBtn.Name = "employeeBtn";
            employeeBtn.Size = new Size(94, 29);
            employeeBtn.TabIndex = 1;
            employeeBtn.Text = "Employees";
            employeeBtn.UseVisualStyleBackColor = true;
            employeeBtn.Click += employeeBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.Location = new Point(55, 60);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Size = new Size(94, 29);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.UseVisualStyleBackColor = true;
            dashboardBtn.Click += dashboardBtn_Click;
            // 
            // contentPanel
            // 
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            contentPanel.BackColor = SystemColors.Info;
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(982, 753);
            contentPanel.TabIndex = 5;
            // 
            // MainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 753);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Name = "MainForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "MainForm";
            sidebarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion
        private Panel sidebarPanel;
        private Button reportsBtn;
        private Button payrollBtn;
        private Button attendanceBtn;
        private Button employeeBtn;
        private Button dashboardBtn;
        private Panel contentPanel;
        private Button salaryBtn;
        private Button leaveBtn;
        private Button logoutBtn;
    }
}