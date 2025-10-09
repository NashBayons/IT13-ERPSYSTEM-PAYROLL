namespace tryagain.Employee
{
    partial class AccountEmployee
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
            label6 = new Label();
            saveBtn = new Button();
            cancelBtn = new Button();
            curUsernameTxt = new TextBox();
            newUsernameTxt = new TextBox();
            curPasswordTxt = new TextBox();
            newPasswordTxt = new TextBox();
            newConfirmPasswordTxt = new TextBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 22.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label1.Location = new Point(38, 15);
            label1.Name = "label1";
            label1.Size = new Size(316, 50);
            label1.TabIndex = 0;
            label1.Text = "Account Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 18F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label2.Location = new Point(292, 116);
            label2.Name = "label2";
            label2.Size = new Size(152, 41);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Font = new Font("Segoe UI", 18F);
            label3.Location = new Point(224, 174);
            label3.Name = "label3";
            label3.Size = new Size(220, 41);
            label3.TabIndex = 2;
            label3.Text = "New Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI", 18F);
            label4.Location = new Point(194, 234);
            label4.Name = "label4";
            label4.Size = new Size(250, 41);
            label4.TabIndex = 3;
            label4.Text = "Current Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Segoe UI", 18F);
            label5.Location = new Point(233, 285);
            label5.Name = "label5";
            label5.Size = new Size(211, 41);
            label5.TabIndex = 4;
            label5.Text = "New Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 18F);
            label6.Location = new Point(119, 343);
            label6.Name = "label6";
            label6.Size = new Size(325, 41);
            label6.TabIndex = 5;
            label6.Text = "Confirm New Password";
            // 
            // saveBtn
            // 
            saveBtn.BackColor = Color.FromArgb(0, 192, 0);
            saveBtn.FlatStyle = FlatStyle.Flat;
            saveBtn.Font = new Font("Segoe UI Semibold", 13.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            saveBtn.ForeColor = Color.White;
            saveBtn.Location = new Point(511, 459);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(157, 51);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = false;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.Gray;
            cancelBtn.FlatStyle = FlatStyle.Flat;
            cancelBtn.Font = new Font("Segoe UI", 13.8F, FontStyle.Regular, GraphicsUnit.Point, 0);
            cancelBtn.ForeColor = Color.White;
            cancelBtn.Location = new Point(348, 459);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(138, 51);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // curUsernameTxt
            // 
            curUsernameTxt.Location = new Point(450, 116);
            curUsernameTxt.Multiline = true;
            curUsernameTxt.Name = "curUsernameTxt";
            curUsernameTxt.ReadOnly = true;
            curUsernameTxt.Size = new Size(298, 41);
            curUsernameTxt.TabIndex = 8;
            // 
            // newUsernameTxt
            // 
            newUsernameTxt.Location = new Point(450, 174);
            newUsernameTxt.Multiline = true;
            newUsernameTxt.Name = "newUsernameTxt";
            newUsernameTxt.Size = new Size(298, 41);
            newUsernameTxt.TabIndex = 9;
            // 
            // curPasswordTxt
            // 
            curPasswordTxt.Location = new Point(450, 234);
            curPasswordTxt.Multiline = true;
            curPasswordTxt.Name = "curPasswordTxt";
            curPasswordTxt.PasswordChar = '*';
            curPasswordTxt.ReadOnly = true;
            curPasswordTxt.Size = new Size(298, 41);
            curPasswordTxt.TabIndex = 10;
            // 
            // newPasswordTxt
            // 
            newPasswordTxt.Location = new Point(450, 285);
            newPasswordTxt.Multiline = true;
            newPasswordTxt.Name = "newPasswordTxt";
            newPasswordTxt.PasswordChar = '*';
            newPasswordTxt.Size = new Size(298, 41);
            newPasswordTxt.TabIndex = 11;
            // 
            // newConfirmPasswordTxt
            // 
            newConfirmPasswordTxt.Location = new Point(450, 343);
            newConfirmPasswordTxt.Multiline = true;
            newConfirmPasswordTxt.Name = "newConfirmPasswordTxt";
            newConfirmPasswordTxt.PasswordChar = '*';
            newConfirmPasswordTxt.Size = new Size(298, 41);
            newConfirmPasswordTxt.TabIndex = 12;
            // 
            // AccountEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1032, 753);
            Controls.Add(newConfirmPasswordTxt);
            Controls.Add(newPasswordTxt);
            Controls.Add(curPasswordTxt);
            Controls.Add(newUsernameTxt);
            Controls.Add(curUsernameTxt);
            Controls.Add(cancelBtn);
            Controls.Add(saveBtn);
            Controls.Add(label6);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            FormBorderStyle = FormBorderStyle.None;
            Name = "AccountEmployee";
            Text = "AccountEmployee";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private Label label6;
        private Button saveBtn;
        private Button cancelBtn;
        private TextBox curUsernameTxt;
        private TextBox newUsernameTxt;
        private TextBox curPasswordTxt;
        private TextBox newPasswordTxt;
        private TextBox newConfirmPasswordTxt;
    }
}