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
using System.Windows.Forms.DataVisualization.Charting;


namespace tryagain.Admin
{
    public partial class DashboardwithCharts : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        public DashboardwithCharts()
        {
            InitializeComponent();
            // CRITICAL: Call the chart configuration after the form loads
            this.Load += DashboardwithCharts_Load;
        }

        private void DashboardwithCharts_Load(object sender, EventArgs e)
        {
            // Call your chart configuration method here
            ConfigureAttendanceChart();
            ConfigurePayrollChart();
            ConfigureLeaveChart();
        }

        public void ConfigureAttendanceChart()
        {
            // The number of days back you want to display (e.g., last 30 days)
            const int DAYS_TO_DISPLAY = 30;

            // 1. Get the data from the DB
            List<DailyAttendance> attendanceData = GetAttendanceDataFromDb(DAYS_TO_DISPLAY);

            // Get total employee count for context
            int totalEmployees = GetTotalEmployeeCount();

            // Ensure the chart is clean before binding
            attendanceChart.Series.Clear();
            attendanceChart.ChartAreas.Clear();
            attendanceChart.Titles.Clear();

            // Handle case where no data is returned
            if (attendanceData.Count == 0)
            {
                attendanceChart.Titles.Add("No Attendance Data Available");
                // Add a default chart area even with no data
                ChartArea emptyArea = new ChartArea("EmptyArea");
                attendanceChart.ChartAreas.Add(emptyArea);
                return;
            }

            // 2. Add Chart Area and Title
            ChartArea chartArea1 = new ChartArea("MainArea");
            attendanceChart.ChartAreas.Add(chartArea1);

            // Add title with employee count context
            Title mainTitle = new Title($"Attendance Rate Trend (Last {DAYS_TO_DISPLAY} Days)");
            mainTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            attendanceChart.Titles.Add(mainTitle);

            // Add subtitle with employee count
            Title subTitle = new Title($"Total Employees: {totalEmployees}");
            subTitle.Font = new Font("Arial", 10, FontStyle.Regular);
            subTitle.ForeColor = Color.Gray;
            subTitle.Docking = Docking.Top;
            attendanceChart.Titles.Add(subTitle);

            // 3. Create and Configure the Series
            Series series1 = new Series("Present Rate");
            series1.ChartType = SeriesChartType.Line;
            series1.BorderWidth = 3;
            series1.Color = Color.DodgerBlue;

            series1.MarkerStyle = MarkerStyle.Circle;
            series1.MarkerSize = 6;
            series1.MarkerColor = Color.DarkBlue;
            series1.IsValueShownAsLabel = false;

            attendanceChart.Series.Add(series1);

            // 4. Bind the Data
            series1.Points.DataBind(attendanceData, "Date", "PresentPercentage", "");

            // 5. Configure Axes for Clarity

            // X-Axis (Dates)
            chartArea1.AxisX.Title = "Date";
            chartArea1.AxisX.IntervalType = DateTimeIntervalType.Days;
            chartArea1.AxisX.LabelStyle.Interval = DAYS_TO_DISPLAY > 14 ? 7 : 1;
            chartArea1.AxisX.LabelStyle.Format = "MMM dd";
            chartArea1.AxisX.LabelStyle.Angle = -45; // Angle labels for better readability
            chartArea1.AxisX.MajorGrid.LineColor = Color.LightGray;

            // Y-Axis (Percentage) - FIXED: Better minimum calculation
            double minPercentage = attendanceData.Min(d => d.PresentPercentage);
            double maxPercentage = attendanceData.Max(d => d.PresentPercentage);

            // Set a reasonable minimum (at least 10% below the lowest value, but not below 0)
            chartArea1.AxisY.Minimum = Math.Max(0, Math.Floor(minPercentage - 10));
            chartArea1.AxisY.Maximum = Math.Min(100, Math.Ceiling(maxPercentage + 5));

            chartArea1.AxisY.Title = "Present Percentage (%)";
            chartArea1.AxisY.Interval = 10; // Changed to 10% for better readability
            chartArea1.AxisY.LabelStyle.Format = "0'%'";
            chartArea1.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Optional: Add a 100% goal line if max is near 100%
            if (maxPercentage > 85)
            {
                StripLine goalLine = new StripLine();
                goalLine.IntervalOffset = 100;
                goalLine.StripWidth = 0.5;
                goalLine.BackColor = Color.Green;
                goalLine.BorderColor = Color.DarkGreen;
                goalLine.BorderDashStyle = ChartDashStyle.Dash;
                chartArea1.AxisY.StripLines.Add(goalLine);
            }

            // Force the chart to refresh
            attendanceChart.Invalidate();
        }

        private List<DailyAttendance> GetAttendanceDataFromDb(int daysBack)
        {
            var attendanceData = new List<DailyAttendance>();

            // Calculate the start date for the trend
            DateTime startDate = DateTime.Today.AddDays(-daysBack);

            string sql = @"
                WITH DailyStatus AS (
                    SELECT 
                        CAST(Date AS DATE) AS AttendanceDate,
                        COUNT(CASE WHEN Status = 'Present' THEN 1 END) AS PresentCount,
                        COUNT(EmployeeID) AS TotalCount
                    FROM 
                        Attendance
                    WHERE 
                        Date >= @StartDate
                    GROUP BY 
                        CAST(Date AS DATE)
                )
                SELECT 
                    AttendanceDate, 
                    (CAST(PresentCount AS FLOAT) / TotalCount) * 100 AS PresentPercentage
                FROM 
                    DailyStatus
                ORDER BY 
                    AttendanceDate;
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        attendanceData.Add(new DailyAttendance
                        {
                            Date = reader.GetDateTime(0),
                            PresentPercentage = reader.GetDouble(1)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return attendanceData;
        }

        private int GetTotalEmployeeCount()
        {
            int totalEmployees = 0;

            // You might want to query from an Employees table instead if you have one
            // For now, this counts distinct employees from Attendance table
            string sql = "SELECT COUNT(DISTINCT EmployeeID) FROM Attendance";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    object result = command.ExecuteScalar();
                    if (result != null && result != DBNull.Value)
                    {
                        totalEmployees = Convert.ToInt32(result);
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error getting employee count: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return totalEmployees;
        }

        public void ConfigurePayrollChart()
        {
            const int MONTHS_TO_DISPLAY = 6;

            // Get payroll data
            List<MonthlyPayroll> payrollData = GetPayrollDataFromDb(MONTHS_TO_DISPLAY);

            // Clear existing chart
            chartPayroll.Series.Clear();
            chartPayroll.ChartAreas.Clear();
            chartPayroll.Titles.Clear();
            chartPayroll.Legends.Clear();

            if (payrollData.Count == 0)
            {
                chartPayroll.Titles.Add("No Payroll Data Available");
                ChartArea emptyArea = new ChartArea("EmptyArea");
                chartPayroll.ChartAreas.Add(emptyArea);
                return;
            }

            // Add Chart Area
            ChartArea chartArea = new ChartArea("PayrollArea");
            chartPayroll.ChartAreas.Add(chartArea);

            // Add Title
            Title mainTitle = new Title($"Payroll Breakdown (Last {MONTHS_TO_DISPLAY} Months)");
            mainTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            chartPayroll.Titles.Add(mainTitle);

            // Calculate total payroll for context
            decimal totalPayroll = payrollData.Sum(p => p.NetPay);
            Title subTitle = new Title($"Total Paid: ₱{totalPayroll:N2}");
            subTitle.Font = new Font("Arial", 10, FontStyle.Regular);
            subTitle.ForeColor = Color.Gray;
            chartPayroll.Titles.Add(subTitle);

            // Create Series for Base Pay
            Series basePaySeries = new Series("Base Pay");
            basePaySeries.ChartType = SeriesChartType.StackedColumn;
            basePaySeries.Color = Color.FromArgb(52, 152, 219); // Blue
            basePaySeries.BorderWidth = 1;
            basePaySeries.BorderColor = Color.White;

            // Create Series for Bonuses
            Series bonusSeries = new Series("Bonuses");
            bonusSeries.ChartType = SeriesChartType.StackedColumn;
            bonusSeries.Color = Color.FromArgb(46, 204, 113); // Green
            bonusSeries.BorderWidth = 1;
            bonusSeries.BorderColor = Color.White;

            // Create Series for Deductions (shown as negative impact)
            Series deductionSeries = new Series("Deductions");
            deductionSeries.ChartType = SeriesChartType.StackedColumn;
            deductionSeries.Color = Color.FromArgb(231, 76, 60); // Red
            deductionSeries.BorderWidth = 1;
            deductionSeries.BorderColor = Color.White;

            // Add data points
            foreach (var data in payrollData)
            {
                basePaySeries.Points.AddXY(data.MonthYear, data.BasePay);
                bonusSeries.Points.AddXY(data.MonthYear, data.BonusAmount);
                // Deductions shown as negative to illustrate reduction
                deductionSeries.Points.AddXY(data.MonthYear, -data.Deductions);
            }

            // Add series to chart
            chartPayroll.Series.Add(basePaySeries);
            chartPayroll.Series.Add(bonusSeries);
            chartPayroll.Series.Add(deductionSeries);

            // Configure X-Axis
            chartArea.AxisX.Title = "Month";
            chartArea.AxisX.MajorGrid.LineColor = Color.LightGray;
            chartArea.AxisX.LabelStyle.Angle = -45;
            chartArea.AxisX.Interval = 1;

            // Configure Y-Axis
            chartArea.AxisY.Title = "Amount (₱)";
            chartArea.AxisY.LabelStyle.Format = "₱#,##0";
            chartArea.AxisY.MajorGrid.LineColor = Color.LightGray;

            // Add Legend
            Legend legend = new Legend("PayrollLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 9);
            chartPayroll.Legends.Add(legend);

            // Add a line at zero to show the deduction separation
            StripLine zeroLine = new StripLine();
            zeroLine.IntervalOffset = 0;
            zeroLine.StripWidth = 0.5;
            zeroLine.BackColor = Color.Black;
            chartArea.AxisY.StripLines.Add(zeroLine);

            // Refresh chart
            chartPayroll.Invalidate();
        }

        private List<MonthlyPayroll> GetPayrollDataFromDb(int monthsBack)
        {
            var payrollData = new List<MonthlyPayroll>();
            DateTime startDate = DateTime.Today.AddMonths(-monthsBack);

            string sql = @"
                SELECT 
                    FORMAT(pb.pay_period_start, 'MMM yyyy') AS MonthYear,
                    pb.pay_period_start,
                    SUM(pr.base_pay) AS TotalBasePay,
                    SUM(pr.bonus_amount) AS TotalBonus,
                    SUM(pr.deductions_total) AS TotalDeductions,
                    SUM(pr.net_pay) AS TotalNetPay
                FROM 
                    Payroll_Batch pb
                INNER JOIN 
                    Payroll_Record pr ON pb.batch_id = pr.batch_id
                WHERE 
                    pb.pay_period_start >= @StartDate
                    AND pb.status = 'paid'
                GROUP BY 
                    FORMAT(pb.pay_period_start, 'MMM yyyy'),
                    pb.pay_period_start
                ORDER BY 
                    pb.pay_period_start;
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);
                command.Parameters.AddWithValue("@StartDate", startDate);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        payrollData.Add(new MonthlyPayroll
                        {
                            MonthYear = reader.GetString(0),
                            PeriodStart = reader.GetDateTime(1),
                            BasePay = reader.GetDecimal(2),
                            BonusAmount = reader.GetDecimal(3),
                            Deductions = reader.GetDecimal(4),
                            NetPay = reader.GetDecimal(5)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return payrollData;
        }

        public void ConfigureLeaveChart()
        {
            // Get leave distribution data
            List<LeaveTypeData> leaveData = GetLeaveDistributionFromDb();

            // Clear existing chart
            chartLeave.Series.Clear();
            chartLeave.ChartAreas.Clear();
            chartLeave.Titles.Clear();
            chartLeave.Legends.Clear();

            if (leaveData.Count == 0)
            {
                chartLeave.Titles.Add("No Leave Data Available");
                ChartArea emptyArea = new ChartArea("EmptyArea");
                chartLeave.ChartAreas.Add(emptyArea);
                return;
            }

            // Add Chart Area
            ChartArea chartArea = new ChartArea("LeaveArea");
            chartArea.BackColor = Color.Transparent;
            chartLeave.ChartAreas.Add(chartArea);

            // Add Title
            Title mainTitle = new Title("Leave Type Distribution");
            mainTitle.Font = new Font("Arial", 14, FontStyle.Bold);
            chartLeave.Titles.Add(mainTitle);

            // Calculate totals for subtitle
            int totalLeaveRequests = leaveData.Sum(l => l.Count);
            int totalDays = leaveData.Sum(l => l.TotalDays);
            Title subTitle = new Title($"Total Requests: {totalLeaveRequests} | Total Days: {totalDays}");
            subTitle.Font = new Font("Arial", 10, FontStyle.Regular);
            subTitle.ForeColor = Color.Gray;
            chartLeave.Titles.Add(subTitle);

            // Create Donut Chart Series
            Series series = new Series("LeaveTypes");
            series.ChartType = SeriesChartType.Doughnut;
            series.IsValueShownAsLabel = true;
            series.Font = new Font("Arial", 10, FontStyle.Bold);
            series.LabelForeColor = Color.White;

            // Format labels to show percentage
            series["PieLabelStyle"] = "Outside";
            series.LabelFormat = "P1";
            series.Label = "#PERCENT";
            //series.LegendText = "#VALX (#VALY)";.
            series.IsVisibleInLegend = false;

            // Set donut hole size (makes it a donut instead of pie)
            series["DoughnutRadius"] = "40";

            // Define colors for each leave type
            Color[] leaveColors = new Color[]
            {
                Color.FromArgb(52, 152, 219),   // Blue - Vacation
                Color.FromArgb(231, 76, 60),    // Red - Sick
                Color.FromArgb(241, 196, 15),   // Yellow - Emergency
                Color.FromArgb(149, 165, 166)   // Gray - Other
            };

            // Add data points with custom colors
            int colorIndex = 0;
            foreach (var leave in leaveData)
            {
                DataPoint point = new DataPoint();
                point.SetValueXY(leave.LeaveType, leave.Count);
                point.Color = leaveColors[colorIndex % leaveColors.Length];


                point.Label = $"#VALX\n(#PERCENT)";

                // Add custom property to show days in tooltip
                point.ToolTip = $"{leave.LeaveType}\nRequests: {leave.Count}\nTotal Days: {leave.TotalDays}";

                series.Points.Add(point);
                colorIndex++;
            }

            chartLeave.Series.Add(series);

            // Configure Legend
            Legend legend = new Legend("LeaveLegend");
            legend.Docking = Docking.Bottom;
            legend.Alignment = StringAlignment.Center;
            legend.Font = new Font("Arial", 10);
            legend.LegendStyle = LegendStyle.Table;
            legend.TableStyle = LegendTableStyle.Wide;
            chartLeave.Legends.Add(legend);

            // Optional: Add a custom legend with more details
            legend.CustomItems.Clear();
            foreach (var leave in leaveData)
            {
                LegendItem item = new LegendItem();
                item.Name = leave.LeaveType;

                // Add color box
                LegendCell colorCell = new LegendCell(LegendCellType.SeriesSymbol, "", ContentAlignment.MiddleCenter);
                item.Cells.Add(colorCell);

                // Add leave type name
                LegendCell nameCell = new LegendCell(LegendCellType.Text, leave.LeaveType, ContentAlignment.MiddleLeft);
                nameCell.Font = new Font("Arial", 9, FontStyle.Bold);
                item.Cells.Add(nameCell);

                // Add count
                LegendCell countCell = new LegendCell(LegendCellType.Text, $"{leave.Count} requests", ContentAlignment.MiddleLeft);
                countCell.Font = new Font("Arial", 9);
                countCell.ForeColor = Color.Gray;
                item.Cells.Add(countCell);

                // Add days
                LegendCell daysCell = new LegendCell(LegendCellType.Text, $"({leave.TotalDays} days)", ContentAlignment.MiddleLeft);
                daysCell.Font = new Font("Arial", 9);
                daysCell.ForeColor = Color.Gray;
                item.Cells.Add(daysCell);

                // Set the color based on leave type
                int idx = leaveData.IndexOf(leave);
                item.Color = leaveColors[idx % leaveColors.Length];

                legend.CustomItems.Add(item);
            }

            // Refresh chart
            chartLeave.Invalidate();
        }

        private List<LeaveTypeData> GetLeaveDistributionFromDb()
        {
            var leaveData = new List<LeaveTypeData>();

            // Query to get count and total days for each leave type
            // Only counting approved leaves for accurate distribution
            string sql = @"
                SELECT 
                    leave_type,
                    COUNT(*) AS LeaveCount,
                    SUM(DATEDIFF(DAY, start_date, end_date) + 1) AS TotalDays
                FROM 
                    Leave_Record
                WHERE 
                    status = 'Approved'
                GROUP BY 
                    leave_type
                ORDER BY 
                    LeaveCount DESC;
            ";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlCommand command = new SqlCommand(sql, connection);

                try
                {
                    connection.Open();
                    SqlDataReader reader = command.ExecuteReader();

                    while (reader.Read())
                    {
                        leaveData.Add(new LeaveTypeData
                        {
                            LeaveType = reader.GetString(0),
                            Count = reader.GetInt32(1),
                            TotalDays = reader.IsDBNull(2) ? 0 : reader.GetInt32(2)
                        });
                    }
                    reader.Close();
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Database Error: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }

            return leaveData;
        }
    }
}


public class DailyAttendance
{
    public DateTime Date { get; set; }
    public double PresentPercentage { get; set; }
}

public class MonthlyPayroll
{
    public string MonthYear { get; set; }
    public DateTime PeriodStart { get; set; }
    public decimal BasePay { get; set; }
    public decimal BonusAmount { get; set; }
    public decimal Deductions { get; set; }
    public decimal NetPay { get; set; }
}

public class LeaveTypeData
{
    public string LeaveType { get; set; }
    public int Count { get; set; }
    public int TotalDays { get; set; }
}