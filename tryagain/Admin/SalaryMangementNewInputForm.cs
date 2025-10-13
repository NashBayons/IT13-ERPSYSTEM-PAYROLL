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
    public partial class SalaryMangementNewInputForm : Form
    {
        public bool IsEditMode { get; set; }
        public int SalaryID { get; set; }
        public int SelectedDepartmentId { get; set; }
        public int SelectedPositionId { get; set; }
        public decimal GrossSalary { get; set; }

        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;
        public SalaryMangementNewInputForm()
        {
            InitializeComponent();

        }

        private void SalaryMangementNewInputForm_Load_1(object sender, EventArgs e)
        {
            LoadDepartments();

            if (IsEditMode)
            {
                this.Text = "Edit Salary";
                SalaryTxt.Text = GrossSalary.ToString("0.00");

                deptCmb.SelectedValue = SelectedDepartmentId;
                LoadPositions(SelectedDepartmentId);
                posCmb.SelectedValue = SelectedPositionId;
            }
            else
            {
                this.Text = "Add Salary";
            }
        }

        public void LoadDepartments()
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT dept_id, name FROM Department where status=1", conn);
                DataTable dt = new DataTable();
                da.Fill(dt);

                deptCmb.DataSource = dt;
                deptCmb.DisplayMember = "name";
                deptCmb.ValueMember = "dept_id";

                if (dt.Rows.Count > 0)
                {
                    deptCmb.SelectedIndex = 0;
                }
            }
        }

        private void deptCmb_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (deptCmb.SelectedValue is int deptId)
                LoadPositions(deptId);
        }

        private void LoadPositions(int deptId)
        {
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlDataAdapter da = new SqlDataAdapter("SELECT position_id, name FROM Position WHERE dept_id = @id AND status = 1", conn);
                da.SelectCommand.Parameters.AddWithValue("@id", deptId);
                DataTable dt = new DataTable();
                da.Fill(dt);

                posCmb.DataSource = dt;
                posCmb.DisplayMember = "name";
                posCmb.ValueMember = "position_id";
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            try
            {
                if (posCmb.SelectedValue == null || string.IsNullOrEmpty(SalaryTxt.Text))
                {
                    MessageBox.Show("Please fill all fields.");
                    return;
                }

                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();

                    // ✅ Check for duplicate
                    SqlCommand check = new SqlCommand("SELECT COUNT(*) FROM Salaries WHERE PositionID = @pos", conn);
                    check.Parameters.AddWithValue("@pos", posCmb.SelectedValue);
                    int exists = (int)check.ExecuteScalar();

                    if (exists > 0 && !IsEditMode)
                    {
                        MessageBox.Show("This position already has an assigned salary.");
                        return;
                    }

                    SqlCommand cmd;
                    if (this.IsEditMode)
                    {
                        cmd = new SqlCommand("UPDATE Salaries SET PositionID=@pos, GrossSalary=@gross WHERE SalaryID=@id", conn);
                        cmd.Parameters.AddWithValue("@id", this.SalaryID);
                    }
                    else
                    {
                        cmd = new SqlCommand("INSERT INTO Salaries (PositionID, GrossSalary) VALUES (@pos, @gross)", conn);
                    }

                    cmd.Parameters.AddWithValue("@pos", posCmb.SelectedValue);
                    cmd.Parameters.AddWithValue("@gross", decimal.Parse(SalaryTxt.Text));
                    cmd.ExecuteNonQuery();
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            } 
            catch (Exception ex)
            {
                MessageBox.Show("Error loading salaries: " + ex.Message);
            }
            
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }

        
    }

}
