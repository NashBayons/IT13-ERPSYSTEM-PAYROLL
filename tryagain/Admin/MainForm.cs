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
    public partial class MainForm : Form
    {
        public MainForm()
        {
            InitializeComponent();
            ShowDashboard();
        }

        private void ShowDashboard()
        {
            contentPanel.Controls.Clear();
            LoadForm(new dashboardForm());
        }

        private void LoadForm(Form form)
        {
            contentPanel.Controls.Clear();

            form.TopLevel = false;
            form.FormBorderStyle = FormBorderStyle.None;
            form.Dock = DockStyle.Fill;

            contentPanel.Controls.Add(form);
            form.Show();
        }

        public void Logout()
        {
            if (MessageBox.Show("Are you sure you want to log out?", "Confirm Logout", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.No)
            {
                return;
            }

            LoginForm loginForm = new LoginForm();
            loginForm.Show();

            this.Close();
        }

        private void dashboardBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new dashboardForm());
        }

        private void employeeBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new EmployeeForm());
        }

        private void attendanceBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new AttendanceForm());
        }

        private void payrollBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new PayrollBatchForm());
        }

        private void reportsBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new ReportsForm());
        }

        private void salaryBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new SalaryMangementForm());
        }

        private void leaveBtn_Click(object sender, EventArgs e)
        {
            LoadForm(new LeaveRequestForm());
        }

        private void logoutBtn_Click(object sender, EventArgs e)
        {
            Logout();
        }

        private void sidebarPanel_Paint(object sender, PaintEventArgs e)
        {

        }
    }
}
