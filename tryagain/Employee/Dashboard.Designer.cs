namespace tryagain.Employee
{
    partial class Dashboard
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
            components = new System.ComponentModel.Container();
            label5 = new Label();
            backgroundWorker1 = new System.ComponentModel.BackgroundWorker();
            backgroundWorker2 = new System.ComponentModel.BackgroundWorker();
            namePositionTxt = new Label();
            panel1 = new Panel();
            hoursworkedLabel = new Label();
            label20 = new Label();
            attendancestatusLabel = new Label();
            timeoutLabel = new Label();
            timeinLabel = new Label();
            label7 = new Label();
            label4 = new Label();
            label1 = new Label();
            label2 = new Label();
            panel2 = new Panel();
            nextbatchLabel = new Label();
            paidonLabel = new Label();
            lastnetpayLabel = new Label();
            batchLabel = new Label();
            label15 = new Label();
            label10 = new Label();
            label9 = new Label();
            label8 = new Label();
            label3 = new Label();
            panel4 = new Panel();
            upcominglabelLeave = new Label();
            approveleaveLabel = new Label();
            pendingleaveLabel = new Label();
            label13 = new Label();
            label12 = new Label();
            label11 = new Label();
            label6 = new Label();
            panel3 = new Panel();
            datenowLabel = new Label();
            label14 = new Label();
            timer1 = new System.Windows.Forms.Timer(components);
            timenowLabel = new Label();
            panel1.SuspendLayout();
            panel2.SuspendLayout();
            panel4.SuspendLayout();
            panel3.SuspendLayout();
            SuspendLayout();
            // 
            // label5
            // 
            label5.AutoSize = true;
            label5.Font = new Font("Arial", 16F, FontStyle.Bold);
            label5.Location = new Point(6, 6);
            label5.Name = "label5";
            label5.Size = new Size(143, 32);
            label5.TabIndex = 12;
            label5.Text = "Welcome!";
            label5.TextAlign = ContentAlignment.BottomCenter;
            // 
            // namePositionTxt
            // 
            namePositionTxt.AutoSize = true;
            namePositionTxt.Font = new Font("Arial", 16F, FontStyle.Bold);
            namePositionTxt.Location = new Point(145, 6);
            namePositionTxt.Name = "namePositionTxt";
            namePositionTxt.Size = new Size(225, 32);
            namePositionTxt.TabIndex = 13;
            namePositionTxt.Text = "Name (Position)";
            namePositionTxt.TextAlign = ContentAlignment.BottomCenter;
            // 
            // panel1
            // 
            panel1.Controls.Add(hoursworkedLabel);
            panel1.Controls.Add(label20);
            panel1.Controls.Add(attendancestatusLabel);
            panel1.Controls.Add(timeoutLabel);
            panel1.Controls.Add(timeinLabel);
            panel1.Controls.Add(label7);
            panel1.Controls.Add(label4);
            panel1.Controls.Add(label1);
            panel1.Controls.Add(label2);
            panel1.Location = new Point(31, 159);
            panel1.Name = "panel1";
            panel1.Size = new Size(250, 236);
            panel1.TabIndex = 14;
            // 
            // hoursworkedLabel
            // 
            hoursworkedLabel.AutoSize = true;
            hoursworkedLabel.Location = new Point(154, 166);
            hoursworkedLabel.Name = "hoursworkedLabel";
            hoursworkedLabel.Size = new Size(52, 20);
            hoursworkedLabel.TabIndex = 8;
            hoursworkedLabel.Text = "Status:";
            // 
            // label20
            // 
            label20.AutoSize = true;
            label20.Location = new Point(14, 166);
            label20.Name = "label20";
            label20.Size = new Size(106, 20);
            label20.TabIndex = 7;
            label20.Text = "Hours Worked:";
            // 
            // attendancestatusLabel
            // 
            attendancestatusLabel.AutoSize = true;
            attendancestatusLabel.Location = new Point(154, 132);
            attendancestatusLabel.Name = "attendancestatusLabel";
            attendancestatusLabel.Size = new Size(58, 20);
            attendancestatusLabel.TabIndex = 6;
            attendancestatusLabel.Text = "label19";
            // 
            // timeoutLabel
            // 
            timeoutLabel.AutoSize = true;
            timeoutLabel.Location = new Point(154, 99);
            timeoutLabel.Name = "timeoutLabel";
            timeoutLabel.Size = new Size(58, 20);
            timeoutLabel.TabIndex = 5;
            timeoutLabel.Text = "label18";
            // 
            // timeinLabel
            // 
            timeinLabel.AutoSize = true;
            timeinLabel.Location = new Point(154, 65);
            timeinLabel.Name = "timeinLabel";
            timeinLabel.Size = new Size(58, 20);
            timeinLabel.TabIndex = 4;
            timeinLabel.Text = "label17";
            // 
            // label7
            // 
            label7.AutoSize = true;
            label7.Location = new Point(14, 132);
            label7.Name = "label7";
            label7.Size = new Size(52, 20);
            label7.TabIndex = 3;
            label7.Text = "Status:";
            // 
            // label4
            // 
            label4.AutoSize = true;
            label4.Location = new Point(14, 99);
            label4.Name = "label4";
            label4.Size = new Size(73, 20);
            label4.TabIndex = 2;
            label4.Text = "Time Out:";
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.Location = new Point(14, 65);
            label1.Name = "label1";
            label1.Size = new Size(61, 20);
            label1.TabIndex = 1;
            label1.Text = "Time in:";
            // 
            // label2
            // 
            label2.AutoSize = true;
            label2.Location = new Point(27, 13);
            label2.Name = "label2";
            label2.Size = new Size(129, 20);
            label2.TabIndex = 0;
            label2.Text = "Attendance Today";
            // 
            // panel2
            // 
            panel2.Controls.Add(nextbatchLabel);
            panel2.Controls.Add(paidonLabel);
            panel2.Controls.Add(lastnetpayLabel);
            panel2.Controls.Add(batchLabel);
            panel2.Controls.Add(label15);
            panel2.Controls.Add(label10);
            panel2.Controls.Add(label9);
            panel2.Controls.Add(label8);
            panel2.Controls.Add(label3);
            panel2.Location = new Point(333, 159);
            panel2.Name = "panel2";
            panel2.Size = new Size(250, 236);
            panel2.TabIndex = 15;
            // 
            // nextbatchLabel
            // 
            nextbatchLabel.AutoSize = true;
            nextbatchLabel.Location = new Point(168, 166);
            nextbatchLabel.Name = "nextbatchLabel";
            nextbatchLabel.Size = new Size(49, 20);
            nextbatchLabel.TabIndex = 10;
            nextbatchLabel.Text = "Batch:";
            // 
            // paidonLabel
            // 
            paidonLabel.AutoSize = true;
            paidonLabel.Location = new Point(168, 132);
            paidonLabel.Name = "paidonLabel";
            paidonLabel.Size = new Size(49, 20);
            paidonLabel.TabIndex = 9;
            paidonLabel.Text = "Batch:";
            // 
            // lastnetpayLabel
            // 
            lastnetpayLabel.AutoSize = true;
            lastnetpayLabel.Location = new Point(168, 99);
            lastnetpayLabel.Name = "lastnetpayLabel";
            lastnetpayLabel.Size = new Size(49, 20);
            lastnetpayLabel.TabIndex = 8;
            lastnetpayLabel.Text = "Batch:";
            // 
            // batchLabel
            // 
            batchLabel.AutoSize = true;
            batchLabel.Location = new Point(168, 65);
            batchLabel.Name = "batchLabel";
            batchLabel.Size = new Size(49, 20);
            batchLabel.TabIndex = 7;
            batchLabel.Text = "Batch:";
            // 
            // label15
            // 
            label15.AutoSize = true;
            label15.Location = new Point(36, 132);
            label15.Name = "label15";
            label15.Size = new Size(61, 20);
            label15.TabIndex = 6;
            label15.Text = "Paid on:";
            // 
            // label10
            // 
            label10.AutoSize = true;
            label10.Location = new Point(36, 166);
            label10.Name = "label10";
            label10.Size = new Size(84, 20);
            label10.TabIndex = 5;
            label10.Text = "Next Batch:";
            // 
            // label9
            // 
            label9.AutoSize = true;
            label9.Location = new Point(36, 65);
            label9.Name = "label9";
            label9.Size = new Size(49, 20);
            label9.TabIndex = 4;
            label9.Text = "Batch:";
            // 
            // label8
            // 
            label8.AutoSize = true;
            label8.Location = new Point(36, 99);
            label8.Name = "label8";
            label8.Size = new Size(92, 20);
            label8.TabIndex = 4;
            label8.Text = "Last Net Pay:";
            // 
            // label3
            // 
            label3.AutoSize = true;
            label3.Location = new Point(36, 13);
            label3.Name = "label3";
            label3.Size = new Size(118, 20);
            label3.TabIndex = 1;
            label3.Text = "Payroll Snapshot";
            // 
            // panel4
            // 
            panel4.Controls.Add(upcominglabelLeave);
            panel4.Controls.Add(approveleaveLabel);
            panel4.Controls.Add(pendingleaveLabel);
            panel4.Controls.Add(label13);
            panel4.Controls.Add(label12);
            panel4.Controls.Add(label11);
            panel4.Controls.Add(label6);
            panel4.Location = new Point(669, 159);
            panel4.Name = "panel4";
            panel4.Size = new Size(250, 236);
            panel4.TabIndex = 17;
            // 
            // upcominglabelLeave
            // 
            upcominglabelLeave.AutoSize = true;
            upcominglabelLeave.Location = new Point(157, 132);
            upcominglabelLeave.Name = "upcominglabelLeave";
            upcominglabelLeave.Size = new Size(65, 20);
            upcominglabelLeave.TabIndex = 11;
            upcominglabelLeave.Text = "Pending:";
            // 
            // approveleaveLabel
            // 
            approveleaveLabel.AutoSize = true;
            approveleaveLabel.Location = new Point(157, 99);
            approveleaveLabel.Name = "approveleaveLabel";
            approveleaveLabel.Size = new Size(65, 20);
            approveleaveLabel.TabIndex = 10;
            approveleaveLabel.Text = "Pending:";
            // 
            // pendingleaveLabel
            // 
            pendingleaveLabel.AutoSize = true;
            pendingleaveLabel.Location = new Point(157, 65);
            pendingleaveLabel.Name = "pendingleaveLabel";
            pendingleaveLabel.Size = new Size(65, 20);
            pendingleaveLabel.TabIndex = 9;
            pendingleaveLabel.Text = "Pending:";
            // 
            // label13
            // 
            label13.AutoSize = true;
            label13.Location = new Point(36, 132);
            label13.Name = "label13";
            label13.Size = new Size(81, 20);
            label13.TabIndex = 8;
            label13.Text = "Upcoming:";
            // 
            // label12
            // 
            label12.AutoSize = true;
            label12.Location = new Point(36, 99);
            label12.Name = "label12";
            label12.Size = new Size(78, 20);
            label12.TabIndex = 7;
            label12.Text = "Approved:";
            // 
            // label11
            // 
            label11.AutoSize = true;
            label11.Location = new Point(36, 65);
            label11.Name = "label11";
            label11.Size = new Size(65, 20);
            label11.TabIndex = 6;
            label11.Text = "Pending:";
            // 
            // label6
            // 
            label6.AutoSize = true;
            label6.Location = new Point(60, 13);
            label6.Name = "label6";
            label6.Size = new Size(113, 20);
            label6.TabIndex = 3;
            label6.Text = "Leave Summary";
            // 
            // panel3
            // 
            panel3.Controls.Add(timenowLabel);
            panel3.Controls.Add(datenowLabel);
            panel3.Controls.Add(label14);
            panel3.Controls.Add(label5);
            panel3.Controls.Add(namePositionTxt);
            panel3.Location = new Point(22, 12);
            panel3.Name = "panel3";
            panel3.Size = new Size(963, 113);
            panel3.TabIndex = 18;
            // 
            // datenowLabel
            // 
            datenowLabel.AutoSize = true;
            datenowLabel.Location = new Point(99, 54);
            datenowLabel.Name = "datenowLabel";
            datenowLabel.Size = new Size(81, 20);
            datenowLabel.TabIndex = 14;
            datenowLabel.Text = "Date Label";
            // 
            // label14
            // 
            label14.AutoSize = true;
            label14.Location = new Point(9, 54);
            label14.Name = "label14";
            label14.Size = new Size(66, 20);
            label14.TabIndex = 4;
            label14.Text = "Today is:";
            // 
            // timenowLabel
            // 
            timenowLabel.AutoSize = true;
            timenowLabel.Location = new Point(216, 54);
            timenowLabel.Name = "timenowLabel";
            timenowLabel.Size = new Size(58, 20);
            timenowLabel.TabIndex = 15;
            timenowLabel.Text = "label16";
            // 
            // Dashboard
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1014, 493);
            Controls.Add(panel3);
            Controls.Add(panel4);
            Controls.Add(panel2);
            Controls.Add(panel1);
            Margin = new Padding(3, 4, 3, 4);
            Name = "Dashboard";
            Text = "Dashboard";
            panel1.ResumeLayout(false);
            panel1.PerformLayout();
            panel2.ResumeLayout(false);
            panel2.PerformLayout();
            panel4.ResumeLayout(false);
            panel4.PerformLayout();
            panel3.ResumeLayout(false);
            panel3.PerformLayout();
            ResumeLayout(false);
        }

        #endregion
        private Label label5;
        private System.ComponentModel.BackgroundWorker backgroundWorker1;
        private System.ComponentModel.BackgroundWorker backgroundWorker2;
        private Label namePositionTxt;
        private Panel panel1;
        private Label label2;
        private Panel panel2;
        private Label label3;
        private Panel panel4;
        private Label label6;
        private Label label7;
        private Label label4;
        private Label label1;
        private Label label9;
        private Label label8;
        private Label label10;
        private Label label13;
        private Label label12;
        private Label label11;
        private Label hoursworkedLabel;
        private Label label20;
        private Label attendancestatusLabel;
        private Label timeoutLabel;
        private Label timeinLabel;
        private Label nextbatchLabel;
        private Label paidonLabel;
        private Label lastnetpayLabel;
        private Label batchLabel;
        private Label label15;
        private Panel panel3;
        private Label datenowLabel;
        private Label label14;
        private Label upcominglabelLeave;
        private Label approveleaveLabel;
        private Label pendingleaveLabel;
        private System.Windows.Forms.Timer timer1;
        private Label timenowLabel;
    }
}