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
    public partial class PayRollForm : Form
    {
        private List<PayrollRecord> payrollRecords;
        public PayRollForm()
        {
            InitializeComponent();
            InitializeData();
            ShowPayroll();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
        private void InitializeData()
        {
            payrollRecords = new List<PayrollRecord>
            {
                new PayrollRecord { EmployeeID = "EMP001", PayPeriod = "Sept 2025", BasicSalary = 30000, OvertimePay = 2000, Allowances = 1500, Deductions = 500, NetPay = 33000, Status = "Paid" },
                new PayrollRecord { EmployeeID = "EMP002", PayPeriod = "Sept 2025", BasicSalary = 45000, OvertimePay = 1000, Allowances = 2000, Deductions = 1000, NetPay = 47000, Status = "Paid" }
            };
        }
        private void ShowPayroll()
        {
            listBoxPayroll.Items.Clear();
            foreach (var record in payrollRecords)
            {
                listBoxPayroll.Items.Add(
                    $"{record.EmployeeID} | {record.PayPeriod} | Basic: {record.BasicSalary:C} | Net: {record.NetPay:C} | {record.Status}"
                );
            }
        }

    }
    public class PayrollRecord
    {
        public string EmployeeID { get; set; }
        public string PayPeriod { get; set; }
        public decimal BasicSalary { get; set; }
        public decimal OvertimePay { get; set; }
        public decimal Allowances { get; set; }
        public decimal Deductions { get; set; }
        public decimal NetPay { get; set; }
        public string Status { get; set; }
    }
}
