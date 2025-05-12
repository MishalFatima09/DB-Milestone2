using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Windows.Forms;
using DB_M2_Chat;
using static TravelEase.Forms.ManageTripsForm;

namespace TravelEase.Forms
{
    //remove later!!!!!!!!!!!!!!!
    public class Trip
    {
        public string TripID { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public string TripType { get; set; }
        public int AccessibilityScore { get; set; }
        public int Sustainability_Score { get; set; }
        public string TourCategory { get; set; }
    }

    public partial class ManageTripsForm : Form
    {

        public ManageTripsForm()
        {
            InitializeComponent();
            LoadTrips();
        }

        private void ManageTripsForm_Load(object sender, EventArgs e)
        {
            // Future event handling can go here
        }

        private void ManageTripsForm_Load_1(object sender, EventArgs e)
        {

        }

        private List<Trip> GetTripsFromDatabase(string filter = "")
        {
            var result = new List<Trip>();

            using (SqlConnection conn = new SqlConnection("Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;"))
            {
                conn.Open();
                string query = @"SELECT TripID, Title, Description, Price, Duration, Capacity,
                        TripType, AccessibilityScore, Sustainability_Score, TourCategory
                 FROM Trip";
                if (!string.IsNullOrWhiteSpace(filter))
                {
                    query += " WHERE Title LIKE @filter";
                }

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    if (!string.IsNullOrWhiteSpace(filter))
                        cmd.Parameters.AddWithValue("@filter", "%" + filter + "%");

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            result.Add(new Trip
                            {
                                TripID = reader["TripID"].ToString(),
                                Title = reader["Title"].ToString(),
                                Description = reader["Description"].ToString(),
                                Price = Convert.ToDecimal(reader["Price"]),
                                Duration = Convert.ToInt32(reader["Duration"]),
                                Capacity = Convert.ToInt32(reader["Capacity"]),
                                TripType = reader["TripType"].ToString(),
                                AccessibilityScore = Convert.ToInt32(reader["AccessibilityScore"]),
                                Sustainability_Score = Convert.ToInt32(reader["Sustainability_Score"]),
                                TourCategory = reader["TourCategory"].ToString()
                            });
                        }
                    }
                }
            }

            return result;
        }


        private void LoadTrips(string filter = "")
        {
            var trips = GetTripsFromDatabase(filter);

            dgvTrips.DataSource = null;
            dgvTrips.DataSource = trips;
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {

            LoadTrips(txtSearch.Text);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "";
            LoadTrips();
        }


        private void DeleteTripFromDatabase(string tripId)
        {
            using (SqlConnection conn = new SqlConnection("Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;"))
            {
                conn.Open();
                string query = "DELETE FROM Trip WHERE TripID = @TripID";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TripID", tripId);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        private void dgvTrips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var row = dgvTrips.Rows[e.RowIndex];
                var selectedTrip = row.DataBoundItem as Trip;

                if (selectedTrip == null)
                {
                    // This avoids crash when you click a button row with no data
                    return;
                }

                if (e.ColumnIndex == dgvTrips.Columns["Edit"].Index)
                {
                    var editForm = new EditTripForm(selectedTrip);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        LoadTrips();
                    }
                }
                else if (e.ColumnIndex == dgvTrips.Columns["Delete"].Index)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this trip?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        DeleteTripFromDatabase(selectedTrip.TripID); // ensure you added TripID
                        LoadTrips();
                    }
                }
            }
        }


    }
}
