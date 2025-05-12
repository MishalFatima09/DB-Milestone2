using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class ProviderMainForm
    {
        private Panel sidebar, contentPanel;
        private Timer sidebarTimer;
        private Label lblTitle;
        private Button btnServiceIntegration, btnAllServices, btnAddService, btnBookingManagement, btnPerformanceReports;

        private void InitializeComponent()
        {
            // form
            this.Text = "Provider Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new EventHandler(this.ProviderMainForm_Load);

            // sidebar panel
            sidebar = new Panel
            {
                Width = sidebarMinWidth,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(11, 57, 84)
            };
            sidebar.MouseEnter += Sidebar_MouseEnter;
            sidebar.MouseLeave += Sidebar_MouseLeave;

            // content panel
            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // timer
            sidebarTimer = new Timer { Interval = 10 };
            sidebarTimer.Tick += SidebarTimer_Tick;

            // title label
            lblTitle = new Label
            {
                Text = "🏨",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };

            // sidebar buttons
            btnServiceIntegration = CreateSidebarButton("📨", "Service Integration", 70);
            btnAllServices = CreateSidebarButton("🏷️", "All Services", 120);
            btnAddService = CreateSidebarButton("➕", "Add Service", 170);
            btnBookingManagement = CreateSidebarButton("📆", "Booking Management", 220);
            btnPerformanceReports = CreateSidebarButton("📊", "Performance Reports", 270);

            // button click events
            btnServiceIntegration.Click += btnServiceIntegration_Click;
            btnAllServices.Click += btnAllServices_Click;
            btnAddService.Click += btnAddService_Click;
            btnBookingManagement.Click += btnBookingManagement_Click;
            btnPerformanceReports.Click += btnPerformanceReports_Click;

            // assemble sidebar
            sidebar.Controls.AddRange(new Control[]
            {
                lblTitle,
                btnServiceIntegration,
                btnAllServices,
                btnAddService,
                btnBookingManagement,
                btnPerformanceReports
            });

            // add to form
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