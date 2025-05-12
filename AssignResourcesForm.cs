using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class AssignResourcesForm : Form
    {
        private ComboBox cmbBooking, cmbService, cmbStatus, cmbServiceType;
        private Button btnAssign;
        private Label lblBooking, lblService, lblStatus;
        private Button btnViewAssigned;

        private string connectionString = "Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;"; // replace with your actual connection string

        public AssignResourcesForm()
        {
            InitializeComponent();
            LoadBookings();
            LoadServices();
        }

        private void InitializeComponent()
        {
            this.lblBooking = new System.Windows.Forms.Label();
            this.lblType = new System.Windows.Forms.Label();
            this.lblService = new System.Windows.Forms.Label();
            this.lblStatus = new System.Windows.Forms.Label();
            this.cmbBooking = new System.Windows.Forms.ComboBox();
            this.cmbServiceType = new System.Windows.Forms.ComboBox();
            this.cmbService = new System.Windows.Forms.ComboBox();
            this.cmbStatus = new System.Windows.Forms.ComboBox();
            this.btnAssign = new System.Windows.Forms.Button();
            this.btnViewAssigned = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // lblBooking
            // 
            this.lblBooking.Location = new System.Drawing.Point(0, 0);
            this.lblBooking.Name = "lblBooking";
            this.lblBooking.Size = new System.Drawing.Size(100, 23);
            this.lblBooking.TabIndex = 0;
            // 
            // lblType
            // 
            this.lblType.Location = new System.Drawing.Point(0, 0);
            this.lblType.Name = "lblType";
            this.lblType.Size = new System.Drawing.Size(100, 23);
            this.lblType.TabIndex = 2;
            // 
            // lblService
            // 
            this.lblService.Location = new System.Drawing.Point(0, 0);
            this.lblService.Name = "lblService";
            this.lblService.Size = new System.Drawing.Size(100, 23);
            this.lblService.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.Location = new System.Drawing.Point(0, 0);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(100, 23);
            this.lblStatus.TabIndex = 6;
            // 
            // cmbBooking
            // 
            this.cmbBooking.Location = new System.Drawing.Point(0, 0);
            this.cmbBooking.Name = "cmbBooking";
            this.cmbBooking.Size = new System.Drawing.Size(121, 21);
            this.cmbBooking.TabIndex = 1;
            // 
            // cmbServiceType
            // 
            this.cmbServiceType.Items.AddRange(new object[] {
            "Guide",
            "Hotel",
            "Transport"});
            this.cmbServiceType.Location = new System.Drawing.Point(0, 0);
            this.cmbServiceType.Name = "cmbServiceType";
            this.cmbServiceType.Size = new System.Drawing.Size(121, 21);
            this.cmbServiceType.TabIndex = 3;
            // 
            // cmbService
            // 
            this.cmbService.Location = new System.Drawing.Point(0, 0);
            this.cmbService.Name = "cmbService";
            this.cmbService.Size = new System.Drawing.Size(121, 21);
            this.cmbService.TabIndex = 5;
            // 
            // cmbStatus
            // 
            this.cmbStatus.Items.AddRange(new object[] {
            "Pending",
            "Confirmed",
            "Cancelled"});
            this.cmbStatus.Location = new System.Drawing.Point(0, 0);
            this.cmbStatus.Name = "cmbStatus";
            this.cmbStatus.Size = new System.Drawing.Size(121, 21);
            this.cmbStatus.TabIndex = 7;
            // 
            // btnAssign
            // 
            this.btnAssign.Location = new System.Drawing.Point(0, 0);
            this.btnAssign.Name = "btnAssign";
            this.btnAssign.Size = new System.Drawing.Size(75, 23);
            this.btnAssign.TabIndex = 8;
            // 
            // btnViewAssigned
            // 
            this.btnViewAssigned.Font = new System.Drawing.Font("Segoe UI", 10F);
            this.btnViewAssigned.Location = new System.Drawing.Point(650, 20);
            this.btnViewAssigned.Name = "btnViewAssigned";
            this.btnViewAssigned.Size = new System.Drawing.Size(200, 40);
            this.btnViewAssigned.TabIndex = 9;
            this.btnViewAssigned.Text = "📋 View Assigned Services";
            this.btnViewAssigned.Click += new System.EventHandler(this.BtnViewAssigned_Click);
            // 
            // AssignResourcesForm
            // 
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(191)))), ((int)(((byte)(215)))), ((int)(((byte)(234)))));
            this.ClientSize = new System.Drawing.Size(484, 361);
            this.Controls.Add(this.lblBooking);
            this.Controls.Add(this.cmbBooking);
            this.Controls.Add(this.lblType);
            this.Controls.Add(this.cmbServiceType);
            this.Controls.Add(this.lblService);
            this.Controls.Add(this.cmbService);
            this.Controls.Add(this.lblStatus);
            this.Controls.Add(this.cmbStatus);
            this.Controls.Add(this.btnAssign);
            this.Controls.Add(this.btnViewAssigned);
            this.Name = "AssignResourcesForm";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Assign Resources to Booking";
            this.Load += new System.EventHandler(this.AssignResourcesForm_Load);
            this.ResumeLayout(false);

        }

        private void AssignResourcesForm_Load(object sender, EventArgs e)
        {

        }

        private void LoadBookings()
        {
            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                string query = "SELECT BookingID FROM Booking";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbBooking.Items.Add(reader["BookingID"].ToString());
                }
                con.Close();
            }
        }

        private void LoadServices()
        {
            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                string query = "SELECT ServiceID, Name FROM Service";
                SqlCommand cmd = new SqlCommand(query, con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbService.Items.Add($"{reader["ServiceID"]} - {reader["Name"]}");
                }
                con.Close();
            }
        }

        private void BtnAssign_Click(object sender, EventArgs e)
        {
            if (cmbBooking.SelectedItem == null || cmbService.SelectedItem == null)
            {
                MessageBox.Show("Please select a booking and a service.");
                return;
            }

            string assignmentId = Guid.NewGuid().ToString().Substring(0, 5).ToUpper();
            string bookingId = cmbBooking.SelectedItem.ToString();
            string serviceId = cmbService.SelectedItem.ToString().Split('-')[0].Trim();
            string status = cmbStatus.SelectedItem.ToString();

            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                string query = "INSERT INTO AssignedService (AssignmentID, Status, ServiceID, BookingID) VALUES (@AssignmentID, @Status, @ServiceID, @BookingID)";
                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@AssignmentID", assignmentId);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@ServiceID", serviceId);
                cmd.Parameters.AddWithValue("@BookingID", bookingId);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Service assigned successfully!");
            }
        }

        private void BtnViewAssigned_Click(object sender, EventArgs e)
        {
            var viewForm = new ViewAssignedServicesForm();
            viewForm.ShowDialog();
        }

        private void CmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbServiceType.SelectedItem?.ToString();
            cmbService.Items.Clear();

            if (!string.IsNullOrEmpty(selectedType))
            {
                using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
                {
                    string query = "SELECT ServiceID, Name FROM Service WHERE Type = @Type";
                    SqlCommand cmd = new SqlCommand(query, con);
                    cmd.Parameters.AddWithValue("@Type", selectedType);
                    con.Open();
                    SqlDataReader reader = cmd.ExecuteReader();
                    while (reader.Read())
                    {
                        cmbService.Items.Add($"{reader["ServiceID"]} - {reader["Name"]}");
                    }
                    con.Close();
                }
            }
        }

    }
}
