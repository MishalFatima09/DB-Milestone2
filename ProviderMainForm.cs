using System;
using System.Windows.Forms;
using System.Drawing;
using DB_M2_Chat;

namespace TravelEase.Forms
{
    public partial class ProviderMainForm : Form
    {
        // expansion state and limits
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        public ProviderMainForm()
        {
            InitializeComponent();
        }

        private void ProviderMainForm_Load(object sender, EventArgs e)
        {
            // any startup logic
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

        private void btnServiceIntegration_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new ServiceIntegrationForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnAllServices_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new AllServicesForm { TopLevel = false, Dock = DockStyle.Fill };
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

        private void btnBookingManagement_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new BookingManagementForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnPerformanceReports_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new PerformanceReportForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}