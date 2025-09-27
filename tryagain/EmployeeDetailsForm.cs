using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace tryagain
{
    public partial class EmployeeDetailsForm : Form
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public EmployeeDetailsForm(string firstName = "", string lastName = "", string dept = "", string pos = "", string status = "")
        {
            InitializeComponent();

            FirstNameTB.Text = firstName;
            LastNameTB.Text = lastName;
            DepartmentCB.Text = dept;
            PositionTB.Text = pos;
            StatusCB.Items.AddRange(new[] { "Active", "Inactive" });
            StatusCB.Text = string.IsNullOrEmpty(status) ? "Active" : status;

            submitBtn.Click += BtnSave_Click;
            cancelBtn.Click += BtnCancel_Click;
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            // Collect values
            FirstName = FirstNameTB.Text;
            LastName = LastNameTB.Text;
            Department = DepartmentCB.Text;
            Position = PositionTB.Text;
            Status = StatusCB.Text;

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("First and Last Name are required.");
                return;
            }

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void BtnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}

