namespace tryagain
{
    partial class SalaryMangementForm
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
            dgvSalaryGrid = new DataGridView();
            addSalaryBtn = new Button();
            editSalaryBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvSalaryGrid).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(321, 46);
            label1.TabIndex = 0;
            label1.Text = "Salary Mangement";
            // 
            // dgvSalaryGrid
            // 
            dgvSalaryGrid.AllowUserToAddRows = false;
            dgvSalaryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvSalaryGrid.BackgroundColor = SystemColors.Control;
            dgvSalaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvSalaryGrid.Location = new Point(20, 80);
            dgvSalaryGrid.Name = "dgvSalaryGrid";
            dgvSalaryGrid.ReadOnly = true;
            dgvSalaryGrid.RowHeadersWidth = 51;
            dgvSalaryGrid.Size = new Size(900, 400);
            dgvSalaryGrid.TabIndex = 1;
            // 
            // addSalaryBtn
            // 
            addSalaryBtn.BackColor = Color.RoyalBlue;
            addSalaryBtn.FlatStyle = FlatStyle.Flat;
            addSalaryBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            addSalaryBtn.ForeColor = Color.White;
            addSalaryBtn.Location = new Point(20, 500);
            addSalaryBtn.Name = "addSalaryBtn";
            addSalaryBtn.Size = new Size(120, 40);
            addSalaryBtn.TabIndex = 2;
            addSalaryBtn.Text = "button1";
            addSalaryBtn.UseVisualStyleBackColor = false;
            addSalaryBtn.Click += addSalaryBtn_Click;
            // 
            // editSalaryBtn
            // 
            editSalaryBtn.BackColor = Color.RoyalBlue;
            editSalaryBtn.FlatStyle = FlatStyle.Flat;
            editSalaryBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold);
            editSalaryBtn.ForeColor = Color.White;
            editSalaryBtn.Location = new Point(160, 500);
            editSalaryBtn.Name = "editSalaryBtn";
            editSalaryBtn.Size = new Size(89, 40);
            editSalaryBtn.TabIndex = 3;
            editSalaryBtn.Text = "button2";
            editSalaryBtn.UseVisualStyleBackColor = false;
            editSalaryBtn.Click += editSalaryBtn_Click;
            // 
            // SalaryMangementForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 706);
            Controls.Add(editSalaryBtn);
            Controls.Add(addSalaryBtn);
            Controls.Add(dgvSalaryGrid);
            Controls.Add(label1);
            Name = "SalaryMangementForm";
            Text = "SalaryMangementForm";
            ((System.ComponentModel.ISupportInitialize)dgvSalaryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvSalaryGrid;
        private Button addSalaryBtn;
        private Button editSalaryBtn;
    }
}