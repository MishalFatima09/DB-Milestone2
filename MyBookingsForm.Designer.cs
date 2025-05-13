using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class MyBookingsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header elements
        private Label lblTitle;
        private Label lblDescription;

        // Control panel
        private Panel panelControls;
        private Label lblFilterBy;
        private ComboBox cmbFilterStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;
        private Button btnExport;

        // Summary panel
        private Panel panelSummary;
        private Panel panelTotalBookings;
        private Panel panelUpcomingBookings;
        private Panel panelCompletedBookings;

        // Summary labels
        private Label lblTotalBookingsTitle;
        private Label lblTotalBookings;
        private Label lblUpcomingBookingsTitle;
        private Label lblUpcomingBookings;
        private Label lblCompletedBookingsTitle;
        private Label lblCompletedBookings;

        // Data grid
        private DataGridView dgvBookings;

        // Action buttons
        private Panel panelActions;
        private Button btnViewDetails;
        private Button btnCancelBooking;
        private Button btnLeaveReview;

        // Booking details panel
        private Panel bookingDetailsPanel;
        private Label lblDetailsTitle;
        private Button btnCloseDetails;
        private Label lblBookingId, lblBookingIdValue;
        private Label lblTripName, lblTripNameValue;
        private Label lblDateRange, lblDateRangeValue;
        private Label lblStatus, lblStatusValue;
        private Label lblPrice, lblPriceValue;
        private Label lblBookingDate, lblBookingDateValue;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Title Label
            this.lblTitle = new Label
            {
                Text = "🧳 My Bookings",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "View and manage all your travel bookings in one place",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Control Panel
            this.panelControls = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(760, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Filter Label
            this.lblFilterBy = new Label
            {
                Text = "Filter Status:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Filter ComboBox
            this.cmbFilterStatus = new ComboBox
            {
                Location = new Point(100, 12),
                Size = new Size(140, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbFilterStatus.Items.AddRange(new object[] { "All Bookings", "Upcoming", "Completed", "Cancelled" });
            this.cmbFilterStatus.SelectedIndexChanged += new EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            // Search TextBox
            this.txtSearch = new TextBox
            {
                Location = new Point(260, 12),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9)
            };
            this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);

            // Search Button
            this.btnSearch = new Button
            {
                Text = "🔍",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(470, 12),
                Size = new Size(30, 25)
            };
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Refresh Button
            this.btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(510, 12),
                Size = new Size(80, 25)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Export Button
            this.btnExport = new Button
            {
                Text = "Export Data",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(650, 12),
                Size = new Size(90, 25)
            };
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            // Add controls to panel
            this.panelControls.Controls.AddRange(new Control[]
            {
                this.lblFilterBy,
                this.cmbFilterStatus,
                this.txtSearch,
                this.btnSearch,
                this.btnRefresh,
                this.btnExport
            });

            // Summary Panel
            this.panelSummary = new Panel
            {
                Location = new Point(30, 140),
                Size = new Size(760, 70),
                BackColor = Color.White
            };

            // Total Bookings Panel
            this.panelTotalBookings = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(230, 242, 255)
            };

            // Total Bookings Title
            this.lblTotalBookingsTitle = new Label
            {
                Text = "Total Bookings",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Total Bookings Count
            this.lblTotalBookings = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelTotalBookings.Controls.AddRange(new Control[]
            {
                this.lblTotalBookingsTitle,
                this.lblTotalBookings
            });

            // Upcoming Bookings Panel
            this.panelUpcomingBookings = new Panel
            {
                Location = new Point(260, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(229, 243, 255)
            };

            // Upcoming Bookings Title
            this.lblUpcomingBookingsTitle = new Label
            {
                Text = "Upcoming Bookings",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Blue,
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Upcoming Bookings Count
            this.lblUpcomingBookings = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelUpcomingBookings.Controls.AddRange(new Control[]
            {
                this.lblUpcomingBookingsTitle,
                this.lblUpcomingBookings
            });

            // Completed Bookings Panel
            this.panelCompletedBookings = new Panel
            {
                Location = new Point(510, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(234, 249, 236)
            };

            // Completed Bookings Title
            this.lblCompletedBookingsTitle = new Label
            {
                Text = "Completed Bookings",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(46, 139, 87),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Completed Bookings Count
            this.lblCompletedBookings = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(46, 139, 87),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelCompletedBookings.Controls.AddRange(new Control[]
            {
                this.lblCompletedBookingsTitle,
                this.lblCompletedBookings
            });

            // Add panels to summary panel
            this.panelSummary.Controls.AddRange(new Control[]
            {
                this.panelTotalBookings,
                this.panelUpcomingBookings,
                this.panelCompletedBookings
            });

            // Bookings DataGridView
            this.dgvBookings = new DataGridView
            {
                Location = new Point(30, 220),
                Size = new Size(760, 250),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 25 }
            };

            // Set up columns
            this.dgvBookings.ColumnCount = 6;
            this.dgvBookings.Columns[0].Name = "BookingId";
            this.dgvBookings.Columns[0].HeaderText = "ID";
            this.dgvBookings.Columns[0].Width = 50;
            this.dgvBookings.Columns[1].Name = "TripName";
            this.dgvBookings.Columns[1].HeaderText = "Trip";
            this.dgvBookings.Columns[1].Width = 150;
            this.dgvBookings.Columns[2].Name = "StartDate";
            this.dgvBookings.Columns[2].HeaderText = "From";
            this.dgvBookings.Columns[2].Width = 80;
            this.dgvBookings.Columns[3].Name = "EndDate";
            this.dgvBookings.Columns[3].HeaderText = "To";
            this.dgvBookings.Columns[3].Width = 80;
            this.dgvBookings.Columns[4].Name = "Status";
            this.dgvBookings.Columns[4].HeaderText = "Status";
            this.dgvBookings.Columns[4].Width = 100;
            this.dgvBookings.Columns[5].Name = "Price";
            this.dgvBookings.Columns[5].HeaderText = "Price";
            this.dgvBookings.Columns[5].Width = 80;

            this.dgvBookings.SelectionChanged += new EventHandler(this.dgvBookings_SelectionChanged);
            this.dgvBookings.CellDoubleClick += new DataGridViewCellEventHandler(this.dgvBookings_CellDoubleClick);

            // Action Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 480),
                Size = new Size(760, 50),
                BackColor = Color.White
            };

            // View Details Button
            this.btnViewDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 10),
                Size = new Size(100, 30),
                Enabled = false
            };
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

            // Cancel Booking Button
            this.btnCancelBooking = new Button
            {
                Text = "✗ Cancel Booking",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(120, 10),
                Size = new Size(120, 30),
                Enabled = false
            };
            this.btnCancelBooking.FlatAppearance.BorderSize = 0;
            this.btnCancelBooking.Click += new EventHandler(this.btnCancelBooking_Click);

            // Leave Review Button
            this.btnLeaveReview = new Button
            {
                Text = "⭐ Leave Review",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(250, 10),
                Size = new Size(120, 30),
                Enabled = false
            };
            this.btnLeaveReview.FlatAppearance.BorderSize = 0;
            this.btnLeaveReview.Click += new EventHandler(this.btnLeaveReview_Click);

            // Add controls to action panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnViewDetails,
                this.btnCancelBooking,
                this.btnLeaveReview
            });

            // Booking Details Panel (initially hidden)
            this.bookingDetailsPanel = new Panel
            {
                Location = new Point(150, 150),
                Size = new Size(500, 300),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle,
                Visible = false
            };

            // Details Panel Title
            this.lblDetailsTitle = new Label
            {
                Text = "Booking Details",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 20),
                Size = new Size(200, 30),
                AutoSize = true
            };

            // Close Details Button
            this.btnCloseDetails = new Button
            {
                Text = "×",
                Font = new Font("Arial", 12, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                BackColor = Color.Transparent,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(460, 10),
                Size = new Size(30, 30)
            };
            this.btnCloseDetails.FlatAppearance.BorderSize = 0;
            this.btnCloseDetails.Click += new EventHandler(this.btnCloseDetails_Click);

            // Booking detail labels
            this.lblBookingId = new Label
            {
                Text = "Booking ID:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 70),
                Size = new Size(120, 20)
            };

            this.lblBookingIdValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(150, 70),
                Size = new Size(250, 20)
            };

            this.lblTripName = new Label
            {
                Text = "Trip Name:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 100),
                Size = new Size(120, 20)
            };

            this.lblTripNameValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(150, 100),
                Size = new Size(250, 20)
            };

            this.lblDateRange = new Label
            {
                Text = "Travel Dates:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 130),
                Size = new Size(120, 20)
            };

            this.lblDateRangeValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(150, 130),
                Size = new Size(250, 20)
            };

            this.lblStatus = new Label
            {
                Text = "Status:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 160),
                Size = new Size(120, 20)
            };

            this.lblStatusValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                Location = new Point(150, 160),
                Size = new Size(250, 20)
            };

            this.lblPrice = new Label
            {
                Text = "Total Price:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 190),
                Size = new Size(120, 20)
            };

            this.lblPriceValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(150, 190),
                Size = new Size(250, 20)
            };

            this.lblBookingDate = new Label
            {
                Text = "Booking Date:",
                Font = new Font("Segoe UI", 10, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 220),
                Size = new Size(120, 20)
            };

            this.lblBookingDateValue = new Label
            {
                Text = "",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.Black,
                Location = new Point(150, 220),
                Size = new Size(250, 20)
            };

            // Add controls to details panel
            this.bookingDetailsPanel.Controls.AddRange(new Control[] {
                this.lblDetailsTitle,
                this.btnCloseDetails,
                this.lblBookingId, this.lblBookingIdValue,
                this.lblTripName, this.lblTripNameValue,
                this.lblDateRange, this.lblDateRangeValue,
                this.lblStatus, this.lblStatusValue,
                this.lblPrice, this.lblPriceValue,
                this.lblBookingDate, this.lblBookingDateValue
            });

            // Form properties
            this.Text = "My Bookings";
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 550);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelControls,
                this.panelSummary,
                this.dgvBookings,
                this.panelActions,
                this.bookingDetailsPanel
            });

            this.Load += new EventHandler(this.MyBookingsForm_Load);
        }
    }
}