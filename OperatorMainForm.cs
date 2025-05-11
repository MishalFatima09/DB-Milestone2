using System;
using System.Windows.Forms;
using System.Drawing;


namespace TravelEase.Forms
{
    public partial class OperatorMainForm : Form
    {
        public OperatorMainForm()
        {
            InitializeComponent();
        }

        private void OperatorMainForm_Load(object sender, EventArgs e)
        {
            // Optional: logic to run on load
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
            lblTitle.Text = expanded ? "🗺️  Operator" : "🗺️";
            lblTitle.TextAlign = expanded
                ? ContentAlignment.MiddleLeft
                : ContentAlignment.MiddleCenter;

            foreach (Control ctrl in sidebar.Controls)
            {
                if (ctrl is Button btn && btn.Tag is string label)
                {
                    btn.Text = expanded
                        ? $"{btn.Text.Split(' ')[0]}  {label}"
                        : btn.Text.Split(' ')[0];
                    btn.TextAlign = expanded
                        ? ContentAlignment.MiddleLeft
                        : ContentAlignment.MiddleCenter;
                    btn.Width = expanded
                        ? sidebarMaxWidth - 10
                        : sidebarMinWidth - 10;
                }
            }
        }

        private void BtnAddTrip_Click(object sender, EventArgs e)
        {
           // try {

                contentPanel.Controls.Clear();
                var form = new AddTripForm { TopLevel = false, Dock = DockStyle.Fill };
                contentPanel.Controls.Add(form);
                form.Show();
            //}  
            // catch (Exception ex)
            // {
            //     MessageBox.Show($"An error accurred: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            // }
        }
        private void BtnManageTrips_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new ManageTripsForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }

        private void BtnAssignResources_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new AssignResourcesForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
        }
    }
}
