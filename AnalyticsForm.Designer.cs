using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class AnalyticsForm
    {
        private System.ComponentModel.IContainer components = null;

        // Summary panels
        private Panel panelSummary;
        private Panel panelBookings;
        private Panel panelRevenue;
        private Panel panelUsers;
        private Panel panelTours;

        // Summary labels
        private Label lblBookingsTitle;
        private Label lblTotalBookings;
        private Label lblRevenueTitle;
        private Label lblTotalRevenue;
        private Label lblUsersTitle;
        private Label lblActiveUsers;
        private Label lblToursTitle;
        private Label lblCompletedTours;

        // Controls
        private Label lblTitle;
        private Label lblDescription;
        private ComboBox cmbTimeFrame;
        private ComboBox cmbChartType;
        private Button btnExportPDF;
        private Button btnExportCSV;
        private Button btnRefresh;
        private DataGridView dgvRevenue;
        private DataGridView dgvTopDestinations;
        private Label lblRevenueByCategory;
        private Label lblTopDestinations;
        private Panel panelControls;
        private Label lblTimeFrame;
        private Label lblChartType;

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
                Text = "📊 Platform Analytics",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Monitor your platform metrics and performance",
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

            // Time Frame Label
            this.lblTimeFrame = new Label
            {
                Text = "Time Frame:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 15),
                AutoSize = true
            };

            // Time Frame ComboBox
            this.cmbTimeFrame = new ComboBox
            {
                Location = new Point(100, 12),
                Size = new Size(140, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbTimeFrame.Items.AddRange(new object[] { "Last 30 Days", "Last 3 Months", "Last 6 Months", "Last Year", "All Time" });
            this.cmbTimeFrame.SelectedIndexChanged += new EventHandler(this.cmbTimeFrame_SelectedIndexChanged);

            // Chart Type Label
            this.lblChartType = new Label
            {
                Text = "Chart Type:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(265, 15),
                AutoSize = true
            };

            // Chart Type ComboBox
            this.cmbChartType = new ComboBox
            {
                Location = new Point(340, 12),
                Size = new Size(120, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbChartType.Items.AddRange(new object[] { "Line Chart", "Bar Chart", "Area Chart" });
            this.cmbChartType.SelectedIndexChanged += new EventHandler(this.cmbChartType_SelectedIndexChanged);

            // Refresh Button
            this.btnRefresh = new Button
            {
                Text = "🔄 Refresh",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(480, 10),
                Size = new Size(80, 30)
            };
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Click += new EventHandler(this.btnRefresh_Click);

            // Export PDF Button
            this.btnExportPDF = new Button
            {
                Text = "Export PDF",
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(570, 10),
                Size = new Size(80, 30)
            };
            this.btnExportPDF.FlatAppearance.BorderSize = 0;
            this.btnExportPDF.Click += new EventHandler(this.btnExportPDF_Click);

            // Export CSV Button
            this.btnExportCSV = new Button
            {
                Text = "Export CSV",
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(660, 10),
                Size = new Size(80, 30)
            };
            this.btnExportCSV.FlatAppearance.BorderSize = 0;
            this.btnExportCSV.Click += new EventHandler(this.btnExportCSV_Click);

            // Add controls to panel
            this.panelControls.Controls.AddRange(new Control[]
            {
                this.lblTimeFrame,
                this.cmbTimeFrame,
                this.lblChartType,
                this.cmbChartType,
                this.btnRefresh,
                this.btnExportPDF,
                this.btnExportCSV
            });

            // Summary Panel
            this.panelSummary = new Panel
            {
                Location = new Point(30, 140),
                Size = new Size(760, 90),
                BackColor = Color.White
            };

            // Reuse your existing summary panel setup (panelBookings, panelRevenue, panelUsers, panelTours)
            // -- omitted for brevity, since they're unchanged --

            // Add panels to summary panel
            this.panelSummary.Controls.AddRange(new Control[]
            {
                this.panelBookings,
                this.panelRevenue,
                this.panelUsers,
                this.panelTours
            });

            // Revenue by Category Label
            this.lblRevenueByCategory = new Label
            {
                Text = "Revenue by Category",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 240),
                AutoSize = true
            };

            // Revenue DataGridView
            this.dgvRevenue = new DataGridView
            {
                Location = new Point(30, 270),
                Size = new Size(370, 160),
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
            this.dgvRevenue.ColumnCount = 4;
            this.dgvRevenue.Columns[0].Name = "Category";
            this.dgvRevenue.Columns[1].Name = "Revenue";
            this.dgvRevenue.Columns[2].Name = "Percentage";
            this.dgvRevenue.Columns[3].Name = "Growth";

            // Top Destinations Label
            this.lblTopDestinations = new Label
            {
                Text = "Top Destinations",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(420, 240),
                AutoSize = true
            };

            // Top Destinations DataGridView
            this.dgvTopDestinations = new DataGridView
            {
                Location = new Point(420, 270),
                Size = new Size(370, 160),
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
            this.dgvTopDestinations.ColumnCount = 3;
            this.dgvTopDestinations.Columns[0].Name = "Destination";
            this.dgvTopDestinations.Columns[1].Name = "Bookings";
            this.dgvTopDestinations.Columns[2].Name = "Rating";

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 470); // Reduced height after removing charts

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelControls,
                this.panelSummary,
                this.lblRevenueByCategory,
                this.dgvRevenue,
                this.lblTopDestinations,
                this.dgvTopDestinations
            });

            this.Load += new EventHandler(this.AnalyticsForm_Load);
        }
    }
}
