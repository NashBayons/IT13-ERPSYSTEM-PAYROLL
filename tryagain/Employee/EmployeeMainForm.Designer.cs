namespace tryagain.Employee
{
    partial class EmployeeMainForm
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            sidebarPanel = new Panel();
            accountbtn = new Button();
            Settingsbtn = new Button();
            Attendancetbtn = new Button();
            payrollBtn = new Button();
            Employeeprofilebtn = new Button();
            Dashboardbtn = new Button();
            contentPanel = new Panel();
            logoutBtn = new Button();
            sidebarPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.DarkGray;
            sidebarPanel.Controls.Add(logoutBtn);
            sidebarPanel.Controls.Add(accountbtn);
            sidebarPanel.Controls.Add(Settingsbtn);
            sidebarPanel.Controls.Add(Attendancetbtn);
            sidebarPanel.Controls.Add(payrollBtn);
            sidebarPanel.Controls.Add(Employeeprofilebtn);
            sidebarPanel.Controls.Add(Dashboardbtn);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 853);
            sidebarPanel.TabIndex = 5;
            // 
            // accountbtn
            // 
            accountbtn.Location = new Point(41, 365);
            accountbtn.Name = "accountbtn";
            accountbtn.Size = new Size(127, 29);
            accountbtn.TabIndex = 5;
            accountbtn.Text = "Account";
            accountbtn.UseVisualStyleBackColor = true;
            accountbtn.Click += accountbtn_Click;
            // 
            // Settingsbtn
            // 
            Settingsbtn.Location = new Point(41, 307);
            Settingsbtn.Name = "Settingsbtn";
            Settingsbtn.Size = new Size(127, 29);
            Settingsbtn.TabIndex = 4;
            Settingsbtn.Text = "Settings";
            Settingsbtn.UseVisualStyleBackColor = true;
            Settingsbtn.Click += Settingsbtn_Click_1;
            // 
            // Attendancetbtn
            // 
            Attendancetbtn.Location = new Point(41, 245);
            Attendancetbtn.Name = "Attendancetbtn";
            Attendancetbtn.Size = new Size(127, 29);
            Attendancetbtn.TabIndex = 3;
            Attendancetbtn.Text = "Attendance";
            Attendancetbtn.UseVisualStyleBackColor = true;
            Attendancetbtn.Click += Attendancetbtn_Click_1;
            // 
            // payrollBtn
            // 
            payrollBtn.Location = new Point(41, 181);
            payrollBtn.Name = "payrollBtn";
            payrollBtn.Size = new Size(127, 29);
            payrollBtn.TabIndex = 2;
            payrollBtn.Text = "Payroll";
            payrollBtn.UseVisualStyleBackColor = true;
            payrollBtn.Click += payrollBtn_Click_1;
            // 
            // Employeeprofilebtn
            // 
            Employeeprofilebtn.Location = new Point(41, 117);
            Employeeprofilebtn.Name = "Employeeprofilebtn";
            Employeeprofilebtn.Size = new Size(127, 29);
            Employeeprofilebtn.TabIndex = 1;
            Employeeprofilebtn.Text = "Employee Profile";
            Employeeprofilebtn.UseVisualStyleBackColor = true;
            Employeeprofilebtn.Click += Employeeprofilebtn_Click;
            // 
            // Dashboardbtn
            // 
            Dashboardbtn.Location = new Point(41, 64);
            Dashboardbtn.Name = "Dashboardbtn";
            Dashboardbtn.Size = new Size(127, 29);
            Dashboardbtn.TabIndex = 0;
            Dashboardbtn.Text = "Dashboard";
            Dashboardbtn.UseVisualStyleBackColor = true;
            Dashboardbtn.Click += Dashboardbtn_Click_1;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(982, 853);
            contentPanel.TabIndex = 5;
            // 
            // logoutBtn
            // 
            logoutBtn.Location = new Point(41, 802);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(127, 29);
            logoutBtn.TabIndex = 6;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = true;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1182, 853);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeMainForm";
            Text = "Form1";
            sidebarPanel.ResumeLayout(false);
            ResumeLayout(false);
        }

        #endregion

        private Panel sidebarPanel;
        private Button Settingsbtn;
        private Button Attendancetbtn;
        private Button payrollBtn;
        private Button Employeeprofilebtn;
        private Button Dashboardbtn;
        private Button accountbtn;
        private Panel contentPanel;
        private Button logoutBtn;
    }
}
