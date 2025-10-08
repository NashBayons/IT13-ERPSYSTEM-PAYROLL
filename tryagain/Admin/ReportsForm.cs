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
using iTextSharp.text;
using iTextSharp.text.pdf;
using ClosedXML.Excel;
using System.IO;

namespace tryagain
{
    public partial class ReportsForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public ReportsForm()
        {
            InitializeComponent();
        }


        private void LoadAttendanceReport(DateTime fromDate, DateTime toDate, string department = "All")
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string sql = @"
            SELECT e.employeeid, 
                   (e.firstname + ' ' + e.lastname) AS FullName,
                   SUM(CASE WHEN a.status = 'Present' THEN 1 ELSE 0 END) AS Present,
                   SUM(CASE WHEN a.status = 'Absent' THEN 1 ELSE 0 END) AS Absent,
                   SUM(CASE WHEN a.status IN ('On Leave', 'Leave') THEN 1 ELSE 0 END) AS Leave,
                   SUM(CASE WHEN a.status = 'Late' THEN 1 ELSE 0 END) AS Late
            FROM Attendance a
            JOIN Employees e ON a.employeeid = e.employeeid
            WHERE a.date BETWEEN @FromDate AND @ToDate
            /**DEPT_FILTER**/
            GROUP BY e.employeeid, e.firstname, e.lastname
            ORDER BY FullName";

                // If filtering by department
                if (department != "All")
                    sql = sql.Replace("/**DEPT_FILTER**/", "AND e.department = @Department");
                else
                    sql = sql.Replace("/**DEPT_FILTER**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (department != "All")
                        cmd.Parameters.AddWithValue("@Department", department);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    int totalEmployees = dt.Rows.Count;

                    // ✅ Total days in selected range
                    int totalDays = (toDate - fromDate).Days + 1;

                    summaryLbl.Text = $"Total Employees: {totalEmployees}    Total Days: {totalDays}";
                }
            }
        }

        private void LoadPayrollReport(DateTime fromDate, DateTime toDate, string department = "All")
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
                SUM(pr.base_pay) AS TotalBasePay,
                SUM(pr.gross_salary) AS TotalGrossPay,
                SUM(pr.deductions_total) AS TotalDeductions,
                SUM(pr.bonus_amount) AS TotalBonuses,
                SUM(pr.net_pay) AS TotalNetPay
                FROM Payroll_Record pr
                JOIN Payroll_Batch pb ON pr.batch_id = pb.batch_id
                JOIN Employees e ON pr.employee_id = e.employeeid
                WHERE pb.payment_date BETWEEN @FromDate AND @ToDate
                /**DEPT_FILTER**/
                GROUP BY pb.pay_period_start, pb.pay_period_end, pb.payment_date
                ORDER BY pb.pay_period_start DESC";

                if (department != "All")
                    sql = sql.Replace("/**DEPT_FILTER**/", "AND e.department = @Department");
                else
                    sql = sql.Replace("/**DEPT_FILTER**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (department != "All")
                        cmd.Parameters.AddWithValue("@Department", department);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    // ✅ Summary across all batches
                    int totalEmployees = dt.AsEnumerable().Sum(r => r.Field<int>("TotalEmployees"));
                    decimal totalPayroll = dt.AsEnumerable().Sum(r => r.Field<decimal>("TotalNetPay"));

                    summaryLbl.Text = $"Total Employees Paid: {totalEmployees}    Total Payroll Disbursed: ₱{totalPayroll:N2}";
                }
            }
        }

        private void LoadLeaveReport(DateTime fromDate, DateTime toDate, string department = "All")
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
            /**DEPT_FILTER**/
            ORDER BY lr.start_date DESC";

                if (department != "All")
                    sql = sql.Replace("/**DEPT_FILTER**/", "AND e.department = @Department");
                else
                    sql = sql.Replace("/**DEPT_FILTER**/", "");

                using (SqlCommand cmd = new SqlCommand(sql, conn))
                {
                    cmd.Parameters.AddWithValue("@FromDate", fromDate);
                    cmd.Parameters.AddWithValue("@ToDate", toDate);
                    if (department != "All")
                        cmd.Parameters.AddWithValue("@Department", department);

                    SqlDataAdapter da = new SqlDataAdapter(cmd);
                    DataTable dt = new DataTable();
                    da.Fill(dt);

                    reportsDvg.DataSource = dt;

                    // ✅ Summary
                    int totalRequests = dt.Rows.Count;
                    int approved = dt.AsEnumerable().Count(r => r.Field<string>("status") == "Approved");
                    int pending = dt.AsEnumerable().Count(r => r.Field<string>("status") == "Pending");
                    int rejected = dt.AsEnumerable().Count(r => r.Field<string>("status") == "Rejected");

                    summaryLbl.Text = $"Total Requests: {totalRequests}   Approved: {approved}   Pending: {pending}   Rejected: {rejected}";
                }
            }
        }

        private void generateBtn_Click(object sender, EventArgs e)
        {
            DateTime fromDate = datefromPicker.Value.Date;
            DateTime toDate = datetoPicker.Value.Date;
            string department = DeparmentCmb.SelectedItem?.ToString() ?? "All";
            string reportType = reportTypeCmb.SelectedItem?.ToString();

            if (reportType == "Attendance Summary")
            {
                LoadAttendanceReport(fromDate, toDate, department);
            }
            else if (reportType == "Payroll")
            {
                LoadPayrollReport(fromDate, toDate, department);
            }
            else if (reportType == "Leave")
            {
                LoadLeaveReport(fromDate, toDate, department);
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
    }

}

