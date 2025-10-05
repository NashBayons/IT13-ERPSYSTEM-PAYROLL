namespace tryagain
{
    partial class EmployeeForm
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
            dgvEmployee = new DataGridView();
            addEmpBtn = new Button();
            editBtn1 = new Button();
            deleteBtn1 = new Button();
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(175, 46);
            label1.TabIndex = 0;
            label1.Text = "Employee";
            // 
            // dgvEmployee
            // 
            dgvEmployee.AllowUserToAddRows = false;
            dgvEmployee.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvEmployee.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvEmployee.Location = new Point(20, 80);
            dgvEmployee.Name = "dgvEmployee";
            dgvEmployee.ReadOnly = true;
            dgvEmployee.RowHeadersVisible = false;
            dgvEmployee.RowHeadersWidth = 51;
            dgvEmployee.Size = new Size(800, 400);
            dgvEmployee.TabIndex = 1;
            // 
            // addEmpBtn
            // 
            addEmpBtn.BackColor = Color.FromArgb(63, 81, 181);
            addEmpBtn.FlatStyle = FlatStyle.Flat;
            addEmpBtn.ForeColor = Color.White;
            addEmpBtn.Location = new Point(20, 500);
            addEmpBtn.Name = "addEmpBtn";
            addEmpBtn.Size = new Size(120, 40);
            addEmpBtn.TabIndex = 2;
            addEmpBtn.Text = "Add Employee";
            addEmpBtn.UseVisualStyleBackColor = false;
            addEmpBtn.Click += addEmpBtn_Click;
            // 
            // editBtn1
            // 
            editBtn1.BackColor = Color.FromArgb(63, 81, 181);
            editBtn1.FlatStyle = FlatStyle.Flat;
            editBtn1.ForeColor = Color.White;
            editBtn1.Location = new Point(160, 500);
            editBtn1.Name = "editBtn1";
            editBtn1.Size = new Size(80, 40);
            editBtn1.TabIndex = 3;
            editBtn1.Text = "Edit";
            editBtn1.UseVisualStyleBackColor = false;
            editBtn1.Click += editBtn1_Click;
            // 
            // deleteBtn1
            // 
            deleteBtn1.BackColor = Color.FromArgb(244, 67, 54);
            deleteBtn1.FlatStyle = FlatStyle.Flat;
            deleteBtn1.ForeColor = Color.White;
            deleteBtn1.Location = new Point(260, 500);
            deleteBtn1.Name = "deleteBtn1";
            deleteBtn1.Size = new Size(80, 40);
            deleteBtn1.TabIndex = 4;
            deleteBtn1.Text = "Delete";
            deleteBtn1.UseVisualStyleBackColor = false;
            deleteBtn1.Click += deleteBtn1_Click;
            // 
            // EmployeeForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(deleteBtn1);
            Controls.Add(editBtn1);
            Controls.Add(addEmpBtn);
            Controls.Add(dgvEmployee);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "EmployeeForm";
            Text = "EmployeeForm";
            ((System.ComponentModel.ISupportInitialize)dgvEmployee).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private DataGridView dgvEmployee;
        private Button addEmpBtn;
        private Button editBtn1;
        private Button deleteBtn1;
    }
}