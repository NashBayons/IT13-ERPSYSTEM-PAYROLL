namespace tryagain
{
    partial class ReportsForm
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
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            datefromPicker = new DateTimePicker();
            datetoPicker = new DateTimePicker();
            DeparmentCmb = new ComboBox();
            reportTypeCmb = new ComboBox();
            generateBtn = new Button();
            expCSVBtn = new Button();
            expPDFBtn = new Button();
            reportsDvg = new DataGridView();
            summaryLbl = new Label();
            panel1 = new Panel();
            ((System.ComponentModel.ISupportInitialize)reportsDvg).BeginInit();
            panel1.SuspendLayout();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 18);
            label1.Name = "label1";
            label1.Size = new Size(401, 50);
            label1.TabIndex = 0;
            label1.Text = "REPORTS & ANALYTICS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(28, 84);
            label2.Name = "label2";
            label2.Size = new Size(53, 23);
            label2.TabIndex = 1;
            label2.Text = "From:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label3.Location = new Point(50, 118);
            label3.Name = "label3";
            label3.Size = new Size(31, 23);
            label3.TabIndex = 2;
            label3.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label4.Location = new Point(267, 84);
            label4.Name = "label4";
            label4.Size = new Size(106, 23);
            label4.TabIndex = 3;
            label4.Text = "Department:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label5.Location = new Point(268, 117);
            label5.Name = "label5";
            label5.Size = new Size(105, 23);
            label5.TabIndex = 4;
            label5.Text = "Report Type:";
            // 
            // datefromPicker
            // 
            datefromPicker.Format = DateTimePickerFormat.Short;
            datefromPicker.Location = new Point(97, 83);
            datefromPicker.Name = "datefromPicker";
            datefromPicker.Size = new Size(127, 27);
            datefromPicker.TabIndex = 5;
            // 
            // datetoPicker
            // 
            datetoPicker.Format = DateTimePickerFormat.Short;
            datetoPicker.Location = new Point(97, 116);
            datetoPicker.Name = "datetoPicker";
            datetoPicker.Size = new Size(127, 27);
            datetoPicker.TabIndex = 6;
            // 
            // DeparmentCmb
            // 
            DeparmentCmb.FormattingEnabled = true;
            DeparmentCmb.Location = new Point(379, 83);
            DeparmentCmb.Name = "DeparmentCmb";
            DeparmentCmb.Size = new Size(175, 28);
            DeparmentCmb.TabIndex = 7;
            // 
            // reportTypeCmb
            // 
            reportTypeCmb.FormattingEnabled = true;
            reportTypeCmb.Items.AddRange(new object[] { "Attendance Summary", "Payroll", "Leave" });
            reportTypeCmb.Location = new Point(379, 117);
            reportTypeCmb.Name = "reportTypeCmb";
            reportTypeCmb.Size = new Size(175, 28);
            reportTypeCmb.TabIndex = 8;
            // 
            // generateBtn
            // 
            generateBtn.BackColor = Color.RoyalBlue;
            generateBtn.FlatStyle = FlatStyle.Flat;
            generateBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            generateBtn.ForeColor = Color.White;
            generateBtn.Location = new Point(12, 190);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(109, 33);
            generateBtn.TabIndex = 9;
            generateBtn.Text = "Generate Report";
            generateBtn.UseVisualStyleBackColor = false;
            generateBtn.Click += generateBtn_Click;
            // 
            // expCSVBtn
            // 
            expCSVBtn.BackColor = Color.FromArgb(0, 192, 0);
            expCSVBtn.FlatStyle = FlatStyle.Flat;
            expCSVBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expCSVBtn.ForeColor = Color.White;
            expCSVBtn.Location = new Point(127, 190);
            expCSVBtn.Name = "expCSVBtn";
            expCSVBtn.Size = new Size(109, 33);
            expCSVBtn.TabIndex = 10;
            expCSVBtn.Text = "Export CSV";
            expCSVBtn.UseVisualStyleBackColor = false;
            expCSVBtn.Click += expCSVBtn_Click;
            // 
            // expPDFBtn
            // 
            expPDFBtn.BackColor = Color.Red;
            expPDFBtn.FlatStyle = FlatStyle.Flat;
            expPDFBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            expPDFBtn.ForeColor = Color.White;
            expPDFBtn.Location = new Point(242, 190);
            expPDFBtn.Name = "expPDFBtn";
            expPDFBtn.Size = new Size(109, 33);
            expPDFBtn.TabIndex = 11;
            expPDFBtn.Text = "Export PDF";
            expPDFBtn.UseVisualStyleBackColor = false;
            expPDFBtn.Click += expPDFBtn_Click;
            // 
            // reportsDvg
            // 
            reportsDvg.AllowUserToAddRows = false;
            reportsDvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportsDvg.BackgroundColor = SystemColors.Control;
            reportsDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportsDvg.Location = new Point(16, 24);
            reportsDvg.Name = "reportsDvg";
            reportsDvg.RowHeadersVisible = false;
            reportsDvg.RowHeadersWidth = 51;
            reportsDvg.Size = new Size(903, 304);
            reportsDvg.TabIndex = 12;
            // 
            // summaryLbl
            // 
            summaryLbl.AutoSize = true;
            summaryLbl.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            summaryLbl.Location = new Point(20, 594);
            summaryLbl.Name = "summaryLbl";
            summaryLbl.Size = new Size(146, 25);
            summaryLbl.TabIndex = 13;
            summaryLbl.Text = "Total Employees";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(reportsDvg);
            panel1.Location = new Point(12, 229);
            panel1.Name = "panel1";
            panel1.Size = new Size(938, 349);
            panel1.TabIndex = 14;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(summaryLbl);
            Controls.Add(expPDFBtn);
            Controls.Add(expCSVBtn);
            Controls.Add(generateBtn);
            Controls.Add(reportTypeCmb);
            Controls.Add(DeparmentCmb);
            Controls.Add(datetoPicker);
            Controls.Add(datefromPicker);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(panel1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)reportsDvg).EndInit();
            panel1.ResumeLayout(false);
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private DateTimePicker datefromPicker;
        private DateTimePicker datetoPicker;
        private ComboBox DeparmentCmb;
        private ComboBox reportTypeCmb;
        private Button generateBtn;
        private Button expCSVBtn;
        private Button expPDFBtn;
        private DataGridView reportsDvg;
        private Label summaryLbl;
        private Panel panel1;
    }
}