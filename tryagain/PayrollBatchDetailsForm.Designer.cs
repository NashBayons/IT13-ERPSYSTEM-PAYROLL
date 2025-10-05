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
            finalizeselectBtn.Location = new Point(10, 500);
            finalizeselectBtn.Name = "finalizeselectBtn";
            finalizeselectBtn.Size = new Size(180, 35);
            finalizeselectBtn.TabIndex = 1;
            finalizeselectBtn.Text = "Finalize Batch (Paid)";
            finalizeselectBtn.UseVisualStyleBackColor = true;
            finalizeselectBtn.Click += finalizeselectBtn_Click;
            // 
            // editselectBtn
            // 
            editselectBtn.Location = new Point(200, 500);
            editselectBtn.Name = "editselectBtn";
            editselectBtn.Size = new Size(180, 35);
            editselectBtn.TabIndex = 2;
            editselectBtn.Text = "Edit Selected Record";
            editselectBtn.UseVisualStyleBackColor = true;
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