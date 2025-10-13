namespace tryagain.Employee
{
    partial class Payroll_System
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
            label5 = new Label();
            panel2 = new Panel();
            paymentdateLabel = new Label();
            label1 = new Label();
            deductionsValueLabel = new Label();
            bonusesValueLabel = new Label();
            basepayValueLabel = new Label();
            grossSalaryValueLabel = new Label();
            label8 = new Label();
            label7 = new Label();
            MonthYearLabel = new Label();
            panel4 = new Panel();
            netpayValueLabel = new Label();
            label16 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            payrollDvg = new DataGridView();
            label2 = new Label();
            filterBtn = new Button();
            filterComboCmb = new ComboBox();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)payrollDvg).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16F, FontStyle.Bold);
            label5.Location = new Point(12, 33);
            label5.Name = "label5";
            label5.Size = new Size(235, 32);
            label5.TabIndex = 20;
            label5.Text = "Payroll Overview";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(paymentdateLabel);
            panel2.Controls.Add(label1);
            panel2.Controls.Add(deductionsValueLabel);
            panel2.Controls.Add(bonusesValueLabel);
            panel2.Controls.Add(basepayValueLabel);
            panel2.Controls.Add(grossSalaryValueLabel);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(MonthYearLabel);
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(12, 87);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(990, 75);
            panel2.TabIndex = 29;
            // 
            // paymentdateLabel
            // 
            paymentdateLabel.AutoSize = true;
            paymentdateLabel.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            paymentdateLabel.Location = new Point(218, 42);
            paymentdateLabel.Name = "paymentdateLabel";
            paymentdateLabel.Size = new Size(103, 19);
            paymentdateLabel.TabIndex = 40;
            paymentdateLabel.Text = "(Month Year)";
            paymentdateLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(18, 42);
            label1.Name = "label1";
            label1.Size = new Size(112, 19);
            label1.TabIndex = 39;
            label1.Text = "Payment Date";
            label1.TextAlign = ContentAlignment.BottomCenter;
            // 
            // deductionsValueLabel
            // 
            deductionsValueLabel.AutoSize = true;
            deductionsValueLabel.ForeColor = Color.Red;
            deductionsValueLabel.Location = new Point(755, 71);
            deductionsValueLabel.Name = "deductionsValueLabel";
            deductionsValueLabel.Size = new Size(84, 20);
            deductionsValueLabel.TabIndex = 38;
            deductionsValueLabel.Text = "Deductions";
            // 
            // bonusesValueLabel
            // 
            bonusesValueLabel.AutoSize = true;
            bonusesValueLabel.ForeColor = Color.Green;
            bonusesValueLabel.Location = new Point(407, 71);
            bonusesValueLabel.Name = "bonusesValueLabel";
            bonusesValueLabel.Size = new Size(63, 20);
            bonusesValueLabel.TabIndex = 37;
            bonusesValueLabel.Text = "bonuses";
            // 
            // basepayValueLabel
            // 
            basepayValueLabel.AutoSize = true;
            basepayValueLabel.ForeColor = Color.Green;
            basepayValueLabel.Location = new Point(121, 120);
            basepayValueLabel.Name = "basepayValueLabel";
            basepayValueLabel.Size = new Size(64, 20);
            basepayValueLabel.TabIndex = 36;
            basepayValueLabel.Text = "basepay";
            // 
            // grossSalaryValueLabel
            // 
            grossSalaryValueLabel.AutoSize = true;
            grossSalaryValueLabel.ForeColor = Color.Green;
            grossSalaryValueLabel.Location = new Point(120, 71);
            grossSalaryValueLabel.Name = "grossSalaryValueLabel";
            grossSalaryValueLabel.Size = new Size(65, 20);
            grossSalaryValueLabel.TabIndex = 35;
            grossSalaryValueLabel.Text = "Earnings";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.ForeColor = Color.Green;
            label8.Location = new Point(306, 71);
            label8.Name = "label8";
            label8.Size = new Size(63, 20);
            label8.TabIndex = 34;
            label8.Text = "Bonuses";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.ForeColor = Color.Green;
            label7.Location = new Point(18, 120);
            label7.Name = "label7";
            label7.Size = new Size(66, 20);
            label7.TabIndex = 33;
            label7.Text = "Base Pay";
            // 
            // MonthYearLabel
            // 
            MonthYearLabel.AutoSize = true;
            MonthYearLabel.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            MonthYearLabel.Location = new Point(218, 14);
            MonthYearLabel.Name = "MonthYearLabel";
            MonthYearLabel.Size = new Size(103, 19);
            MonthYearLabel.TabIndex = 32;
            MonthYearLabel.Text = "(Month Year)";
            MonthYearLabel.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(netpayValueLabel);
            panel4.Controls.Add(label16);
            panel4.Location = new Point(675, 120);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(303, 52);
            panel4.TabIndex = 31;
            // 
            // netpayValueLabel
            // 
            netpayValueLabel.AutoSize = true;
            netpayValueLabel.Font = new Font("Segoe UI", 10.25F);
            netpayValueLabel.ForeColor = Color.Green;
            netpayValueLabel.Location = new Point(180, 13);
            netpayValueLabel.Name = "netpayValueLabel";
            netpayValueLabel.Size = new Size(0, 25);
            netpayValueLabel.TabIndex = 21;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.25F);
            label16.ForeColor = Color.Green;
            label16.Location = new Point(8, 13);
            label16.Name = "label16";
            label16.Size = new Size(76, 25);
            label16.TabIndex = 20;
            label16.Text = "Net Pay:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(665, 71);
            label4.Name = "label4";
            label4.Size = new Size(84, 20);
            label4.TabIndex = 17;
            label4.Text = "Deductions";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.ForeColor = Color.Green;
            label3.Location = new Point(18, 71);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 16;
            label3.Text = "Gross Salary";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 14);
            label6.Name = "label6";
            label6.Size = new Size(194, 19);
            label6.TabIndex = 15;
            label6.Text = "Current Payroll Summary";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(payrollDvg);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(12, 231);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(990, 400);
            panel3.TabIndex = 30;
            // 
            // payrollDvg
            // 
            payrollDvg.BackgroundColor = SystemColors.Control;
            payrollDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            payrollDvg.Location = new Point(0, 61);
            payrollDvg.Margin = new Padding(3, 4, 3, 4);
            payrollDvg.Name = "payrollDvg";
            payrollDvg.RowHeadersVisible = false;
            payrollDvg.RowHeadersWidth = 51;
            payrollDvg.Size = new Size(987, 339);
            payrollDvg.TabIndex = 17;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(18, 25);
            label2.Name = "label2";
            label2.Size = new Size(167, 27);
            label2.TabIndex = 16;
            label2.Text = "Payroll History";
            label2.TextAlign = ContentAlignment.BottomCenter;
            // 
            // filterBtn
            // 
            filterBtn.BackColor = Color.CornflowerBlue;
            filterBtn.FlatStyle = FlatStyle.Flat;
            filterBtn.ForeColor = Color.White;
            filterBtn.Location = new Point(187, 181);
            filterBtn.Name = "filterBtn";
            filterBtn.Size = new Size(94, 29);
            filterBtn.TabIndex = 32;
            filterBtn.Text = "Filter";
            filterBtn.UseVisualStyleBackColor = true;
            filterBtn.Click += filterBtn_Click;
            // 
            // filterComboCmb
            // 
            filterComboCmb.FormattingEnabled = true;
            filterComboCmb.Items.AddRange(new object[] { "Batch (Newest First)", "Batch (Oldest First)", "Payment Date (Newest First)", "Payment Date (Oldest First)" });
            filterComboCmb.Location = new Point(12, 181);
            filterComboCmb.Name = "filterComboCmb";
            filterComboCmb.Size = new Size(151, 28);
            filterComboCmb.TabIndex = 33;
            // 
            // Payroll_System
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 706);
            Controls.Add(filterComboCmb);
            Controls.Add(filterBtn);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(label5);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Payroll_System";
            Text = "Payroll_System";
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)payrollDvg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Panel panel2;
        private Panel panel3;
        private Label label6;
        private Label label4;
        private Label label3;
        private Label label2;
        private Panel panel4;
        private Label label16;
        private DataGridView payrollDvg;
        private Label label8;
        private Label label7;
        private Label MonthYearLabel;
        private Label deductionsValueLabel;
        private Label bonusesValueLabel;
        private Label basepayValueLabel;
        private Label grossSalaryValueLabel;
        private Label netpayValueLabel;
        private Label paymentdateLabel;
        private Label label1;
        private Button filterBtn;
        private ComboBox filterComboCmb;
    }
}