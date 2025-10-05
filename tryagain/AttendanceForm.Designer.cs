namespace tryagain
{
    partial class AttendanceForm
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
            panel1 = new Panel();
            txtSearch = new TextBox();
            btnFilter11 = new Button();
            label5 = new Label();
            cmbStatus1 = new ComboBox();
            label4 = new Label();
            dtpTo1 = new DateTimePicker();
            label3 = new Label();
            dtpFrom = new DateTimePicker();
            label2 = new Label();
            dgvAttendance1 = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance1).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(337, 46);
            label1.TabIndex = 0;
            label1.Text = "Attendance Records";
            // 
            // panel1
            // 
            panel1.Controls.Add(txtSearch);
            panel1.Controls.Add(btnFilter11);
            panel1.Controls.Add(label5);
            panel1.Controls.Add(cmbStatus1);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(dtpTo1);
            panel1.Controls.Add(label3);
            panel1.Controls.Add(dtpFrom);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(20, 70);
            panel1.Name = "panel1";
            panel1.Size = new Size(950, 60);
            panel1.TabIndex = 1;
            // 
            // txtSearch
            // 
            txtSearch.Location = new Point(628, 16);
            txtSearch.Name = "txtSearch";
            txtSearch.Size = new Size(125, 27);
            txtSearch.TabIndex = 9;
            // 
            // btnFilter11
            // 
            btnFilter11.BackColor = Color.LightSkyBlue;
            btnFilter11.FlatStyle = FlatStyle.Flat;
            btnFilter11.ForeColor = Color.White;
            btnFilter11.Location = new Point(788, 14);
            btnFilter11.Name = "btnFilter11";
            btnFilter11.Size = new Size(80, 30);
            btnFilter11.TabIndex = 8;
            btnFilter11.Text = "Filter";
            btnFilter11.UseVisualStyleBackColor = false;
            btnFilter11.Click += btnFilter11_Click;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(538, 19);
            label5.Name = "label5";
            label5.Size = new Size(75, 20);
            label5.TabIndex = 7;
            label5.Text = "Employee";
            // 
            // cmbStatus1
            // 
            cmbStatus1.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbStatus1.FormattingEnabled = true;
            cmbStatus1.Location = new Point(432, 16);
            cmbStatus1.Name = "cmbStatus1";
            cmbStatus1.Size = new Size(100, 28);
            cmbStatus1.TabIndex = 5;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(376, 19);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 4;
            label4.Text = "Status";
            // 
            // dtpTo1
            // 
            dtpTo1.Location = new Point(250, 14);
            dtpTo1.Name = "dtpTo1";
            dtpTo1.Size = new Size(120, 27);
            dtpTo1.TabIndex = 3;
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(194, 19);
            label3.Name = "label3";
            label3.Size = new Size(25, 20);
            label3.TabIndex = 2;
            label3.Text = "To";
            // 
            // dtpFrom
            // 
            dtpFrom.Location = new Point(68, 14);
            dtpFrom.Name = "dtpFrom";
            dtpFrom.Size = new Size(120, 27);
            dtpFrom.TabIndex = 1;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(12, 19);
            label2.Name = "label2";
            label2.Size = new Size(43, 20);
            label2.TabIndex = 0;
            label2.Text = "From";
            // 
            // dgvAttendance1
            // 
            dgvAttendance1.AllowUserToAddRows = false;
            dgvAttendance1.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgvAttendance1.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            dgvAttendance1.ColumnHeadersVisible = false;
            dgvAttendance1.Location = new Point(20, 150);
            dgvAttendance1.Name = "dgvAttendance1";
            dgvAttendance1.ReadOnly = true;
            dgvAttendance1.RowHeadersVisible = false;
            dgvAttendance1.RowHeadersWidth = 51;
            dgvAttendance1.Size = new Size(950, 400);
            dgvAttendance1.TabIndex = 2;
            // 
            // AttendanceForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(dgvAttendance1);
            Controls.Add(panel1);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AttendanceForm";
            Text = "AttendanceForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)dgvAttendance1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Panel panel1;
        private Label label5;
        private Label label4;
        private Label label3;
        private Label label2;
        private Button btnFilter11;
        private TextBox txtSearch;
    }
}