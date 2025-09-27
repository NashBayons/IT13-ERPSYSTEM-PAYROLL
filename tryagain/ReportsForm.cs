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
    public partial class ReportsForm : Form
    {
        private List<ReportItem> reports;
        public ReportsForm()
        {
            InitializeComponent();
            InitializeData();
            ShowReports();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        private void InitializeData()
        {
            reports = new List<ReportItem>
            {
                new ReportItem { Title = "Monthly Attendance Summary", Description = "Attendance trends and absences report for Sept 2025" },
                new ReportItem { Title = "Payroll Report", Description = "Net pay breakdown for all employees for Sept 2025" },
                new ReportItem { Title = "Employee Status Report", Description = "List of active vs inactive employees" }
            };
        }
        private void ShowReports()
        {
            listBoxReports.Items.Clear();
            foreach (var report in reports)
            {
                listBoxReports.Items.Add($"{report.Title} - {report.Description}");
            }
        }
    }
    public class ReportItem
    {
        public string Title { get; set; }
        public string Description { get; set; }
    }
}

