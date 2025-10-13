using ClosedXML.Excel;
using DocumentFormat.OpenXml.Bibliography;
using iTextSharp.text;
using iTextSharp.text.pdf;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class ReportsForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public ReportsForm()
        {
            InitializeComponent();
            LoadDepartments();
        }


        private void LoadAttendanceReport(DateTime fromDate, DateTime toDate, int? departmentId = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT 
                e.employeeid,
                (e.firstname + ' ' + e.lastname) AS FullName,
                ISNULL(SUM(CASE WHEN a.status = 'Present' THEN 1 ELSE 0 END),0) AS Present,
                ISNULL(SUM(CASE WHEN a.status = 'Absent' THEN 1 ELSE 0 END),0) AS Absent,
                ISNULL(SUM(CASE WHEN a.status IN ('On Leave','Leave') THEN 1 ELSE 0 END),0) AS LeaveDays,
                ISNULL(SUM(CASE WHEN a.status = 'Late' THEN 1 ELSE 0 END),0) AS Late
            FROM Attendance a
            JOIN Employees e ON a.employeeid = e.employeeid
            WHERE a.[date] BETWEEN @FromDate AND @ToDate
            /**DEPT_CONDITION**/
            GROUP BY e.employeeid, e.firstname, e.lastname
            ORDER BY FullName;
        ";

                if (departmentId.HasValue)
                    sql = sql.Replace("/**DEPT_CONDITION**/", "AND e.DepartmentID = @DeptId");
                else
                    sql = sql.Replace("/**DEPT_CONDITION**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (departmentId.HasValue)
                        cmd.Parameters.AddWithValue("@DeptId", departmentId.Value);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    int totalEmployees = dt.Rows.Count;
                    int totalDays = (toDate - fromDate).Days + 1;
                    summaryLbl.Text = $"Total Employees: {totalEmployees}    Total Days: {totalDays}";
                }
            }
        }

        private void LoadPayrollReport(DateTime fromDate, DateTime toDate, int? departmentId = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT 
                pb.pay_period_start,
                pb.pay_period_end,
                pb.payment_date,
                COUNT(DISTINCT pr.employee_id) AS TotalEmployees,
                ISNULL(SUM(pr.base_pay),0) AS TotalBasePay,
                ISNULL(SUM(pr.gross_salary),0) AS TotalGrossPay,
                ISNULL(SUM(pr.deductions_total),0) AS TotalDeductions,
                ISNULL(SUM(pr.bonus_amount),0) AS TotalBonuses,
                ISNULL(SUM(pr.net_pay),0) AS TotalNetPay
            FROM Payroll_Record pr
            JOIN Payroll_Batch pb ON pr.batch_id = pb.batch_id
            JOIN Employees e ON pr.employee_id = e.employeeid
            WHERE pb.payment_date BETWEEN @FromDate AND @ToDate
            /**DEPT_CONDITION**/
            GROUP BY pb.pay_period_start, pb.pay_period_end, pb.payment_date
            ORDER BY pb.pay_period_start DESC;
        ";

                if (departmentId.HasValue)
                    sql = sql.Replace("/**DEPT_CONDITION**/", "AND e.DepartmentID = @DeptId");
                else
                    sql = sql.Replace("/**DEPT_CONDITION**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (departmentId.HasValue)
                        cmd.Parameters.AddWithValue("@DeptId", departmentId.Value);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    int totalEmployees = dt.AsEnumerable().Sum(r => r.Field<int>("TotalEmployees"));
                    decimal totalPayroll = dt.AsEnumerable().Sum(r => r.Field<decimal>("TotalNetPay"));

                    summaryLbl.Text = $"Total Employees Paid: {totalEmployees}    Total Payroll Disbursed: ₱{totalPayroll:N2}";
                }
            }
        }

        private void LoadLeaveReport(DateTime fromDate, DateTime toDate, int? departmentId = null)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT 
                e.employeeid,
                (e.firstname + ' ' + e.lastname) AS FullName,
                lr.leave_type,
                lr.start_date,
                lr.end_date,
                lr.status,
                lr.remarks
            FROM Leave_Record lr
            JOIN Employees e ON lr.employee_id = e.employeeid
            WHERE lr.start_date BETWEEN @FromDate AND @ToDate
            /**DEPT_CONDITION**/
            ORDER BY lr.start_date DESC;
        ";

                if (departmentId.HasValue)
                    sql = sql.Replace("/**DEPT_CONDITION**/", "AND e.DepartmentID = @DeptId");
                else
                    sql = sql.Replace("/**DEPT_CONDITION**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (departmentId.HasValue)
                        cmd.Parameters.AddWithValue("@DeptId", departmentId.Value);

                    DataTable dt = new DataTable();
                    using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                        da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    int totalRequests = dt.Rows.Count;
                    int approved = dt.AsEnumerable().Count(r => string.Equals(r.Field<string>("status"), "Approved", StringComparison.OrdinalIgnoreCase));
                    int pending = dt.AsEnumerable().Count(r => string.Equals(r.Field<string>("status"), "Pending", StringComparison.OrdinalIgnoreCase));
                    int rejected = dt.AsEnumerable().Count(r => string.Equals(r.Field<string>("status"), "Rejected", StringComparison.OrdinalIgnoreCase));

                    summaryLbl.Text = $"Total Requests: {totalRequests}   Approved: {approved}   Pending: {pending}   Rejected: {rejected}";
                }
            }
        }


        private void generateBtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = datefromPicker.Value.Date;
            DateTime toDate = datetoPicker.Value.Date;
            int? departmentId = GetSelectedDepartmentId();
            string reportType = reportTypeCmb.SelectedItem?.ToString();

            if (reportType == "Attendance Summary")
            {
                LoadAttendanceReport(fromDate, toDate, departmentId);
            }
            else if (reportType == "Payroll")
            {
                LoadPayrollReport(fromDate, toDate, departmentId);
            }
            else if (reportType == "Leave")
            {
                LoadLeaveReport(fromDate, toDate, departmentId);
            }
        }

        private void expCSVBtn_Click(object sender, EventArgs e)
        {
            if (reportsDvg.DataSource == null || reportsDvg.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "Excel Workbook|*.xlsx", FileName = "Report.xlsx" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    DataTable dt = reportsDvg.DataSource as DataTable;

                    using (XLWorkbook wb = new XLWorkbook())
                    {
                        // Add table first (ClosedXML will place headers at row 1)
                        var ws = wb.Worksheets.Add(dt, "Report");

                        // Insert 2 rows ABOVE the table (shift everything down)
                        ws.Row(1).InsertRowsAbove(2);

                        // Title (Row 1)
                        ws.Cell(1, 1).Value = "ERP Report";
                        ws.Range(1, 1, 1, dt.Columns.Count).Merge().Style
                            .Font.SetBold().Font.SetFontSize(16)
                            .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Center);

                        // Summary (Row 2)
                        if (!string.IsNullOrEmpty(summaryLbl.Text))
                        {
                            ws.Cell(2, 1).Value = summaryLbl.Text;
                            ws.Range(2, 1, 2, dt.Columns.Count).Merge().Style
                                .Font.SetItalic()
                                .Alignment.SetHorizontal(XLAlignmentHorizontalValues.Left);
                        }

                        // Auto adjust column widths
                        ws.Columns().AdjustToContents();

                        wb.SaveAs(sfd.FileName);
                    }

                    MessageBox.Show("Excel file saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting Excel: " + ex.Message);
                }
            }
        }

        private void expPDFBtn_Click(object sender, EventArgs e)
        {
            if (reportsDvg.DataSource == null || reportsDvg.Rows.Count == 0)
            {
                MessageBox.Show("No data to export.");
                return;
            }

            using (SaveFileDialog sfd = new SaveFileDialog { Filter = "PDF File|*.pdf", FileName = "Report.pdf" })
            {
                if (sfd.ShowDialog() != DialogResult.OK) return;

                try
                {
                    using (FileStream fs = new FileStream(sfd.FileName, FileMode.Create, FileAccess.Write))
                    {
                        // create document
                        Document doc = new Document(PageSize.A4, 20f, 20f, 20f, 20f);
                        PdfWriter.GetInstance(doc, fs);
                        doc.Open();

                        // Fonts (construct directly to avoid FontFactory overload issues)
                        var titleFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 16f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        var headerFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 11f, iTextSharp.text.Font.BOLD, BaseColor.BLACK);
                        var cellFont = new iTextSharp.text.Font(iTextSharp.text.Font.FontFamily.HELVETICA, 10f, iTextSharp.text.Font.NORMAL, BaseColor.BLACK);

                        // Title
                        Paragraph title = new Paragraph("ERP Report", titleFont) { Alignment = Element.ALIGN_CENTER };
                        doc.Add(title);
                        doc.Add(new Paragraph("\n"));

                        // Add summary label text if available (e.g., totals)
                        string summaryText = (summaryLbl != null) ? summaryLbl.Text : string.Empty;
                        if (!string.IsNullOrWhiteSpace(summaryText))
                        {
                            Paragraph summary = new Paragraph(summaryText, headerFont) { Alignment = Element.ALIGN_LEFT };
                            doc.Add(summary);
                            doc.Add(new Paragraph("\n"));
                        }

                        // Build PDF table with the same number of columns
                        PdfPTable pdfTable = new PdfPTable(reportsDvg.ColumnCount)
                        {
                            WidthPercentage = 100
                        };

                        // Add headers
                        foreach (DataGridViewColumn column in reportsDvg.Columns)
                        {
                            PdfPCell headerCell = new PdfPCell(new Phrase(column.HeaderText ?? string.Empty, headerFont))
                            {
                                BackgroundColor = new BaseColor(235, 235, 235),
                                HorizontalAlignment = Element.ALIGN_CENTER,
                                Padding = 4
                            };
                            pdfTable.AddCell(headerCell);
                        }

                        // Add rows
                        foreach (DataGridViewRow row in reportsDvg.Rows)
                        {
                            if (row.IsNewRow) continue;
                            foreach (DataGridViewCell cell in row.Cells)
                            {
                                string text = cell.Value?.ToString() ?? string.Empty;
                                PdfPCell dataCell = new PdfPCell(new Phrase(text, cellFont)) { Padding = 4 };
                                pdfTable.AddCell(dataCell);
                            }
                        }

                        doc.Add(pdfTable);

                        // Optional: add generation info/footer
                        doc.Add(new Paragraph("\n"));
                        var genInfo = new Paragraph($"Generated: {DateTime.Now:G}", cellFont) { Alignment = Element.ALIGN_RIGHT };
                        doc.Add(genInfo);

                        doc.Close();
                    }

                    MessageBox.Show("PDF file saved successfully.");
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error exporting PDF: " + ex.Message);
                }
            }
        }

        private void LoadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter(
                    "SELECT dept_id, name FROM Department WHERE status = 1 ORDER BY name", conn);

                DataTable dt = new DataTable();
                da.Fill(dt);

                // Create a copy so we can insert "All" row without modifying original schema
                DataTable dtWithAll = dt.Clone();
                dtWithAll.Columns["dept_id"].DataType = typeof(int); // ensure type
                dtWithAll.Rows.Add(DBNull.Value, "All"); // Position 0 -> All

                // Merge the real departments
                foreach (DataRow r in dt.Rows)
                    dtWithAll.ImportRow(r);

                DeparmentCmb.DisplayMember = "name";
                DeparmentCmb.ValueMember = "dept_id";
                DeparmentCmb.DataSource = dtWithAll;

                if (dt.Rows.Count > 0)
                {
                    DeparmentCmb.SelectedIndex = 0;
                }
            }
        }

        private int? GetSelectedDepartmentId()
        {
            if (DeparmentCmb.SelectedValue == null || DeparmentCmb.SelectedValue == DBNull.Value)
                return null;
            return Convert.ToInt32(DeparmentCmb.SelectedValue);
        }
    }

}

