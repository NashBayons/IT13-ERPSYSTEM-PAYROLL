using Microsoft.Data.SqlClient;
using System;
using System.Configuration;
using System.Data;
using System.Drawing;
using System.Windows.Forms;

namespace tryagain
{
    public partial class SalaryDetailsForm : Form
    {
        public int EmployeeID { get; set; }
        public decimal GrossSalary { get; set; }
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        // Strongly typed class for ComboBox items
        private class EmployeeItem
        {
            public int ID { get; set; }
            public string Name { get; set; }
            public override string ToString() => Name; // displays in ComboBox
        }

        public SalaryDetailsForm()
        {
            InitializeComponent();
            LoadEmployees();
            this.Load += SalaryDetailsForm_Load;
        }

        private void SalaryDetailsForm_Load(object sender, EventArgs e)
        {
            PreFillForm();
        }

        private void LoadEmployees()
        {
            empCmb.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName + ' ' + LastName AS FullName FROM Employees", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    empCmb.Items.Add(new EmployeeItem
                    {
                        ID = reader.GetInt32(0),
                        Name = reader.GetString(1)
                    });
                }
                reader.Close();
            }
        }

        private void PreFillForm()
        {
            // Fill Gross Salary textbox
            grossSalTxt.Text = GrossSalary.ToString("F2");

            // Select the employee in ComboBox
            for (int i = 0; i < empCmb.Items.Count; i++)
            {
                if (((EmployeeItem)empCmb.Items[i]).ID == EmployeeID)
                {
                    empCmb.SelectedIndex = i;
                    break;
                }
            }
        }

        private void SaveBtn_Click(object sender, EventArgs e)
        {
            if (empCmb.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            if (!decimal.TryParse(grossSalTxt.Text, out decimal gross))
            {
                MessageBox.Show("Please enter a valid Gross Salary.");
                return;
            }

            EmployeeID = ((EmployeeItem)empCmb.SelectedItem).ID;
            GrossSalary = gross;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }

        private void CancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
