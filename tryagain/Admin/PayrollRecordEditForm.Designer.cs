namespace tryagain
{
    partial class PayrollRecordEditForm
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
            employeeLbl = new Label();
            grossSalLbl = new Label();
            basepayLbl = new Label();
            deductionLbl = new Label();
            bonusesLbl = new Label();
            dgvDeduct = new DataGridView();
            dgvBonus = new DataGridView();
            deductAddBtn = new Button();
            deductEditBtn = new Button();
            deductDeleteBtn = new Button();
            bonusAddBtn = new Button();
            bonusEditBtn = new Button();
            bonusDeleteBtn = new Button();
            savechangeBtn = new Button();
            cancelChangesBtn = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvDeduct).BeginInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonus).BeginInit();
            SuspendLayout();
            // 
            // employeeLbl
            // 
            employeeLbl.AutoSize = true;
            employeeLbl.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            employeeLbl.Location = new Point(10, 10);
            employeeLbl.Name = "employeeLbl";
            employeeLbl.Size = new Size(59, 23);
            employeeLbl.TabIndex = 0;
            employeeLbl.Text = "label1";
            // 
            // grossSalLbl
            // 
            grossSalLbl.AutoSize = true;
            grossSalLbl.Location = new Point(10, 40);
            grossSalLbl.Name = "grossSalLbl";
            grossSalLbl.Size = new Size(50, 20);
            grossSalLbl.TabIndex = 1;
            grossSalLbl.Text = "label2";
            // 
            // basepayLbl
            // 
            basepayLbl.AutoSize = true;
            basepayLbl.Location = new Point(10, 70);
            basepayLbl.Name = "basepayLbl";
            basepayLbl.Size = new Size(50, 20);
            basepayLbl.TabIndex = 2;
            basepayLbl.Text = "label3";
            // 
            // deductionLbl
            // 
            deductionLbl.AutoSize = true;
            deductionLbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deductionLbl.Location = new Point(10, 97);
            deductionLbl.Name = "deductionLbl";
            deductionLbl.Size = new Size(96, 23);
            deductionLbl.TabIndex = 3;
            deductionLbl.Text = "Deductions";
            // 
            // bonusesLbl
            // 
            bonusesLbl.AutoSize = true;
            bonusesLbl.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bonusesLbl.Location = new Point(400, 97);
            bonusesLbl.Name = "bonusesLbl";
            bonusesLbl.Size = new Size(73, 23);
            bonusesLbl.TabIndex = 4;
            bonusesLbl.Text = "Bonuses";
            // 
            // dgvDeduct
            // 
            dgvDeduct.AllowUserToAddRows = false;
            dgvDeduct.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvDeduct.BackgroundColor = SystemColors.Control;
            dgvDeduct.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvDeduct.Location = new Point(10, 120);
            dgvDeduct.Name = "dgvDeduct";
            dgvDeduct.RowHeadersVisible = false;
            dgvDeduct.RowHeadersWidth = 51;
            dgvDeduct.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvDeduct.Size = new Size(360, 300);
            dgvDeduct.TabIndex = 5;
            // 
            // dgvBonus
            // 
            dgvBonus.AllowUserToAddRows = false;
            dgvBonus.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvBonus.BackgroundColor = SystemColors.Control;
            dgvBonus.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvBonus.Location = new Point(400, 120);
            dgvBonus.Name = "dgvBonus";
            dgvBonus.RowHeadersVisible = false;
            dgvBonus.RowHeadersWidth = 51;
            dgvBonus.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            dgvBonus.Size = new Size(350, 300);
            dgvBonus.TabIndex = 6;
            // 
            // deductAddBtn
            // 
            deductAddBtn.BackColor = Color.RoyalBlue;
            deductAddBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deductAddBtn.ForeColor = Color.White;
            deductAddBtn.Location = new Point(10, 430);
            deductAddBtn.Name = "deductAddBtn";
            deductAddBtn.Size = new Size(83, 35);
            deductAddBtn.TabIndex = 7;
            deductAddBtn.Text = "Deduct";
            deductAddBtn.UseVisualStyleBackColor = false;
            deductAddBtn.Click += deductAddBtn_Click;
            // 
            // deductEditBtn
            // 
            deductEditBtn.BackColor = Color.DarkGoldenrod;
            deductEditBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deductEditBtn.ForeColor = Color.White;
            deductEditBtn.Location = new Point(99, 430);
            deductEditBtn.Name = "deductEditBtn";
            deductEditBtn.Size = new Size(70, 35);
            deductEditBtn.TabIndex = 8;
            deductEditBtn.Text = "Edit";
            deductEditBtn.UseVisualStyleBackColor = false;
            deductEditBtn.Click += deductEditBtn_Click;
            // 
            // deductDeleteBtn
            // 
            deductDeleteBtn.BackColor = Color.Red;
            deductDeleteBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            deductDeleteBtn.ForeColor = Color.White;
            deductDeleteBtn.Location = new Point(175, 430);
            deductDeleteBtn.Name = "deductDeleteBtn";
            deductDeleteBtn.Size = new Size(70, 35);
            deductDeleteBtn.TabIndex = 9;
            deductDeleteBtn.Text = "Delete";
            deductDeleteBtn.UseVisualStyleBackColor = false;
            deductDeleteBtn.Click += deductDeleteBtn_Click;
            // 
            // bonusAddBtn
            // 
            bonusAddBtn.BackColor = Color.RoyalBlue;
            bonusAddBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bonusAddBtn.ForeColor = Color.White;
            bonusAddBtn.Location = new Point(400, 430);
            bonusAddBtn.Name = "bonusAddBtn";
            bonusAddBtn.Size = new Size(83, 35);
            bonusAddBtn.TabIndex = 10;
            bonusAddBtn.Text = "Add";
            bonusAddBtn.UseVisualStyleBackColor = false;
            bonusAddBtn.Click += bonusAddBtn_Click;
            // 
            // bonusEditBtn
            // 
            bonusEditBtn.BackColor = Color.DarkGoldenrod;
            bonusEditBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold);
            bonusEditBtn.ForeColor = Color.White;
            bonusEditBtn.Location = new Point(489, 430);
            bonusEditBtn.Name = "bonusEditBtn";
            bonusEditBtn.Size = new Size(70, 35);
            bonusEditBtn.TabIndex = 11;
            bonusEditBtn.Text = "Edit";
            bonusEditBtn.UseVisualStyleBackColor = false;
            bonusEditBtn.Click += bonusEditBtn_Click;
            // 
            // bonusDeleteBtn
            // 
            bonusDeleteBtn.BackColor = Color.Red;
            bonusDeleteBtn.Font = new Font("Segoe UI Semibold", 9F, FontStyle.Bold, GraphicsUnit.Point, 0);
            bonusDeleteBtn.ForeColor = Color.White;
            bonusDeleteBtn.Location = new Point(565, 430);
            bonusDeleteBtn.Name = "bonusDeleteBtn";
            bonusDeleteBtn.Size = new Size(70, 35);
            bonusDeleteBtn.TabIndex = 12;
            bonusDeleteBtn.Text = "Delete";
            bonusDeleteBtn.UseVisualStyleBackColor = false;
            bonusDeleteBtn.Click += bonusDeleteBtn_Click;
            // 
            // savechangeBtn
            // 
            savechangeBtn.BackColor = Color.FromArgb(0, 192, 0);
            savechangeBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            savechangeBtn.ForeColor = Color.White;
            savechangeBtn.Location = new Point(108, 502);
            savechangeBtn.Name = "savechangeBtn";
            savechangeBtn.Size = new Size(150, 39);
            savechangeBtn.TabIndex = 13;
            savechangeBtn.Text = "Save Changes";
            savechangeBtn.UseVisualStyleBackColor = false;
            savechangeBtn.Click += savechangeBtn_Click;
            // 
            // cancelChangesBtn
            // 
            cancelChangesBtn.BackColor = Color.Gray;
            cancelChangesBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            cancelChangesBtn.ForeColor = Color.White;
            cancelChangesBtn.Location = new Point(10, 502);
            cancelChangesBtn.Name = "cancelChangesBtn";
            cancelChangesBtn.Size = new Size(92, 39);
            cancelChangesBtn.TabIndex = 14;
            cancelChangesBtn.Text = "Cancel";
            cancelChangesBtn.UseVisualStyleBackColor = false;
            cancelChangesBtn.Click += cancelChangesBtn_Click;
            // 
            // PayrollRecordEditForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(782, 553);
            Controls.Add(cancelChangesBtn);
            Controls.Add(savechangeBtn);
            Controls.Add(bonusDeleteBtn);
            Controls.Add(bonusEditBtn);
            Controls.Add(bonusAddBtn);
            Controls.Add(deductDeleteBtn);
            Controls.Add(deductEditBtn);
            Controls.Add(deductAddBtn);
            Controls.Add(dgvBonus);
            Controls.Add(dgvDeduct);
            Controls.Add(bonusesLbl);
            Controls.Add(deductionLbl);
            Controls.Add(basepayLbl);
            Controls.Add(grossSalLbl);
            Controls.Add(employeeLbl);
            Name = "PayrollRecordEditForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "Edit Payroll Record";
            ((System.ComponentModel.ISupportInitialize)dgvDeduct).EndInit();
            ((System.ComponentModel.ISupportInitialize)dgvBonus).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label employeeLbl;
        private Label grossSalLbl;
        private Label basepayLbl;
        private Label deductionLbl;
        private Label bonusesLbl;
        private DataGridView dgvDeduct;
        private DataGridView dgvBonus;
        private Button deductAddBtn;
        private Button deductEditBtn;
        private Button deductDeleteBtn;
        private Button bonusAddBtn;
        private Button bonusEditBtn;
        private Button bonusDeleteBtn;
        private Button savechangeBtn;
        private Button cancelChangesBtn;
    }
}