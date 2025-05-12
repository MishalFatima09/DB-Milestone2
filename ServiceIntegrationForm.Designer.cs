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

//using System.Drawing;
//using System.Windows.Forms;
//using System;

//namespace DB_M2_Chat
//{
//    partial class ServiceIntegrationForm
//    {
//        private System.ComponentModel.IContainer components = null;
//        private Label lblTitle;
//        private DataGridView dgvServiceRequests;
//        private Panel panelActions;
//        private Button btnAccept;
//        private Button btnReject;
//        private Button btnDetails;
//        private Label lblDescription;
//        private Panel panelHeader;
//        private Panel panelFooter;

//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        private void InitializeComponent()
//        {
//            this.components = new System.ComponentModel.Container();

//            // Header Panel
//            this.panelHeader = new Panel
//            {
//                Dock = DockStyle.Top,
//                Height = 70,
//                BackColor = Color.FromArgb(191, 215, 234)
//            };

//            // Title Label
//            this.lblTitle = new Label
//            {
//                Text = "📨 Service Integration",
//                Font = new Font("Segoe UI", 14, FontStyle.Bold),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(20, 15),
//                AutoSize = true
//            };

//            // Description Label
//            this.lblDescription = new Label
//            {
//                Text = "Accept or reject service assignments from operators",
//                Font = new Font("Segoe UI", 10),
//                ForeColor = Color.FromArgb(11, 57, 84),
//                Location = new Point(22, 40),
//                AutoSize = true
//            };

//            // Add controls to header panel
//            this.panelHeader.Controls.AddRange(new Control[]
//            {
//                this.lblTitle,
//                this.lblDescription
//            });

//            // DataGridView for Service Requests
//            this.dgvServiceRequests = new DataGridView
//            {
//                Dock = DockStyle.Fill,
//                BackgroundColor = Color.White,
//                BorderStyle = BorderStyle.None,
//                AllowUserToAddRows = false,
//                AllowUserToDeleteRows = false,
//                ReadOnly = true,
//                SelectionMode = DataGridViewSelectionMode.FullRowSelect,
//                MultiSelect = false,
//                RowHeadersVisible = false,
//                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill,
//                AllowUserToResizeRows = false,
//                CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal,
//                RowTemplate = { Height = 35 }
//            };

//            // Configure DataGridView appearance
//            this.dgvServiceRequests.EnableHeadersVisualStyles = false;
//            this.dgvServiceRequests.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 57, 84);
//            this.dgvServiceRequests.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
//            this.dgvServiceRequests.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 10, FontStyle.Bold);
//            this.dgvServiceRequests.ColumnHeadersDefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleLeft;
//            this.dgvServiceRequests.ColumnHeadersHeight = 40;
//            this.dgvServiceRequests.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.DisableResizing;
//            this.dgvServiceRequests.DefaultCellStyle.Font = new Font("Segoe UI", 9);
//            this.dgvServiceRequests.DefaultCellStyle.SelectionBackColor = Color.FromArgb(180, 200, 250);
//            this.dgvServiceRequests.DefaultCellStyle.SelectionForeColor = Color.Black;
//            this.dgvServiceRequests.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(245, 249, 252);

//            // Configure DataGridView columns
//            this.dgvServiceRequests.ColumnCount = 5;
//            this.dgvServiceRequests.Columns[0].Name = "ID";
//            this.dgvServiceRequests.Columns[0].Width = 70;
//            this.dgvServiceRequests.Columns[1].Name = "Service";
//            this.dgvServiceRequests.Columns[1].Width = 150;
//            this.dgvServiceRequests.Columns[2].Name = "Description";
//            this.dgvServiceRequests.Columns[2].Width = 200;
//            this.dgvServiceRequests.Columns[3].Name = "Date";
//            this.dgvServiceRequests.Columns[3].Width = 100;
//            this.dgvServiceRequests.Columns[4].Name = "Status";
//            this.dgvServiceRequests.Columns[4].Width = 80;

//            // Footer Panel
//            this.panelFooter = new Panel
//            {
//                Dock = DockStyle.Bottom,
//                Height = 60,
//                BackColor = Color.FromArgb(191, 215, 234)
//            };

//            // Actions Panel
//            this.panelActions = new Panel
//            {
//                Size = new Size(500, 40),
//                Location = new Point(20, 10),
//                BackColor = Color.FromArgb(191, 215, 234)
//            };

//            // Accept Button
//            this.btnAccept = new Button
//            {
//                Text = "Accept",
//                BackColor = Color.FromArgb(40, 167, 69),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(0, 2),
//                Size = new Size(100, 35),
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                Cursor = Cursors.Hand
//            };
//            this.btnAccept.FlatAppearance.BorderSize = 0;
//            this.btnAccept.Click += new EventHandler(this.btnAccept_Click);

//            // Reject Button
//            this.btnReject = new Button
//            {
//                Text = "Reject",
//                BackColor = Color.FromArgb(220, 53, 69),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(110, 2),
//                Size = new Size(100, 35),
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                Cursor = Cursors.Hand
//            };
//            this.btnReject.FlatAppearance.BorderSize = 0;
//            this.btnReject.Click += new EventHandler(this.btnReject_Click);

//            // Details Button
//            this.btnDetails = new Button
//            {
//                Text = "View Details",
//                BackColor = Color.FromArgb(40, 120, 180),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Location = new Point(220, 2),
//                Size = new Size(120, 35),
//                Font = new Font("Segoe UI", 9, FontStyle.Bold),
//                Cursor = Cursors.Hand
//            };
//            this.btnDetails.FlatAppearance.BorderSize = 0;
//            this.btnDetails.Click += new EventHandler(this.btnDetails_Click);

//            // Add buttons to actions panel
//            this.panelActions.Controls.AddRange(new Control[]
//            {
//                this.btnAccept,
//                this.btnReject,
//                this.btnDetails
//            });

//            // Add actions panel to footer panel
//            this.panelFooter.Controls.Add(this.panelActions);

//            // Form properties
//            this.BackColor = Color.White;
//            this.ClientSize = new Size(820, 500);
//            this.FormBorderStyle = FormBorderStyle.FixedSingle;
//            this.MaximizeBox = false;
//            this.StartPosition = FormStartPosition.CenterScreen;
//            this.Text = "Service Integration";

//            // Add controls to form
//            this.Controls.AddRange(new Control[]
//            {
//                this.panelHeader,
//                this.dgvServiceRequests,
//                this.panelFooter
//            });

//            this.Load += new EventHandler(this.ServiceIntegrationForm_Load);
//        }
//    }
//}