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

        // UI components
        private Label lblEmployeeName;
        private Label lblGrossSalary;
        private Label lblBasePay;
        private DataGridView dgvDeductions;
        private DataGridView dgvBonuses;
        private Button btnAddDeduction, btnEditDeduction, btnDeleteDeduction;
        private Button btnAddBonus, btnEditBonus, btnDeleteBonus;
        private Button btnSave;

        // In-memory data
        private DataTable dtDeductions;
        private DataTable dtBonuses;
        private decimal grossSalary, basePay;
        public PayrollRecordEditForm(int recordId, int batchId)
        {
            _recordId = recordId;
            _batchId = batchId;

            this.Text = "Edit Payroll Record";
            this.Size = new Size(800, 600);
            InitializeUI();
            Load += PayrollRecordEditForm_Load;
        }

        private void InitializeUI()
        {
            lblEmployeeName = new Label { Location = new Point(10, 10), AutoSize = true, Font = new Font("Segoe UI", 10, FontStyle.Bold) };
            lblGrossSalary = new Label { Location = new Point(10, 40), AutoSize = true };
            lblBasePay = new Label { Location = new Point(10, 70), AutoSize = true };

            this.Controls.Add(lblEmployeeName);
            this.Controls.Add(lblGrossSalary);
            this.Controls.Add(lblBasePay);

            // Deductions grid
            Label lblDeductions = new Label { Text = "Deductions", Location = new Point(10, 100), AutoSize = true };
            this.Controls.Add(lblDeductions);

            dgvDeductions = new DataGridView
            {
                Location = new Point(10, 120),
                Size = new Size(360, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvDeductions);

            btnAddDeduction = new Button { Text = "Add", Location = new Point(10, 430) };
            btnEditDeduction = new Button { Text = "Edit", Location = new Point(90, 430) };
            btnDeleteDeduction = new Button { Text = "Delete", Location = new Point(170, 430) };

            btnAddDeduction.Click += (s, e) => AddOrEditDeduction(null);
            btnEditDeduction.Click += (s, e) => EditSelectedDeduction();
            btnDeleteDeduction.Click += (s, e) => DeleteSelectedDeduction();

            this.Controls.Add(btnAddDeduction);
            this.Controls.Add(btnEditDeduction);
            this.Controls.Add(btnDeleteDeduction);

            // Bonuses grid
            Label lblBonuses = new Label { Text = "Bonuses", Location = new Point(400, 100), AutoSize = true };
            this.Controls.Add(lblBonuses);

            dgvBonuses = new DataGridView
            {
                Location = new Point(400, 120),
                Size = new Size(360, 300),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvBonuses);

            btnAddBonus = new Button { Text = "Add", Location = new Point(400, 430) };
            btnEditBonus = new Button { Text = "Edit", Location = new Point(480, 430) };
            btnDeleteBonus = new Button { Text = "Delete", Location = new Point(560, 430) };

            btnAddBonus.Click += (s, e) => AddOrEditBonus(null);
            btnEditBonus.Click += (s, e) => EditSelectedBonus();
            btnDeleteBonus.Click += (s, e) => DeleteSelectedBonus();

            this.Controls.Add(btnAddBonus);
            this.Controls.Add(btnEditBonus);
            this.Controls.Add(btnDeleteBonus);

            // Save button
            btnSave = new Button { Text = "Save Changes", Location = new Point(10, 500), Width = 120 };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
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
                        lblEmployeeName.Text = "Employee: " + reader.GetString(2);
                        lblGrossSalary.Text = $"Gross Salary: {grossSalary:C2}";
                        lblBasePay.Text = $"Base Pay: {basePay:C2}";
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
            dgvDeductions.DataSource = dtDeductions;
            if (dgvDeductions.Columns.Contains("deduction_id"))
                dgvDeductions.Columns["deduction_id"].Visible = false;
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
            dgvBonuses.DataSource = dtBonuses;
            if (dgvBonuses.Columns.Contains("bonus_id"))
                dgvBonuses.Columns["bonus_id"].Visible = false;
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

        private void EditSelectedDeduction()
        {
            if (dgvDeductions.SelectedRows.Count > 0)
            {
                var rowView = dgvDeductions.SelectedRows[0].DataBoundItem as DataRowView;
                AddOrEditDeduction(rowView.Row);
            }
        }

        private void DeleteSelectedDeduction()
        {
            if (dgvDeductions.SelectedRows.Count > 0)
            {
                dgvDeductions.Rows.Remove(dgvDeductions.SelectedRows[0]);
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
            if (dgvBonuses.SelectedRows.Count > 0)
            {
                var rowView = dgvBonuses.SelectedRows[0].DataBoundItem as DataRowView;
                AddOrEditBonus(rowView.Row);
            }
        }

        private void DeleteSelectedBonus()
        {
            if (dgvBonuses.SelectedRows.Count > 0)
            {
                dgvBonuses.Rows.Remove(dgvBonuses.SelectedRows[0]);
            }
        }

        // ---------------- Save ----------------
        private void BtnSave_Click(object sender, EventArgs e)
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

        // class closing bracket
    }
}
