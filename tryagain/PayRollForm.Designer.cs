namespace tryagain
{
    partial class PayRollForm
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
            listBoxPayroll = new ListBox();
            SuspendLayout();
            // 
            // listBoxPayroll
            // 
            listBoxPayroll.FormattingEnabled = true;
            listBoxPayroll.Location = new Point(282, 86);
            listBoxPayroll.Name = "listBoxPayroll";
            listBoxPayroll.Size = new Size(304, 224);
            listBoxPayroll.TabIndex = 0;
            // 
            // PayRollForm
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(800, 450);
            Controls.Add(listBoxPayroll);
            Name = "PayRollForm";
            Text = "PayRollForm";
            ResumeLayout(false);
        }

        #endregion

        private ListBox listBoxPayroll;
    }
}