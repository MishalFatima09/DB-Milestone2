using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class SearchTripsForm
    {
        private Label lblHeader;
        private Panel pnlSearchCriteria;
        private Label lblDestination;
        private ComboBox cmbDestination;
        private Label lblDates;
        private DateTimePicker dtpStartDate;
        private Label lblDateSeparator;
        private DateTimePicker dtpEndDate;
        private Label lblTripType;
        private ComboBox cmbTripType;
        private Label lblPriceRange;
        private TrackBar trkPriceRange;
        private Label lblIncludes;
        private CheckBox chkIncludeFlights;
        private CheckBox chkIncludeHotels;
        private CheckBox chkIncludeActivities;
        private Button btnSearch;
        private Button btnClear;
        private FlowLayoutPanel flpSearchResults;
        private Label lblResults;

        private void InitializeComponent()
        {
            // Form properties
            this.Text = "Search Trips";
            this.Size = new Size(800, 600);
            this.AutoScroll = true;
            this.BackColor = ColorTranslator.FromHtml("#BFD7EA");
            this.Load += new EventHandler(this.SearchTripsForm_Load);

            // Header
            lblHeader = new Label
            {
                Text = "Find Your Perfect Trip",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#0B3954"),
                Location = new Point(20, 20),
                Size = new Size(760, 30)
            };

            // Search criteria panel
            pnlSearchCriteria = new Panel
            {
                Location = new Point(20, 60),
                Size = new Size(760, 160),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Destination
            lblDestination = new Label
            {
                Text = "Destination:",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 20),
                Size = new Size(80, 20)
            };

            cmbDestination = new ComboBox
            {
                Location = new Point(110, 20),
                Size = new Size(200, 25),
                AutoCompleteMode = AutoCompleteMode.SuggestAppend,
                AutoCompleteSource = AutoCompleteSource.ListItems
            };

            // Trip Type
            lblTripType = new Label
            {
                Text = "Trip Type:",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 60),
                Size = new Size(80, 20)
            };

            cmbTripType = new ComboBox
            {
                Location = new Point(110, 60),
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };

            // Dates
            lblDates = new Label
            {
                Text = "Travel Dates:",
                Font = new Font("Segoe UI", 9),
                Location = new Point(20, 100),
                Size = new Size(80, 20)
            };

            dtpStartDate = new DateTimePicker
            {
                Location = new Point(110, 100),
                Size = new Size(120, 25),
                Format = DateTimePickerFormat.Short
            };

            lblDateSeparator = new Label
            {
                Text = "to",
                Font = new Font("Segoe UI", 9),
                Location = new Point(235, 100),
                Size = new Size(20, 20),
                TextAlign = ContentAlignment.MiddleCenter
            };

            dtpEndDate = new DateTimePicker
            {
                Location = new Point(260, 100),
                Size = new Size(120, 25),
                Format = DateTimePickerFormat.Short
            };

            // Price Range
            lblPriceRange = new Label
            {
                Text = "Price Range: $0 - $5000",
                Font = new Font("Segoe UI", 9),
                Location = new Point(350, 20),
                Size = new Size(200, 20)
            };

            trkPriceRange = new TrackBar
            {
                Location = new Point(350, 40),
                Size = new Size(200, 45),
                Minimum = 5,
                Maximum = 100,
                TickFrequency = 10,
                Value = 50
            };
            trkPriceRange.Scroll += new EventHandler(this.trkPriceRange_Scroll);

            // Includes
            lblIncludes = new Label
            {
                Text = "Include:",
                Font = new Font("Segoe UI", 9),
                Location = new Point(350, 100),
                Size = new Size(60, 20)
            };

            chkIncludeFlights = new CheckBox
            {
                Text = "Flights",
                Location = new Point(410, 100),
                Size = new Size(70, 20),
                Checked = false
            };

            chkIncludeHotels = new CheckBox
            {
                Text = "Hotels",
                Location = new Point(480, 100),
                Size = new Size(70, 20),
                Checked = false
            };

            chkIncludeActivities = new CheckBox
            {
                Text = "Activities",
                Location = new Point(550, 100),
                Size = new Size(80, 20),
                Checked = false
            };

            // Buttons
            btnSearch = new Button
            {
                Text = "Search",
                BackColor = ColorTranslator.FromHtml("#0B3954"),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Location = new Point(650, 40),
                Size = new Size(90, 35)
            };
            btnSearch.FlatAppearance.BorderSize = 0;
            btnSearch.Click += new EventHandler(this.btnSearch_Click);

            btnClear = new Button
            {
                Text = "Clear",
                BackColor = Color.Silver,
                ForeColor = Color.Black,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9),
                Location = new Point(650, 80),
                Size = new Size(90, 35)
            };
            btnClear.FlatAppearance.BorderSize = 0;
            btnClear.Click += new EventHandler(this.btnClear_Click);

            // Results label
            lblResults = new Label
            {
                Text = "Search Results",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                ForeColor = ColorTranslator.FromHtml("#0B3954"),
                Location = new Point(20, 230),
                Size = new Size(760, 25)
            };

            // Results panel
            flpSearchResults = new FlowLayoutPanel
            {
                Location = new Point(20, 260),
                Size = new Size(760, 300),
                AutoScroll = true,
                BorderStyle = BorderStyle.None,
                FlowDirection = FlowDirection.TopDown,
                WrapContents = false
            };

            // Add controls to panel
            pnlSearchCriteria.Controls.AddRange(new Control[] {
                lblDestination, cmbDestination,
                lblTripType, cmbTripType,
                lblDates, dtpStartDate, lblDateSeparator, dtpEndDate,
                lblPriceRange, trkPriceRange,
                lblIncludes, chkIncludeFlights, chkIncludeHotels, chkIncludeActivities,
                btnSearch, btnClear
            });

            // Add controls to form
            this.Controls.AddRange(new Control[] {
                lblHeader,
                pnlSearchCriteria,
                lblResults,
                flpSearchResults
            });
        }
    }
}