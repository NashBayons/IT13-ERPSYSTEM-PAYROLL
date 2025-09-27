namespace tryagain
{
    partial class ReportsForm
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
            listBoxReports = new ListBox();
            SuspendLayout();
            // 
            // listBoxReports
            // 
            listBoxReports.FormattingEnabled = true;
            listBoxReports.Location = new Point(87, 88);
            listBoxReports.Name = "listBoxReports";
            listBoxReports.Size = new Size(276, 224);
            listBoxReports.TabIndex = 0;
            // 
            // ReportsForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxReports);
            Name = "ReportsForm";
            Text = "ReportsForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxReports;
    }
}