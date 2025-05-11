using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows.Forms;
using DB_M2_Chat;
using static TravelEase.Forms.ManageTripsForm;

namespace TravelEase.Forms
{
    //remove later!!!!!!!!!!!!!!!
    public class Trip
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public int Duration { get; set; }
        public int Capacity { get; set; }
        public string TripType { get; set; }
        public int AccessibilityScore { get; set; }
        public int SustainabilityScore { get; set; }
        public string TourCategory { get; set; }
    }

    public partial class ManageTripsForm : Form
    {

        public ManageTripsForm()
        {
            InitializeComponent();
        }

        private void ManageTripsForm_Load(object sender, EventArgs e)
        {
            // Future event handling can go here
        }

        private void ManageTripsForm_Load_1(object sender, EventArgs e)
        {

        }

        private List<Trip> trips = new List<Trip>
        {
            new Trip { Title = "Desert Safari", Price = 150, Duration = 2 },
            new Trip { Title = "City Tour", Price = 80, Duration = 1 }
        };


        private void LoadTrips(string filter = "")
        {
            var filtered = string.IsNullOrWhiteSpace(filter)
                ? trips
                : trips.Where(t => t.Title.IndexOf(filter, StringComparison.OrdinalIgnoreCase) >= 0).ToList();

            dgvTrips.DataSource = null;
            dgvTrips.DataSource = filtered;
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

        private void dgvTrips_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            if (e.RowIndex >= 0)
            {
                var selectedTrip = (Trip)dgvTrips.Rows[e.RowIndex].DataBoundItem;

                if (e.ColumnIndex == dgvTrips.Columns["Edit"].Index)
                {
                    // Open edit form (pass the trip)
                    var editForm = new EditTripForm(selectedTrip);
                    if (editForm.ShowDialog() == DialogResult.OK)
                    {
                        // Refresh after editing
                        LoadTrips();
                    }
                }
                else if (e.ColumnIndex == dgvTrips.Columns["Delete"].Index)
                {
                    var result = MessageBox.Show("Are you sure you want to delete this trip?", "Confirm", MessageBoxButtons.YesNo);
                    if (result == DialogResult.Yes)
                    {
                        trips.Remove(selectedTrip);
                        LoadTrips();
                    }
                }
            }
        }

    }
}
