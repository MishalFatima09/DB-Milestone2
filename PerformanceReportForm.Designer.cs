using System.Drawing;
using System.Windows.Forms;
using System;

namespace DB_M2_Chat
{
    partial class PerformanceReportForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblDescription;
        private TabControl tabControlReports;
        private TabPage tabPageOccupancy;
        private TabPage tabPageRevenue;
        private TabPage tabPageReviews;
        private DataGridView dgvOccupancy;
        private DataGridView dgvRevenue;
        private DataGridView dgvReviews;
        private Panel panelFilters;
        private ComboBox cmbTimePeriod;
        private Label lblTimePeriod;
        private Button btnRefresh;
        private Button btnExportPDF;
        private Button btnExportExcel;
        private Button btnViewReviewDetails;

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
                Text = "📊 Performance Reports",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Monitor occupancy rates, traveler feedback, and revenue",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Filter Panel
            this.panelFilters = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(760, 50),
                BackColor = Color.White
            };

            // Time Period Label
            this.lblTimePeriod = new Label
            {
                Text = "Time Period:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Time Period ComboBox
            this.cmbTimePeriod = new ComboBox
            {
                Location = new Point(100, 12),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbTimePeriod.Items.AddRange(new object[] { "Last Month", "Last Quarter", "Last Year", "All Time" });
            this.cmbTimePeriod.SelectedIndex = 0;
            this.cmbTimePeriod.SelectedIndexChanged += new EventHandler(this.cmbTimePeriod_SelectedIndexChanged);

            // Refresh Button
            this.btnRefresh = new Button
            {
                Text = "Refresh Data",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(270, 10),
                Size = new Size(120, 30)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Export PDF Button
            this.btnExportPDF = new Button
            {
                Text = "Export to PDF",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(400, 10),
                Size = new Size(120, 30)
            };
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.Click += new EventHandler(this.btnExportPDF_Click);

            // Export Excel Button
            this.btnExportExcel = new Button
            {
                Text = "Export to Excel",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(530, 10),
                Size = new Size(120, 30)
            };
            this.btnExportExcel.FlatAppearance.BorderSize = 0;
            this.btnExportExcel.Click += new EventHandler(this.btnExportExcel_Click);

            // Add controls to filter panel
            this.panelFilters.Controls.AddRange(new Control[]
            {
                this.lblTimePeriod,
                this.cmbTimePeriod,
                this.btnRefresh,
                this.btnExportPDF,
                this.btnExportExcel
            });

            // Tab Control for different reports
            this.tabControlReports = new TabControl
            {
                Location = new Point(30, 140),
                Size = new Size(760, 310),
                Font = new Font("Segoe UI", 9)
            };

            // Occupancy Tab
            this.tabPageOccupancy = new TabPage
            {
                Text = "Occupancy Rates",
                BackColor = Color.White
            };

            // Revenue Tab
            this.tabPageRevenue = new TabPage
            {
                Text = "Revenue",
                BackColor = Color.White
            };

            // Reviews Tab
            this.tabPageReviews = new TabPage
            {
                Text = "Traveler Feedback",
                BackColor = Color.White
            };

            // Occupancy DataGridView
            this.dgvOccupancy = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(730, 260),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Configure Occupancy DataGridView columns
            this.dgvOccupancy.ColumnCount = 4;
            this.dgvOccupancy.Columns[0].Name = "Month";
            this.dgvOccupancy.Columns[1].Name = "Current";
            this.dgvOccupancy.Columns[2].Name = "Previous";
            this.dgvOccupancy.Columns[3].Name = "Change";

            // Revenue DataGridView
            this.dgvRevenue = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(730, 260),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Configure Revenue DataGridView columns
            this.dgvRevenue.ColumnCount = 4;
            this.dgvRevenue.Columns[0].Name = "Month";
            this.dgvRevenue.Columns[1].Name = "Current";
            this.dgvRevenue.Columns[2].Name = "Previous";
            this.dgvRevenue.Columns[3].Name = "Change";

            // Reviews DataGridView
            this.dgvReviews = new DataGridView
            {
                Location = new Point(10, 10),
                Size = new Size(730, 220),
                BackgroundColor = Color.White,
                BorderStyle = BorderStyle.None,
                AllowUserToAddRows = false,
                AllowUserToDeleteRows = false,
                ReadOnly = true,
                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
                MultiSelect = false,
                RowHeadersVisible = false,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            // Configure Reviews DataGridView columns
            this.dgvReviews.ColumnCount = 5;
            this.dgvReviews.Columns[0].Name = "ID";
            this.dgvReviews.Columns[0].Width = 80;
            this.dgvReviews.Columns[1].Name = "ReviewerName";
            this.dgvReviews.Columns[1].HeaderText = "Reviewer";
            this.dgvReviews.Columns[1].Width = 150;
            this.dgvReviews.Columns[2].Name = "ReviewText";
            this.dgvReviews.Columns[2].HeaderText = "Feedback";
            this.dgvReviews.Columns[2].Width = 280;
            this.dgvReviews.Columns[3].Name = "Date";
            this.dgvReviews.Columns[3].Width = 100;
            this.dgvReviews.Columns[4].Name = "Rating";
            this.dgvReviews.Columns[4].Width = 80;

            // View Review Details Button
            this.btnViewReviewDetails = new Button
            {
                Text = "View Full Review",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 235),
                Size = new Size(140, 30)
            };
            this.btnViewReviewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewReviewDetails.Click += new EventHandler(this.btnViewReviewDetails_Click);

            // Add controls to tabs
            this.tabPageOccupancy.Controls.Add(this.dgvOccupancy);
            this.tabPageRevenue.Controls.Add(this.dgvRevenue);
            this.tabPageReviews.Controls.AddRange(new Control[]
            {
                this.dgvReviews,
                this.btnViewReviewDetails
            });

            // Add tabs to tab control
            this.tabControlReports.TabPages.AddRange(new TabPage[]
            {
                this.tabPageOccupancy,
                this.tabPageRevenue,
                this.tabPageReviews
            });

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 480);
            this.FormBorderStyle = FormBorderStyle.None;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelFilters,
                this.tabControlReports
            });

            this.Load += new EventHandler(this.PerformanceReportForm_Load);
        }
    }
}