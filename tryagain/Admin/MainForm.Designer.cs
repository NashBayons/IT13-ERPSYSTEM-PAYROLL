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
            DepartmentBtn = new Button();
            leaveBtn = new Button();
            salaryBtn = new Button();
            reportsBtn = new Button();
            payrollBtn = new Button();
            attendanceBtn = new Button();
            employeeBtn = new Button();
            dashboardBtn = new Button();
            pictureBox1 = new PictureBox();
            logoutBtn = new Button();
            contentPanel = new Panel();
            sidebarPanel.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.DarkBlue;
            sidebarPanel.Controls.Add(DepartmentBtn);
            sidebarPanel.Controls.Add(leaveBtn);
            sidebarPanel.Controls.Add(salaryBtn);
            sidebarPanel.Controls.Add(reportsBtn);
            sidebarPanel.Controls.Add(payrollBtn);
            sidebarPanel.Controls.Add(attendanceBtn);
            sidebarPanel.Controls.Add(employeeBtn);
            sidebarPanel.Controls.Add(dashboardBtn);
            sidebarPanel.Controls.Add(pictureBox1);
            sidebarPanel.Controls.Add(logoutBtn);
            sidebarPanel.Dock = DockStyle.Left;
            sidebarPanel.Location = new Point(0, 0);
            sidebarPanel.Name = "sidebarPanel";
            sidebarPanel.Size = new Size(200, 753);
            sidebarPanel.TabIndex = 4;
            sidebarPanel.Paint += sidebarPanel_Paint;
            // 
            // DepartmentBtn
            // 
            DepartmentBtn.BackColor = Color.RoyalBlue;
            DepartmentBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            DepartmentBtn.ForeColor = Color.White;
            DepartmentBtn.Location = new Point(23, 342);
            DepartmentBtn.Name = "DepartmentBtn";
            DepartmentBtn.Size = new Size(151, 42);
            DepartmentBtn.TabIndex = 9;
            DepartmentBtn.Text = "Department";
            DepartmentBtn.UseVisualStyleBackColor = false;
            DepartmentBtn.Click += DepartmentBtn_Click;
            // 
            // leaveBtn
            // 
            leaveBtn.BackColor = Color.RoyalBlue;
            leaveBtn.Font = new Font("Segoe UI", 10.2F);
            leaveBtn.ForeColor = Color.White;
            leaveBtn.Location = new Point(23, 440);
            leaveBtn.Name = "leaveBtn";
            leaveBtn.Size = new Size(151, 42);
            leaveBtn.TabIndex = 6;
            leaveBtn.Text = "Leave";
            leaveBtn.UseVisualStyleBackColor = false;
            leaveBtn.Click += leaveBtn_Click;
            // 
            // salaryBtn
            // 
            salaryBtn.BackColor = Color.RoyalBlue;
            salaryBtn.Font = new Font("Segoe UI", 10.2F);
            salaryBtn.ForeColor = Color.White;
            salaryBtn.Location = new Point(23, 540);
            salaryBtn.Name = "salaryBtn";
            salaryBtn.Size = new Size(151, 42);
            salaryBtn.TabIndex = 5;
            salaryBtn.Text = "Salary Man.";
            salaryBtn.UseVisualStyleBackColor = false;
            salaryBtn.Click += salaryBtn_Click;
            // 
            // reportsBtn
            // 
            reportsBtn.BackColor = Color.RoyalBlue;
            reportsBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            reportsBtn.ForeColor = Color.White;
            reportsBtn.Location = new Point(23, 590);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(151, 42);
            reportsBtn.TabIndex = 4;
            reportsBtn.Text = "Reports";
            reportsBtn.UseVisualStyleBackColor = false;
            reportsBtn.Click += reportsBtn_Click;
            // 
            // payrollBtn
            // 
            payrollBtn.BackColor = Color.RoyalBlue;
            payrollBtn.Font = new Font("Segoe UI", 10.2F);
            payrollBtn.ForeColor = Color.White;
            payrollBtn.Location = new Point(23, 490);
            payrollBtn.Name = "payrollBtn";
            payrollBtn.Size = new Size(151, 42);
            payrollBtn.TabIndex = 3;
            payrollBtn.Text = "Payroll";
            payrollBtn.UseVisualStyleBackColor = false;
            payrollBtn.Click += payrollBtn_Click;
            // 
            // attendanceBtn
            // 
            attendanceBtn.BackColor = Color.RoyalBlue;
            attendanceBtn.Font = new Font("Segoe UI", 10.2F);
            attendanceBtn.ForeColor = Color.White;
            attendanceBtn.Location = new Point(23, 390);
            attendanceBtn.Name = "attendanceBtn";
            attendanceBtn.Size = new Size(151, 42);
            attendanceBtn.TabIndex = 2;
            attendanceBtn.Text = "Attendance";
            attendanceBtn.UseVisualStyleBackColor = false;
            attendanceBtn.Click += attendanceBtn_Click;
            // 
            // employeeBtn
            // 
            employeeBtn.BackColor = Color.RoyalBlue;
            employeeBtn.Font = new Font("Segoe UI", 10.2F);
            employeeBtn.ForeColor = Color.White;
            employeeBtn.Location = new Point(23, 290);
            employeeBtn.Name = "employeeBtn";
            employeeBtn.Size = new Size(151, 42);
            employeeBtn.TabIndex = 1;
            employeeBtn.Text = "Employees";
            employeeBtn.UseVisualStyleBackColor = false;
            employeeBtn.Click += employeeBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.BackColor = Color.RoyalBlue;
            dashboardBtn.Font = new Font("Segoe UI", 10.2F);
            dashboardBtn.ForeColor = Color.White;
            dashboardBtn.Location = new Point(23, 240);
            dashboardBtn.Name = "dashboardBtn";
            dashboardBtn.Size = new Size(151, 42);
            dashboardBtn.TabIndex = 0;
            dashboardBtn.Text = "Dashboard";
            dashboardBtn.UseVisualStyleBackColor = false;
            dashboardBtn.Click += dashboardBtn_Click;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = Color.Transparent;
            pictureBox1.Image = Properties.Resources.logo2;
            pictureBox1.Location = new Point(9, 12);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(185, 255);
            pictureBox1.SizeMode = PictureBoxSizeMode.CenterImage;
            pictureBox1.TabIndex = 8;
            pictureBox1.TabStop = false;
            // 
            // logoutBtn
            // 
            logoutBtn.BackColor = Color.Red;
            logoutBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            logoutBtn.ForeColor = Color.White;
            logoutBtn.Location = new Point(23, 699);
            logoutBtn.Name = "logoutBtn";
            logoutBtn.Size = new Size(151, 42);
            logoutBtn.TabIndex = 7;
            logoutBtn.Text = "Log Out";
            logoutBtn.UseVisualStyleBackColor = false;
            logoutBtn.Click += logoutBtn_Click;
            // 
            // contentPanel
            // 
            contentPanel.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right;
            contentPanel.BackColor = Color.WhiteSmoke;
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
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
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
        private PictureBox pictureBox1;
        private Button DepartmentBtn;
    }
}