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
            label16 = new Label();
            empPasswordTxt = new TextBox();
            empUsernameTxt = new TextBox();
            label17 = new Label();
            label18 = new Label();
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
            label2.Location = new Point(32, 107);
            label2.Name = "label2";
            label2.Size = new Size(79, 20);
            label2.TabIndex = 1;
            label2.Text = "Last Name";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(32, 166);
            label3.Name = "label3";
            label3.Size = new Size(89, 20);
            label3.TabIndex = 2;
            label3.Text = "Department";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(32, 219);
            label4.Name = "label4";
            label4.Size = new Size(61, 20);
            label4.TabIndex = 3;
            label4.Text = "Position";
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Location = new Point(32, 272);
            label5.Name = "label5";
            label5.Size = new Size(49, 20);
            label5.TabIndex = 4;
            label5.Text = "Status";
            // 
            // FirstNameTB
            // 
            FirstNameTB.Location = new Point(32, 77);
            FirstNameTB.Name = "FirstNameTB";
            FirstNameTB.Size = new Size(151, 27);
            FirstNameTB.TabIndex = 5;
            // 
            // LastNameTB
            // 
            LastNameTB.Location = new Point(32, 136);
            LastNameTB.Name = "LastNameTB";
            LastNameTB.Size = new Size(151, 27);
            LastNameTB.TabIndex = 6;
            // 
            // PositionTB
            // 
            PositionTB.Location = new Point(32, 242);
            PositionTB.Name = "PositionTB";
            PositionTB.Size = new Size(151, 27);
            PositionTB.TabIndex = 8;
            // 
            // StatusCB
            // 
            StatusCB.FormattingEnabled = true;
            StatusCB.Items.AddRange(new object[] { "Active", "Inactive" });
            StatusCB.Location = new Point(32, 295);
            StatusCB.Name = "StatusCB";
            StatusCB.Size = new Size(151, 28);
            StatusCB.TabIndex = 9;
            // 
            // DepartmentCB
            // 
            DepartmentCB.FormattingEnabled = true;
            DepartmentCB.Items.AddRange(new object[] { "HR", "IT", "CS" });
            DepartmentCB.Location = new Point(32, 189);
            DepartmentCB.Name = "DepartmentCB";
            DepartmentCB.Size = new Size(151, 28);
            DepartmentCB.TabIndex = 10;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(316, 397);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(94, 29);
            submitBtn.TabIndex = 11;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(416, 397);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label6.Location = new Point(19, 18);
            label6.Name = "label6";
            label6.Size = new Size(202, 25);
            label6.TabIndex = 13;
            label6.Text = "Employee Information";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label7.Location = new Point(259, 18);
            label7.Name = "label7";
            label7.Size = new Size(208, 25);
            label7.TabIndex = 14;
            label7.Text = "Additional Information";
            // 
            // hiredateDtp
            // 
            hiredateDtp.Format = DateTimePickerFormat.Short;
            hiredateDtp.Location = new Point(32, 349);
            hiredateDtp.Name = "hiredateDtp";
            hiredateDtp.Size = new Size(151, 27);
            hiredateDtp.TabIndex = 15;
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(32, 326);
            label8.Name = "label8";
            label8.Size = new Size(73, 20);
            label8.TabIndex = 16;
            label8.Text = "Hire Date";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(259, 113);
            label9.Name = "label9";
            label9.Size = new Size(94, 20);
            label9.TabIndex = 20;
            label9.Text = "Date of Birth";
            // 
            // birthdateDtp
            // 
            birthdateDtp.Format = DateTimePickerFormat.Short;
            birthdateDtp.Location = new Point(259, 136);
            birthdateDtp.Name = "birthdateDtp";
            birthdateDtp.Size = new Size(208, 27);
            birthdateDtp.TabIndex = 19;
            // 
            // emailaddTxt
            // 
            emailaddTxt.Location = new Point(259, 77);
            emailaddTxt.Name = "emailaddTxt";
            emailaddTxt.Size = new Size(208, 27);
            emailaddTxt.TabIndex = 18;
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(259, 52);
            label10.Name = "label10";
            label10.Size = new Size(103, 20);
            label10.TabIndex = 17;
            label10.Text = "Email Address";
            // 
            // addressTxt
            // 
            addressTxt.Location = new Point(259, 190);
            addressTxt.Multiline = true;
            addressTxt.Name = "addressTxt";
            addressTxt.Size = new Size(208, 49);
            addressTxt.TabIndex = 22;
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(259, 165);
            label11.Name = "label11";
            label11.Size = new Size(62, 20);
            label11.TabIndex = 21;
            label11.Text = "Address";
            // 
            // emergencyContactTxt
            // 
            emergencyContactTxt.Location = new Point(527, 190);
            emergencyContactTxt.Name = "emergencyContactTxt";
            emergencyContactTxt.Size = new Size(151, 27);
            emergencyContactTxt.TabIndex = 28;
            // 
            // emergencyRelationshipTxt
            // 
            emergencyRelationshipTxt.Location = new Point(527, 136);
            emergencyRelationshipTxt.Name = "emergencyRelationshipTxt";
            emergencyRelationshipTxt.Size = new Size(151, 27);
            emergencyRelationshipTxt.TabIndex = 27;
            // 
            // emergencyNameTxt
            // 
            emergencyNameTxt.Location = new Point(527, 77);
            emergencyNameTxt.Name = "emergencyNameTxt";
            emergencyNameTxt.Size = new Size(151, 27);
            emergencyNameTxt.TabIndex = 26;
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(527, 166);
            label12.Name = "label12";
            label12.Size = new Size(69, 20);
            label12.TabIndex = 25;
            label12.Text = "Contact#";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(527, 107);
            label13.Name = "label13";
            label13.Size = new Size(91, 20);
            label13.TabIndex = 24;
            label13.Text = "Relationship";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(527, 52);
            label14.Name = "label14";
            label14.Size = new Size(104, 20);
            label14.TabIndex = 23;
            label14.Text = "Contact Name";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label15.Location = new Point(527, 18);
            label15.Name = "label15";
            label15.Size = new Size(177, 25);
            label15.TabIndex = 29;
            label15.Text = "Emergency Contact";
            // 
            // label16
            // 
            label16.AutoSize = true;
            label16.Font = new Font("Segoe UI", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label16.Location = new Point(737, 18);
            label16.Name = "label16";
            label16.Size = new Size(171, 25);
            label16.TabIndex = 34;
            label16.Text = "Employee Account";
            // 
            // empPasswordTxt
            // 
            empPasswordTxt.Location = new Point(737, 136);
            empPasswordTxt.Name = "empPasswordTxt";
            empPasswordTxt.PasswordChar = '*';
            empPasswordTxt.Size = new Size(151, 27);
            empPasswordTxt.TabIndex = 33;
            // 
            // empUsernameTxt
            // 
            empUsernameTxt.Location = new Point(737, 77);
            empUsernameTxt.Name = "empUsernameTxt";
            empUsernameTxt.Size = new Size(151, 27);
            empUsernameTxt.TabIndex = 32;
            // 
            // label17
            // 
            label17.AutoSize = true;
            label17.Location = new Point(737, 107);
            label17.Name = "label17";
            label17.Size = new Size(70, 20);
            label17.TabIndex = 31;
            label17.Text = "Password";
            // 
            // label18
            // 
            label18.AutoSize = true;
            label18.Location = new Point(737, 52);
            label18.Name = "label18";
            label18.Size = new Size(75, 20);
            label18.TabIndex = 30;
            label18.Text = "Username";
            // 
            // EmployeeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(941, 437);
            Controls.Add(label16);
            Controls.Add(empPasswordTxt);
            Controls.Add(empUsernameTxt);
            Controls.Add(label17);
            Controls.Add(label18);
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
        private Label label16;
        private TextBox empPasswordTxt;
        private TextBox empUsernameTxt;
        private Label label17;
        private Label label18;
    }
}