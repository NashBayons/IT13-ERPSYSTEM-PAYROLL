using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain.Employee
{
    public partial class EmployeeMainForm : Form
    {
        private int _userId;
        private int _empId;
        public EmployeeMainForm(int userId, int empId)
        {
            InitializeComponent();
            _userId = userId;
            _empId = empId;
            ShowDashboard();
            contentPanel.AutoScroll = true;
            contentPanel.Dock = DockStyle.Fill;

        }

        private void ShowDashboard()
        {
            contentPanel.Controls.Clear();
            LoadForm(new Employee.Dashboard());
        }

        // Method to load a form into the contentPanel
        private void LoadForm(Form form)
        {
            contentPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;
            form.Anchor = AnchorStyles.Top | AnchorStyles.Left | AnchorStyles.Right | AnchorStyles.Bottom;

            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void Logout()
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return; 
            }

            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void Dashboardbtn_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Employee.Dashboard());
        }

        private void Employeeprofilebtn_Click(object sender, EventArgs e)
        {
            LoadForm(new Employee.Employee_Profile(_empId));
        }

        private void payrollBtn_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Employee.Payroll_System(_empId));
        }

        private void Attendancetbtn_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Employee.Attendance());
        }

        private void Settingsbtn_Click_1(object sender, EventArgs e)
        {
            LoadForm(new Employee.Settings());
        }

        private void accountbtn_Click(object sender, EventArgs e)
        {
            // Implement logic for account button if required
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Logout();
        }
    }
}
