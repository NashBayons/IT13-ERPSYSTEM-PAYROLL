namespace tryagain.Employee
{
    partial class LeaveForm
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
            label5 = new Label();
            label1 = new Label();
            label2 = new Label();
            label3 = new Label();
            label4 = new Label();
            dateFrom = new DateTimePicker();
            dateTo = new DateTimePicker();
            leavetypeCmb = new ComboBox();
            reasonTxt = new TextBox();
            submitBtn = new Button();
            cancelBtn = new Button();
            label6 = new Label();
            leaveDgv = new DataGridView();
            ((System.ComponentModel.ISupportInitialize)leaveDgv).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16F, FontStyle.Bold);
            label5.Location = new Point(12, 9);
            label5.Name = "label5";
            label5.Size = new Size(207, 32);
            label5.TabIndex = 22;
            label5.Text = "Leave Request";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(18, 59);
            label1.Name = "label1";
            label1.Size = new Size(82, 20);
            label1.TabIndex = 23;
            label1.Text = "Leave Type";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(18, 101);
            label2.Name = "label2";
            label2.Size = new Size(76, 20);
            label2.TabIndex = 24;
            label2.Text = "Start Date";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(227, 101);
            label3.Name = "label3";
            label3.Size = new Size(70, 20);
            label3.TabIndex = 25;
            label3.Text = "End Date";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(18, 144);
            label4.Name = "label4";
            label4.Size = new Size(57, 20);
            label4.TabIndex = 26;
            label4.Text = "Reason";
            // 
            // dateFrom
            // 
            dateFrom.Format = DateTimePickerFormat.Short;
            dateFrom.Location = new Point(106, 101);
            dateFrom.Name = "dateFrom";
            dateFrom.Size = new Size(104, 27);
            dateFrom.TabIndex = 27;
            // 
            // dateTo
            // 
            dateTo.Format = DateTimePickerFormat.Short;
            dateTo.Location = new Point(303, 101);
            dateTo.Name = "dateTo";
            dateTo.Size = new Size(104, 27);
            dateTo.TabIndex = 28;
            // 
            // leavetypeCmb
            // 
            leavetypeCmb.FormattingEnabled = true;
            leavetypeCmb.Items.AddRange(new object[] { "Vacation", "Sick", "Emergency", "Other" });
            leavetypeCmb.Location = new Point(106, 56);
            leavetypeCmb.Name = "leavetypeCmb";
            leavetypeCmb.Size = new Size(151, 28);
            leavetypeCmb.TabIndex = 29;
            // 
            // reasonTxt
            // 
            reasonTxt.Location = new Point(106, 144);
            reasonTxt.Multiline = true;
            reasonTxt.Name = "reasonTxt";
            reasonTxt.Size = new Size(281, 54);
            reasonTxt.TabIndex = 30;
            // 
            // submitBtn
            // 
            submitBtn.Location = new Point(106, 204);
            submitBtn.Name = "submitBtn";
            submitBtn.Size = new Size(94, 29);
            submitBtn.TabIndex = 31;
            submitBtn.Text = "Submit";
            submitBtn.UseVisualStyleBackColor = true;
            submitBtn.Click += submitBtn_Click;
            // 
            // cancelBtn
            // 
            cancelBtn.Location = new Point(206, 204);
            cancelBtn.Name = "cancelBtn";
            cancelBtn.Size = new Size(94, 29);
            cancelBtn.TabIndex = 32;
            cancelBtn.Text = "Cancel";
            cancelBtn.UseVisualStyleBackColor = true;
            cancelBtn.Click += cancelBtn_Click;
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Font = new Font("Arial", 16F, FontStyle.Bold);
            label6.Location = new Point(18, 264);
            label6.Name = "label6";
            label6.Size = new Size(251, 32);
            label6.TabIndex = 33;
            label6.Text = "My Leave Request";
            label6.TextAlign = ContentAlignment.BottomCenter;
            // 
            // leaveDgv
            // 
            leaveDgv.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            leaveDgv.Location = new Point(18, 324);
            leaveDgv.Name = "leaveDgv";
            leaveDgv.RowHeadersWidth = 51;
            leaveDgv.Size = new Size(865, 318);
            leaveDgv.TabIndex = 34;
            // 
            // LeaveRequest
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 749);
            Controls.Add(leaveDgv);
            Controls.Add(label6);
            Controls.Add(cancelBtn);
            Controls.Add(submitBtn);
            Controls.Add(reasonTxt);
            Controls.Add(leavetypeCmb);
            Controls.Add(dateTo);
            Controls.Add(dateFrom);
            Controls.Add(label4);
            Controls.Add(label3);
            Controls.Add(label2);
            Controls.Add(label1);
            Controls.Add(label5);
            Margin = new Padding(3, 4, 3, 4);
            Name = "LeaveRequest";
            Text = "Settings";
            ((System.ComponentModel.ISupportInitialize)leaveDgv).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label label1;
        private Label label2;
        private Label label3;
        private Label label4;
        private DateTimePicker dateFrom;
        private DateTimePicker dateTo;
        private ComboBox leavetypeCmb;
        private TextBox reasonTxt;
        private Button submitBtn;
        private Button cancelBtn;
        private Label label6;
        private DataGridView leaveDgv;
    }
}