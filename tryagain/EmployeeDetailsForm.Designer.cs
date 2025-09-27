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
            FirstNameTB.Size = new Size(125, 27);
            FirstNameTB.TabIndex = 5;
            // 
            // LastNameTB
            // 
            LastNameTB.Location = new Point(32, 136);
            LastNameTB.Name = "LastNameTB";
            LastNameTB.Size = new Size(125, 27);
            LastNameTB.TabIndex = 6;
            // 
            // PositionTB
            // 
            PositionTB.Location = new Point(32, 242);
            PositionTB.Name = "PositionTB";
            PositionTB.Size = new Size(125, 27);
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
            submitBtn.Location = new Point(32, 329);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(94, 29);
            submitBtn.TabIndex = 11;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(147, 329);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 12;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            // 
            // EmployeeDetailsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(397, 450);
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
    }
}