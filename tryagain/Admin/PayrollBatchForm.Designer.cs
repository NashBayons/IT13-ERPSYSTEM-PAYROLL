namespace tryagain
{
    partial class PayrollBatchForm
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
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            dtpPeriodFrom = new DateTimePicker();
            dtpPeriodTo = new DateTimePicker();
            dtpPayment = new DateTimePicker();
            gendraftBtn = new Button();
            refreshBtn = new Button();
            dgvPayrollBatch = new DataGridView();
            viewbatchBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayrollBatch).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(153, 28);
            label1.TabIndex = 0;
            label1.Text = "Pay Period Start:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(114, 47);
            label2.Name = "label2";
            label2.Size = new Size(49, 28);
            label2.TabIndex = 1;
            label2.Text = "End:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 12F);
            label3.Location = new Point(389, 12);
            label3.Name = "label3";
            label3.Size = new Size(137, 28);
            label3.TabIndex = 2;
            label3.Text = "Payment Date:";
            // 
            // dtpPeriodFrom
            // 
            dtpPeriodFrom.Format = DateTimePickerFormat.Short;
            dtpPeriodFrom.Location = new Point(169, 14);
            dtpPeriodFrom.Name = "dtpPeriodFrom";
            dtpPeriodFrom.Size = new Size(150, 27);
            dtpPeriodFrom.TabIndex = 3;
            // 
            // dtpPeriodTo
            // 
            dtpPeriodTo.Format = DateTimePickerFormat.Short;
            dtpPeriodTo.Location = new Point(169, 47);
            dtpPeriodTo.Name = "dtpPeriodTo";
            dtpPeriodTo.Size = new Size(150, 27);
            dtpPeriodTo.TabIndex = 4;
            // 
            // dtpPayment
            // 
            dtpPayment.Format = DateTimePickerFormat.Short;
            dtpPayment.Location = new Point(532, 13);
            dtpPayment.Name = "dtpPayment";
            dtpPayment.Size = new Size(150, 27);
            dtpPayment.TabIndex = 5;
            // 
            // gendraftBtn
            // 
            gendraftBtn.BackColor = Color.FromArgb(0, 192, 0);
            gendraftBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gendraftBtn.ForeColor = Color.White;
            gendraftBtn.Location = new Point(10, 90);
            gendraftBtn.Name = "gendraftBtn";
            gendraftBtn.Size = new Size(153, 36);
            gendraftBtn.TabIndex = 6;
            gendraftBtn.Text = "Generate Draft";
            gendraftBtn.UseVisualStyleBackColor = false;
            gendraftBtn.Click += gendraftBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.RoyalBlue;
            refreshBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            refreshBtn.ForeColor = Color.White;
            refreshBtn.Location = new Point(844, 9);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(126, 37);
            refreshBtn.TabIndex = 7;
            refreshBtn.Text = "Refresh";
            refreshBtn.UseVisualStyleBackColor = false;
            refreshBtn.Click += refreshBtn_Click;
            // 
            // dgvPayrollBatch
            // 
            dgvPayrollBatch.AllowUserToAddRows = false;
            dgvPayrollBatch.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayrollBatch.BackgroundColor = SystemColors.Control;
            dgvPayrollBatch.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayrollBatch.Location = new Point(10, 132);
            dgvPayrollBatch.MultiSelect = false;
            dgvPayrollBatch.Name = "dgvPayrollBatch";
            dgvPayrollBatch.ReadOnly = true;
            dgvPayrollBatch.RowHeadersVisible = false;
            dgvPayrollBatch.RowHeadersWidth = 51;
            dgvPayrollBatch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayrollBatch.Size = new Size(960, 509);
            dgvPayrollBatch.TabIndex = 8;
            dgvPayrollBatch.DoubleClick += viewbatchBtn_Click;
            // 
            // viewbatchBtn
            // 
            viewbatchBtn.BackColor = Color.DarkBlue;
            viewbatchBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewbatchBtn.ForeColor = Color.White;
            viewbatchBtn.Location = new Point(10, 647);
            viewbatchBtn.Name = "viewbatchBtn";
            viewbatchBtn.Size = new Size(168, 44);
            viewbatchBtn.TabIndex = 9;
            viewbatchBtn.Text = "View Selected Batch";
            viewbatchBtn.UseVisualStyleBackColor = false;
            viewbatchBtn.Click += viewbatchBtn_Click;
            // 
            // PayrollBatchForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(viewbatchBtn);
            Controls.Add(dgvPayrollBatch);
            Controls.Add(refreshBtn);
            Controls.Add(gendraftBtn);
            Controls.Add(dtpPayment);
            Controls.Add(dtpPeriodTo);
            Controls.Add(dtpPeriodFrom);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "PayrollBatchForm";
            Text = "PayrollBatchForm";
            Load += PayrollBatchForm_Load;
            ((System.ComponentModel.ISupportInitialize)dgvPayrollBatch).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private DateTimePicker dtpPeriodFrom;
        private DateTimePicker dtpPeriodTo;
        private DateTimePicker dtpPayment;
        private Button gendraftBtn;
        private Button refreshBtn;
        private DataGridView dgvPayrollBatch;
        private Button viewbatchBtn;
    }
}