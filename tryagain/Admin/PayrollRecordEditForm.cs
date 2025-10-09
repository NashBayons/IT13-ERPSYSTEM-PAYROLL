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
    public partial class PayrollRecordEditForm : Form
    {

        private int _recordId;
        private int _batchId;
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        // In-memory data
        private DataTable dtDeductions;
        private DataTable dtBonuses;
        private decimal grossSalary, basePay;
        public PayrollRecordEditForm(int recordId, int batchId)
        {
            InitializeComponent();
            _recordId = recordId;
            _batchId = batchId;

            this.Text = "Edit Payroll Record";
            this.Size = new Size(800, 600);
            Load += PayrollRecordEditForm_Load;
        }

        private void PayrollRecordEditForm_Load(object sender, EventArgs e)
        {
            LoadRecordHeader();
            LoadDeductions();
            LoadBonuses();
        }

        private void LoadRecordHeader()
        {
            string sql = @"
                    SELECT r.gross_salary, r.base_pay, e.FirstName + ' ' + e.LastName AS EmployeeName
                    FROM Payroll_Record r
                    JOIN Employees e ON r.employee_id = e.EmployeeID
                    WHERE r.payroll_record_id = @id;";

            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _recordId);
                conn.Open();
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        grossSalary = reader.GetDecimal(0);
                        basePay = reader.GetDecimal(1);
                        employeeLbl.Text = "Employee: " + reader.GetString(2);
                        grossSalLbl.Text = $"Gross Salary: {grossSalary:C2}";
                        basepayLbl.Text = $"Base Pay: {basePay:C2}";
                    }
                }
            }
        }

        private void LoadDeductions()
        {
            dtDeductions = new DataTable();
            string sql = "SELECT deduction_id, deduction_type, amount FROM Deduction_Record WHERE payroll_record_id = @id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _recordId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtDeductions);
                }
            }
            dgvDeduct.DataSource = dtDeductions;
            if (dgvDeduct.Columns.Contains("deduction_id"))
                dgvDeduct.Columns["deduction_id"].Visible = false;
        }

        private void LoadBonuses()
        {
            dtBonuses = new DataTable();
            string sql = "SELECT bonus_id, bonus_type, amount FROM Bonus_Record WHERE payroll_record_id = @id;";
            using (SqlConnection conn = new SqlConnection(connectionString))
            using (SqlCommand cmd = new SqlCommand(sql, conn))
            {
                cmd.Parameters.AddWithValue("@id", _recordId);
                using (SqlDataAdapter da = new SqlDataAdapter(cmd))
                {
                    da.Fill(dtBonuses);
                }
            }
            dgvBonus.DataSource = dtBonuses;
            if (dgvBonus.Columns.Contains("bonus_id"))
                dgvBonus.Columns["bonus_id"].Visible = false;
        }

        private void AddOrEditDeduction(DataRow row)
        {
            string type = row?["deduction_type"].ToString() ?? "";
            decimal amount = row != null ? Convert.ToDecimal(row["amount"]) : 0m;

            using (var dlg = new SimpleInputDialog("Deduction Type", type, "Amount", amount))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (row == null)
                    {
                        DataRow newRow = dtDeductions.NewRow();
                        newRow["deduction_type"] = dlg.Value1;
                        newRow["amount"] = dlg.Value2;
                        dtDeductions.Rows.Add(newRow);
                    }
                    else
                    {
                        row["deduction_type"] = dlg.Value1;
                        row["amount"] = dlg.Value2;
                    }
                }
            }
        }


        // ---------------- Bonus CRUD ----------------
        private void AddOrEditBonus(DataRow row)
        {
            string type = row?["bonus_type"].ToString() ?? "";
            decimal amount = row != null ? Convert.ToDecimal(row["amount"]) : 0m;

            using (var dlg = new SimpleInputDialog("Bonus Type", type, "Amount", amount))
            {
                if (dlg.ShowDialog() == DialogResult.OK)
                {
                    if (row == null)
                    {
                        DataRow newRow = dtBonuses.NewRow();
                        newRow["bonus_type"] = dlg.Value1;
                        newRow["amount"] = dlg.Value2;
                        dtBonuses.Rows.Add(newRow);
                    }
                    else
                    {
                        row["bonus_type"] = dlg.Value1;
                        row["amount"] = dlg.Value2;
                    }
                }
            }
        }

        private void EditSelectedBonus()
        {
            if (dgvBonus.SelectedRows.Count > 0)
            {
                var rowView = dgvBonus.SelectedRows[0].DataBoundItem as DataRowView;
                AddOrEditBonus(rowView.Row);
            }
        }

        private void EditSelectedDeduct()
        {
            if (dgvDeduct.SelectedRows.Count > 0)
            {
                var rowView = dgvDeduct.SelectedRows[0].DataBoundItem as DataRowView;
                AddOrEditDeduction(rowView.Row);
            }
        }

        private void DeleteSelectedDeduct()
        {
            if (dgvDeduct.SelectedRows.Count > 0)
            {
                dgvDeduct.Rows.Remove(dgvDeduct.SelectedRows[0]);
            }
        }

        private void DeleteSelectedBonus()
        {
            if (dgvBonus.SelectedRows.Count > 0)
            {
                dgvBonus.Rows.Remove(dgvBonus.SelectedRows[0]);
            }
        }

        private void savechangeBtn_Click(object sender, EventArgs e)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlTransaction tx = conn.BeginTransaction();

                try
                {
                    // Clear old deductions and bonuses
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Deduction_Record WHERE payroll_record_id=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", _recordId);
                        cmd.ExecuteNonQuery();
                    }
                    using (SqlCommand cmd = new SqlCommand("DELETE FROM Bonus_Record WHERE payroll_record_id=@id", conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@id", _recordId);
                        cmd.ExecuteNonQuery();
                    }

                    // Insert current deductions
                    foreach (DataRow r in dtDeductions.Rows)
                    {
                        string sql = "INSERT INTO Deduction_Record (payroll_record_id, deduction_type, amount) VALUES (@rec, @type, @amt)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rec", _recordId);
                            cmd.Parameters.AddWithValue("@type", r["deduction_type"].ToString());
                            cmd.Parameters.AddWithValue("@amt", Convert.ToDecimal(r["amount"]));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Insert current bonuses
                    foreach (DataRow r in dtBonuses.Rows)
                    {
                        string sql = "INSERT INTO Bonus_Record (payroll_record_id, bonus_type, amount) VALUES (@rec, @type, @amt)";
                        using (SqlCommand cmd = new SqlCommand(sql, conn, tx))
                        {
                            cmd.Parameters.AddWithValue("@rec", _recordId);
                            cmd.Parameters.AddWithValue("@type", r["bonus_type"].ToString());
                            cmd.Parameters.AddWithValue("@amt", Convert.ToDecimal(r["amount"]));
                            cmd.ExecuteNonQuery();
                        }
                    }

                    // Recalc totals
                    decimal totalDeductions = 0m;
                    foreach (DataRow r in dtDeductions.Rows)
                        totalDeductions += Convert.ToDecimal(r["amount"]);

                    decimal totalBonus = 0m;
                    foreach (DataRow r in dtBonuses.Rows)
                        totalBonus += Convert.ToDecimal(r["amount"]);

                    decimal net = basePay - totalDeductions + totalBonus;

                    // Update Payroll_Record
                    string updateRecord = @"UPDATE Payroll_Record 
                                            SET deductions_total=@ded, bonus_amount=@bonus, net_pay=@net 
                                            WHERE payroll_record_id=@id";
                    using (SqlCommand cmd = new SqlCommand(updateRecord, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@ded", totalDeductions);
                        cmd.Parameters.AddWithValue("@bonus", totalBonus);
                        cmd.Parameters.AddWithValue("@net", net);
                        cmd.Parameters.AddWithValue("@id", _recordId);
                        cmd.ExecuteNonQuery();
                    }

                    // Update batch total
                    string updateBatch = @"UPDATE Payroll_Batch 
                                           SET total_net_pay = (
                                               SELECT SUM(net_pay) FROM Payroll_Record WHERE batch_id=@batch
                                           )
                                           WHERE batch_id=@batch";
                    using (SqlCommand cmd = new SqlCommand(updateBatch, conn, tx))
                    {
                        cmd.Parameters.AddWithValue("@batch", _batchId);
                        cmd.ExecuteNonQuery();
                    }

                    tx.Commit();
                    MessageBox.Show("Record updated successfully!", "Saved", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    this.Close();
                }
                catch (Exception ex)
                {
                    tx.Rollback();
                    MessageBox.Show("Save failed: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void deductAddBtn_Click(object sender, EventArgs e)
        {
            AddOrEditDeduction(null);
        }

        private void deductEditBtn_Click(object sender, EventArgs e)
        {
            EditSelectedDeduct();
        }

        private void deductDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteSelectedDeduct();
        }

        private void bonusAddBtn_Click(object sender, EventArgs e)
        {
            AddOrEditBonus(null);
        }

        private void bonusEditBtn_Click(object sender, EventArgs e)
        {
            EditSelectedBonus();
        }

        private void bonusDeleteBtn_Click(object sender, EventArgs e)
        {
            DeleteSelectedBonus();
        }

        private void cancelChangesBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
