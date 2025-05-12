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
            this.Text = "Assign Resources to Booking";
            this.Size = new System.Drawing.Size(500, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = System.Drawing.Color.FromArgb(191, 215, 234);

            // Labels
            lblBooking = new Label() { Text = "Select Booking:", Location = new Point(30, 30), AutoSize = true };
            Label lblType = new Label() { Text = "Service Type:", Location = new Point(30, 80), AutoSize = true };
            lblService = new Label() { Text = "Select Service:", Location = new Point(30, 130), AutoSize = true };
            lblStatus = new Label() { Text = "Select Status:", Location = new Point(30, 180), AutoSize = true };

            // ComboBoxes
            cmbBooking = new ComboBox() { Location = new Point(150, 30), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbServiceType = new ComboBox() { Location = new Point(150, 80), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbService = new ComboBox() { Location = new Point(150, 130), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };
            cmbStatus = new ComboBox() { Location = new Point(150, 180), Width = 250, DropDownStyle = ComboBoxStyle.DropDownList };

            cmbServiceType.Items.AddRange(new string[] { "Guide", "Hotel", "Transport" });
            cmbServiceType.SelectedIndexChanged += CmbServiceType_SelectedIndexChanged;

            cmbStatus.Items.AddRange(new string[] { "Pending", "Confirmed", "Cancelled" });
            cmbStatus.SelectedIndex = 0;

            // Assign Button
            btnAssign = new Button() { Text = "Assign", Location = new Point(150, 230), Width = 100 };
            btnAssign.Click += BtnAssign_Click;

            // View Assigned Services Button
            this.btnViewAssigned = new Button();
            this.btnViewAssigned.Text = "📋 View Assigned Services";
            this.btnViewAssigned.Font = new Font("Segoe UI", 10, FontStyle.Regular);
            this.btnViewAssigned.Size = new Size(200, 40);
            this.btnViewAssigned.Location = new Point(650, 20);
            this.btnViewAssigned.Click += new EventHandler(this.BtnViewAssigned_Click);

            // Add controls to form
            this.Controls.Add(lblBooking);
            this.Controls.Add(cmbBooking);
            this.Controls.Add(lblType);
            this.Controls.Add(cmbServiceType);
            this.Controls.Add(lblService);
            this.Controls.Add(cmbService);
            this.Controls.Add(lblStatus);
            this.Controls.Add(cmbStatus);
            this.Controls.Add(btnAssign);
            this.Controls.Add(this.btnViewAssigned);
        }


        private void LoadBookings()
        {
            using (SqlConnection con = new SqlConnection(connectionString))
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
            using (SqlConnection con = new SqlConnection(connectionString))
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

            using (SqlConnection con = new SqlConnection(connectionString))
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
                using (SqlConnection con = new SqlConnection(connectionString))
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
