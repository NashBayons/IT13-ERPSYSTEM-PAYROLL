namespace tryagain.Admin
{
    partial class SalaryMangementNewForm
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
            AddSalBtn = new Button();
            EditSalBtn = new Button();
            SalaryGrid = new DataGridView();
            label1 = new Label();
            DeleteSalBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)SalaryGrid).BeginInit();
            SuspendLayout();
            // 
            // AddSalBtn
            // 
            AddSalBtn.BackColor = Color.DarkBlue;
            AddSalBtn.FlatStyle = FlatStyle.Flat;
            AddSalBtn.ForeColor = Color.White;
            AddSalBtn.Location = new Point(45, 130);
            AddSalBtn.Name = "AddSalBtn";
            AddSalBtn.Size = new Size(94, 29);
            AddSalBtn.TabIndex = 6;
            AddSalBtn.Text = "Add Salary";
            AddSalBtn.UseVisualStyleBackColor = false;
            AddSalBtn.Click += AddSalBtn_Click;
            // 
            // EditSalBtn
            // 
            EditSalBtn.BackColor = Color.DarkBlue;
            EditSalBtn.FlatStyle = FlatStyle.Flat;
            EditSalBtn.ForeColor = Color.White;
            EditSalBtn.Location = new Point(155, 130);
            EditSalBtn.Name = "EditSalBtn";
            EditSalBtn.Size = new Size(94, 29);
            EditSalBtn.TabIndex = 7;
            EditSalBtn.Text = "Edit";
            EditSalBtn.UseVisualStyleBackColor = false;
            EditSalBtn.Click += EditSalBtn_Click;
            // 
            // SalaryGrid
            // 
            SalaryGrid.AllowUserToAddRows = false;
            SalaryGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            SalaryGrid.BackgroundColor = SystemColors.Control;
            SalaryGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            SalaryGrid.Location = new Point(47, 178);
            SalaryGrid.Name = "SalaryGrid";
            SalaryGrid.RowHeadersVisible = false;
            SalaryGrid.RowHeadersWidth = 51;
            SalaryGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            SalaryGrid.Size = new Size(602, 371);
            SalaryGrid.TabIndex = 9;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold);
            label1.Location = new Point(47, 23);
            label1.Name = "label1";
            label1.Size = new Size(370, 50);
            label1.TabIndex = 10;
            label1.Text = "Salary Management";
            // 
            // DeleteSalBtn
            // 
            DeleteSalBtn.BackColor = Color.Red;
            DeleteSalBtn.FlatStyle = FlatStyle.Flat;
            DeleteSalBtn.ForeColor = Color.White;
            DeleteSalBtn.Location = new Point(255, 130);
            DeleteSalBtn.Name = "DeleteSalBtn";
            DeleteSalBtn.Size = new Size(94, 29);
            DeleteSalBtn.TabIndex = 8;
            DeleteSalBtn.Text = "Delete";
            DeleteSalBtn.UseVisualStyleBackColor = false;
            DeleteSalBtn.Visible = false;
            DeleteSalBtn.Click += DeleteSalBtn_Click;
            // 
            // SalaryMangementNewForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 706);
            Controls.Add(label1);
            Controls.Add(SalaryGrid);
            Controls.Add(DeleteSalBtn);
            Controls.Add(EditSalBtn);
            Controls.Add(AddSalBtn);
            FormBorderStyle = FormBorderStyle.None;
            Name = "SalaryMangementNewForm";
            Text = "SalaryMangementNewForm";
            ((System.ComponentModel.ISupportInitialize)SalaryGrid).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Button AddSalBtn;
        private Button EditSalBtn;
        private DataGridView SalaryGrid;
        private Label label1;
        private Button DeleteSalBtn;
    }
}