using System;
using System.Collections.Generic;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class TripDashboardForm : Form
    {
        // Sample data for trips
        private List<TripInfo> upcomingTrips;
        private TripInfo selectedTrip;

        public TripDashboardForm()
        {
            InitializeComponent();
            LoadSampleData();
        }

        private void TripDashboardForm_Load(object sender, EventArgs e)
        {
            DisplayUpcomingTrips();
            if (upcomingTrips.Count > 0)
            {
                // Select the first trip by default
                tripListBox.SelectedIndex = 0;
                DisplayTripDetails(upcomingTrips[0]);
            }
            else
            {
                ShowNoTripsMessage();
            }
        }

        private void LoadSampleData()
        {
            // Sample data - in a real app, this would come from a database
            upcomingTrips = new List<TripInfo>
            {
                new TripInfo
                {
                    TripId = "TR-2025-001",
                    Destination = "Paris, France",
                    StartDate = DateTime.Now.AddDays(15),
                    EndDate = DateTime.Now.AddDays(22),
                    Status = "Confirmed",
                    BookingDetails = "Booking #: BK-10045\nPayment: Completed\nTotal Cost: $1,250.00",
                    Itinerary = "Day 1: Arrival at Charles de Gaulle Airport\n" +
                                "Day 2: Eiffel Tower & River Seine Cruise\n" +
                                "Day 3: Louvre Museum & Notre Dame Cathedral\n" +
                                "Day 4: Versailles Palace Day Trip\n" +
                                "Day 5: Montmartre & Sacré-Cœur\n" +
                                "Day 6: Free day for shopping\n" +
                                "Day 7: Departure",
                    Accommodation = "Hotel De Paris\nAddress: 12 Rue de Rivoli, 75001 Paris\nCheck-in: 3:00 PM\nCheck-out: 11:00 AM\nRoom Type: Deluxe Double",
                    CancellationPolicy = "Free cancellation until 7 days before arrival.\n50% charge if cancelled 3-7 days before arrival.\nNo refund if cancelled less than 3 days before arrival."
                },
                new TripInfo
                {
                    TripId = "TR-2025-002",
                    Destination = "Tokyo, Japan",
                    StartDate = DateTime.Now.AddDays(45),
                    EndDate = DateTime.Now.AddDays(53),
                    Status = "Awaiting Payment",
                    BookingDetails = "Booking #: BK-10089\nPayment Due: May 30, 2025\nTotal Cost: $1,875.00",
                    Itinerary = "Day 1: Arrival at Narita International Airport\n" +
                                "Day 2: Tokyo Tower & Asakusa Temple\n" +
                                "Day 3: Meiji Shrine & Harajuku\n" +
                                "Day 4: Day trip to Mt. Fuji\n" +
                                "Day 5: Tsukiji Market & Ginza\n" +
                                "Day 6: Akihabara & Ueno Park\n" +
                                "Day 7: Free day for shopping\n" +
                                "Day 8: Departure",
                    Accommodation = "Sakura Hotel Shinjuku\nAddress: 2-34-7 Shinjuku, Tokyo 160-0022\nCheck-in: 2:00 PM\nCheck-out: 10:00 AM\nRoom Type: Superior Twin",
                    CancellationPolicy = "Free cancellation until 14 days before arrival.\n70% charge if cancelled 7-14 days before arrival.\nNo refund if cancelled less than 7 days before arrival."
                },
                new TripInfo
                {
                    TripId = "TR-2025-003",
                    Destination = "Bali, Indonesia",
                    StartDate = DateTime.Now.AddDays(75),
                    EndDate = DateTime.Now.AddDays(82),
                    Status = "Confirmed",
                    BookingDetails = "Booking #: BK-10112\nPayment: Completed\nTotal Cost: $950.00",
                    Itinerary = "Day 1: Arrival at Ngurah Rai International Airport\n" +
                                "Day 2: Ubud Monkey Forest & Rice Terraces\n" +
                                "Day 3: Uluwatu Temple & Kecak Dance\n" +
                                "Day 4: Tanah Lot & Sunset Dinner\n" +
                                "Day 5: Bali Safari & Marine Park\n" +
                                "Day 6: Beach day at Nusa Dua\n" +
                                "Day 7: Departure",
                    Accommodation = "Bali Paradise Resort\nAddress: Jl. Pantai Kuta No. 12, Badung, Bali\nCheck-in: 2:00 PM\nCheck-out: 12:00 PM\nRoom Type: Ocean View Villa",
                    CancellationPolicy = "Free cancellation until 30 days before arrival.\n30% charge if cancelled 15-30 days before arrival.\n70% charge if cancelled 7-15 days before arrival.\nNo refund if cancelled less than 7 days before arrival."
                }
            };
        }

        private void DisplayUpcomingTrips()
        {
            tripListBox.Items.Clear();

            foreach (var trip in upcomingTrips)
            {
                string status = trip.Status == "Confirmed" ? "✓" : "⌛";
                tripListBox.Items.Add($"{status} {trip.Destination} ({trip.StartDate.ToString("MMM dd")} - {trip.EndDate.ToString("MMM dd")})");
            }
        }

        private void DisplayTripDetails(TripInfo trip)
        {
            selectedTrip = trip;

            // Update header
            lblDestination.Text = trip.Destination;
            lblDates.Text = $"{trip.StartDate.ToString("MMM dd, yyyy")} - {trip.EndDate.ToString("MMM dd, yyyy")}";
            lblStatus.Text = trip.Status;
            lblStatus.ForeColor = trip.Status == "Confirmed" ? Color.Green : Color.Orange;

            // Update trip info
            lblTripId.Text = $"Trip ID: {trip.TripId}";
            txtBookingDetails.Text = trip.BookingDetails;
            txtItinerary.Text = trip.Itinerary;
            txtAccommodation.Text = trip.Accommodation;
            txtCancellationPolicy.Text = trip.CancellationPolicy;

            // Show the details panel
            panelDetails.Visible = true;
        }

        private void ShowNoTripsMessage()
        {
            panelDetails.Visible = false;
            lblNoTrips.Visible = true;
        }

        private void tripListBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            int selectedIndex = tripListBox.SelectedIndex;
            if (selectedIndex >= 0 && selectedIndex < upcomingTrips.Count)
            {
                DisplayTripDetails(upcomingTrips[selectedIndex]);
                lblNoTrips.Visible = false;
            }
        }

        private void btnViewPass_Click(object sender, EventArgs e)
        {
            if (selectedTrip != null)
            {
                MessageBox.Show("Digital Pass feature will be implemented soon!", "Coming Soon", MessageBoxButtons.OK, MessageBoxIcon.Information);
                // In a real app, this would open the Digital Pass form
            }
        }

        private void btnContactSupport_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Our support team is available 24/7.\nPhone: +1-800-TRAVEL-EASE\nEmail: support@travelease.com",
                "Contact Support", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }

    // Class to hold trip information
    public class TripInfo
    {
        public string TripId { get; set; }
        public string Destination { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public string Status { get; set; }
        public string BookingDetails { get; set; }
        public string Itinerary { get; set; }
        public string Accommodation { get; set; }
        public string CancellationPolicy { get; set; }
    }
}