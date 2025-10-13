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

namespace tryagain.Admin
{
    public partial class SalaryMangementNewForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public SalaryMangementNewForm()
        {
            InitializeComponent();
            LoadSalaries();
        }

        private void LoadSalaries()
        {
            try
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlDataAdapter da = new SqlDataAdapter(@"
                SELECT s.SalaryID,
                       p.name AS PositionName,
                       d.name AS DepartmentName,
                       s.GrossSalary
                FROM Salaries s
                JOIN Position p ON s.PositionID = p.position_id
                JOIN Department d ON p.dept_id = d.dept_id", conn);

                    DataTable dt = new DataTable();
                    da.Fill(dt);
                    SalaryGrid.DataSource = dt;

                    SalaryGrid.Columns["SalaryID"].Visible = false; // hide ID column
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error loading salaries: " + ex.Message);
            }
        }

        private void AddSalBtn_Click(object sender, EventArgs e)
        {
            using (SalaryMangementNewInputForm form = new SalaryMangementNewInputForm())
            {
                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSalaries();
                }
            }
        }

        private void EditSalBtn_Click(object sender, EventArgs e)
        {
            if (SalaryGrid.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a salary record to edit.");
                return;
            }

            int salaryId = Convert.ToInt32(SalaryGrid.SelectedRows[0].Cells["SalaryID"].Value);
            decimal gross = Convert.ToDecimal(SalaryGrid.SelectedRows[0].Cells["GrossSalary"].Value);
            int deptId = 0, posId = 0;

            // Fetch Department and Position IDs
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand(@"
            SELECT p.dept_id, p.position_id
            FROM Salaries s
            JOIN Position p ON s.PositionID = p.position_id
            WHERE s.SalaryID = @id", conn);
                cmd.Parameters.AddWithValue("@id", salaryId);
                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    deptId = reader.GetInt32(0);
                    posId = reader.GetInt32(1);
                }
            }

            // Pass values to input form
            using (SalaryMangementNewInputForm form = new SalaryMangementNewInputForm())
            {
                form.IsEditMode = true;
                form.SalaryID = salaryId;
                form.SelectedDepartmentId = deptId;
                form.SelectedPositionId = posId;
                form.GrossSalary = gross;

                if (form.ShowDialog() == DialogResult.OK)
                {
                    LoadSalaries();
                }
            }
        }

        private void DeleteSalBtn_Click(object sender, EventArgs e)
        {

        }
    }
}
