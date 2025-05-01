using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class ProviderMainForm : Form
    {
        private Panel sidebar, contentPanel;
        private System.Windows.Forms.Timer sidebarTimer;
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        private Label lblTitle;
        private Button btnMyServices;
        private Button btnAddService;
        private Button btnBookingRequests;

        public ProviderMainForm()
        {
            this.Text = "Provider Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            sidebar = new Panel
            {
                Width = sidebarMinWidth,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(30, 30, 60)
            };

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.White
            };

            sidebar.MouseEnter += Sidebar_MouseEnter;
            sidebar.MouseLeave += Sidebar_MouseLeave;

            sidebarTimer = new System.Windows.Forms.Timer { Interval = 10 };
            sidebarTimer.Tick += SidebarTimer_Tick;

            lblTitle = new Label
            {
                Text = "🏨",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnMyServices = CreateSidebarButton("🏷️", "My Services", 70);
            btnAddService = CreateSidebarButton("➕", "Add Service", 120);
            btnBookingRequests = CreateSidebarButton("📩", "Booking Requests", 170);

            sidebar.Controls.AddRange(new Control[] { lblTitle, btnMyServices, btnAddService, btnBookingRequests });
            this.Controls.Add(contentPanel);
            this.Controls.Add(sidebar);

            btnMyServices.Click += btnMyServices_Click;
            btnAddService.Click += btnAddService_Click;
            btnBookingRequests.Click += btnBookingRequests_Click;
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
                BackColor = Color.FromArgb(50, 50, 100),
                TextAlign = ContentAlignment.MiddleCenter
            };
            btn.FlatAppearance.BorderSize = 0;
            btn.MouseEnter += Sidebar_MouseEnter;
            btn.MouseLeave += Sidebar_MouseLeave;
            return btn;
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
            lblTitle.Text = expanded ? "🏨  Provider" : "🏨";
            lblTitle.TextAlign = expanded ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
            foreach (Control ctrl in sidebar.Controls)
            {
                if (ctrl is Button btn && btn.Tag is string label)
                {
                    btn.Text = expanded ? btn.Text.Split(' ')[0] + "  " + label : btn.Text.Split(' ')[0];
                    btn.TextAlign = expanded ? ContentAlignment.MiddleLeft : ContentAlignment.MiddleCenter;
                    btn.Width = expanded ? sidebarMaxWidth - 10 : sidebarMinWidth - 10;
                }
            }
        }

        private void btnMyServices_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new MyServicesForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new AddServiceForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnBookingRequests_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new BookingRequestsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
