using DB_M2_Chat;
using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class AdminMainForm : Form
    {
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        public AdminMainForm()
        {
            InitializeComponent();
        }

        private void AdminMainForm_Load(object sender, EventArgs e)
        {
            // Load logic here if needed
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
            lblTitle.Text = expanded ? "🛠️  Admin" : "🛠️";
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

        private void btnUserMgmt_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new UserManagementForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnCategoryMgmt_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new CategoryForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnAnalytics_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new AnalyticsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void btnReviewMod_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new ReviewModerationForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}