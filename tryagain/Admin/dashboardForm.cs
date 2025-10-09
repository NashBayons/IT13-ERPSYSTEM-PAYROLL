using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;


namespace tryagain
{

    public partial class dashboardForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int present, absent, leave, late;
        public dashboardForm()
        {
            InitializeComponent();
            LoadDashboard();

        }

        private void LoadDashboard()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // 1. Total Employees
                SqlCommand cmdEmp = new SqlCommand("SELECT COUNT(*) FROM Employees WHERE Status = 'Active';", conn);
                totalEmployeeLbl.Text = cmdEmp.ExecuteScalar().ToString();

                // 2. Present Today
                SqlCommand cmdPresent = new SqlCommand("SELECT COUNT(*) FROM Attendance WHERE CAST(Date AS DATE) = CAST(GETDATE() AS DATE) AND Status = 'Present'", conn);
                int present = Convert.ToInt32(cmdPresent.ExecuteScalar());
                presentTodayLbl.Text = present.ToString();

                // 3. Absent Today
                SqlCommand cmdAbsent = new SqlCommand("SELECT COUNT(*) FROM Attendance WHERE CAST(Date AS DATE) = CAST(GETDATE() AS DATE) AND Status = 'Absent';", conn);
                int absent = Convert.ToInt32(cmdAbsent.ExecuteScalar());
                absentTodayLbl.Text = absent.ToString();

                // 4. Month Payroll (sum of paid or pending batches this month)
                SqlCommand cmdPayroll = new SqlCommand("SELECT ISNULL(SUM(total_net_pay),0) FROM Payroll_Batch WHERE MONTH(payment_date) = MONTH(GETDATE())  AND YEAR(payment_date) = YEAR(GETDATE());", conn);
                monthPayrollLbl.Text = "₱ " + Convert.ToDecimal(cmdPayroll.ExecuteScalar()).ToString("N2");

                // 5. Absent Rate Today
                int totalEmployees = Convert.ToInt32(totalEmployeeLbl.Text);
                if (totalEmployees > 0)
                {
                    int absentRate = (int)Math.Round((absent * 100.0) / totalEmployees);
                    progressBar1.Value = Math.Min(absentRate, 100); // ProgressBar safe range
                }

                // 6. Top 5 Absentees
                SqlCommand cmdTopAbsent = new SqlCommand(@"
                    SELECT TOP 5 
                        (E.FirstName + ' ' + E.LastName) AS Employee, 
                        COUNT(A.AttendanceID) AS AbsentDays
                    FROM Employees E
                    JOIN Attendance A ON E.EmployeeID = A.EmployeeID
                    WHERE A.Status = 'Absent'
                    GROUP BY E.FirstName, E.LastName
                    ORDER BY AbsentDays DESC", conn);

                SqlDataAdapter da = new SqlDataAdapter(cmdTopAbsent);
                DataTable dt = new DataTable();
                da.Fill(dt);
                AbsentDvg.DataSource = dt; // assuming you used a DataGridView

                // 7. Upcoming Payroll Batches
                SqlCommand cmdBatches = new SqlCommand(@"
                    SELECT TOP 5 batch_id, status, payment_date 
                    FROM Payroll_Batch
                    WHERE payment_date >= CAST(GETDATE() AS DATE)
                    ORDER BY payment_date", conn);
                SqlDataAdapter da2 = new SqlDataAdapter(cmdBatches);
                DataTable dt2 = new DataTable();
                da2.Fill(dt2);
                PayrollDvg.DataSource = dt2; // another DataGridView
            }
        }

        private void label1_Click(object sender, EventArgs e)
        {
            
        }
    }



}

