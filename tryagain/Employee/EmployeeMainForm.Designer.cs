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
            pictureBox2 = new PictureBox();
            logoutBtn = new Button();
            accountbtn = new Button();
            Settingsbtn = new Button();
            Attendancetbtn = new Button();
            payrollBtn = new Button();
            Employeeprofilebtn = new Button();
            Dashboardbtn = new Button();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox2).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.DarkBlue;
            sidebarPanel.Controls.Add(accountbtn);
            sidebarPanel.Controls.Add(Settingsbtn);
            sidebarPanel.Controls.Add(Attendancetbtn);
            sidebarPanel.Controls.Add(payrollBtn);
            sidebarPanel.Controls.Add(Employeeprofilebtn);
            sidebarPanel.Controls.Add(Dashboardbtn);
            sidebarPanel.Controls.Add(pictureBox2);
            sidebarPanel.Controls.Add(logoutBtn);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 753);
            sidebarPanel.TabIndex = 5;
            // 
            // pictureBox2
            // 
            pictureBox2.BackColor = Color.Transparent;
            pictureBox2.Image = Properties.Resources.logo2;
            pictureBox2.Location = new Point(9, 12);
            pictureBox2.Name = "pictureBox2";
            pictureBox2.Size = new Size(185, 255);
            pictureBox2.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox2.TabIndex = 10;
            pictureBox2.TabStop = false;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.Red;
            logoutBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.Location = new Point(23, 699);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(151, 42);
            logoutBtn.TabIndex = 6;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // accountbtn
            // 
            accountbtn.BackColor = Color.RoyalBlue;
            accountbtn.Font = new Font("Segoe UI", 10.2F);
            accountbtn.ForeColor = Color.White;
            accountbtn.Location = new Point(23, 488);
            accountbtn.Name = "accountbtn";
            accountbtn.Size = new Size(151, 42);
            accountbtn.TabIndex = 5;
            accountbtn.Text = "Account";
            accountbtn.UseVisualStyleBackColor = false;
            accountbtn.Click += accountbtn_Click;
            // 
            // Settingsbtn
            // 
            Settingsbtn.BackColor = Color.RoyalBlue;
            Settingsbtn.Font = new Font("Segoe UI", 10.2F);
            Settingsbtn.ForeColor = Color.White;
            Settingsbtn.Location = new Point(23, 438);
            Settingsbtn.Name = "Settingsbtn";
            Settingsbtn.Size = new Size(151, 42);
            Settingsbtn.TabIndex = 4;
            Settingsbtn.Text = "Settings";
            Settingsbtn.UseVisualStyleBackColor = false;
            Settingsbtn.Click += Settingsbtn_Click_1;
            // 
            // Attendancetbtn
            // 
            Attendancetbtn.BackColor = Color.RoyalBlue;
            Attendancetbtn.Font = new Font("Segoe UI", 10.2F);
            Attendancetbtn.ForeColor = Color.White;
            Attendancetbtn.Location = new Point(23, 388);
            Attendancetbtn.Name = "Attendancetbtn";
            Attendancetbtn.Size = new Size(151, 42);
            Attendancetbtn.TabIndex = 3;
            Attendancetbtn.Text = "Attendance";
            Attendancetbtn.UseVisualStyleBackColor = false;
            Attendancetbtn.Click += Attendancetbtn_Click_1;
            // 
            // payrollBtn
            // 
            payrollBtn.BackColor = Color.RoyalBlue;
            payrollBtn.Font = new Font("Segoe UI", 10.2F);
            payrollBtn.ForeColor = Color.White;
            payrollBtn.Location = new Point(23, 338);
            payrollBtn.Name = "payrollBtn";
            payrollBtn.Size = new Size(151, 42);
            payrollBtn.TabIndex = 2;
            payrollBtn.Text = "Payroll";
            payrollBtn.UseVisualStyleBackColor = false;
            payrollBtn.Click += payrollBtn_Click_1;
            // 
            // Employeeprofilebtn
            // 
            Employeeprofilebtn.BackColor = Color.RoyalBlue;
            Employeeprofilebtn.Font = new Font("Segoe UI", 10.2F);
            Employeeprofilebtn.ForeColor = Color.White;
            Employeeprofilebtn.Location = new Point(23, 288);
            Employeeprofilebtn.Name = "Employeeprofilebtn";
            Employeeprofilebtn.Size = new Size(151, 42);
            Employeeprofilebtn.TabIndex = 1;
            Employeeprofilebtn.Text = "Employee Profile";
            Employeeprofilebtn.UseVisualStyleBackColor = false;
            Employeeprofilebtn.Click += Employeeprofilebtn_Click;
            // 
            // Dashboardbtn
            // 
            Dashboardbtn.BackColor = Color.RoyalBlue;
            Dashboardbtn.Font = new Font("Segoe UI", 10.2F);
            Dashboardbtn.ForeColor = Color.White;
            Dashboardbtn.Location = new Point(23, 238);
            Dashboardbtn.Name = "Dashboardbtn";
            Dashboardbtn.Size = new Size(151, 42);
            Dashboardbtn.TabIndex = 0;
            Dashboardbtn.Text = "Dashboard";
            Dashboardbtn.UseVisualStyleBackColor = false;
            Dashboardbtn.Click += Dashboardbtn_Click_1;
            // 
            // contentPanel
            // 
            contentPanel.BackColor = Color.White;
            contentPanel.Dock = DockStyle.Fill;
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(1032, 753);
            contentPanel.TabIndex = 5;
            // 
            // EmployeeMainForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1232, 753);
            Controls.Add(contentPanel);
            Controls.Add(sidebarPanel);
            Margin = new Padding(3, 4, 3, 4);
            Name = "EmployeeMainForm";
            Text = "Form1";
            sidebarPanel.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)pictureBox2).EndInit();
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
        private PictureBox pictureBox2;
    }
}
