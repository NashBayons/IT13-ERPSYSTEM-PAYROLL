namespace tryagain
{
    partial class SalaryDetailsForm
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
            SaveBtn = new Button();
            CancelBtn = new Button();
            empCmb = new ComboBox();
            grossSalTxt = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)grossSalTxt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(20, 20);
            label1.Name = "label1";
            label1.Size = new Size(98, 28);
            label1.TabIndex = 0;
            label1.Text = "Employee";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 12F);
            label2.Location = new Point(20, 70);
            label2.Name = "label2";
            label2.Size = new Size(119, 28);
            label2.TabIndex = 1;
            label2.Text = "Gross Salary";
            // 
            // SaveBtn
            // 
            SaveBtn.BackColor = Color.FromArgb(0, 192, 0);
            SaveBtn.FlatStyle = FlatStyle.Flat;
            SaveBtn.Font = new Font("Segoe UI Semibold", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            SaveBtn.ForeColor = Color.White;
            SaveBtn.Location = new Point(165, 151);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(104, 39);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = false;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.BackColor = Color.Red;
            CancelBtn.FlatStyle = FlatStyle.Flat;
            CancelBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            CancelBtn.ForeColor = Color.White;
            CancelBtn.Location = new Point(55, 151);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(104, 39);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = false;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // empCmb
            // 
            empCmb.FormattingEnabled = true;
            empCmb.Location = new Point(145, 20);
            empCmb.Name = "empCmb";
            empCmb.Size = new Size(151, 28);
            empCmb.TabIndex = 4;
            // 
            // grossSalTxt
            // 
            grossSalTxt.Location = new Point(145, 71);
            grossSalTxt.Name = "grossSalTxt";
            grossSalTxt.Size = new Size(151, 27);
            grossSalTxt.TabIndex = 5;
            // 
            // SalaryDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(352, 211);
            Controls.Add(grossSalTxt);
            Controls.Add(empCmb);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SalaryDetailsForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "SalaryDetailsForm";
            ((System.ComponentModel.ISupportInitialize)grossSalTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Button SaveBtn;
        private Button CancelBtn;
        private ComboBox empCmb;
        private NumericUpDown grossSalTxt;
    }
}