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
            ((System.ComponentModel.ISupportInitialize)reportsDvg).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(341, 28);
            label1.Name = "label1";
            label1.Size = new Size(151, 20);
            label1.TabIndex = 0;
            label1.Text = "REPORTS & ANALYTICS";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(20, 85);
            label2.Name = "label2";
            label2.Size = new Size(46, 20);
            label2.TabIndex = 1;
            label2.Text = "From:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(193, 85);
            label3.Name = "label3";
            label3.Size = new Size(28, 20);
            label3.TabIndex = 2;
            label3.Text = "To:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(365, 85);
            label4.Name = "label4";
            label4.Size = new Size(92, 20);
            label4.TabIndex = 3;
            label4.Text = "Department:";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(20, 118);
            label5.Name = "label5";
            label5.Size = new Size(92, 20);
            label5.TabIndex = 4;
            label5.Text = "Report Type:";
            // 
            // datefromPicker
            // 
            datefromPicker.Format = DateTimePickerFormat.Short;
            datefromPicker.Location = new Point(76, 80);
            datefromPicker.Name = "datefromPicker";
            datefromPicker.Size = new Size(111, 27);
            datefromPicker.TabIndex = 5;
            // 
            // datetoPicker
            // 
            datetoPicker.Format = DateTimePickerFormat.Short;
            datetoPicker.Location = new Point(248, 80);
            datetoPicker.Name = "datetoPicker";
            datetoPicker.Size = new Size(111, 27);
            datetoPicker.TabIndex = 6;
            // 
            // DeparmentCmb
            // 
            DeparmentCmb.FormattingEnabled = true;
            DeparmentCmb.Items.AddRange(new object[] { "All", "HR", "IT", "CS" });
            DeparmentCmb.Location = new Point(463, 82);
            DeparmentCmb.Name = "DeparmentCmb";
            DeparmentCmb.Size = new Size(100, 28);
            DeparmentCmb.TabIndex = 7;
            // 
            // reportTypeCmb
            // 
            reportTypeCmb.FormattingEnabled = true;
            reportTypeCmb.Items.AddRange(new object[] { "Attendance Summary", "Payroll", "Leave" });
            reportTypeCmb.Location = new Point(118, 115);
            reportTypeCmb.Name = "reportTypeCmb";
            reportTypeCmb.Size = new Size(100, 28);
            reportTypeCmb.TabIndex = 8;
            // 
            // generateBtn
            // 
            generateBtn.Location = new Point(28, 163);
            generateBtn.Name = "generateBtn";
            generateBtn.Size = new Size(94, 29);
            generateBtn.TabIndex = 9;
            generateBtn.Text = "Generate Report";
            generateBtn.UseVisualStyleBackColor = true;
            generateBtn.Click += generateBtn_Click;
            // 
            // expCSVBtn
            // 
            expCSVBtn.Location = new Point(149, 163);
            expCSVBtn.Name = "expCSVBtn";
            expCSVBtn.Size = new Size(94, 29);
            expCSVBtn.TabIndex = 10;
            expCSVBtn.Text = "Export CSV";
            expCSVBtn.UseVisualStyleBackColor = true;
            expCSVBtn.Click += expCSVBtn_Click;
            // 
            // expPDFBtn
            // 
            expPDFBtn.Location = new Point(274, 163);
            expPDFBtn.Name = "expPDFBtn";
            expPDFBtn.Size = new Size(94, 29);
            expPDFBtn.TabIndex = 11;
            expPDFBtn.Text = "Export PDF";
            expPDFBtn.UseVisualStyleBackColor = true;
            expPDFBtn.Click += expPDFBtn_Click;
            // 
            // reportsDvg
            // 
            reportsDvg.AllowUserToAddRows = false;
            reportsDvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            reportsDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            reportsDvg.Location = new Point(28, 239);
            reportsDvg.Name = "reportsDvg";
            reportsDvg.RowHeadersVisible = false;
            reportsDvg.RowHeadersWidth = 51;
            reportsDvg.Size = new Size(903, 304);
            reportsDvg.TabIndex = 12;
            // 
            // summaryLbl
            // 
            summaryLbl.AutoSize = true;
            summaryLbl.Location = new Point(28, 561);
            summaryLbl.Name = "summaryLbl";
            summaryLbl.Size = new Size(118, 20);
            summaryLbl.TabIndex = 13;
            summaryLbl.Text = "Total Employees";
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(982, 753);
            Controls.Add(summaryLbl);
            Controls.Add(reportsDvg);
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
            FormBorderStyle = FormBorderStyle.None;
            Name = "ReportsForm";
            Text = "ReportsForm";
            ((System.ComponentModel.ISupportInitialize)reportsDvg).EndInit();
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
    }
}