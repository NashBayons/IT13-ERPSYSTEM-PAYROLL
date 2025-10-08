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
    public partial class dashboardForm : Form
    {
        public dashboardForm()
        {
            InitializeComponent();
        }

        private void LoadAttendanceChart()
        {
            chartAttendance.Series.Clear();
            chartAttendance.ChartAreas.Clear();

            chartAttendance.ChartAreas.Add(new ChartArea("MainArea"));
            Series series = new Series("Attendance");
            series.ChartType = SeriesChartType.Pie;

            // Example data (replace with SQL query results)
            series.Points.AddXY("Present", 35);
            series.Points.AddXY("Absent", 5);
            series.Points.AddXY("On Leave", 2);
            series.Points.AddXY("Late", 3);

            chartAttendance.Series.Add(series);
        }

    }
}
