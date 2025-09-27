using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Configuration;
using System.Data;
using Microsoft.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace tryagain
{
    public partial class AttendanceForm : Form
    {
        private string connectionString = ConfigurationManager.ConnectionStrings["MyDbConnection"].ConnectionString;

        private Color primaryColor = Color.FromArgb(63, 81, 181);  // Deep Indigo
        private Color secondaryColor = Color.FromArgb(245, 246, 250);  // Light Slate
        private Color accentColor = Color.FromArgb(239, 83, 80);  // Coral Red
        private Color textColor = Color.FromArgb(33, 33, 33);  // Dark Gray for text
        public AttendanceForm()
        {
            InitializeComponent();
            LoadAttendance();

            this.TopLevel = false;
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
        }
     

        private void LoadAttendance()
        {
            this.Controls.Clear();

            Label titleLabel = new Label
            {
                Text = "Attendance Records",
                Font = new Font("Segoe UI", 20F, FontStyle.Bold),
                Location = new Point(20, 20),
                AutoSize = true
            };
            this.Controls.Add(titleLabel);

            DataGridView dgvAttendance = new DataGridView
            {
                Name = "dgvAttendance",
                Location = new Point(20, 80),
                Size = new Size(900, 400),
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                ReadOnly = true,
                AllowUserToAddRows = false
            };
            this.Controls.Add(dgvAttendance);

            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                conn.Open();

                string query = @"
                    SELECT A.AttendanceID, E.FirstName + ' ' + E.LastName AS EmployeeName,
                           A.Date, A.TimeIn, A.TimeOut, A.WorkHours, A.Status
                    FROM Attendance A
                    INNER JOIN Employees E ON A.EmployeeID = E.EmployeeID
                    ORDER BY A.Date DESC";

                SqlDataAdapter da = new SqlDataAdapter(query, conn);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvAttendance.DataSource = dt;
            }

            // Add buttons like original design
            Button btnAdd = new Button
            {
                Text = "Add Attendance",
                Location = new Point(20, 500),
                Size = new Size(140, 40),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            //btnAdd.Click += BtnAdd_Click;
            this.Controls.Add(btnAdd);

            Button btnEdit = new Button
            {
                Text = "Edit",
                Location = new Point(180, 500),
                Size = new Size(80, 40),
                BackColor = Color.FromArgb(63, 81, 181),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            //btnEdit.Click += BtnEdit_Click;
            this.Controls.Add(btnEdit);

            Button btnDelete = new Button
            {
                Text = "Delete",
                Location = new Point(280, 500),
                Size = new Size(80, 40),
                BackColor = Color.FromArgb(244, 67, 54),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnDelete.Click += BtnDelete_Click;
            this.Controls.Add(btnDelete);
        }

        //private void BtnAdd_Click(object sender, EventArgs e)
        //{
        //    using (var form = new AttendanceDetailsForm())
        //    {
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            using (SqlConnection conn = new SqlConnection(connectionString))
        //            {
        //                conn.Open();
        //                SqlCommand cmd = new SqlCommand(
        //                    "INSERT INTO Attendance (EmployeeID, Date, TimeIn, TimeOut, WorkHours, Status) VALUES (@EmployeeID, @Date, @TimeIn, @TimeOut, @WorkHours, @Status)", conn);

        //                //cmd.Parameters.AddWithValue("@EmployeeID", form.EmployeeID);
        //                //cmd.Parameters.AddWithValue("@Date", form.Date);
        //                //cmd.Parameters.AddWithValue("@TimeIn", (object)form.TimeIn ?? DBNull.Value);
        //                //cmd.Parameters.AddWithValue("@TimeOut", (object)form.TimeOut ?? DBNull.Value);
        //                //cmd.Parameters.AddWithValue("@WorkHours", form.WorkHours);
        //                //cmd.Parameters.AddWithValue("@Status", form.Status);

        //                cmd.ExecuteNonQuery();
        //            }
        //            LoadAttendance();
        //        }
        //    }
        //}

        //private void BtnEdit_Click(object sender, EventArgs e)
        //{
        //    DataGridView dgv = this.Controls["dgvAttendance"] as DataGridView;
        //    if (dgv.CurrentRow == null) return;

        //    int attendanceId = Convert.ToInt32(dgv.CurrentRow.Cells["AttendanceID"].Value);

        //    using (var form = new AttendanceDetailsForm(
        //        Convert.ToInt32(dgv.CurrentRow.Cells["AttendanceID"].Value),
        //        dgv.CurrentRow.Cells["EmployeeName"].Value.ToString(),
        //        Convert.ToDateTime(dgv.CurrentRow.Cells["Date"].Value),
        //        dgv.CurrentRow.Cells["TimeIn"].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dgv.CurrentRow.Cells["TimeIn"].Value),
        //        dgv.CurrentRow.Cells["TimeOut"].Value == DBNull.Value ? (DateTime?)null : Convert.ToDateTime(dgv.CurrentRow.Cells["TimeOut"].Value),
        //        Convert.ToDecimal(dgv.CurrentRow.Cells["WorkHours"].Value),
        //        dgv.CurrentRow.Cells["Status"].Value.ToString()
        //    ))
        //    {
        //        if (form.ShowDialog() == DialogResult.OK)
        //        {
        //            using (SqlConnection conn = new SqlConnection(connectionString))
        //            {
        //                conn.Open();
        //                SqlCommand cmd = new SqlCommand(
        //                    "UPDATE Attendance SET Date=@Date, TimeIn=@TimeIn, TimeOut=@TimeOut, WorkHours=@WorkHours, Status=@Status WHERE AttendanceID=@AttendanceID", conn);

        //                cmd.Parameters.AddWithValue("@Date", form.Date);
        //                cmd.Parameters.AddWithValue("@TimeIn", (object)form.TimeIn ?? DBNull.Value);
        //                cmd.Parameters.AddWithValue("@TimeOut", (object)form.TimeOut ?? DBNull.Value);
        //                cmd.Parameters.AddWithValue("@WorkHours", form.WorkHours);
        //                cmd.Parameters.AddWithValue("@Status", form.Status);
        //                cmd.Parameters.AddWithValue("@AttendanceID", attendanceId);

        //                cmd.ExecuteNonQuery();
        //            }
        //            LoadAttendance();
        //        }
        //    }
        //}

        private void BtnDelete_Click(object sender, EventArgs e)
        {
            DataGridView dgv = this.Controls["dgvAttendance"] as DataGridView;
            if (dgv.CurrentRow == null) return;

            int attendanceId = Convert.ToInt32(dgv.CurrentRow.Cells["AttendanceID"].Value);

            var confirm = MessageBox.Show("Are you sure you want to delete this record?", "Confirm Delete", MessageBoxButtons.YesNo);
            if (confirm == DialogResult.Yes)
            {
                using (SqlConnection conn = new SqlConnection(connectionString))
                {
                    conn.Open();
                    SqlCommand cmd = new SqlCommand("DELETE FROM Attendance WHERE AttendanceID=@AttendanceID", conn);
                    cmd.Parameters.AddWithValue("@AttendanceID", attendanceId);
                    cmd.ExecuteNonQuery();
                }
                LoadAttendance();
            }
        }



    }
    public class AttendanceRecord
    {
        public string EmployeeID { get; set; }
        public DateTime Date { get; set; }
        public DateTime? TimeIn { get; set; }
        public DateTime? TimeOut { get; set; }
        public double WorkHours { get; set; }
        public string Status { get; set; }
    }
}
