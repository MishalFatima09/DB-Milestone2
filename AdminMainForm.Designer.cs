using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class AdminMainForm
    {
        private Panel sidebar, contentPanel;
        private Timer sidebarTimer;
        private Label lblTitle;
        private Button btnUserMgmt;
        private Button btnCategoryMgmt;
        private Button btnAnalytics;

        private void InitializeComponent()
        {
            this.sidebar = new Panel();
            this.contentPanel = new Panel();
            this.sidebarTimer = new Timer();
            this.lblTitle = new Label();
            this.btnUserMgmt = CreateSidebarButton("👤", "User Management", 70);
            this.btnUserMgmt.Click += new System.EventHandler(this.btnUserMgmt_Click);

            this.btnCategoryMgmt = CreateSidebarButton("🗂️", "Categories", 120);
            this.btnCategoryMgmt.Click += new System.EventHandler(this.btnCategoryMgmt_Click);

            this.btnAnalytics = CreateSidebarButton("📊", "Analytics", 170);
            this.btnAnalytics.Click += new System.EventHandler(this.btnAnalytics_Click);

            // 
            // AdminMainForm
            // 
            this.Text = "Admin Panel";
            this.Size = new Size(1000, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.Load += new System.EventHandler(this.AdminMainForm_Load);

            // 
            // sidebar
            // 
            this.sidebar.Width = 50;
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
            // sidebarTimer
            // 
            this.sidebarTimer.Interval = 10;
            this.sidebarTimer.Tick += new System.EventHandler(this.SidebarTimer_Tick);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "🛠️";
            this.lblTitle.ForeColor = Color.White;
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.Dock = DockStyle.Top;
            this.lblTitle.Height = 60;
            this.lblTitle.TextAlign = ContentAlignment.MiddleCenter;

            // Add controls to sidebar
            this.sidebar.Controls.Add(this.lblTitle);
            this.sidebar.Controls.Add(this.btnUserMgmt);
            this.sidebar.Controls.Add(this.btnCategoryMgmt);
            this.sidebar.Controls.Add(this.btnAnalytics);

            // Add panels to main form
            this.Controls.Add(this.contentPanel);
            this.Controls.Add(this.sidebar);
        }

        private Button CreateSidebarButton(string icon, string label, int top)
        {
            var btn = new Button
            {
                Text = icon,
                Tag = label,
                Width = 40,
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
