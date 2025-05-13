using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class TravelerMainForm
    {
        private Panel sidebar, contentPanel;
        private Timer sidebarTimer;
        private Label lblTitle;
        private Button btnSearchTrips, btnTripDashboard, btnDigitalPass, btnMyBookings, btnReviews, btnProfile;

        private void InitializeComponent()
        {
            // Form
            this.Text = "Traveler Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new EventHandler(this.TravelerMainForm_Load);

            // Sidebar panel
            sidebar = new Panel
            {
                Width = sidebarMinWidth,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(11, 57, 84)
            };
            sidebar.MouseEnter += Sidebar_MouseEnter;
            sidebar.MouseLeave += Sidebar_MouseLeave;

            // Content panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = ColorTranslator.FromHtml("#BFD7EA")
            };

            // Sidebar timer
            sidebarTimer = new Timer { Interval = 10 };
            sidebarTimer.Tick += new EventHandler(this.SidebarTimer_Tick);

            // Title label
            lblTitle = new Label
            {
                Text = "🧳",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // Sidebar buttons - Reordered based on frequency of use
            btnTripDashboard = CreateSidebarButton("📊", "Trip Dashboard", 70);
            btnTripDashboard.Click += new EventHandler(this.btnTripDashboard_Click);

            btnSearchTrips = CreateSidebarButton("🔍", "Search Trips", 120);
            btnSearchTrips.Click += new EventHandler(this.btnSearchTrips_Click);

            btnMyBookings = CreateSidebarButton("📅", "My Bookings", 170);
            btnMyBookings.Click += new EventHandler(this.btnMyBookings_Click);

            btnDigitalPass = CreateSidebarButton("🎫", "Digital Pass", 220);
            btnDigitalPass.Click += new EventHandler(this.btnDigitalPass_Click);

            btnReviews = CreateSidebarButton("⭐", "Reviews", 270);
            btnReviews.Click += new EventHandler(this.btnReviews_Click);

            btnProfile = CreateSidebarButton("✏️", "Edit Profile", 320);
            btnProfile.Click += new EventHandler(this.btnProfile_Click);

            // Assemble sidebar
            sidebar.Controls.AddRange(new Control[] {
                lblTitle,
                btnTripDashboard,
                btnSearchTrips,
                btnMyBookings,
                btnDigitalPass,
                btnReviews,
                btnProfile
            });

            // Add panels to form
            this.Controls.Add(contentPanel);
            this.Controls.Add(sidebar);
        }

        private Button CreateSidebarButton(string icon, string label, int top)
        {
            var btn = new Button
            {
                Text = icon,
                Tag = label,
                Width = sidebarMinWidth - 10,
                Height = 40,
                Left = 5,
                Top = top,
                FlatStyle = FlatStyle.Flat,
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.White,
                BackColor = Color.FromArgb(11, 57, 84),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += Sidebar_MouseEnter;
            btn.MouseLeave += Sidebar_MouseLeave;
            return btn;
        }
    }
}