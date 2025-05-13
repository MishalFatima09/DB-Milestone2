using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class DigitalPassForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header elements
        private Label lblTitle;
        private Label lblDescription;

        // Control panel
        private Panel panelControls;
        private Label lblFilterBy;
        private ComboBox cmbFilterType;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;

        // Summary panel
        private Panel panelSummary;
        private Panel panelTotalPasses;
        private Panel panelUpcomingPasses;
        private Panel panelExpiredPasses;

        // Summary labels
        private Label lblTotalPassesTitle;
        private Label lblTotalPasses;
        private Label lblUpcomingPassesTitle;
        private Label lblUpcomingPasses;
        private Label lblExpiredPassesTitle;
        private Label lblExpiredPasses;

        // Data grid
        private DataGridView dgvPasses;

        // Action buttons
        private Panel panelActions;
        private Button btnViewDetails;
        private Button btnDownload;
        private Button btnShare;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Title Label
            this.lblTitle = new Label
            {
                Text = "🎫 Digital Travel Pass",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Access your e-tickets, hotel vouchers, and activity passes all in one place",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Control Panel
            this.panelControls = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(760, 50),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Filter Label
            this.lblFilterBy = new Label
            {
                Text = "Filter Pass Type:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Filter ComboBox
            this.cmbFilterType = new ComboBox
            {
                Location = new Point(115, 12),
                Size = new Size(140, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbFilterType.Items.AddRange(new object[] { "All Passes", "Flight Tickets", "Hotel Vouchers", "Activity Passes", "Transportation" });
            this.cmbFilterType.SelectedIndexChanged += new EventHandler(this.cmbFilterType_SelectedIndexChanged);

            // Search TextBox
            this.txtSearch = new TextBox
            {
                Location = new Point(270, 12),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9)
            };
            this.txtSearch.KeyPress += new KeyPressEventHandler(this.txtSearch_KeyPress);

            // Search Button
            this.btnSearch = new Button
            {
                Text = "🔍",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(480, 12),
                Size = new Size(30, 25)
            };
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Refresh Button
            this.btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(520, 12),
                Size = new Size(80, 25)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Add controls to panel
            this.panelControls.Controls.AddRange(new Control[]
            {
                this.lblFilterBy,
                this.cmbFilterType,
                this.txtSearch,
                this.btnSearch,
                this.btnRefresh
            });

            // Summary Panel
            this.panelSummary = new Panel
            {
                Location = new Point(30, 140),
                Size = new Size(760, 70),
                BackColor = Color.White
            };

            // Total Passes Panel
            this.panelTotalPasses = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(230, 242, 255)
            };

            // Total Passes Title
            this.lblTotalPassesTitle = new Label
            {
                Text = "Total Passes",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Total Passes Count
            this.lblTotalPasses = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelTotalPasses.Controls.AddRange(new Control[]
            {
                this.lblTotalPassesTitle,
                this.lblTotalPasses
            });

            // Upcoming Passes Panel
            this.panelUpcomingPasses = new Panel
            {
                Location = new Point(260, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(229, 243, 255)
            };

            // Upcoming Passes Title
            this.lblUpcomingPassesTitle = new Label
            {
                Text = "Upcoming Passes",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Blue,
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Upcoming Passes Count
            this.lblUpcomingPasses = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelUpcomingPasses.Controls.AddRange(new Control[]
            {
                this.lblUpcomingPassesTitle,
                this.lblUpcomingPasses
            });

            // Expired Passes Panel
            this.panelExpiredPasses = new Panel
            {
                Location = new Point(510, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(255, 243, 224)
            };

            // Expired Passes Title
            this.lblExpiredPassesTitle = new Label
            {
                Text = "Expired Passes",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(230, 126, 34),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Expired Passes Count
            this.lblExpiredPasses = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 126, 34),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelExpiredPasses.Controls.AddRange(new Control[]
            {
                this.lblExpiredPassesTitle,
                this.lblExpiredPasses
            });

            // Add panels to summary panel
            this.panelSummary.Controls.AddRange(new Control[]
            {
                this.panelTotalPasses,
                this.panelUpcomingPasses,
                this.panelExpiredPasses
            });

            // Passes DataGridView
            this.dgvPasses = new DataGridView
            {
                Location = new Point(30, 220),
                Size = new Size(760, 250),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
                RowTemplate = { Height = 25 }
            };

            // Set up columns
            this.dgvPasses.ColumnCount = 7;
            this.dgvPasses.Columns[0].Name = "ID";
            this.dgvPasses.Columns[0].Width = 50;
            this.dgvPasses.Columns[1].Name = "Type";
            this.dgvPasses.Columns[1].Width = 100;
            this.dgvPasses.Columns[2].Name = "Title";
            this.dgvPasses.Columns[2].Width = 150;
            this.dgvPasses.Columns[3].Name = "Booking Reference";
            this.dgvPasses.Columns[3].Width = 120;
            this.dgvPasses.Columns[4].Name = "Issue Date";
            this.dgvPasses.Columns[4].Width = 100;
            this.dgvPasses.Columns[5].Name = "Valid Until";
            this.dgvPasses.Columns[5].Width = 100;
            this.dgvPasses.Columns[6].Name = "Status";
            this.dgvPasses.Columns[6].Width = 100;

            this.dgvPasses.SelectionChanged += new EventHandler(this.dgvPasses_SelectionChanged);

            // Action Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 480),
                Size = new Size(760, 50),
                BackColor = Color.White
            };

            // View Details Button
            this.btnViewDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 10),
                Size = new Size(110, 30),
                Enabled = false
            };
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

            // Download Button
            this.btnDownload = new Button
            {
                Text = "📥 Download",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(130, 10),
                Size = new Size(110, 30),
                Enabled = false
            };
            this.btnDownload.FlatAppearance.BorderSize = 0;
            this.btnDownload.Click += new EventHandler(this.btnDownload_Click);

            // Share Button
            this.btnShare = new Button
            {
                Text = "📤 Share",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(250, 10),
                Size = new Size(110, 30),
                Enabled = false
            };
            this.btnShare.FlatAppearance.BorderSize = 0;
            this.btnShare.Click += new EventHandler(this.btnShare_Click);

            // Add controls to action panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnViewDetails,
                this.btnDownload,
                this.btnShare
            });

            // Form properties
            this.Text = "Digital Travel Pass";
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelControls,
                this.panelSummary,
                this.dgvPasses,
                this.panelActions
            });

            this.Load += new EventHandler(this.DigitalTravelPassForm_Load);
        }
    }
}