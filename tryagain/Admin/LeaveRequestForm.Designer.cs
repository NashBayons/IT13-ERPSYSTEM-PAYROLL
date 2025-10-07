namespace tryagain
{
    partial class LeaveRequestForm
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
            dgvLeaveRequests = new DataGridView();
            loadreqBtn = new Button();
            approveBtn = new Button();
            rejectBtn = new Button();
            label1 = new Label();
            txtEmployeeName = new TextBox();
            label2 = new Label();
            cmbLeaveType = new ComboBox();
            label3 = new Label();
            label4 = new Label();
            dtpFrom = new DateTimePicker();
            dtpTo = new DateTimePicker();
            filterBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvLeaveRequests).BeginInit();
            SuspendLayout();
            // 
            // dgvLeaveRequests
            // 
            dgvLeaveRequests.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvLeaveRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaveRequests.Location = new Point(25, 95);
            dgvLeaveRequests.Name = "dgvLeaveRequests";
            dgvLeaveRequests.RowHeadersVisible = false;
            dgvLeaveRequests.RowHeadersWidth = 51;
            dgvLeaveRequests.Size = new Size(903, 445);
            dgvLeaveRequests.TabIndex = 0;
            // 
            // loadreqBtn
            // 
            loadreqBtn.Location = new Point(25, 546);
            loadreqBtn.Name = "loadreqBtn";
            loadreqBtn.Size = new Size(94, 29);
            loadreqBtn.TabIndex = 1;
            loadreqBtn.Text = "Load Request";
            loadreqBtn.UseVisualStyleBackColor = true;
            loadreqBtn.Click += loadreqBtn_Click;
            // 
            // approveBtn
            // 
            approveBtn.Location = new Point(135, 546);
            approveBtn.Name = "approveBtn";
            approveBtn.Size = new Size(94, 29);
            approveBtn.TabIndex = 2;
            approveBtn.Text = "Approve";
            approveBtn.UseVisualStyleBackColor = true;
            approveBtn.Click += approveBtn_Click;
            // 
            // rejectBtn
            // 
            rejectBtn.Location = new Point(250, 546);
            rejectBtn.Name = "rejectBtn";
            rejectBtn.Size = new Size(94, 29);
            rejectBtn.TabIndex = 3;
            rejectBtn.Text = "Reject";
            rejectBtn.UseVisualStyleBackColor = true;
            rejectBtn.Click += rejectBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(25, 31);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 4;
            label1.Text = "Employee";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(106, 28);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(125, 27);
            txtEmployeeName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(249, 32);
            label2.Name = "label2";
            label2.Size = new Size(82, 20);
            label2.TabIndex = 6;
            label2.Text = "Leave Type";
            // 
            // cmbLeaveType
            // 
            cmbLeaveType.FormattingEnabled = true;
            cmbLeaveType.Location = new Point(337, 29);
            cmbLeaveType.Name = "cmbLeaveType";
            cmbLeaveType.Size = new Size(151, 28);
            cmbLeaveType.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(504, 32);
            label3.Name = "label3";
            label3.Size = new Size(50, 20);
            label3.TabIndex = 8;
            label3.Text = "label3";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(719, 32);
            label4.Name = "label4";
            label4.Size = new Size(50, 20);
            label4.TabIndex = 9;
            label4.Text = "label4";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(560, 29);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(153, 27);
            dtpFrom.TabIndex = 10;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(775, 28);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(153, 27);
            dtpTo.TabIndex = 11;
            // 
            // filterBtn
            // 
            filterBtn.Location = new Point(834, 61);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(94, 29);
            filterBtn.TabIndex = 12;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += filterBtn_Click;
            // 
            // LeaveRequestForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 706);
            Controls.Add(filterBtn);
            Controls.Add(dtpTo);
            Controls.Add(dtpFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(cmbLeaveType);
            Controls.Add(label2);
            Controls.Add(txtEmployeeName);
            Controls.Add(label1);
            Controls.Add(rejectBtn);
            Controls.Add(approveBtn);
            Controls.Add(loadreqBtn);
            Controls.Add(dgvLeaveRequests);
            FormBorderStyle = FormBorderStyle.None;
            Name = "LeaveRequestForm";
            Text = "LeaveRequestForm";
            ((System.ComponentModel.ISupportInitialize)dgvLeaveRequests).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private DataGridView dgvLeaveRequests;
        private Button loadreqBtn;
        private Button approveBtn;
        private Button rejectBtn;
        private Label label1;
        private TextBox txtEmployeeName;
        private Label label2;
        private ComboBox cmbLeaveType;
        private Label label3;
        private Label label4;
        private DateTimePicker dtpFrom;
        private DateTimePicker dtpTo;
        private Button filterBtn;
    }
}