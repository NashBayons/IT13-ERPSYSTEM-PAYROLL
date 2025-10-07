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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Payroll_System));
            button1 = new Button();
            pictureBox1 = new PictureBox();
            button2 = new Button();
            label5 = new Label();
            pictureBox3 = new PictureBox();
            panel2 = new Panel();
            label16 = new Label();
            panel4 = new Panel();
            label8 = new Label();
            label7 = new Label();
            label4 = new Label();
            label3 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            payrollDvg = new DataGridView();
            label2 = new Label();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).BeginInit();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)payrollDvg).BeginInit();
            SuspendLayout();
            // 
            // button1
            // 
            button1.BackColor = SystemColors.HighlightText;
            button1.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button1.ForeColor = Color.DarkBlue;
            button1.Location = new Point(512, 9);
            button1.Margin = new Padding(3, 4, 3, 4);
            button1.Name = "button1";
            button1.Size = new Size(205, 52);
            button1.TabIndex = 17;
            button1.Text = "     Download Payslip";
            button1.UseVisualStyleBackColor = false;
            // 
            // pictureBox1
            // 
            pictureBox1.BackColor = SystemColors.HighlightText;
            pictureBox1.Image = (Image)resources.GetObject("pictureBox1.Image");
            pictureBox1.Location = new Point(523, 22);
            pictureBox1.Margin = new Padding(3, 4, 3, 4);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(26, 27);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 18;
            pictureBox1.TabStop = false;
            // 
            // button2
            // 
            button2.BackColor = SystemColors.HighlightText;
            button2.Font = new Font("Arial", 9.75F, FontStyle.Regular, GraphicsUnit.Point, 0);
            button2.ForeColor = Color.DarkBlue;
            button2.Location = new Point(732, 9);
            button2.Margin = new Padding(3, 4, 3, 4);
            button2.Name = "button2";
            button2.Size = new Size(205, 52);
            button2.TabIndex = 19;
            button2.Text = "     Download Payslip";
            button2.UseVisualStyleBackColor = false;
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16F, FontStyle.Bold);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(209, 32);
            label5.TabIndex = 20;
            label5.Text = "Payroll History";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // pictureBox3
            // 
            pictureBox3.BackColor = SystemColors.HighlightText;
            pictureBox3.Image = (Image)resources.GetObject("pictureBox3.Image");
            pictureBox3.Location = new Point(748, 22);
            pictureBox3.Margin = new Padding(3, 4, 3, 4);
            pictureBox3.Name = "pictureBox3";
            pictureBox3.Size = new Size(26, 27);
            pictureBox3.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox3.TabIndex = 28;
            pictureBox3.TabStop = false;
            // 
            // panel2
            // 
            panel2.BackColor = SystemColors.ButtonHighlight;
            panel2.Controls.Add(panel4);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label7);
            panel2.Controls.Add(label4);
            panel2.Controls.Add(label3);
            panel2.Controls.Add(label6);
            panel2.Location = new Point(12, 87);
            panel2.Margin = new Padding(3, 4, 3, 4);
            panel2.Name = "panel2";
            panel2.Size = new Size(922, 271);
            panel2.TabIndex = 29;
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.25F);
            label16.ForeColor = Color.Green;
            label16.Location = new Point(8, 13);
            label16.Name = "label16";
            label16.Size = new Size(287, 25);
            label16.TabIndex = 20;
            label16.Text = "Net Pay                                ₱5.000";
            // 
            // panel4
            // 
            panel4.BackColor = Color.White;
            panel4.Controls.Add(label16);
            panel4.Location = new Point(563, 199);
            panel4.Margin = new Padding(3, 4, 3, 4);
            panel4.Name = "panel4";
            panel4.Size = new Size(335, 52);
            panel4.TabIndex = 31;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Font = new Font("Segoe UI", 10.25F);
            label8.ForeColor = Color.Black;
            label8.Location = new Point(500, 72);
            label8.Name = "label8";
            label8.Size = new Size(144, 25);
            label8.TabIndex = 19;
            label8.Text = "Total Deductions";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.25F);
            label7.ForeColor = Color.Black;
            label7.Location = new Point(169, 69);
            label7.Name = "label7";
            label7.Size = new Size(101, 25);
            label7.TabIndex = 18;
            label7.Text = "Salary Total";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.ForeColor = Color.Red;
            label4.Location = new Point(347, 74);
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
            label3.Size = new Size(65, 20);
            label3.TabIndex = 16;
            label3.Text = "Earnings";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 14.25F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label6.Location = new Point(18, 25);
            label6.Name = "label6";
            label6.Size = new Size(365, 27);
            label6.TabIndex = 15;
            label6.Text = "October 2025 Payroll Breakdown";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel3
            // 
            panel3.BackColor = SystemColors.ButtonHighlight;
            panel3.Controls.Add(payrollDvg);
            panel3.Controls.Add(label2);
            panel3.Location = new Point(12, 366);
            panel3.Margin = new Padding(3, 4, 3, 4);
            panel3.Name = "panel3";
            panel3.Size = new Size(925, 361);
            panel3.TabIndex = 30;
            // 
            // payrollDvg
            // 
            payrollDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            payrollDvg.Location = new Point(0, 61);
            payrollDvg.Margin = new Padding(3, 4, 3, 4);
            payrollDvg.Name = "payrollDvg";
            payrollDvg.RowHeadersWidth = 51;
            payrollDvg.Size = new Size(922, 300);
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
            // Payroll_System
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 739);
            Controls.Add(panel3);
            Controls.Add(panel2);
            Controls.Add(pictureBox3);
            Controls.Add(label5);
            Controls.Add(button2);
            Controls.Add(pictureBox1);
            Controls.Add(button1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Payroll_System";
            Text = "Payroll_System";
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ((System.ComponentModel.ISupportInitialize)pictureBox3).EndInit();
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
        private Button button1;
        private PictureBox pictureBox1;
        private Button button2;
        private Label label5;
        private PictureBox pictureBox3;
        private Panel panel2;
        private Panel panel3;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label3;
        private Label label2;
        private Label label8;
        private Panel panel4;
        private Label label16;
        private DataGridView payrollDvg;
    }
}