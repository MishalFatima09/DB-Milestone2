using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class OperatorMainForm
    {
        private Panel sidebar, contentPanel;
        private Timer sidebarTimer;
        private bool isExpanded = false;
        private int sidebarMaxWidth = 200;
        private int sidebarMinWidth = 50;

        private Label lblTitle;
        private Button btnAddTrip, btnManageTrips, btnAssignResources;

        private void InitializeComponent()
        {
            this.sidebar = new Panel();
            this.contentPanel = new Panel();
            this.sidebarTimer = new Timer();
            this.lblTitle = new Label();

            // 
            // OperatorMainForm
            // 
            this.Text = "Operator Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.OperatorMainForm_Load);

            // 
            // sidebar
            // 
            this.sidebar.Width = sidebarMinWidth;
            this.sidebar.Dock = DockStyle.Left;
            this.sidebar.BackColor = Color.FromArgb(11, 57, 84);
            this.sidebar.MouseEnter += Sidebar_MouseEnter;
            this.sidebar.MouseLeave += Sidebar_MouseLeave;

            // 
            // contentPanel
            // 
            this.contentPanel.Dock = DockStyle.Fill;
            this.contentPanel.BackColor = Color.FromArgb(191, 215, 234);

            //
            // Picture
            //
            PictureBox pictureBox = new PictureBox();
            pictureBox.Image = DB_M2_Chat.Properties.Resources.logo; 
            pictureBox.SizeMode = PictureBoxSizeMode.Zoom;
            pictureBox.Size = new Size(300, 300);
            pictureBox.Location = new Point(
                (this.contentPanel.Width - pictureBox.Width) / 2,
                (this.contentPanel.Height - pictureBox.Height) / 2
            );
            pictureBox.Anchor = AnchorStyles.None;

            this.contentPanel.Controls.Add(pictureBox);

            // 
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "🗺️";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 60;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // 
            // btnAddTrip
            // 
            this.btnAddTrip = CreateSidebarButton("➕", "Add Trip", 70);

            // 
            // btnManageTrips
            // 
            this.btnManageTrips = CreateSidebarButton("📋", "Manage Trips", 120);

            // 
            // btnAssignResources
            // 
            this.btnAssignResources = CreateSidebarButton("📦", "Assign Resources", 170);

            // Add controls to sidebar
            this.sidebar.Controls.AddRange(new Control[] {
                this.lblTitle,
                this.btnAddTrip,
                this.btnManageTrips,
                this.btnAssignResources
            });

            // Add panels to form
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebar);
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
