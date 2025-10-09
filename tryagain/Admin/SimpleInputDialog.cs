using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class SimpleInputDialog : Form
    {

        private TextBox txtValue1;
        private NumericUpDown numValue2;
        private Button btnOk, btnCancel;

        public string Value1 => txtValue1.Text.Trim();
        public decimal Value2 => numValue2.Value;
        public SimpleInputDialog(string label1, string default1, string label2, decimal default2)
        {
            this.Text = "Input";
            this.Size = new Size(350, 180);

            Label lbl1 = new Label { Text = label1, Location = new Point(10, 10), AutoSize = true };
            txtValue1 = new TextBox { Location = new Point(130, 10), Width = 150, Text = default1 };

            Label lbl2 = new Label { Text = label2, Location = new Point(10, 40), AutoSize = true };
            numValue2 = new NumericUpDown { Location = new Point(130, 40), Width = 150, DecimalPlaces = 2, Maximum = 1000000, Value = default2 };

            btnOk = new Button { Text = "OK", Location = new Point(40, 80), Height=35, DialogResult = DialogResult.OK };
            btnCancel = new Button { Text = "Cancel", Location = new Point(140, 80), Height = 35, DialogResult = DialogResult.Cancel };

            this.Controls.Add(lbl1);
            this.Controls.Add(txtValue1);
            this.Controls.Add(lbl2);
            this.Controls.Add(numValue2);
            this.Controls.Add(btnOk);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}
