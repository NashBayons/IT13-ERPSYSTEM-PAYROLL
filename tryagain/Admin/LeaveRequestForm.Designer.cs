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
            dgvLeaveRequests.BackgroundColor = SystemColors.Control;
            dgvLeaveRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvLeaveRequests.Location = new Point(25, 105);
            dgvLeaveRequests.Name = "dgvLeaveRequests";
            dgvLeaveRequests.RowHeadersVisible = false;
            dgvLeaveRequests.RowHeadersWidth = 51;
            dgvLeaveRequests.Size = new Size(903, 445);
            dgvLeaveRequests.TabIndex = 0;
            // 
            // loadreqBtn
            // 
            loadreqBtn.BackColor = Color.RoyalBlue;
            loadreqBtn.Font = new Font("Segoe UI", 10.2F);
            loadreqBtn.ForeColor = Color.White;
            loadreqBtn.Location = new Point(25, 566);
            loadreqBtn.Name = "loadreqBtn";
            loadreqBtn.Size = new Size(147, 39);
            loadreqBtn.TabIndex = 1;
            loadreqBtn.Text = "Load Request";
            loadreqBtn.UseVisualStyleBackColor = false;
            loadreqBtn.Click += loadreqBtn_Click;
            // 
            // approveBtn
            // 
            approveBtn.BackColor = Color.FromArgb(0, 192, 0);
            approveBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            approveBtn.ForeColor = Color.White;
            approveBtn.Location = new Point(178, 566);
            approveBtn.Name = "approveBtn";
            approveBtn.Size = new Size(109, 39);
            approveBtn.TabIndex = 2;
            approveBtn.Text = "Approve";
            approveBtn.UseVisualStyleBackColor = false;
            approveBtn.Click += approveBtn_Click;
            // 
            // rejectBtn
            // 
            rejectBtn.BackColor = Color.Red;
            rejectBtn.Font = new Font("Segoe UI", 10.2F);
            rejectBtn.ForeColor = Color.White;
            rejectBtn.Location = new Point(293, 566);
            rejectBtn.Name = "rejectBtn";
            rejectBtn.Size = new Size(109, 39);
            rejectBtn.TabIndex = 3;
            rejectBtn.Text = "Reject";
            rejectBtn.UseVisualStyleBackColor = false;
            rejectBtn.Click += rejectBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(34, 31);
            label1.Name = "label1";
            label1.Size = new Size(94, 25);
            label1.TabIndex = 4;
            label1.Text = "Employee:";
            // 
            // txtEmployeeName
            // 
            txtEmployeeName.Location = new Point(130, 28);
            txtEmployeeName.Name = "txtEmployeeName";
            txtEmployeeName.Size = new Size(125, 27);
            txtEmployeeName.TabIndex = 5;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(27, 64);
            label2.Name = "label2";
            label2.Size = new Size(102, 25);
            label2.TabIndex = 6;
            label2.Text = "Leave Type:";
            // 
            // cmbLeaveType
            // 
            cmbLeaveType.FormattingEnabled = true;
            cmbLeaveType.Location = new Point(130, 65);
            cmbLeaveType.Name = "cmbLeaveType";
            cmbLeaveType.Size = new Size(151, 28);
            cmbLeaveType.TabIndex = 7;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(332, 30);
            label3.Name = "label3";
            label3.Size = new Size(58, 25);
            label3.TabIndex = 8;
            label3.Text = "From:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.8F);
            label4.Location = new Point(356, 67);
            label4.Name = "label4";
            label4.Size = new Size(34, 25);
            label4.TabIndex = 9;
            label4.Text = "To:";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(397, 26);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(153, 27);
            dtpFrom.TabIndex = 10;
            // 
            // dtpTo
            // 
            dtpTo.Location = new Point(397, 66);
            dtpTo.Name = "dtpTo";
            dtpTo.Size = new Size(153, 27);
            dtpTo.TabIndex = 11;
            // 
            // filterBtn
            // 
            filterBtn.BackColor = Color.DarkBlue;
            filterBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            filterBtn.ForeColor = Color.White;
            filterBtn.Location = new Point(586, 20);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(117, 36);
            filterBtn.TabIndex = 12;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = false;
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