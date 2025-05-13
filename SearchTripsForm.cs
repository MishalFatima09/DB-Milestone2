using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class SearchTripsForm : Form
    {
        public SearchTripsForm()
        {
            InitializeComponent();
        }

        private void SearchTripsForm_Load(object sender, EventArgs e)
        {
            // Populate destinations dropdown with sample data
            cmbDestination.Items.AddRange(new string[] {
                "Paris, France",
                "Rome, Italy",
                "Tokyo, Japan",
                "New York, USA",
                "London, UK",
                "Sydney, Australia",
                "Bali, Indonesia",
                "Cape Town, South Africa",
                "Dubai, UAE",
                "Cancun, Mexico"
            });

            // Populate trip types with sample data
            cmbTripType.Items.AddRange(new string[] {
                "All Types",
                "Beach Vacation",
                "City Break",
                "Adventure",
                "Cultural Tour",
                "Cruise",
                "Wildlife Safari",
                "Mountain Retreat",
                "Luxury Resort"
            });
            cmbTripType.SelectedIndex = 0;

            // Set date range defaults
            dtpStartDate.Value = DateTime.Now.AddDays(7);
            dtpEndDate.Value = DateTime.Now.AddDays(14);

            // Set price range defaults
            trkPriceRange.Value = 50;
            lblPriceRange.Text = $"Price Range: $0 - ${trkPriceRange.Value * 100}";

            // Add sample trip data
            PopulateSampleTripData();
        }

        private void PopulateSampleTripData()
        {
            // Clear existing items
            flpSearchResults.Controls.Clear();

            // Add sample trips
            AddTripCard("Paris Weekend Getaway", "Paris, France", "City Break", "3 days", "$750", "https://example.com/paris.jpg");
            AddTripCard("Rome Cultural Experience", "Rome, Italy", "Cultural Tour", "7 days", "$1,200", "https://example.com/rome.jpg");
            AddTripCard("Tokyo Explorer", "Tokyo, Japan", "Adventure", "10 days", "$2,500", "https://example.com/tokyo.jpg");
            AddTripCard("New York City Break", "New York, USA", "City Break", "4 days", "$950", "https://example.com/newyork.jpg");
            AddTripCard("London Theatre & Arts", "London, UK", "Cultural Tour", "5 days", "$1,100", "https://example.com/london.jpg");
        }

        private void AddTripCard(string title, string destination, string type, string duration, string price, string imageUrl)
        {
            Panel card = new Panel
            {
                Width = flpSearchResults.Width - 30,
                Height = 120,
                BorderStyle = BorderStyle.FixedSingle,
                BackColor = Color.White,
                Margin = new Padding(5)
            };

            // Image placeholder (in a real app, you'd load the actual image)
            Panel imagePanel = new Panel
            {
                Width = 100,
                Height = 100,
                Left = 10,
                Top = 10,
                BackColor = ColorTranslator.FromHtml("#BFD7EA")
            };

            Label imagePlaceholder = new Label
            {
                Text = "🖼️",
                Font = new Font("Segoe UI", 24),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill
            };
            imagePanel.Controls.Add(imagePlaceholder);

            // Trip info
            Label lblTitle = new Label
            {
                Text = title,
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Left = 120,
                Top = 10,
                Width = card.Width - 130,
                Height = 25
            };

            Label lblDestination = new Label
            {
                Text = $"Destination: {destination}",
                Font = new Font("Segoe UI", 9),
                Left = 120,
                Top = 35,
                Width = 200,
                Height = 20
            };

            Label lblType = new Label
            {
                Text = $"Type: {type}",
                Font = new Font("Segoe UI", 9),
                Left = 120,
                Top = 55,
                Width = 200,
                Height = 20
            };

            Label lblDuration = new Label
            {
                Text = $"Duration: {duration}",
                Font = new Font("Segoe UI", 9),
                Left = 330,
                Top = 35,
                Width = 150,
                Height = 20
            };

            Label lblPrice = new Label
            {
                Text = $"Price: {price}",
                Font = new Font("Segoe UI", 9),
                Left = 330,
                Top = 55,
                Width = 150,
                Height = 20
            };

            Button btnViewDetails = new Button
            {
                Text = "View Details",
                BackColor = ColorTranslator.FromHtml("#0B3954"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Left = card.Width - 130,
                Top = 40,
                Width = 110,
                Height = 30
            };
            btnViewDetails.FlatAppearance.BorderSize = 0;
            btnViewDetails.Click += (s, e) => MessageBox.Show($"Details for {title} would open here.");

            // Add all controls to the card
            card.Controls.AddRange(new Control[] {
                imagePanel, lblTitle, lblDestination, lblType,
                lblDuration, lblPrice, btnViewDetails
            });

            // Add the card to the results panel
            flpSearchResults.Controls.Add(card);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            // In a real application, this would search the database
            // For now, we'll just display a message with the search criteria
            string destination = cmbDestination.Text;
            string tripType = cmbTripType.Text;
            DateTime startDate = dtpStartDate.Value;
            DateTime endDate = dtpEndDate.Value;
            int maxPrice = trkPriceRange.Value * 100;

            MessageBox.Show($"Searching for trips to {destination}\n" +
                           $"Trip type: {tripType}\n" +
                           $"Dates: {startDate.ToShortDateString()} to {endDate.ToShortDateString()}\n" +
                           $"Max price: ${maxPrice}");

            // Here you would update the search results based on criteria
        }

        private void trkPriceRange_Scroll(object sender, EventArgs e)
        {
            lblPriceRange.Text = $"Price Range: $0 - ${trkPriceRange.Value * 100}";
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            cmbDestination.Text = "";
            cmbTripType.SelectedIndex = 0;
            dtpStartDate.Value = DateTime.Now.AddDays(7);
            dtpEndDate.Value = DateTime.Now.AddDays(14);
            trkPriceRange.Value = 50;
            lblPriceRange.Text = $"Price Range: $0 - ${trkPriceRange.Value * 100}";
            chkIncludeFlights.Checked = false;
            chkIncludeHotels.Checked = false;
            chkIncludeActivities.Checked = false;
        }
    }
}