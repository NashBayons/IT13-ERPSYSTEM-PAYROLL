namespace tryagain.Admin
{
    partial class SalaryMangementNewInputForm
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
            SaveBtn = new Button();
            CancelBtn = new Button();
            deptCmb = new ComboBox();
            posCmb = new ComboBox();
            SalaryTxt = new NumericUpDown();
            ((System.ComponentModel.ISupportInitialize)SalaryTxt).BeginInit();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(74, 69);
            label1.Name = "label1";
            label1.Size = new Size(89, 20);
            label1.TabIndex = 0;
            label1.Text = "Department";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(74, 108);
            label2.Name = "label2";
            label2.Size = new Size(61, 20);
            label2.TabIndex = 1;
            label2.Text = "Position";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(74, 146);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 2;
            label3.Text = "Gross Salary";
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(97, 202);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 3;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(214, 202);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 29);
            CancelBtn.TabIndex = 4;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // deptCmb
            // 
            deptCmb.FormattingEnabled = true;
            deptCmb.Location = new Point(206, 66);
            deptCmb.Name = "deptCmb";
            deptCmb.Size = new Size(151, 28);
            deptCmb.TabIndex = 5;
            deptCmb.SelectedIndexChanged += deptCmb_SelectedIndexChanged;
            // 
            // posCmb
            // 
            posCmb.FormattingEnabled = true;
            posCmb.Location = new Point(206, 105);
            posCmb.Name = "posCmb";
            posCmb.Size = new Size(151, 28);
            posCmb.TabIndex = 6;
            // 
            // SalaryTxt
            // 
            SalaryTxt.DecimalPlaces = 2;
            SalaryTxt.Increment = new decimal(new int[] { 100, 0, 0, 0 });
            SalaryTxt.Location = new Point(207, 144);
            SalaryTxt.Maximum = new decimal(new int[] { 1000000, 0, 0, 0 });
            SalaryTxt.Name = "SalaryTxt";
            SalaryTxt.Size = new Size(150, 27);
            SalaryTxt.TabIndex = 7;
            // 
            // SalaryMangementNewInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(451, 264);
            Controls.Add(SalaryTxt);
            Controls.Add(posCmb);
            Controls.Add(deptCmb);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "SalaryMangementNewInputForm";
            StartPosition = FormStartPosition.CenterParent;
            Text = "SalaryMangementNewInputForm";
            Load += SalaryMangementNewInputForm_Load_1;
            ((System.ComponentModel.ISupportInitialize)SalaryTxt).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Button SaveBtn;
        private Button CancelBtn;
        private ComboBox deptCmb;
        private ComboBox posCmb;
        private NumericUpDown SalaryTxt;
    }
}