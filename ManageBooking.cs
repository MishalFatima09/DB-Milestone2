using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;
using TravelEase;

namespace TravelEase.Forms
{
    public partial class ManageBookingForm : Form
    {
       
        private ComboBox cmbTravelerID;
        private ComboBox cmbTripID;
        private ComboBox cmbStatus;
        private ComboBox cmbPolicy;
        private NumericUpDown numCost;
        private DateTimePicker dtpBookingDate;

        public ManageBookingForm()
        {
            InitializeComponent();
        }

        private void ManageBookingForm_Load(object sender, EventArgs e)
        {
            LoadTravelerIDs();
            LoadTripIDs();
            LoadBookings();
        }

        private void LoadTravelerIDs()
        {
            cmbTravelerID.Items.Clear();
            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT UserID FROM Users", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbTravelerID.Items.Add(reader["UserID"].ToString());
                }
                con.Close();
            }
        }

        private void LoadTripIDs()
        {
            cmbTripID.Items.Clear();
            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("SELECT TripID FROM Trip", con);
                con.Open();
                SqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    cmbTripID.Items.Add(reader["TripID"].ToString());
                }
                con.Close();
            }
        }

        private void LoadBookings()
        {
            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                SqlDataAdapter da = new SqlDataAdapter("SELECT * FROM Booking", con);
                DataTable dt = new DataTable();
                da.Fill(dt);
                dgvBookings.DataSource = dt;
            }
        }

        private void btnAddBooking_Click(object sender, EventArgs e)
        {
            string bookingID = "BK" + Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();
            string travelerID = cmbTravelerID.SelectedItem?.ToString();
            string tripID = cmbTripID.SelectedItem?.ToString();
            string status = cmbStatus.SelectedItem?.ToString();
            string policy = cmbPolicy.SelectedItem?.ToString();
            decimal cost = numCost.Value;
            DateTime bookingDate = dtpBookingDate.Value;

            if (string.IsNullOrEmpty(travelerID) || string.IsNullOrEmpty(tripID) || string.IsNullOrEmpty(status) || string.IsNullOrEmpty(policy))
            {
                MessageBox.Show("Please fill all required fields.", "Validation", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                string query = @"INSERT INTO Booking (BookingID, BookingDate, Status, Cancellation_Policy, TotalCost, TravelerID, TripID) 
                                    VALUES (@BookingID, @BookingDate, @Status, @Policy, @Cost, @TravelerID, @TripID)";

                SqlCommand cmd = new SqlCommand(query, con);
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                cmd.Parameters.AddWithValue("@BookingDate", bookingDate);
                cmd.Parameters.AddWithValue("@Status", status);
                cmd.Parameters.AddWithValue("@Policy", policy);
                cmd.Parameters.AddWithValue("@Cost", cost);
                cmd.Parameters.AddWithValue("@TravelerID", travelerID);
                cmd.Parameters.AddWithValue("@TripID", tripID);

                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Booking added successfully.", "Success");
                LoadBookings();
            }
        }

        private void btnDeleteBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count == 0)
            {
                MessageBox.Show("Please select a booking to delete.", "Notice");
                return;
            }

            string bookingID = dgvBookings.SelectedRows[0].Cells["BookingID"].Value.ToString();

            using (SqlConnection con = new SqlConnection(DbConfig.ConnectionString))
            {
                SqlCommand cmd = new SqlCommand("DELETE FROM Booking WHERE BookingID = @BookingID", con);
                cmd.Parameters.AddWithValue("@BookingID", bookingID);
                con.Open();
                cmd.ExecuteNonQuery();
                con.Close();

                MessageBox.Show("Booking deleted.", "Deleted");
                LoadBookings();
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
        }
    }
}
