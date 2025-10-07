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
        //employee details
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Department { get; set; }
        public string Position { get; set; }
        public string Status { get; set; }
        public DateTime HireDate { get; set; }

        //Additional details
        public string Email { get; set; }
        public DateTime? DateOfBirth { get; set; }
        public string Address { get; set; }
        //Emergency Contact details
        public string ContactName { get; set; }
        public string Relationship { get; set; }
        public string ContactPhone { get; set; }

        // Employee Account credentials
        public string Username { get; set; }
        public string Password { get; set; }

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
            // Employee values
            FirstName = FirstNameTB.Text.Trim();
            LastName = LastNameTB.Text.Trim();
            Department = DepartmentCB.Text.Trim();
            Position = PositionTB.Text.Trim();
            Status = StatusCB.Text.Trim();
            HireDate = hiredateDtp.Value;

            // additional values
            Email = emailaddTxt.Text.Trim();
            DateOfBirth = birthdateDtp.Value;
            Address = addressTxt.Text.Trim();

            // emergency contact values
            ContactName = emergencyNameTxt.Text.Trim();
            Relationship = emergencyRelationshipTxt.Text.Trim();
            ContactPhone = emergencyContactTxt.Text.Trim();

            // Employee Account Details
            Username = empUsernameTxt.Text.Trim();
            Password = empPasswordTxt.Text.Trim();

            if (string.IsNullOrWhiteSpace(FirstName) || string.IsNullOrWhiteSpace(LastName))
            {
                MessageBox.Show("First and Last Name are required.");
                return;
            }
            if (string.IsNullOrWhiteSpace(Email))
            {
                MessageBox.Show("Email is required.");
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

