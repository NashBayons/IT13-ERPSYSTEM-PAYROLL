namespace tryagain
{
    partial class PayrollBatchDetailsForm
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
            dgvPayrollRecords = new DataGridView();
            finalizeselectBtn = new Button();
            editselectBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvPayrollRecords).BeginInit();
            SuspendLayout();
            // 
            // dgvPayrollRecords
            // 
            dgvPayrollRecords.AllowUserToAddRows = false;
            dgvPayrollRecords.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvPayrollRecords.BackgroundColor = SystemColors.Control;
            dgvPayrollRecords.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvPayrollRecords.Location = new Point(10, 10);
            dgvPayrollRecords.MultiSelect = false;
            dgvPayrollRecords.Name = "dgvPayrollRecords";
            dgvPayrollRecords.ReadOnly = true;
            dgvPayrollRecords.RowHeadersVisible = false;
            dgvPayrollRecords.RowHeadersWidth = 51;
            dgvPayrollRecords.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvPayrollRecords.Size = new Size(960, 480);
            dgvPayrollRecords.TabIndex = 0;
            dgvPayrollRecords.DoubleClick += editselectBtn_Click;
            // 
            // finalizeselectBtn
            // 
            finalizeselectBtn.BackColor = Color.FromArgb(0, 192, 0);
            finalizeselectBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            finalizeselectBtn.ForeColor = Color.White;
            finalizeselectBtn.Location = new Point(10, 500);
            finalizeselectBtn.Name = "finalizeselectBtn";
            finalizeselectBtn.Size = new Size(184, 44);
            finalizeselectBtn.TabIndex = 1;
            finalizeselectBtn.Text = "Finalize Batch (Paid)";
            finalizeselectBtn.UseVisualStyleBackColor = false;
            finalizeselectBtn.Click += finalizeselectBtn_Click;
            // 
            // editselectBtn
            // 
            editselectBtn.BackColor = Color.DarkGoldenrod;
            editselectBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            editselectBtn.ForeColor = Color.White;
            editselectBtn.Location = new Point(200, 500);
            editselectBtn.Name = "editselectBtn";
            editselectBtn.Size = new Size(186, 44);
            editselectBtn.TabIndex = 2;
            editselectBtn.Text = "Edit Selected Record";
            editselectBtn.UseVisualStyleBackColor = false;
            editselectBtn.Click += editselectBtn_Click;
            // 
            // PayrollBatchDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1000, 600);
            Controls.Add(editselectBtn);
            Controls.Add(finalizeselectBtn);
            Controls.Add(dgvPayrollRecords);
            Name = "PayrollBatchDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "PayrollBatchDetailsForm";
            ((System.ComponentModel.ISupportInitialize)dgvPayrollRecords).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private DataGridView dgvPayrollRecords;
        private Button finalizeselectBtn;
        private Button editselectBtn;
    }
}