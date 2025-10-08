namespace tryagain.Employee
{
    partial class Attendance
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
            dateNowLabel = new Label();
            timeinBtn = new Button();
            timeoutBtn = new Button();
            label2 = new Label();
            statusLabel = new Label();
            panel1 = new Panel();
            label4 = new Label();
            attendanceDvg = new DataGridView();
            panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)attendanceDvg).BeginInit();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16F, FontStyle.Bold);
            label5.Location = new Point(344, 18);
            label5.Name = "label5";
            label5.Size = new Size(312, 32);
            label5.TabIndex = 21;
            label5.Text = "Attendance Monitoring";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(44, 65);
            label1.Name = "label1";
            label1.Size = new Size(49, 20);
            label1.TabIndex = 22;
            label1.Text = "Today";
            // 
            // dateNowLabel
            // 
            dateNowLabel.AutoSize = true;
            dateNowLabel.Location = new Point(123, 65);
            dateNowLabel.Name = "dateNowLabel";
            dateNowLabel.Size = new Size(114, 20);
            dateNowLabel.TabIndex = 23;
            dateNowLabel.Text = "Month Day year";
            // 
            // timeinBtn
            // 
            timeinBtn.Location = new Point(120, 120);
            timeinBtn.Name = "timeinBtn";
            timeinBtn.Size = new Size(94, 29);
            timeinBtn.TabIndex = 24;
            timeinBtn.Text = "Time In";
            timeinBtn.UseVisualStyleBackColor = true;
            timeinBtn.Click += timeinBtn_Click;
            // 
            // timeoutBtn
            // 
            timeoutBtn.Location = new Point(290, 120);
            timeoutBtn.Name = "timeoutBtn";
            timeoutBtn.Size = new Size(94, 29);
            timeoutBtn.TabIndex = 25;
            timeoutBtn.Text = "Time Out";
            timeoutBtn.UseVisualStyleBackColor = true;
            timeoutBtn.Click += timeoutBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(39, 163);
            label2.Name = "label2";
            label2.Size = new Size(104, 20);
            label2.TabIndex = 26;
            label2.Text = "Current Status:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Location = new Point(188, 163);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(99, 20);
            statusLabel.TabIndex = 27;
            statusLabel.Text = "Event at Time";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(attendanceDvg);
            panel1.Location = new Point(44, 229);
            panel1.Name = "panel1";
            panel1.Size = new Size(589, 308);
            panel1.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(11, 13);
            label4.Name = "label4";
            label4.Size = new Size(136, 20);
            label4.TabIndex = 1;
            label4.Text = "Attendance History";
            // 
            // attendanceDvg
            // 
            attendanceDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attendanceDvg.Dock = DockStyle.Bottom;
            attendanceDvg.Location = new Point(0, 46);
            attendanceDvg.Name = "attendanceDvg";
            attendanceDvg.RowHeadersWidth = 51;
            attendanceDvg.Size = new Size(589, 262);
            attendanceDvg.TabIndex = 0;
            // 
            // Attendance
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 706);
            Controls.Add(panel1);
            Controls.Add(statusLabel);
            Controls.Add(label2);
            Controls.Add(timeoutBtn);
            Controls.Add(timeinBtn);
            Controls.Add(dateNowLabel);
            Controls.Add(label1);
            Controls.Add(label5);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Attendance";
            Text = "Attendance";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)attendanceDvg).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion
        private Label label5;
        private Label label1;
        private Label dateNowLabel;
        private Button timeinBtn;
        private Button timeoutBtn;
        private Label label2;
        private Label statusLabel;
        private Panel panel1;
        private Label label4;
        private DataGridView attendanceDvg;
    }
}