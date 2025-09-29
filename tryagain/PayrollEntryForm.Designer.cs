namespace tryagain
{
    partial class PayrollEntryForm
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
            employeeCmb = new ComboBox();
            grossSalaryTxt = new TextBox();
            deductionsTxt = new TextBox();
            bonusTxt = new TextBox();
            statusCmb = new ComboBox();
            datePicker = new DateTimePicker();
            submitBtn = new Button();
            cancelBtn = new Button();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            label5 = new Label();
            label6 = new Label();
            SuspendLayout();
            // 
            // employeeCmb
            // 
            employeeCmb.FormattingEnabled = true;
            employeeCmb.Location = new Point(182, 59);
            employeeCmb.Name = "employeeCmb";
            employeeCmb.Size = new Size(151, 28);
            employeeCmb.TabIndex = 0;
            // 
            // grossSalaryTxt
            // 
            grossSalaryTxt.Location = new Point(182, 110);
            grossSalaryTxt.Name = "grossSalaryTxt";
            grossSalaryTxt.Size = new Size(125, 27);
            grossSalaryTxt.TabIndex = 1;
            // 
            // deductionsTxt
            // 
            deductionsTxt.Location = new Point(182, 154);
            deductionsTxt.Name = "deductionsTxt";
            deductionsTxt.Size = new Size(125, 27);
            deductionsTxt.TabIndex = 2;
            // 
            // bonusTxt
            // 
            bonusTxt.Location = new Point(182, 200);
            bonusTxt.Name = "bonusTxt";
            bonusTxt.Size = new Size(125, 27);
            bonusTxt.TabIndex = 3;
            // 
            // statusCmb
            // 
            statusCmb.FormattingEnabled = true;
            statusCmb.Location = new Point(182, 248);
            statusCmb.Name = "statusCmb";
            statusCmb.Size = new Size(151, 28);
            statusCmb.TabIndex = 4;
            // 
            // datePicker
            // 
            datePicker.Location = new Point(182, 299);
            datePicker.Name = "datePicker";
            datePicker.Size = new Size(250, 27);
            datePicker.TabIndex = 5;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(141, 357);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(94, 29);
            submitBtn.TabIndex = 6;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += submitBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(258, 357);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(67, 67);
            label1.Name = "label1";
            label1.Size = new Size(75, 20);
            label1.TabIndex = 8;
            label1.Text = "Employee";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(67, 113);
            label2.Name = "label2";
            label2.Size = new Size(89, 20);
            label2.TabIndex = 9;
            label2.Text = "Gross Salary";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(67, 157);
            label3.Name = "label3";
            label3.Size = new Size(84, 20);
            label3.TabIndex = 10;
            label3.Text = "Deductions";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(67, 203);
            label4.Name = "label4";
            label4.Size = new Size(49, 20);
            label4.TabIndex = 11;
            label4.Text = "Bonus";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(67, 251);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 12;
            label5.Text = "Status";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(67, 304);
            label6.Name = "label6";
            label6.Size = new Size(41, 20);
            label6.TabIndex = 13;
            label6.Text = "Date";
            // 
            // PayrollEntryForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(476, 450);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(cancelBtn);
            Controls.Add(submitBtn);
            Controls.Add(datePicker);
            Controls.Add(statusCmb);
            Controls.Add(bonusTxt);
            Controls.Add(deductionsTxt);
            Controls.Add(grossSalaryTxt);
            Controls.Add(employeeCmb);
            Name = "PayrollEntryForm";
            Text = "PayrollEntryForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private ComboBox employeeCmb;
        private TextBox grossSalaryTxt;
        private TextBox deductionsTxt;
        private TextBox bonusTxt;
        private ComboBox statusCmb;
        private DateTimePicker datePicker;
        private Button submitBtn;
        private Button cancelBtn;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
    }
}