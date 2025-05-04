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
        private Button btnSearchTrips, btnMyBookings, btnProfile;

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

            // Sidebar buttons
            btnSearchTrips = CreateSidebarButton("🔍", "Search Trips", 70);
            btnMyBookings = CreateSidebarButton("📅", "My Bookings", 120);
            btnProfile = CreateSidebarButton("✏️", "Edit Profile", 170);

            // Assemble sidebar
            sidebar.Controls.AddRange(new Control[] {
                lblTitle,
                btnSearchTrips,
                btnMyBookings,
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
            btn.Click += (sender, e) => { /* Click handled in main file */ };
            return btn;
        }
    }
}
