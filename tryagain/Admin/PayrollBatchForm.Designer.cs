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
            label1.Location = new Point(10, 14);
            label1.Name = "label1";
            label1.Size = new Size(115, 20);
            label1.TabIndex = 0;
            label1.Text = "Pay Period Start:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(282, 14);
            label2.Name = "label2";
            label2.Size = new Size(37, 20);
            label2.TabIndex = 1;
            label2.Text = "End:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(480, 14);
            label3.Name = "label3";
            label3.Size = new Size(104, 20);
            label3.TabIndex = 2;
            label3.Text = "Payment Date:";
            // 
            // dtpPeriodFrom
            // 
            dtpPeriodFrom.Format = DateTimePickerFormat.Short;
            dtpPeriodFrom.Location = new Point(130, 10);
            dtpPeriodFrom.Name = "dtpPeriodFrom";
            dtpPeriodFrom.Size = new Size(150, 27);
            dtpPeriodFrom.TabIndex = 3;
            // 
            // dtpPeriodTo
            // 
            dtpPeriodTo.Format = DateTimePickerFormat.Short;
            dtpPeriodTo.Location = new Point(325, 10);
            dtpPeriodTo.Name = "dtpPeriodTo";
            dtpPeriodTo.Size = new Size(150, 27);
            dtpPeriodTo.TabIndex = 4;
            // 
            // dtpPayment
            // 
            dtpPayment.Format = DateTimePickerFormat.Short;
            dtpPayment.Location = new Point(590, 10);
            dtpPayment.Name = "dtpPayment";
            dtpPayment.Size = new Size(150, 27);
            dtpPayment.TabIndex = 5;
            // 
            // gendraftBtn
            // 
            gendraftBtn.BackColor = Color.FromArgb(0, 192, 0);
            gendraftBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            gendraftBtn.ForeColor = Color.White;
            gendraftBtn.Location = new Point(746, 7);
            gendraftBtn.Name = "gendraftBtn";
            gendraftBtn.Size = new Size(130, 36);
            gendraftBtn.TabIndex = 6;
            gendraftBtn.Text = "Generate Draft";
            gendraftBtn.UseVisualStyleBackColor = false;
            gendraftBtn.Click += gendraftBtn_Click;
            // 
            // refreshBtn
            // 
            refreshBtn.BackColor = Color.RoyalBlue;
            refreshBtn.ForeColor = Color.White;
            refreshBtn.Location = new Point(882, 6);
            refreshBtn.Name = "refreshBtn";
            refreshBtn.Size = new Size(84, 36);
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
            dgvPayrollBatch.Location = new Point(10, 50);
            dgvPayrollBatch.MultiSelect = false;
            dgvPayrollBatch.Name = "dgvPayrollBatch";
            dgvPayrollBatch.ReadOnly = true;
            dgvPayrollBatch.RowHeadersVisible = false;
            dgvPayrollBatch.RowHeadersWidth = 51;
            dgvPayrollBatch.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayrollBatch.Size = new Size(960, 490);
            dgvPayrollBatch.TabIndex = 8;
            dgvPayrollBatch.DoubleClick += viewbatchBtn_Click;
            // 
            // viewbatchBtn
            // 
            viewbatchBtn.BackColor = Color.DarkBlue;
            viewbatchBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            viewbatchBtn.ForeColor = Color.White;
            viewbatchBtn.Location = new Point(10, 546);
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
            ClientSize = new Size(1000, 600);
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