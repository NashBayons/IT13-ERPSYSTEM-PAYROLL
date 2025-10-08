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
            label1.Location = new Point(112, 22);
            label1.Name = "label1";
            label1.Size = new Size(120, 20);
            label1.TabIndex = 0;
            label1.Text = "Account Settings";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(29, 65);
            label2.Name = "label2";
            label2.Size = new Size(75, 20);
            label2.TabIndex = 1;
            label2.Text = "Username";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(29, 100);
            label3.Name = "label3";
            label3.Size = new Size(109, 20);
            label3.TabIndex = 2;
            label3.Text = "New Username";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(29, 172);
            label4.Name = "label4";
            label4.Size = new Size(122, 20);
            label4.TabIndex = 3;
            label4.Text = "Current Password";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(29, 207);
            label5.Name = "label5";
            label5.Size = new Size(104, 20);
            label5.TabIndex = 4;
            label5.Text = "New Password";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(29, 244);
            label6.Name = "label6";
            label6.Size = new Size(161, 20);
            label6.TabIndex = 5;
            label6.Text = "Confirm New Password";
            // 
            // saveBtn
            // 
            saveBtn.Location = new Point(53, 303);
            saveBtn.Name = "saveBtn";
            saveBtn.Size = new Size(94, 29);
            saveBtn.TabIndex = 6;
            saveBtn.Text = "Save";
            saveBtn.UseVisualStyleBackColor = true;
            saveBtn.Click += saveBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(168, 303);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 7;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // curUsernameTxt
            // 
            curUsernameTxt.Location = new Point(229, 62);
            curUsernameTxt.Name = "curUsernameTxt";
            curUsernameTxt.ReadOnly = true;
            curUsernameTxt.Size = new Size(125, 27);
            curUsernameTxt.TabIndex = 8;
            // 
            // newUsernameTxt
            // 
            newUsernameTxt.Location = new Point(229, 97);
            newUsernameTxt.Name = "newUsernameTxt";
            newUsernameTxt.Size = new Size(125, 27);
            newUsernameTxt.TabIndex = 9;
            // 
            // curPasswordTxt
            // 
            curPasswordTxt.Location = new Point(229, 169);
            curPasswordTxt.Name = "curPasswordTxt";
            curPasswordTxt.PasswordChar = '*';
            curPasswordTxt.ReadOnly = true;
            curPasswordTxt.Size = new Size(125, 27);
            curPasswordTxt.TabIndex = 10;
            // 
            // newPasswordTxt
            // 
            newPasswordTxt.Location = new Point(229, 204);
            newPasswordTxt.Name = "newPasswordTxt";
            newPasswordTxt.PasswordChar = '*';
            newPasswordTxt.Size = new Size(125, 27);
            newPasswordTxt.TabIndex = 11;
            // 
            // newConfirmPasswordTxt
            // 
            newConfirmPasswordTxt.Location = new Point(229, 241);
            newConfirmPasswordTxt.Name = "newConfirmPasswordTxt";
            newConfirmPasswordTxt.PasswordChar = '*';
            newConfirmPasswordTxt.Size = new Size(125, 27);
            newConfirmPasswordTxt.TabIndex = 12;
            // 
            // AccountEmployee
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
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