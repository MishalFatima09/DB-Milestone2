using System.Drawing;
using System.Windows.Forms;
using System;

namespace DB_M2_Chat
{
    partial class ServiceIntegrationForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private DataGridView dgvServiceRequests;
        private Panel panelActions;
        private Button btnAccept;
        private Button btnReject;
        private Button btnDetails;
        private Label lblDescription;

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
                Text = "📨 Service Integration",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Accept or reject service assignments from operators",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // DataGridView for Service Requests
            this.dgvServiceRequests = new DataGridView
            {
                Location = new Point(30, 80),
                Size = new Size(760, 300),
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

            // Configure DataGridView columns
            this.dgvServiceRequests.ColumnCount = 5;
            this.dgvServiceRequests.Columns[0].Name = "ID";
            this.dgvServiceRequests.Columns[0].Width = 80;
            this.dgvServiceRequests.Columns[1].Name = "Service";
            this.dgvServiceRequests.Columns[1].Width = 200;
            this.dgvServiceRequests.Columns[2].Name = "Description";
            this.dgvServiceRequests.Columns[2].Width = 250;
            this.dgvServiceRequests.Columns[3].Name = "Date";
            this.dgvServiceRequests.Columns[3].Width = 120;
            this.dgvServiceRequests.Columns[4].Name = "Status";
            this.dgvServiceRequests.Columns[4].Width = 100;

            // Actions Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 390),
                Size = new Size(760, 60),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Accept Button
            this.btnAccept = new Button
            {
                Text = "Accept",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(0, 10),
                Size = new Size(100, 35)
            };
            this.btnAccept.FlatAppearance.BorderSize = 0;
            this.btnAccept.Click += new EventHandler(this.btnAccept_Click);

            // Reject Button
            this.btnReject = new Button
            {
                Text = "Reject",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(110, 10),
                Size = new Size(100, 35)
            };
            this.btnReject.FlatAppearance.BorderSize = 0;
            this.btnReject.Click += new EventHandler(this.btnReject_Click);

            // Details Button
            this.btnDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(220, 10),
                Size = new Size(120, 35)
            };
            this.btnDetails.FlatAppearance.BorderSize = 0;
            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

            // Add buttons to panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnAccept,
                this.btnReject,
                this.btnDetails
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
                this.dgvServiceRequests,
                this.panelActions
            });

            this.Load += new EventHandler(this.ServiceIntegrationForm_Load);
        }
    }
}