using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class OperatorMainForm : Form
    {
        private Panel sidebar, contentPanel;
        private System.Windows.Forms.Timer sidebarTimer;
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        private Label lblTitle;
        private Button btnAddTrip, btnManageTrips, btnAssignResources;

        public OperatorMainForm()
        {
            this.Text = "Operator Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;

            sidebar = new Panel
            {
                Width = sidebarMinWidth,
                Dock = DockStyle.Left,
                BackColor = Color.FromArgb(11, 57, 84) //coral blue
            };

            contentPanel = new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = Color.FromArgb(191, 215, 234)
            };

            sidebar.MouseEnter += Sidebar_MouseEnter;
            sidebar.MouseLeave += Sidebar_MouseLeave;

            sidebarTimer = new System.Windows.Forms.Timer { Interval = 10 };
            sidebarTimer.Tick += SidebarTimer_Tick;

            lblTitle = new Label
            {
                Text = "🗺️",
                ForeColor = Color.White,
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Dock = DockStyle.Top,
                Height = 60,
                TextAlign = ContentAlignment.MiddleCenter
            };

            btnAddTrip = CreateSidebarButton("➕", "Add Trip", 70);
            btnManageTrips = CreateSidebarButton("📋", "Manage Trips", 120);
            btnAssignResources = CreateSidebarButton("📦", "Assign Resources", 170);

            sidebar.Controls.AddRange(new Control[] { lblTitle, btnAddTrip, btnManageTrips, btnAssignResources });

            this.Controls.Add(contentPanel);
            this.Controls.Add(sidebar);

            btnAddTrip.Click += BtnAddTrip_Click;
            btnManageTrips.Click += BtnManageTrips_Click;
            btnAssignResources.Click += BtnAssignResources_Click;
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

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // OperatorMainForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "OperatorMainForm";
            this.Load += new System.EventHandler(this.OperatorMainForm_Load);
            this.ResumeLayout(false);

        }

        private void OperatorMainForm_Load(object sender, EventArgs e)
        {

        }

        private void BtnAddTrip_Click(object sender, EventArgs e)
        {
            contentPanel.Controls.Clear();
            var form = new AddTripForm { TopLevel = false, Dock = DockStyle.Fill };
            contentPanel.Controls.Add(form);
            form.Show();
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
