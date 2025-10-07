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
    public partial class PayrollBatchDetailsForm : Form
    {

        private int _batchId;
        private string _batchStatus;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public PayrollBatchDetailsForm(int batchId, string status)
        {
            InitializeComponent();
            _batchId = batchId;
            _batchStatus = status;
            this.Text = $"Payroll Batch #{batchId} - Details";
            this.Size = new Size(1000, 600);
            Load += PayrollBatchDetailsForm_Load;
        }

        private void PayrollBatchDetailsForm_Load(object sender, EventArgs e)
        {
            LoadPayrollRecords(_batchId);
        }

        private void LoadPayrollRecords(int batchId)
        {
            string sql = @"
                SELECT * FROM dbo.vw_PayrollRecordDetails 
                    WHERE 
                        batch_id = @batchId
                    ORDER BY 
                        EmployeeName;";

            DataTable dt = new DataTable();
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@batchId", batchId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dt);
                }
            }

            dgvPayrollRecords.DataSource = dt;

            if (dgvPayrollRecords.Columns.Contains("payroll_record_id"))
                dgvPayrollRecords.Columns["payroll_record_id"].Visible = false;
            if (dgvPayrollRecords.Columns.Contains("employee_id"))
                dgvPayrollRecords.Columns["employee_id"].Visible = false;
        }

        private void finalizeselectBtn_Click(object sender, EventArgs e)
        {
            var confirm = MessageBox.Show("Finalize this batch and mark as Paid? This will lock the batch.", "Finalize Batch", MessageBoxButtons.YesNo, MessageBoxIcon.Question);
            if (confirm != DialogResult.Yes) return;

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();
                try
                {
                    string updateBatch = "UPDATE Payroll_Batch SET status = 'Paid', processed_timestamp = GETDATE() WHERE batch_id = @batchId;";
                    using (SqlCommand cmd = new SqlCommand(updateBatch, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@batchId", _batchId);
                        cmd.ExecuteNonQuery();
                    }

                    // Optionally update record statuses if you have such a column. Example:
                    // string updateRecords = "UPDATE Payroll_Record SET status = 'Paid' WHERE batch_id = @batchId;";
                    // using (SqlCommand cmd = new SqlCommand(updateRecords, conn, tx)) { ... }

                    tx.Commit();
                    MessageBox.Show("Batch finalized and marked as Paid.", "Done", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    try { tx.Rollback(); } catch { }
                    MessageBox.Show("Failed to finalize batch: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void editselectBtn_Click(object sender, EventArgs e)
        {
            if (_batchStatus == "Paid")
            {
                MessageBox.Show("This batch is finalized and cannot be edited.", "Locked", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (dgvPayrollRecords.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a payroll record first.", "Edit Record", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            var row = dgvPayrollRecords.SelectedRows[0];

            // ensure the grid has the payroll_record_id column
            if (!dgvPayrollRecords.Columns.Contains("payroll_record_id"))
            {
                MessageBox.Show("Payroll record id column not found.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // protect against nulls
            if (row.Cells["payroll_record_id"].Value == DBNull.Value || row.Cells["payroll_record_id"].Value == null)
            {
                MessageBox.Show("Selected row does not have a payroll record id.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            int recordId = Convert.ToInt32(row.Cells["payroll_record_id"].Value);

            // open the edit dialog (we'll implement this form next)
            using (var frm = new PayrollRecordEditForm(recordId, _batchId))
            {
                frm.ShowDialog();
            }

            // refresh the records after possible edits
            LoadPayrollRecords(_batchId);
        }

        //class closing bracket
    }
}
