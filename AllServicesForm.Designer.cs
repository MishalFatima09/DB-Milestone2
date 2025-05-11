using System.Drawing;
using System.Windows.Forms;
using System;

namespace DB_M2_Chat
{
    partial class AllServicesForm
    {
        private System.ComponentModel.IContainer components = null;
        private Label lblTitle;
        private Label lblDescription;
        private DataGridView dgvServices;
        private Panel panelFilters;
        private Panel panelActions;
        private TextBox txtSearch;
        private Button btnSearch;
        private ComboBox cmbCategory;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnViewDetails;
        private Label lblCategory;
        private Label lblSearchLabel;

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
            // this.components = new System.ComponentModel.Container();

            // Title Label
            this.lblTitle = new Label
            {
                Text = "🏨 All Services",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "View and manage all your services and offerings",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Filter Panel
            this.panelFilters = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(760, 60),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Search Label
            this.lblSearchLabel = new Label
            {
                Text = "Search:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(15, 20),
                AutoSize = true
            };

            // Search TextBox
            this.txtSearch = new TextBox
            {
                Location = new Point(70, 17),
                Size = new Size(200, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Search Button
            this.btnSearch = new Button
            {
                Text = "🔍",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(280, 17),
                Size = new Size(40, 25)
            };
            this.btnSearch.FlatAppearance.BorderSize = 0;
            this.btnSearch.Click += new EventHandler(this.btnSearch_Click);

            // Category Label
            this.lblCategory = new Label
            {
                Text = "Category:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(350, 20),
                AutoSize = true
            };

            // Category ComboBox
            this.cmbCategory = new ComboBox
            {
                Location = new Point(420, 17),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbCategory.Items.AddRange(new object[] { "All", "Hotel", "Transport", "Tour", "Package" });
            this.cmbCategory.SelectedIndex = 0;
            this.cmbCategory.SelectedIndexChanged += new EventHandler(this.cmbCategory_SelectedIndexChanged);

            // Add filter controls to panel
            this.panelFilters.Controls.AddRange(new Control[]
            {
                this.lblSearchLabel,
                this.txtSearch,
                this.btnSearch,
                this.lblCategory,
                this.cmbCategory
            });

            // DataGridView for Services
            this.dgvServices = new DataGridView
            {
                Location = new Point(30, 150),
                Size = new Size(760, 230),
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
            this.dgvServices.ColumnCount = 6;
            this.dgvServices.Columns[0].Name = "ID";
            this.dgvServices.Columns[0].Width = 60;
            this.dgvServices.Columns[1].Name = "Service Name";
            this.dgvServices.Columns[1].Width = 150;
            this.dgvServices.Columns[2].Name = "Category";
            this.dgvServices.Columns[2].Width = 100;
            this.dgvServices.Columns[3].Name = "Price";
            this.dgvServices.Columns[3].Width = 80;
            this.dgvServices.Columns[4].Name = "Availability";
            this.dgvServices.Columns[4].Width = 100;
            this.dgvServices.Columns[5].Name = "Rating";
            this.dgvServices.Columns[5].Width = 80;

            // Actions Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 390),
                Size = new Size(760, 60),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Edit Button
            this.btnEdit = new Button
            {
                Text = "Edit",
                BackColor = Color.FromArgb(255, 193, 7),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(10, 12),
                Size = new Size(100, 35)
            };
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Click += new EventHandler(this.btnEdit_Click);

            // Delete Button
            this.btnDelete = new Button
            {
                Text = "Delete",
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(120, 12),
                Size = new Size(100, 35)
            };
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Click += new EventHandler(this.btnDelete_Click);

            // View Details Button
            this.btnViewDetails = new Button
            {
                Text = "View Details",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(230, 12),
                Size = new Size(120, 35)
            };
            this.btnViewDetails.FlatAppearance.BorderSize = 0;
            this.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

            // Add buttons to actions panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnEdit,
                this.btnDelete,
                this.btnViewDetails
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
                this.dgvServices,
                this.panelActions
            });

            this.Load += new EventHandler(this.AllServicesForm_Load);
        }
    }
}