namespace tryagain.Admin
{
    partial class DashboardwithCharts
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea1 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend1 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series1 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea2 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series2 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea3 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend3 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series3 = new System.Windows.Forms.DataVisualization.Charting.Series();
            attendanceChart = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartPayroll = new System.Windows.Forms.DataVisualization.Charting.Chart();
            chartLeave = new System.Windows.Forms.DataVisualization.Charting.Chart();
            ((System.ComponentModel.ISupportInitialize)attendanceChart).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartPayroll).BeginInit();
            ((System.ComponentModel.ISupportInitialize)chartLeave).BeginInit();
            SuspendLayout();
            // 
            // attendanceChart
            // 
            chartArea1.Name = "ChartArea1";
            attendanceChart.ChartAreas.Add(chartArea1);
            legend1.Name = "Legend1";
            attendanceChart.Legends.Add(legend1);
            attendanceChart.Location = new Point(29, 22);
            attendanceChart.Name = "attendanceChart";
            series1.ChartArea = "ChartArea1";
            series1.Legend = "Legend1";
            series1.Name = "Series1";
            attendanceChart.Series.Add(series1);
            attendanceChart.Size = new Size(375, 375);
            attendanceChart.TabIndex = 0;
            attendanceChart.Text = "chart1";
            // 
            // chartPayroll
            // 
            chartArea2.Name = "ChartArea1";
            chartPayroll.ChartAreas.Add(chartArea2);
            legend2.Name = "Legend1";
            chartPayroll.Legends.Add(legend2);
            chartPayroll.Location = new Point(483, 22);
            chartPayroll.Name = "chartPayroll";
            series2.ChartArea = "ChartArea1";
            series2.Legend = "Legend1";
            series2.Name = "Series1";
            chartPayroll.Series.Add(series2);
            chartPayroll.Size = new Size(375, 375);
            chartPayroll.TabIndex = 1;
            chartPayroll.Text = "chart1";
            // 
            // chartLeave
            // 
            chartArea3.Name = "ChartArea1";
            chartLeave.ChartAreas.Add(chartArea3);
            legend3.Name = "Legend1";
            chartLeave.Legends.Add(legend3);
            chartLeave.Location = new Point(268, 403);
            chartLeave.Name = "chartLeave";
            series3.ChartArea = "ChartArea1";
            series3.Legend = "Legend1";
            series3.Name = "Series1";
            chartLeave.Series.Add(series3);
            chartLeave.Size = new Size(343, 278);
            chartLeave.TabIndex = 2;
            chartLeave.Text = "chart1";
            // 
            // DashboardwithCharts
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(964, 706);
            Controls.Add(chartLeave);
            Controls.Add(chartPayroll);
            Controls.Add(attendanceChart);
            FormBorderStyle = FormBorderStyle.None;
            Name = "DashboardwithCharts";
            Text = "DashboardwithCharts";
            ((System.ComponentModel.ISupportInitialize)attendanceChart).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartPayroll).EndInit();
            ((System.ComponentModel.ISupportInitialize)chartLeave).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private System.Windows.Forms.DataVisualization.Charting.Chart attendanceChart;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartPayroll;
        private System.Windows.Forms.DataVisualization.Charting.Chart chartLeave;
    }
}