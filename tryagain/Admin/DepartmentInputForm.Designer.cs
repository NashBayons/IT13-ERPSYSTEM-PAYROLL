namespace tryagain.Admin
{
    partial class DepartmentInputForm
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
            InputLabel = new Label();
            inputTxt = new TextBox();
            SaveBtn = new Button();
            CancelBtn = new Button();
            PositionCmb = new ComboBox();
            SuspendLayout();
            // 
            // InputLabel
            // 
            InputLabel.AutoSize = true;
            InputLabel.Location = new Point(48, 22);
            InputLabel.Name = "InputLabel";
            InputLabel.Size = new Size(50, 20);
            InputLabel.TabIndex = 0;
            InputLabel.Text = "label1";
            // 
            // inputTxt
            // 
            inputTxt.Location = new Point(48, 59);
            inputTxt.Name = "inputTxt";
            inputTxt.Size = new Size(236, 27);
            inputTxt.TabIndex = 1;
            // 
            // SaveBtn
            // 
            SaveBtn.Location = new Point(48, 152);
            SaveBtn.Name = "SaveBtn";
            SaveBtn.Size = new Size(94, 29);
            SaveBtn.TabIndex = 2;
            SaveBtn.Text = "Save";
            SaveBtn.UseVisualStyleBackColor = true;
            SaveBtn.Click += SaveBtn_Click;
            // 
            // CancelBtn
            // 
            CancelBtn.Location = new Point(161, 152);
            CancelBtn.Name = "CancelBtn";
            CancelBtn.Size = new Size(94, 29);
            CancelBtn.TabIndex = 3;
            CancelBtn.Text = "Cancel";
            CancelBtn.UseVisualStyleBackColor = true;
            CancelBtn.Click += CancelBtn_Click;
            // 
            // PositionCmb
            // 
            PositionCmb.FormattingEnabled = true;
            PositionCmb.Location = new Point(48, 101);
            PositionCmb.Name = "PositionCmb";
            PositionCmb.Size = new Size(236, 28);
            PositionCmb.TabIndex = 4;
            PositionCmb.Visible = false;
            // 
            // DepartmentInputForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(335, 228);
            Controls.Add(PositionCmb);
            Controls.Add(CancelBtn);
            Controls.Add(SaveBtn);
            Controls.Add(inputTxt);
            Controls.Add(InputLabel);
            Name = "DepartmentInputForm";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DepartmentInputForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label InputLabel;
        private TextBox inputTxt;
        private Button SaveBtn;
        private Button CancelBtn;
        private ComboBox PositionCmb;
    }
}