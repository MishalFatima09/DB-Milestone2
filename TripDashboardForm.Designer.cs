using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class TripDashboardForm
    {
        private System.ComponentModel.IContainer components = null;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Main components
            this.panelHeader = new Panel();
            this.lblDashboardTitle = new Label();
            this.panelSidebar = new Panel();
            this.tripListBox = new ListBox();
            this.lblUpcomingTrips = new Label();
            this.panelDetails = new Panel();
            this.panelTripHeader = new Panel();
            this.lblDestination = new Label();
            this.lblDates = new Label();
            this.lblStatus = new Label();
            this.lblTripId = new Label();
            this.tabControl = new TabControl();
            this.tabBooking = new TabPage();
            this.txtBookingDetails = new TextBox();
            this.tabItinerary = new TabPage();
            this.txtItinerary = new TextBox();
            this.tabAccommodation = new TabPage();
            this.txtAccommodation = new TextBox();
            this.tabCancellation = new TabPage();
            this.txtCancellationPolicy = new TextBox();
            this.panelActions = new Panel();
            this.btnViewPass = new Button();
            this.btnContactSupport = new Button();
            this.lblNoTrips = new Label();

            // Form settings
            this.Text = "";
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScaleMode = AutoScaleMode.Font;
            this.BackColor = ColorTranslator.FromHtml("#BFD7EA");
            this.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point, 0);
            this.Padding = new Padding(15);

            // Header Panel
            this.panelHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 60,
                BackColor = Color.FromArgb(11, 57, 84),
                Padding = new Padding(20, 0, 20, 0)
            };

            this.lblDashboardTitle = new Label
            {
                Text = "Trip Dashboard 🌍",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                Dock = DockStyle.Left,
                TextAlign = ContentAlignment.MiddleLeft,
                AutoSize = true
            };

            panelHeader.Controls.Add(lblDashboardTitle);

            // Sidebar Panel
            this.panelSidebar = new Panel
            {
                Dock = DockStyle.Left,
                Width = 250,
                Padding = new Padding(10),
                BackColor = Color.FromArgb(220, 230, 240)
            };

            this.lblUpcomingTrips = new Label
            {
                Text = "Upcoming Trips",
                Font = new Font("Segoe UI", 12, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 40,
                TextAlign = ContentAlignment.MiddleLeft
            };

            this.tripListBox = new ListBox
            {
                Dock = DockStyle.Fill,
                BorderStyle = BorderStyle.None,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.FromArgb(235, 240, 245),
                ForeColor = Color.FromArgb(20, 40, 80),
                ItemHeight = 30,
                IntegralHeight = false
            };
            tripListBox.SelectedIndexChanged += new EventHandler(tripListBox_SelectedIndexChanged);

            panelSidebar.Controls.Add(tripListBox);
            panelSidebar.Controls.Add(lblUpcomingTrips);

            // Details Panel
            this.panelDetails = new Panel
            {
                Dock = DockStyle.Fill,
                Padding = new Padding(15),
                Visible = false
            };

            // Trip Header panel
            this.panelTripHeader = new Panel
            {
                Dock = DockStyle.Top,
                Height = 100,
                Padding = new Padding(5),
                BackColor = Color.White
            };

            this.lblDestination = new Label
            {
                Text = "Destination",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(10, 10),
                AutoSize = true
            };

            this.lblDates = new Label
            {
                Text = "Dates",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(60, 60, 60),
                Location = new Point(10, 40),
                AutoSize = true
            };

            this.lblStatus = new Label
            {
                Text = "Status",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.Green,
                Location = new Point(10, 65),
                AutoSize = true
            };

            this.lblTripId = new Label
            {
                Text = "Trip ID",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Gray,
                Location = new Point(300, 70),
                AutoSize = true,
                Anchor = AnchorStyles.Top | AnchorStyles.Right
            };

            panelTripHeader.Controls.Add(lblDestination);
            panelTripHeader.Controls.Add(lblDates);
            panelTripHeader.Controls.Add(lblStatus);
            panelTripHeader.Controls.Add(lblTripId);

            // Tab Control
            this.tabControl = new TabControl
            {
                Dock = DockStyle.Fill,
                Font = new Font("Segoe UI", 10)
            };

            // Booking Tab
            this.tabBooking = new TabPage
            {
                Text = "Booking Details",
                Padding = new Padding(10)
            };

            this.txtBookingDetails = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            tabBooking.Controls.Add(txtBookingDetails);

            // Itinerary Tab
            this.tabItinerary = new TabPage
            {
                Text = "Itinerary",
                Padding = new Padding(10)
            };

            this.txtItinerary = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None,
                ScrollBars = ScrollBars.Vertical
            };

            tabItinerary.Controls.Add(txtItinerary);

            // Accommodation Tab
            this.tabAccommodation = new TabPage
            {
                Text = "Accommodation",
                Padding = new Padding(10)
            };

            this.txtAccommodation = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            tabAccommodation.Controls.Add(txtAccommodation);

            // Cancellation Policy Tab
            this.tabCancellation = new TabPage
            {
                Text = "Cancellation Policy",
                Padding = new Padding(10)
            };

            this.txtCancellationPolicy = new TextBox
            {
                Dock = DockStyle.Fill,
                Multiline = true,
                ReadOnly = true,
                Font = new Font("Segoe UI", 10),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            tabCancellation.Controls.Add(txtCancellationPolicy);

            // Add all tabs
            tabControl.Controls.Add(tabBooking);
            tabControl.Controls.Add(tabItinerary);
            tabControl.Controls.Add(tabAccommodation);
            tabControl.Controls.Add(tabCancellation);

            // Actions Panel
            this.panelActions = new Panel
            {
                Dock = DockStyle.Bottom,
                Height = 50,
                Padding = new Padding(10)
            };

            this.btnViewPass = new Button
            {
                Text = "View Digital Pass",
                Width = 150,
                Height = 32,
                Location = new Point(10, 10),
                BackColor = Color.FromArgb(11, 57, 84),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnViewPass.FlatAppearance.BorderSize = 0;
            btnViewPass.Click += new EventHandler(btnViewPass_Click);

            this.btnContactSupport = new Button
            {
                Text = "Contact Support",
                Width = 150,
                Height = 32,
                Location = new Point(170, 10),
                BackColor = Color.FromArgb(135, 162, 186),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 9, FontStyle.Bold),
                Cursor = Cursors.Hand
            };
            btnContactSupport.FlatAppearance.BorderSize = 0;
            btnContactSupport.Click += new EventHandler(btnContactSupport_Click);

            panelActions.Controls.Add(btnViewPass);
            panelActions.Controls.Add(btnContactSupport);

            // No trips message
            this.lblNoTrips = new Label
            {
                Text = "You have no upcoming trips. Browse our catalog to book your next adventure!",
                Font = new Font("Segoe UI", 12),
                ForeColor = Color.FromArgb(80, 80, 80),
                TextAlign = ContentAlignment.MiddleCenter,
                Dock = DockStyle.Fill,
                Visible = false
            };

            // Assemble the details panel
            panelDetails.Controls.Add(tabControl);
            panelDetails.Controls.Add(panelActions);
            panelDetails.Controls.Add(panelTripHeader);

            // Add all main components to form
            this.Controls.Add(lblNoTrips);
            this.Controls.Add(panelDetails);
            this.Controls.Add(panelSidebar);
            this.Controls.Add(panelHeader);

            this.Load += new EventHandler(TripDashboardForm_Load);
        }

        private Panel panelHeader;
        private Label lblDashboardTitle;
        private Panel panelSidebar;
        private ListBox tripListBox;
        private Label lblUpcomingTrips;
        private Panel panelDetails;
        private Panel panelTripHeader;
        private Label lblDestination;
        private Label lblDates;
        private Label lblStatus;
        private Label lblTripId;
        private TabControl tabControl;
        private TabPage tabBooking;
        private TextBox txtBookingDetails;
        private TabPage tabItinerary;
        private TextBox txtItinerary;
        private TabPage tabAccommodation;
        private TextBox txtAccommodation;
        private TabPage tabCancellation;
        private TextBox txtCancellationPolicy;
        private Panel panelActions;
        private Button btnViewPass;
        private Button btnContactSupport;
        private Label lblNoTrips;

        #endregion
    }
}