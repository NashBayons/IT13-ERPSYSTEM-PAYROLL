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
using static System.ComponentModel.Design.ObjectSelectorEditor;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace tryagain.Employee
{
    public partial class Attendance : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        private int _empId;
        public Attendance(int empId)
        {

            InitializeComponent();
            _empId = empId;
            LoadAttendanceHistory();
            UpdateCurrentDateAndStatus();
        }

        private void timeinBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Check if already has record for today
                SqlCommand checkCmd = new SqlCommand(
                    "SELECT COUNT(*) FROM Attendance WHERE employeeID=@EmpId AND date=CAST(GETDATE() AS DATE)", conn);
                checkCmd.Parameters.AddWithValue("@EmpId", _empId);

                int count = (int)checkCmd.ExecuteScalar();

                if (count == 0) // No record yet, allow Time In
                {
                    SqlCommand insertCmd = new SqlCommand(@"
                INSERT INTO Attendance (employeeID, date, timeIn, status)
                VALUES (@EmpId, CAST(GETDATE() AS DATE), CAST(GETDATE() AS TIME),
                        CASE WHEN DATEPART(HOUR, GETDATE()) > 8 THEN 'Late' ELSE 'Present' END)", conn);
                    insertCmd.Parameters.AddWithValue("@EmpId", _empId);
                    insertCmd.ExecuteNonQuery();

                    MessageBox.Show("Time In recorded successfully!");
                }
                else
                {
                    MessageBox.Show("You already have an attendance record for today.");
                }

                LoadAttendanceHistory();
            }
        }

        private void timeoutBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                // Update today's record with Time Out
                SqlCommand updateCmd = new SqlCommand(@"
            UPDATE Attendance
            SET timeOut = CAST(GETDATE() AS TIME)
            WHERE employeeID = @EmpId AND date = CAST(GETDATE() AS DATE)", conn);

                updateCmd.Parameters.AddWithValue("@EmpId", _empId);

                int rows = updateCmd.ExecuteNonQuery();

                if (rows > 0)
                {
                    MessageBox.Show("Time Out recorded successfully!");
                }
                else
                {
                    MessageBox.Show("No attendance record found for today. Please Time In first.");
                }

                LoadAttendanceHistory();
            }
        }

        private void UpdateCurrentDateAndStatus()
        {
            try
            {
                // Update current date label
                dateNowLabel.Text = DateTime.Now.ToString("dddd, MMMM dd, yyyy");
                // Example output: "Wednesday, October 08, 2025"

                // Get and display current attendance status
                string status = GetTodayAttendanceStatus();
                statusLabel.Text = status;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating status: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetTodayAttendanceStatus()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    string query = @"
                SELECT TOP 1
                    timeIn,
                    timeOut,
                    status
                FROM Attendance
                WHERE employeeID = @EmpId 
                  AND CAST(date AS DATE) = CAST(GETDATE() AS DATE)
                ORDER BY date DESC;";

                    using (SqlCommand cmd = new SqlCommand(query, conn))
                    {
                        cmd.Parameters.AddWithValue("@EmpId", _empId);

                        using (SqlDataReader reader = cmd.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Check if timeOut exists (user has clocked out)
                                if (reader["timeOut"] != DBNull.Value)
                                {
                                    TimeSpan timeOut = (TimeSpan)reader["timeOut"];
                                    DateTime timeOutDateTime = DateTime.Today.Add(timeOut);
                                    return $"Time Out at {timeOutDateTime.ToString("h:mm tt")}";
                                }
                                // Check if timeIn exists (user has clocked in but not out)
                                else if (reader["timeIn"] != DBNull.Value)
                                {
                                    TimeSpan timeIn = (TimeSpan)reader["timeIn"];
                                    DateTime timeInDateTime = DateTime.Today.Add(timeIn);
                                    return $"Time In at {timeInDateTime.ToString("h:mm tt")}";
                                }
                                else
                                {
                                    return "No attendance record";
                                }
                            }
                            else
                            {
                                // No record for today
                                return "Not clocked in yet";
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                return $"Error: {ex.Message}";
            }
        }

        private void LoadAttendanceHistory()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    string LoadAttendanceQuery = @"
                        SELECT 
                            CONVERT(VARCHAR(10), date, 101) AS [Date],
                            FORMAT(CAST(timeIn AS DATETIME), 'hh:mm tt') AS [Time In],
                            FORMAT(CAST(timeOut AS DATETIME), 'hh:mm tt') AS [Time Out],
                            status AS [Status]
                        FROM Attendance
                        WHERE employeeID = @EmpId
                        ORDER BY date DESC;";

                    SqlCommand cmd = new SqlCommand(LoadAttendanceQuery, conn);
                    cmd.Parameters.AddWithValue("@EmpId", _empId);
                    SqlDataAdapter adapter = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);

                    attendanceDvg.DataSource = dt;
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading attendance history: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
