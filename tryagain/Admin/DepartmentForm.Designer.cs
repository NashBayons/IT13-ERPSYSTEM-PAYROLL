namespace tryagain.Admin
{
    partial class DepartmentForm
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
            panel1 = new Panel();
            DepartmentGrid = new DataGridView();
            DeptDelBtn = new Button();
            DeptEditBtn = new Button();
            DeptAddBtn = new Button();
            label1 = new Label();
            panel2 = new Panel();
            PositionGrid = new DataGridView();
            PosDelBtn = new Button();
            PosEditBtn = new Button();
            PosAddBtn = new Button();
            label2 = new Label();
            PositionFilterCmb = new ComboBox();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)DepartmentGrid).BeginInit();
            panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PositionGrid).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.Controls.Add(DepartmentGrid);
            panel1.Controls.Add(DeptDelBtn);
            panel1.Controls.Add(DeptEditBtn);
            panel1.Controls.Add(DeptAddBtn);
            panel1.Controls.Add(label1);
            panel1.Location = new Point(12, 12);
            panel1.Name = "panel1";
            panel1.Size = new Size(470, 729);
            panel1.TabIndex = 0;
            // 
            // DepartmentGrid
            // 
            DepartmentGrid.AllowUserToAddRows = false;
            DepartmentGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            DepartmentGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            DepartmentGrid.Location = new Point(14, 79);
            DepartmentGrid.MultiSelect = false;
            DepartmentGrid.Name = "DepartmentGrid";
            DepartmentGrid.RowHeadersVisible = false;
            DepartmentGrid.RowHeadersWidth = 51;
            DepartmentGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            DepartmentGrid.Size = new Size(429, 385);
            DepartmentGrid.TabIndex = 4;
            // 
            // DeptDelBtn
            // 
            DeptDelBtn.Location = new Point(214, 481);
            DeptDelBtn.Name = "DeptDelBtn";
            DeptDelBtn.Size = new Size(94, 29);
            DeptDelBtn.TabIndex = 3;
            DeptDelBtn.Text = "Delete";
            DeptDelBtn.UseVisualStyleBackColor = true;
            DeptDelBtn.Click += DeptDelBtn_Click;
            // 
            // DeptEditBtn
            // 
            DeptEditBtn.Location = new Point(114, 481);
            DeptEditBtn.Name = "DeptEditBtn";
            DeptEditBtn.Size = new Size(94, 29);
            DeptEditBtn.TabIndex = 2;
            DeptEditBtn.Text = "Edit";
            DeptEditBtn.UseVisualStyleBackColor = true;
            DeptEditBtn.Click += DeptEditBtn_Click;
            // 
            // DeptAddBtn
            // 
            DeptAddBtn.Location = new Point(14, 481);
            DeptAddBtn.Name = "DeptAddBtn";
            DeptAddBtn.Size = new Size(94, 29);
            DeptAddBtn.TabIndex = 1;
            DeptAddBtn.Text = "Add";
            DeptAddBtn.UseVisualStyleBackColor = true;
            DeptAddBtn.Click += DeptAddBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 13);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Department";
            // 
            // panel2
            // 
            panel2.Controls.Add(PositionFilterCmb);
            panel2.Controls.Add(PositionGrid);
            panel2.Controls.Add(PosDelBtn);
            panel2.Controls.Add(PosEditBtn);
            panel2.Controls.Add(PosAddBtn);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(500, 12);
            panel2.Name = "panel2";
            panel2.Size = new Size(470, 729);
            panel2.TabIndex = 1;
            // 
            // PositionGrid
            // 
            PositionGrid.AllowUserToAddRows = false;
            PositionGrid.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            PositionGrid.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PositionGrid.Location = new Point(21, 79);
            PositionGrid.MultiSelect = false;
            PositionGrid.Name = "PositionGrid";
            PositionGrid.RowHeadersVisible = false;
            PositionGrid.RowHeadersWidth = 51;
            PositionGrid.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            PositionGrid.Size = new Size(429, 385);
            PositionGrid.TabIndex = 5;
            // 
            // PosDelBtn
            // 
            PosDelBtn.Location = new Point(221, 481);
            PosDelBtn.Name = "PosDelBtn";
            PosDelBtn.Size = new Size(94, 29);
            PosDelBtn.TabIndex = 6;
            PosDelBtn.Text = "Delete";
            PosDelBtn.UseVisualStyleBackColor = true;
            PosDelBtn.Click += PosDelBtn_Click;
            // 
            // PosEditBtn
            // 
            PosEditBtn.Location = new Point(121, 481);
            PosEditBtn.Name = "PosEditBtn";
            PosEditBtn.Size = new Size(94, 29);
            PosEditBtn.TabIndex = 5;
            PosEditBtn.Text = "Edit";
            PosEditBtn.UseVisualStyleBackColor = true;
            PosEditBtn.Click += PosEditBtn_Click;
            // 
            // PosAddBtn
            // 
            PosAddBtn.Location = new Point(21, 481);
            PosAddBtn.Name = "PosAddBtn";
            PosAddBtn.Size = new Size(94, 29);
            PosAddBtn.TabIndex = 4;
            PosAddBtn.Text = "Add";
            PosAddBtn.UseVisualStyleBackColor = true;
            PosAddBtn.Click += PosAddBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(21, 13);
            label2.Name = "label2";
            label2.Size = new Size(154, 20);
            label2.TabIndex = 0;
            label2.Text = "Department's Position";
            // 
            // PositionFilterCmb
            // 
            PositionFilterCmb.FormattingEnabled = true;
            PositionFilterCmb.Location = new Point(21, 45);
            PositionFilterCmb.Name = "PositionFilterCmb";
            PositionFilterCmb.Size = new Size(151, 28);
            PositionFilterCmb.TabIndex = 7;
            PositionFilterCmb.SelectedIndexChanged += PositionFilterCmb_SelectedIndexChanged;
            // 
            // DepartmentForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DepartmentForm";
            Text = "DepartmentForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)DepartmentGrid).EndInit();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PositionGrid).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private DataGridView DepartmentGrid;
        private Button DeptDelBtn;
        private Button DeptEditBtn;
        private Button DeptAddBtn;
        private Button PosDelBtn;
        private Button PosEditBtn;
        private Button PosAddBtn;
        private DataGridView PositionGrid;
        private ComboBox PositionFilterCmb;
    }
}