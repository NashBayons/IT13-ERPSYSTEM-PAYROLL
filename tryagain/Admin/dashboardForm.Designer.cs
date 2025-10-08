namespace tryagain
{
    partial class dashboardForm
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
            label1 = new Label();
            panel2 = new Panel();
            totalEmployeeLbl = new Label();
            label2 = new Label();
            panel3 = new Panel();
            presentTodayLbl = new Label();
            label3 = new Label();
            panel4 = new Panel();
            absentTodayLbl = new Label();
            label4 = new Label();
            panel5 = new Panel();
            monthPayrollLbl = new Label();
            label5 = new Label();
            panel6 = new Panel();
            progressBar1 = new ProgressBar();
            label6 = new Label();
            panel7 = new Panel();
            AbsentDvg = new DataGridView();
            label7 = new Label();
            panel8 = new Panel();
            PayrollDvg = new DataGridView();
            label8 = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel3.SuspendLayout();
            panel4.SuspendLayout();
            panel5.SuspendLayout();
            panel6.SuspendLayout();
            panel7.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)AbsentDvg).BeginInit();
            panel8.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)PayrollDvg).BeginInit();
            SuspendLayout();
            // 
            // panel1
            // 
            panel1.BackColor = SystemColors.ControlLight;
            panel1.Controls.Add(label1);
            panel1.Location = new Point(161, 21);
            panel1.Name = "panel1";
            panel1.Size = new Size(658, 73);
            panel1.TabIndex = 0;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(164, 21);
            label1.Name = "label1";
            label1.Size = new Size(260, 20);
            label1.TabIndex = 0;
            label1.Text = "ERP PAYROLL & ATTENDANCE - ADMIN";
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ControlLight;
            panel2.Controls.Add(totalEmployeeLbl);
            panel2.Controls.Add(label2);
            panel2.Location = new Point(27, 136);
            panel2.Name = "panel2";
            panel2.Size = new Size(195, 188);
            panel2.TabIndex = 1;
            // 
            // totalEmployeeLbl
            // 
            totalEmployeeLbl.AutoSize = true;
            totalEmployeeLbl.Location = new Point(66, 81);
            totalEmployeeLbl.Name = "totalEmployeeLbl";
            totalEmployeeLbl.Size = new Size(50, 20);
            totalEmployeeLbl.TabIndex = 2;
            totalEmployeeLbl.Text = "label9";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(31, 17);
            label2.Name = "label2";
            label2.Size = new Size(118, 20);
            label2.TabIndex = 1;
            label2.Text = "Total Employees";
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ControlLight;
            panel3.Controls.Add(presentTodayLbl);
            panel3.Controls.Add(label3);
            panel3.Location = new Point(262, 136);
            panel3.Name = "panel3";
            panel3.Size = new Size(195, 188);
            panel3.TabIndex = 2;
            // 
            // presentTodayLbl
            // 
            presentTodayLbl.AutoSize = true;
            presentTodayLbl.Location = new Point(63, 91);
            presentTodayLbl.Name = "presentTodayLbl";
            presentTodayLbl.Size = new Size(58, 20);
            presentTodayLbl.TabIndex = 3;
            presentTodayLbl.Text = "label10";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(39, 17);
            label3.Name = "label3";
            label3.Size = new Size(101, 20);
            label3.TabIndex = 2;
            label3.Text = "Present Today";
            // 
            // panel4
            // 
            panel4.BackColor = SystemColors.ControlLight;
            panel4.Controls.Add(absentTodayLbl);
            panel4.Controls.Add(label4);
            panel4.Location = new Point(502, 136);
            panel4.Name = "panel4";
            panel4.Size = new Size(195, 188);
            panel4.TabIndex = 3;
            // 
            // absentTodayLbl
            // 
            absentTodayLbl.AutoSize = true;
            absentTodayLbl.Location = new Point(51, 91);
            absentTodayLbl.Name = "absentTodayLbl";
            absentTodayLbl.Size = new Size(58, 20);
            absentTodayLbl.TabIndex = 4;
            absentTodayLbl.Text = "label11";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(36, 17);
            label4.Name = "label4";
            label4.Size = new Size(99, 20);
            label4.TabIndex = 3;
            label4.Text = "Absent Today";
            // 
            // panel5
            // 
            panel5.BackColor = SystemColors.ControlLight;
            panel5.Controls.Add(monthPayrollLbl);
            panel5.Controls.Add(label5);
            panel5.Location = new Point(746, 136);
            panel5.Name = "panel5";
            panel5.Size = new Size(195, 188);
            panel5.TabIndex = 4;
            // 
            // monthPayrollLbl
            // 
            monthPayrollLbl.AutoSize = true;
            monthPayrollLbl.Location = new Point(71, 91);
            monthPayrollLbl.Name = "monthPayrollLbl";
            monthPayrollLbl.Size = new Size(58, 20);
            monthPayrollLbl.TabIndex = 5;
            monthPayrollLbl.Text = "label12";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(36, 17);
            label5.Name = "label5";
            label5.Size = new Size(109, 20);
            label5.TabIndex = 4;
            label5.Text = "Month's Payroll";
            // 
            // panel6
            // 
            panel6.Controls.Add(progressBar1);
            panel6.Controls.Add(label6);
            panel6.Location = new Point(161, 345);
            panel6.Name = "panel6";
            panel6.Size = new Size(658, 73);
            panel6.TabIndex = 1;
            // 
            // progressBar1
            // 
            progressBar1.Location = new Point(21, 33);
            progressBar1.Name = "progressBar1";
            progressBar1.Size = new Size(605, 29);
            progressBar1.TabIndex = 5;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(21, 10);
            label6.Name = "label6";
            label6.Size = new Size(136, 20);
            label6.TabIndex = 4;
            label6.Text = "Absent Rate Today:";
            // 
            // panel7
            // 
            panel7.Controls.Add(AbsentDvg);
            panel7.Controls.Add(label7);
            panel7.Location = new Point(219, 445);
            panel7.Name = "panel7";
            panel7.Size = new Size(238, 249);
            panel7.TabIndex = 5;
            // 
            // AbsentDvg
            // 
            AbsentDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            AbsentDvg.Location = new Point(0, 58);
            AbsentDvg.Name = "AbsentDvg";
            AbsentDvg.RowHeadersWidth = 51;
            AbsentDvg.Size = new Size(238, 188);
            AbsentDvg.TabIndex = 7;
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(13, 12);
            label7.Name = "label7";
            label7.Size = new Size(121, 20);
            label7.TabIndex = 6;
            label7.Text = "Top 5 Absentees:";
            // 
            // panel8
            // 
            panel8.Controls.Add(PayrollDvg);
            panel8.Controls.Add(label8);
            panel8.Location = new Point(532, 445);
            panel8.Name = "panel8";
            panel8.Size = new Size(238, 249);
            panel8.TabIndex = 6;
            // 
            // PayrollDvg
            // 
            PayrollDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            PayrollDvg.Location = new Point(0, 58);
            PayrollDvg.Name = "PayrollDvg";
            PayrollDvg.RowHeadersWidth = 51;
            PayrollDvg.Size = new Size(238, 188);
            PayrollDvg.TabIndex = 8;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(21, 12);
            label8.Name = "label8";
            label8.Size = new Size(181, 20);
            label8.TabIndex = 7;
            label8.Text = "Upcoming Payroll Batches";
            // 
            // dashboardForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 706);
            Controls.Add(panel8);
            Controls.Add(panel7);
            Controls.Add(panel6);
            Controls.Add(panel5);
            Controls.Add(panel4);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "dashboardForm";
            Text = "dashboardForm";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel5.ResumeLayout(false);
            panel5.PerformLayout();
            panel6.ResumeLayout(false);
            panel6.PerformLayout();
            panel7.ResumeLayout(false);
            panel7.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)AbsentDvg).EndInit();
            panel8.ResumeLayout(false);
            panel8.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)PayrollDvg).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel panel1;
        private Label label1;
        private Panel panel2;
        private Label label2;
        private Panel panel3;
        private Label label3;
        private Panel panel4;
        private Label label4;
        private Panel panel5;
        private Label label5;
        private Panel panel6;
        private ProgressBar progressBar1;
        private Label label6;
        private Panel panel7;
        private Label label7;
        private Panel panel8;
        private Label label8;
        private Label totalEmployeeLbl;
        private Label presentTodayLbl;
        private Label absentTodayLbl;
        private Label monthPayrollLbl;
        private DataGridView AbsentDvg;
        private DataGridView PayrollDvg;
    }
}