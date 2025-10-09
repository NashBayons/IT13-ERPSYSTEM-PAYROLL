namespace tryagain
{
    partial class EmployeeDetailsForm
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
            FirstNameTB = new TextBox();
            LastNameTB = new TextBox();
            PositionTB = new TextBox();
            StatusCB = new ComboBox();
            DepartmentCB = new ComboBox();
            submitBtn = new Button();
            cancelBtn = new Button();
            label6 = new Label();
            label7 = new Label();
            hiredateDtp = new DateTimePicker();
            label8 = new Label();
            label9 = new Label();
            birthdateDtp = new DateTimePicker();
            emailaddTxt = new TextBox();
            label10 = new Label();
            addressTxt = new TextBox();
            label11 = new Label();
            emergencyContactTxt = new TextBox();
            emergencyRelationshipTxt = new TextBox();
            emergencyNameTxt = new TextBox();
            label12 = new Label();
            label13 = new Label();
            label14 = new Label();
            label15 = new Label();
            empaccountLbl = new Label();
            empPasswordTxt = new TextBox();
            empUsernameTxt = new TextBox();
            empaccountpassLbl = new Label();
            empaccountuserLbl = new Label();
            comboBox1 = new ComboBox();
            SuspendLayout();
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(32, 52);
            label1.Name = "label1";
            label1.Size = new Size(80, 20);
            label1.TabIndex = 0;
            label1.Text = "First Name";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(33, 88);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(23, 123);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 2;
            label3.Text = "Department";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(51, 156);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 3;
            label4.Text = "Position";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(63, 185);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Status";
            // 
            // FirstNameTB
            // 
            FirstNameTB.Location = new Point(118, 49);
            FirstNameTB.Name = "FirstNameTB";
            FirstNameTB.Size = new Size(151, 27);
            FirstNameTB.TabIndex = 5;
            // 
            // LastNameTB
            // 
            LastNameTB.Location = new Point(118, 82);
            LastNameTB.Name = "LastNameTB";
            LastNameTB.Size = new Size(151, 27);
            LastNameTB.TabIndex = 6;
            // 
            // PositionTB
            // 
            PositionTB.Location = new Point(279, 149);
            PositionTB.Name = "PositionTB";
            PositionTB.Size = new Size(151, 27);
            PositionTB.TabIndex = 8;
            PositionTB.Visible = false;
            // 
            // StatusCB
            // 
            StatusCB.FormattingEnabled = true;
            StatusCB.Items.AddRange(new object[] { "Active", "Inactive" });
            StatusCB.Location = new Point(118, 182);
            StatusCB.Name = "StatusCB";
            StatusCB.Size = new Size(151, 28);
            StatusCB.TabIndex = 9;
            // 
            // DepartmentCB
            // 
            DepartmentCB.FormattingEnabled = true;
            DepartmentCB.Items.AddRange(new object[] { "HR", "IT", "CS" });
            DepartmentCB.Location = new Point(118, 115);
            DepartmentCB.Name = "DepartmentCB";
            DepartmentCB.Size = new Size(151, 28);
            DepartmentCB.TabIndex = 10;
            // 
            // submitBtn
            // 
            submitBtn.BackColor = Color.FromArgb(0, 192, 0);
            submitBtn.Font = new Font("Segoe UI", 10.2F, FontStyle.Bold, GraphicsUnit.Point, 0);
            submitBtn.ForeColor = Color.White;
            submitBtn.Location = new Point(342, 479);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(129, 42);
            submitBtn.TabIndex = 11;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = false;
            // 
            // cancelBtn
            // 
            cancelBtn.BackColor = Color.LightGray;
            cancelBtn.Location = new Point(232, 479);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(104, 42);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = false;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(43, 9);
            label6.Name = "label6";
            label6.Size = new Size(202, 25);
            label6.TabIndex = 13;
            label6.Text = "Employee Information";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(43, 276);
            label7.Name = "label7";
            label7.Size = new Size(208, 25);
            label7.TabIndex = 14;
            label7.Text = "Additional Information";
            // 
            // hiredateDtp
            // 
            hiredateDtp.Format = DateTimePickerFormat.Short;
            hiredateDtp.Location = new Point(118, 216);
            hiredateDtp.Name = "hiredateDtp";
            hiredateDtp.Size = new Size(151, 27);
            hiredateDtp.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(39, 216);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 16;
            label8.Text = "Hire Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(18, 347);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 20;
            label9.Text = "Date of Birth";
            // 
            // birthdateDtp
            // 
            birthdateDtp.Format = DateTimePickerFormat.Short;
            birthdateDtp.Location = new Point(118, 342);
            birthdateDtp.Name = "birthdateDtp";
            birthdateDtp.Size = new Size(208, 27);
            birthdateDtp.TabIndex = 19;
            // 
            // emailaddTxt
            // 
            emailaddTxt.Location = new Point(118, 309);
            emailaddTxt.Name = "emailaddTxt";
            emailaddTxt.Size = new Size(208, 27);
            emailaddTxt.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(9, 312);
            label10.Name = "label10";
            label10.Size = new Size(103, 20);
            label10.TabIndex = 17;
            label10.Text = "Email Address";
            // 
            // addressTxt
            // 
            addressTxt.Location = new Point(118, 375);
            addressTxt.Multiline = true;
            addressTxt.Name = "addressTxt";
            addressTxt.Size = new Size(208, 49);
            addressTxt.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(50, 393);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 21;
            label11.Text = "Address";
            // 
            // emergencyContactTxt
            // 
            emergencyContactTxt.Location = new Point(519, 106);
            emergencyContactTxt.Name = "emergencyContactTxt";
            emergencyContactTxt.Size = new Size(151, 27);
            emergencyContactTxt.TabIndex = 28;
            // 
            // emergencyRelationshipTxt
            // 
            emergencyRelationshipTxt.Location = new Point(519, 73);
            emergencyRelationshipTxt.Name = "emergencyRelationshipTxt";
            emergencyRelationshipTxt.Size = new Size(151, 27);
            emergencyRelationshipTxt.TabIndex = 27;
            // 
            // emergencyNameTxt
            // 
            emergencyNameTxt.Location = new Point(519, 40);
            emergencyNameTxt.Name = "emergencyNameTxt";
            emergencyNameTxt.Size = new Size(151, 27);
            emergencyNameTxt.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(426, 109);
            label12.Name = "label12";
            label12.Size = new Size(87, 20);
            label12.TabIndex = 25;
            label12.Text = "Contact No.";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(422, 73);
            label13.Name = "label13";
            label13.Size = new Size(91, 20);
            label13.TabIndex = 24;
            label13.Text = "Relationship";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(409, 43);
            label14.Name = "label14";
            label14.Size = new Size(104, 20);
            label14.TabIndex = 23;
            label14.Text = "Contact Name";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(409, 9);
            label15.Name = "label15";
            label15.Size = new Size(177, 25);
            label15.TabIndex = 29;
            label15.Text = "Emergency Contact";
            // 
            // empaccountLbl
            // 
            empaccountLbl.AutoSize = true;
            empaccountLbl.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            empaccountLbl.Location = new Point(409, 276);
            empaccountLbl.Name = "empaccountLbl";
            empaccountLbl.Size = new Size(171, 25);
            empaccountLbl.TabIndex = 34;
            empaccountLbl.Text = "Employee Account";
            // 
            // empPasswordTxt
            // 
            empPasswordTxt.Location = new Point(519, 339);
            empPasswordTxt.Name = "empPasswordTxt";
            empPasswordTxt.PasswordChar = '*';
            empPasswordTxt.Size = new Size(151, 27);
            empPasswordTxt.TabIndex = 33;
            // 
            // empUsernameTxt
            // 
            empUsernameTxt.Location = new Point(519, 306);
            empUsernameTxt.Name = "empUsernameTxt";
            empUsernameTxt.Size = new Size(151, 27);
            empUsernameTxt.TabIndex = 32;
            // 
            // empaccountpassLbl
            // 
            empaccountpassLbl.AutoSize = true;
            empaccountpassLbl.Location = new Point(443, 342);
            empaccountpassLbl.Name = "empaccountpassLbl";
            empaccountpassLbl.Size = new Size(70, 20);
            empaccountpassLbl.TabIndex = 31;
            empaccountpassLbl.Text = "Password";
            // 
            // empaccountuserLbl
            // 
            empaccountuserLbl.AutoSize = true;
            empaccountuserLbl.Location = new Point(438, 309);
            empaccountuserLbl.Name = "empaccountuserLbl";
            empaccountuserLbl.Size = new Size(75, 20);
            empaccountuserLbl.TabIndex = 30;
            empaccountuserLbl.Text = "Username";
            // 
            // comboBox1
            // 
            comboBox1.FormattingEnabled = true;
            comboBox1.Location = new Point(118, 149);
            comboBox1.Name = "comboBox1";
            comboBox1.Size = new Size(151, 28);
            comboBox1.TabIndex = 35;
            // 
            // EmployeeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(731, 533);
            Controls.Add(comboBox1);
            Controls.Add(empaccountLbl);
            Controls.Add(empPasswordTxt);
            Controls.Add(empUsernameTxt);
            Controls.Add(empaccountpassLbl);
            Controls.Add(empaccountuserLbl);
            Controls.Add(label15);
            Controls.Add(emergencyContactTxt);
            Controls.Add(emergencyRelationshipTxt);
            Controls.Add(emergencyNameTxt);
            Controls.Add(label12);
            Controls.Add(label13);
            Controls.Add(label14);
            Controls.Add(addressTxt);
            Controls.Add(label11);
            Controls.Add(label9);
            Controls.Add(birthdateDtp);
            Controls.Add(emailaddTxt);
            Controls.Add(label10);
            Controls.Add(label8);
            Controls.Add(hiredateDtp);
            Controls.Add(label7);
            Controls.Add(label6);
            Controls.Add(cancelBtn);
            Controls.Add(submitBtn);
            Controls.Add(DepartmentCB);
            Controls.Add(StatusCB);
            Controls.Add(PositionTB);
            Controls.Add(LastNameTB);
            Controls.Add(FirstNameTB);
            Controls.Add(label5);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Name = "EmployeeDetailsForm";
            Text = "EmployeeDetailsForm";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private Label label5;
        private TextBox FirstNameTB;
        private TextBox LastNameTB;
        private TextBox PositionTB;
        private ComboBox StatusCB;
        private ComboBox DepartmentCB;
        private Button submitBtn;
        private Button cancelBtn;
        private Label label6;
        private Label label7;
        private DateTimePicker hiredateDtp;
        private Label label8;
        private Label label9;
        private DateTimePicker birthdateDtp;
        private TextBox emailaddTxt;
        private Label label10;
        private TextBox addressTxt;
        private Label label11;
        private TextBox emergencyContactTxt;
        private TextBox emergencyRelationshipTxt;
        private TextBox emergencyNameTxt;
        private Label label12;
        private Label label13;
        private Label label14;
        private Label label15;
        private Label empaccountLbl;
        private TextBox empPasswordTxt;
        private TextBox empUsernameTxt;
        private Label empaccountpassLbl;
        private Label empaccountuserLbl;
        private ComboBox comboBox1;
    }
}