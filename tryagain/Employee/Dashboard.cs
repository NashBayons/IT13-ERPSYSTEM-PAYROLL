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

namespace tryagain.Employee
{
    public partial class Dashboard : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _empId;
        public Dashboard(int empId)
        {
            InitializeComponent();
            _empId = empId;
            Dashboard_Load();
        }

        private void Dashboard_Load()
        {
            LoadEmployeeInfo();
            LoadAttendanceToday();
            LoadPayrollSnapshot();
            LoadLeaveSummary();

            // Date and live time
            datenowLabel.Text = DateTime.Now.ToString("MMMM dd, yyyy");
            timer1.Interval = 1000; // every second
            timer1.Tick += (s, ev) => timenowLabel.Text = DateTime.Now.ToString("hh:mm:ss tt");
            timer1.Start();
        }

        private void LoadEmployeeInfo()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
            SELECT 
                e.firstname, 
                e.lastname, 
                d.name AS DepartmentName, 
                p.name AS PositionName
            FROM Employees e
            LEFT JOIN Department d ON e.departmentID = d.dept_id
            LEFT JOIN Position p ON e.positionID = p.position_id
            WHERE e.employeeid = @EmpId";

                SqlCommand cmd = new SqlCommand(query, conn);
                cmd.Parameters.AddWithValue("@EmpId", _empId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string fullName = $"{reader["firstname"]} {reader["lastname"]}";
                        string position = reader["PositionName"] == DBNull.Value ? "N/A" : reader["PositionName"].ToString();
                        string department = reader["DepartmentName"] == DBNull.Value ? "N/A" : reader["DepartmentName"].ToString();

                        namePositionTxt.Text = $"{fullName} ({position} - {department})";
                    }
                    else
                    {
                        namePositionTxt.Text = "Employee not found.";
                    }
                }
            }
        }

        private void LoadAttendanceToday()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT timeIn, timeOut, status FROM Attendance WHERE employeeID=@EmpId AND date=CAST(GETDATE() AS DATE)", conn);
                cmd.Parameters.AddWithValue("@EmpId", _empId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        timeinLabel.Text = reader["timeIn"] == DBNull.Value ? "Not yet" : DateTime.Today.Add((TimeSpan)reader["timeIn"]).ToString("hh:mm tt");
                        timeoutLabel.Text = reader["timeOut"] == DBNull.Value ? "Pending" : DateTime.Today.Add((TimeSpan)reader["timeOut"]).ToString("hh:mm tt");
                        attendancestatusLabel.Text = reader["status"].ToString();

                        if (reader["timeIn"] != DBNull.Value && reader["timeOut"] != DBNull.Value)
                        {
                            TimeSpan inTime = (TimeSpan)reader["timeIn"];
                            TimeSpan outTime = (TimeSpan)reader["timeOut"];
                            hoursworkedLabel.Text = (outTime - inTime).TotalHours.ToString("0.0") + " hrs";
                        }
                        else
                        {
                            hoursworkedLabel.Text = "N/A";
                        }
                    }
                    else
                    {
                        timeinLabel.Text = timeoutLabel.Text = attendancestatusLabel.Text = hoursworkedLabel.Text = "N/A";
                    }
                }
            }
        }

        private void LoadPayrollSnapshot()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT TOP 1 pb.pay_period_start, pb.pay_period_end, pb.payment_date, pr.net_pay
            FROM Payroll_Record pr
            JOIN Payroll_Batch pb ON pr.batch_id = pb.batch_id
            WHERE pr.employee_id = @EmpId
            ORDER BY pb.pay_period_start DESC", conn);

                cmd.Parameters.AddWithValue("@EmpId", _empId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        batchLabel.Text = $"{Convert.ToDateTime(reader["pay_period_start"]).ToShortDateString()} - {Convert.ToDateTime(reader["pay_period_end"]).ToShortDateString()}";
                        lastnetpayLabel.Text = "₱" + Convert.ToDecimal(reader["net_pay"]).ToString("N2");
                        paidonLabel.Text = Convert.ToDateTime(reader["payment_date"]).ToShortDateString();
                        // Next batch would depend on your payroll logic
                        nextbatchLabel.Text = "Next scheduled run";
                    }
                    else
                    {
                        batchLabel.Text = lastnetpayLabel.Text = paidonLabel.Text = nextbatchLabel.Text = "N/A";
                    }
                }
            }
        }

        private void LoadLeaveSummary()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT 
                SUM(CASE WHEN status = 'Pending' THEN 1 ELSE 0 END) AS Pending,
                SUM(CASE WHEN status = 'Approved' THEN 1 ELSE 0 END) AS Approved,
                SUM(CASE WHEN status = 'Approved' AND start_date >= CAST(GETDATE() AS DATE) THEN 1 ELSE 0 END) AS Upcoming
            FROM leave_record
            WHERE employee_id = @EmpId", conn);

                cmd.Parameters.AddWithValue("@EmpId", _empId);

                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        pendingleaveLabel.Text = reader["Pending"].ToString();
                        approveleaveLabel.Text = reader["Approved"].ToString();
                        upcominglabelLeave.Text = reader["Upcoming"].ToString();
                    }
                }
            }
        }

    }
}
