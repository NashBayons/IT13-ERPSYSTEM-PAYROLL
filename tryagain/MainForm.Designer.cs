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
            reportsBtn = new Button();
            payrollBtn = new Button();
            attendanceBtn = new Button();
            employeeBtn = new Button();
            dashboardBtn = new Button();
            contentPanel = new Panel();
            dashboardLbl = new Label();
            sidebarPanel.SuspendLayout();
            contentPanel.SuspendLayout();
            SuspendLayout();
            // 
            // sidebarPanel
            // 
            sidebarPanel.BackColor = Color.DarkGray;
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
            // reportsBtn
            // 
            reportsBtn.Location = new Point(54, 306);
            reportsBtn.Name = "reportsBtn";
            reportsBtn.Size = new Size(94, 29);
            reportsBtn.TabIndex = 4;
            reportsBtn.Text = "Reports";
            reportsBtn.UseVisualStyleBackColor = true;
            reportsBtn.Click += reportsBtn_Click;
            // 
            // payrollBtn
            // 
            payrollBtn.Location = new Point(54, 245);
            payrollBtn.Name = "payrollBtn";
            payrollBtn.Size = new Size(94, 29);
            payrollBtn.TabIndex = 3;
            payrollBtn.Text = "Payroll";
            payrollBtn.UseVisualStyleBackColor = true;
            payrollBtn.Click += payrollBtn_Click;
            // 
            // attendanceBtn
            // 
            attendanceBtn.Location = new Point(54, 182);
            attendanceBtn.Name = "attendanceBtn";
            attendanceBtn.Size = new Size(94, 29);
            attendanceBtn.TabIndex = 2;
            attendanceBtn.Text = "Attendance";
            attendanceBtn.UseVisualStyleBackColor = true;
            attendanceBtn.Click += attendanceBtn_Click;
            // 
            // employeeBtn
            // 
            employeeBtn.Location = new Point(54, 117);
            employeeBtn.Name = "employeeBtn";
            employeeBtn.Size = new Size(94, 29);
            employeeBtn.TabIndex = 1;
            employeeBtn.Text = "Employees";
            employeeBtn.UseVisualStyleBackColor = true;
            employeeBtn.Click += employeeBtn_Click;
            // 
            // dashboardBtn
            // 
            dashboardBtn.Location = new Point(54, 64);
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
            contentPanel.Controls.Add(dashboardLbl);
            contentPanel.Location = new Point(200, 0);
            contentPanel.Name = "contentPanel";
            contentPanel.Size = new Size(982, 753);
            contentPanel.TabIndex = 5;
            // 
            // dashboardLbl
            // 
            dashboardLbl.AutoSize = true;
            dashboardLbl.Location = new Point(54, 29);
            dashboardLbl.Name = "dashboardLbl";
            dashboardLbl.Size = new Size(166, 20);
            dashboardLbl.TabIndex = 5;
            dashboardLbl.Text = "Welcome to Dashboard";
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
            contentPanel.ResumeLayout(false);
            contentPanel.PerformLayout();
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
        private Label dashboardLbl;
    }
}