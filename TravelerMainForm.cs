using System;
using System.Windows.Forms;
using System.Drawing;
using DB_M2_Chat;

namespace TravelEase.Forms
{
    public partial class TravelerMainForm : Form
    {
        // expansion state and size limits
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        public TravelerMainForm()
        {
            InitializeComponent();
        }

        private void TravelerMainForm_Load(object sender, EventArgs e)
        {
            // Load default view - Trip Dashboard
            //btnTripDashboard_Click(sender, e);
        }

        private void Sidebar_MouseEnter(object sender, EventArgs e)
        {
            isExpanded = true;
            sidebarTimer.Start();
        }

        private void Sidebar_MouseLeave(object sender, EventArgs e)
        {
            isExpanded = false;
            sidebarTimer.Start();
        }

        private void SidebarTimer_Tick(object sender, EventArgs e)
        {
            if (isExpanded && sidebar.Width < sidebarMaxWidth)
            {
                sidebar.Width += 10;
                if (sidebar.Width >= sidebarMaxWidth)
                {
                    UpdateSidebarText(true);
                    sidebarTimer.Stop();
                }
            }
            else if (!isExpanded && sidebar.Width > sidebarMinWidth)
            {
                sidebar.Width -= 10;
                if (sidebar.Width <= sidebarMinWidth)
                {
                    UpdateSidebarText(false);
                    sidebarTimer.Stop();
                }
            }
        }

        private void UpdateSidebarText(bool expanded)
        {
            lblTitle.Text = expanded ? "🧳  Traveler" : "🧳";
            lblTitle.TextAlign = expanded
                ? System.Drawing.ContentAlignment.MiddleLeft
                : System.Drawing.ContentAlignment.MiddleCenter;

            foreach (Control ctrl in sidebar.Controls)
            {
                if (ctrl is Button btn && btn.Tag is string label)
                {
                    var icon = btn.Text.Split(' ')[0];
                    btn.Text = expanded
                        ? $"{icon}  {label}"
                        : icon;
                    btn.TextAlign = expanded
                        ? System.Drawing.ContentAlignment.MiddleLeft
                        : System.Drawing.ContentAlignment.MiddleCenter;
                    btn.Width = expanded
                        ? sidebarMaxWidth - 10
                        : sidebarMinWidth - 10;
                }
            }
        }

        private void btnSearchTrips_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new SearchTripsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnTripDashboard_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new TripDashboardForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnDigitalPass_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new DigitalPassForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnMyBookings_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new MyBookingsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnReviews_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new TravelerReviewsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnProfile_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new EditProfileForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}