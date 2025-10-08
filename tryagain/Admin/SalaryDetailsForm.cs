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

        private ComboBox cmbEmployees;
        private TextBox txtGross;
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
            BuildForm();
            LoadEmployees();
            PreFillForm();
        }

        private void BuildForm()
        {
            Label lblEmployee = new Label { Text = "Employee:", Location = new Point(20, 20), AutoSize = true };
            this.Controls.Add(lblEmployee);

            cmbEmployees = new ComboBox { Location = new Point(120, 15), Width = 200, DropDownStyle = ComboBoxStyle.DropDownList };
            this.Controls.Add(cmbEmployees);

            Label lblGross = new Label { Text = "Gross Salary:", Location = new Point(20, 70), AutoSize = true };
            this.Controls.Add(lblGross);

            txtGross = new TextBox { Location = new Point(120, 65), Width = 200 };
            this.Controls.Add(txtGross);

            Button btnSave = new Button { Text = "Save", Location = new Point(120, 110), Size = new Size(80, 30) };
            btnSave.Click += BtnSave_Click;
            this.Controls.Add(btnSave);
        }

        private void LoadEmployees()
        {
            cmbEmployees.Items.Clear();
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();
                SqlCommand cmd = new SqlCommand("SELECT EmployeeID, FirstName + ' ' + LastName AS FullName FROM Employees", conn);
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbEmployees.Items.Add(new EmployeeItem
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
            txtGross.Text = GrossSalary.ToString("F2");

            // Select the employee in ComboBox
            for (int i = 0; i < cmbEmployees.Items.Count; i++)
            {
                if (((EmployeeItem)cmbEmployees.Items[i]).ID == EmployeeID)
                {
                    cmbEmployees.SelectedIndex = i;
                    break;
                }
            }
        }

        private void BtnSave_Click(object sender, EventArgs e)
        {
            if (cmbEmployees.SelectedItem == null)
            {
                MessageBox.Show("Please select an employee.");
                return;
            }

            if (!decimal.TryParse(txtGross.Text, out decimal gross))
            {
                MessageBox.Show("Please enter a valid Gross Salary.");
                return;
            }

            EmployeeID = ((EmployeeItem)cmbEmployees.SelectedItem).ID;
            GrossSalary = gross;

            this.DialogResult = DialogResult.OK;
            this.Close();
        }
    }
}
