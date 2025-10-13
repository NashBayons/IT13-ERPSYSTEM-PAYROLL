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
            label5.Font = new Font("Arial", 19.8000011F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label5.Location = new Point(44, 9);
            label5.Name = "label5";
            label5.Size = new Size(383, 40);
            label5.TabIndex = 21;
            label5.Text = "Attendance Monitoring";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Font = new Font("Segoe UI", 16.2F, FontStyle.Regular, GraphicsUnit.Point, 0);
            label1.Location = new Point(44, 79);
            label1.Name = "label1";
            label1.Size = new Size(95, 38);
            label1.TabIndex = 22;
            label1.Text = "Today:";
            // 
            // dateNowLabel
            // 
            dateNowLabel.AutoSize = true;
            dateNowLabel.Font = new Font("Segoe UI", 16.2F);
            dateNowLabel.Location = new Point(145, 79);
            dateNowLabel.Name = "dateNowLabel";
            dateNowLabel.Size = new Size(216, 38);
            dateNowLabel.TabIndex = 23;
            dateNowLabel.Text = "Month Day year";
            // 
            // timeinBtn
            // 
            timeinBtn.BackColor = Color.FromArgb(0, 192, 0);
            timeinBtn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeinBtn.ForeColor = Color.White;
            timeinBtn.Location = new Point(44, 200);
            timeinBtn.Name = "timeinBtn";
            timeinBtn.Size = new Size(123, 46);
            timeinBtn.TabIndex = 24;
            timeinBtn.Text = "Time In";
            timeinBtn.UseVisualStyleBackColor = false;
            timeinBtn.Click += timeinBtn_Click;
            // 
            // timeoutBtn
            // 
            timeoutBtn.BackColor = Color.Red;
            timeoutBtn.Font = new Font("Segoe UI Semibold", 10.8F, FontStyle.Bold, GraphicsUnit.Point, 0);
            timeoutBtn.ForeColor = Color.White;
            timeoutBtn.Location = new Point(173, 200);
            timeoutBtn.Name = "timeoutBtn";
            timeoutBtn.Size = new Size(123, 46);
            timeoutBtn.TabIndex = 25;
            timeoutBtn.Text = "Time Out";
            timeoutBtn.UseVisualStyleBackColor = false;
            timeoutBtn.Click += timeoutBtn_Click;
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Font = new Font("Segoe UI", 16.2F);
            label2.Location = new Point(44, 135);
            label2.Name = "label2";
            label2.Size = new Size(198, 38);
            label2.TabIndex = 26;
            label2.Text = "Current Status:";
            // 
            // statusLabel
            // 
            statusLabel.AutoSize = true;
            statusLabel.Font = new Font("Segoe UI", 16.2F);
            statusLabel.Location = new Point(248, 135);
            statusLabel.Name = "statusLabel";
            statusLabel.Size = new Size(184, 38);
            statusLabel.TabIndex = 27;
            statusLabel.Text = "Event at Time";
            // 
            // panel1
            // 
            panel1.BackColor = Color.White;
            panel1.Controls.Add(label4);
            panel1.Controls.Add(attendanceDvg);
            panel1.Location = new Point(44, 252);
            panel1.Name = "panel1";
            panel1.Size = new Size(925, 308);
            panel1.TabIndex = 28;
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point, 0);
            label4.Location = new Point(5, 15);
            label4.Name = "label4";
            label4.Size = new Size(188, 28);
            label4.TabIndex = 1;
            label4.Text = "Attendance History";
            // 
            // attendanceDvg
            // 
            attendanceDvg.AllowUserToAddRows = false;
            attendanceDvg.AllowUserToResizeColumns = false;
            attendanceDvg.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            attendanceDvg.BackgroundColor = SystemColors.Control;
            attendanceDvg.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            attendanceDvg.Dock = DockStyle.Bottom;
            attendanceDvg.Location = new Point(0, 46);
            attendanceDvg.Name = "attendanceDvg";
            attendanceDvg.RowHeadersVisible = false;
            attendanceDvg.RowHeadersWidth = 51;
            attendanceDvg.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            attendanceDvg.Size = new Size(925, 262);
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