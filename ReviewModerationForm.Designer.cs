using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class ReviewModerationForm
    {
        private System.ComponentModel.IContainer components = null;

        // Header elements
        private Label lblTitle;
        private Label lblDescription;

        // Control panel
        private Panel panelControls;
        private Label lblFilterBy;
        private ComboBox cmbFilterStatus;
        private TextBox txtSearch;
        private Button btnSearch;
        private Button btnRefresh;

        // Summary panel
        private Panel panelSummary;
        private Panel panelTotalReviews;
        private Panel panelPendingReviews;
        private Panel panelFlaggedReviews;

        // Summary labels
        private Label lblTotalReviewsTitle;
        private Label lblTotalReviews;
        private Label lblPendingReviewsTitle;
        private Label lblPendingReviews;
        private Label lblFlaggedReviewsTitle;
        private Label lblFlaggedReviews;

        // Data grid
        private DataGridView dgvReviews;

        // Action buttons
        private Panel panelActions;
        private Button btnApprove;
        private Button btnReject;
        private Button btnViewDetails;
        private Button btnExport;

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
                Text = "⭐ Review Moderation",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Moderate user reviews to maintain content quality standards",
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
                Text = "Filter Status:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Filter ComboBox
            this.cmbFilterStatus = new ComboBox
            {
                Location = new Point(100, 12),
                Size = new Size(140, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbFilterStatus.Items.AddRange(new object[] { "All Reviews", "Pending Review", "Flagged", "Approved", "Rejected" });
            this.cmbFilterStatus.SelectedIndexChanged += new EventHandler(this.cmbFilterStatus_SelectedIndexChanged);

            // Search TextBox
            this.txtSearch = new TextBox
            {
                Location = new Point(260, 12),
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
                Location = new Point(470, 12),
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
                Location = new Point(510, 12),
                Size = new Size(80, 25)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Export Button
            this.btnExport = new Button
            {
                Text = "Export Data",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(650, 12),
                Size = new Size(90, 25)
            };
            this.btnExport.FlatAppearance.BorderSize = 0;
            this.btnExport.Click += new EventHandler(this.btnExport_Click);

            // Add controls to panel
            this.panelControls.Controls.AddRange(new Control[]
            {
                this.lblFilterBy,
                this.cmbFilterStatus,
                this.txtSearch,
                this.btnSearch,
                this.btnRefresh,
                this.btnExport
            });

            // Summary Panel
            this.panelSummary = new Panel
            {
                Location = new Point(30, 140),
                Size = new Size(760, 70),
                BackColor = Color.White
            };

            // Total Reviews Panel
            this.panelTotalReviews = new Panel
            {
                Location = new Point(10, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(230, 242, 255)
            };

            // Total Reviews Title
            this.lblTotalReviewsTitle = new Label
            {
                Text = "Total Reviews",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Total Reviews Count
            this.lblTotalReviews = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelTotalReviews.Controls.AddRange(new Control[]
            {
                this.lblTotalReviewsTitle,
                this.lblTotalReviews
            });

            // Pending Reviews Panel
            this.panelPendingReviews = new Panel
            {
                Location = new Point(260, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(229, 243, 255)
            };

            // Pending Reviews Title
            this.lblPendingReviewsTitle = new Label
            {
                Text = "Pending Reviews",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.Blue,
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Pending Reviews Count
            this.lblPendingReviews = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.Blue,
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelPendingReviews.Controls.AddRange(new Control[]
            {
                this.lblPendingReviewsTitle,
                this.lblPendingReviews
            });

            // Flagged Reviews Panel
            this.panelFlaggedReviews = new Panel
            {
                Location = new Point(510, 10),
                Size = new Size(240, 50),
                BackColor = Color.FromArgb(255, 243, 224)
            };

            // Flagged Reviews Title
            this.lblFlaggedReviewsTitle = new Label
            {
                Text = "Flagged Reviews",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(230, 126, 34),
                Location = new Point(15, 8),
                AutoSize = true
            };

            // Flagged Reviews Count
            this.lblFlaggedReviews = new Label
            {
                Text = "0",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(230, 126, 34),
                Location = new Point(15, 25),
                AutoSize = true
            };

            // Add controls to panel
            this.panelFlaggedReviews.Controls.AddRange(new Control[]
            {
                this.lblFlaggedReviewsTitle,
                this.lblFlaggedReviews
            });

            // Add panels to summary panel
            this.panelSummary.Controls.AddRange(new Control[]
            {
                this.panelTotalReviews,
                this.panelPendingReviews,
                this.panelFlaggedReviews
            });

            // Reviews DataGridView
            this.dgvReviews = new DataGridView
            {
                Location = new Point(30, 220),
                Size = new Size(760, 250), // Reduced height to make space for buttons
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
            this.dgvReviews.ColumnCount = 7;
            this.dgvReviews.Columns[0].Name = "ID";
            this.dgvReviews.Columns[0].Width = 50;
            this.dgvReviews.Columns[1].Name = "Tour";
            this.dgvReviews.Columns[1].Width = 150;
            this.dgvReviews.Columns[2].Name = "User";
            this.dgvReviews.Columns[2].Width = 100;
            this.dgvReviews.Columns[3].Name = "Rating";
            this.dgvReviews.Columns[3].Width = 60;
            this.dgvReviews.Columns[4].Name = "Content";
            this.dgvReviews.Columns[4].Width = 220;
            this.dgvReviews.Columns[5].Name = "Date";
            this.dgvReviews.Columns[5].Width = 80;
            this.dgvReviews.Columns[6].Name = "Status";
            this.dgvReviews.Columns[6].Width = 100;

            this.dgvReviews.SelectionChanged += new EventHandler(this.dgvReviews_SelectionChanged);

            // Action Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 480), // Adjusted position to be higher
                Size = new Size(760, 50),
                BackColor = Color.White
            };

            // Approve Button
            this.btnApprove = new Button
            {
                Text = "✓ Approve",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 10),
                Size = new Size(100, 30),
                Enabled = false
            };
            this.btnApprove.FlatAppearance.BorderSize = 0;
            this.btnApprove.Click += new EventHandler(this.btnApprove_Click);

            // Reject Button
            this.btnReject = new Button
            {
                Text = "✗ Reject",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(120, 10),
                Size = new Size(100, 30),
                Enabled = false
            };
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.Click += new EventHandler(this.btnReject_Click);

            // View Details Button
            this.btnViewDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(230, 10),
                Size = new Size(100, 30),
                Enabled = false
            };
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

            // Add controls to action panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnApprove,
                this.btnReject,
                this.btnViewDetails
            });

            // Form properties
            this.Text = "Review Moderation";
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 600);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.FormBorderStyle = FormBorderStyle.None; // Remove border
            this.AutoScroll = true; // Enable scrolling if needed

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelControls,
                this.panelSummary,
                this.dgvReviews,
                this.panelActions
            });

            this.Load += new EventHandler(this.ReviewModerationForm_Load);
        }
    }
}