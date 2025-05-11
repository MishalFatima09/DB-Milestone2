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
            //this.btnViewDetails = new Button
            //{
            //    Text = "View Details",
            //    BackColor = Color.FromArgb(40, 120, 180),
            //    ForeColor = Color.White,
            //    FlatStyle = FlatStyle.Flat,
            //    Location = new Point(230, 12),
            //    Size = new Size(120, 35)
            //};
            //this.btnViewDetails.FlatAppearance.BorderSize = 0;
            //.btnViewDetails.Click += new EventHandler(this.btnViewDetails_Click);

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




//namespace DB_M2_Chat
//{
//    partial class AllServicesForm
//    {
//        /// <summary>
//        /// Required designer variable.
//        /// </summary>
//        private System.ComponentModel.IContainer components = null;

//        /// <summary>
//        /// Clean up any resources being used.
//        /// </summary>
//        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
//        protected override void Dispose(bool disposing)
//        {
//            if (disposing && (components != null))
//            {
//                components.Dispose();
//            }
//            base.Dispose(disposing);
//        }

//        #region Windows Form Designer generated code

//        /// <summary>
//        /// Required method for Designer support - do not modify
//        /// the contents of this method with the code editor.
//        /// </summary>
//        private void InitializeComponent()
//        {
//            this.lblTitle = new System.Windows.Forms.Label();
//            this.dgvServices = new System.Windows.Forms.DataGridView();
//            this.txtSearch = new System.Windows.Forms.TextBox();
//            this.btnSearch = new System.Windows.Forms.Button();
//            this.cmbCategory = new System.Windows.Forms.ComboBox();
//            this.lblCategory = new System.Windows.Forms.Label();
//            this.btnAdd = new System.Windows.Forms.Button();
//            this.btnEdit = new System.Windows.Forms.Button();
//            this.btnDelete = new System.Windows.Forms.Button();
//            this.lblServicesCount = new System.Windows.Forms.Label();
//            this.btnLogout = new System.Windows.Forms.Button();
//            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).BeginInit();
//            this.SuspendLayout();
//            // 
//            // lblTitle
//            // 
//            this.lblTitle.AutoSize = true;
//            this.lblTitle.Font = new System.Drawing.Font("Microsoft Sans Serif", 14F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
//            this.lblTitle.Location = new System.Drawing.Point(12, 9);
//            this.lblTitle.Name = "lblTitle";
//            this.lblTitle.Size = new System.Drawing.Size(225, 29);
//            this.lblTitle.TabIndex = 0;
//            this.lblTitle.Text = "Available Services";
//            // 
//            // dgvServices
//            // 
//            this.dgvServices.AllowUserToAddRows = false;
//            this.dgvServices.AllowUserToDeleteRows = false;
//            this.dgvServices.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
//            | System.Windows.Forms.AnchorStyles.Left)
//            | System.Windows.Forms.AnchorStyles.Right)));
//            this.dgvServices.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
//            this.dgvServices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
//            this.dgvServices.Location = new System.Drawing.Point(12, 100);
//            this.dgvServices.MultiSelect = false;
//            this.dgvServices.Name = "dgvServices";
//            this.dgvServices.ReadOnly = true;
//            this.dgvServices.RowHeadersWidth = 51;
//            this.dgvServices.RowTemplate.Height = 24;
//            this.dgvServices.SelectionMode = System.Windows.Forms.DataGridViewSelectionMode.FullRowSelect;
//            this.dgvServices.Size = new System.Drawing.Size(950, 360);
//            this.dgvServices.TabIndex = 1;
//            // 
//            // txtSearch
//            // 
//            this.txtSearch.Location = new System.Drawing.Point(12, 52);
//            this.txtSearch.Name = "txtSearch";
//            this.txtSearch.Size = new System.Drawing.Size(230, 22);
//            this.txtSearch.TabIndex = 2;
//            //this.txtSearch.PlaceholderText = "Search for services...";
//            // 
//            // btnSearch
//            // 
//            this.btnSearch.Location = new System.Drawing.Point(248, 51);
//            this.btnSearch.Name = "btnSearch";
//            this.btnSearch.Size = new System.Drawing.Size(75, 23);
//            this.btnSearch.TabIndex = 3;
//            this.btnSearch.Text = "Search";
//            this.btnSearch.UseVisualStyleBackColor = true;
//            this.btnSearch.Click += new System.EventHandler(this.btnSearch_Click);
//            // 
//            // cmbCategory
//            // 
//            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
//            this.cmbCategory.FormattingEnabled = true;
//            this.cmbCategory.Location = new System.Drawing.Point(405, 52);
//            this.cmbCategory.Name = "cmbCategory";
//            this.cmbCategory.Size = new System.Drawing.Size(177, 24);
//            this.cmbCategory.TabIndex = 4;
//            this.cmbCategory.SelectedIndexChanged += new System.EventHandler(this.cmbCategory_SelectedIndexChanged);
//            // 
//            // lblCategory
//            // 
//            this.lblCategory.AutoSize = true;
//            this.lblCategory.Location = new System.Drawing.Point(340, 55);
//            this.lblCategory.Name = "lblCategory";
//            this.lblCategory.Size = new System.Drawing.Size(65, 16);
//            this.lblCategory.TabIndex = 5;
//            this.lblCategory.Text = "Category:";
//            // 
//            // btnAdd
//            // 
//            this.btnAdd.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.btnAdd.Location = new System.Drawing.Point(12, 475);
//            this.btnAdd.Name = "btnAdd";
//            this.btnAdd.Size = new System.Drawing.Size(120, 35);
//            this.btnAdd.TabIndex = 6;
//            this.btnAdd.Text = "Add Service";
//            this.btnAdd.UseVisualStyleBackColor = true;
//            this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);
//            // 
//            // btnEdit
//            // 
//            this.btnEdit.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.btnEdit.Location = new System.Drawing.Point(138, 475);
//            this.btnEdit.Name = "btnEdit";
//            this.btnEdit.Size = new System.Drawing.Size(120, 35);
//            this.btnEdit.TabIndex = 7;
//            this.btnEdit.Text = "Edit Service";
//            this.btnEdit.UseVisualStyleBackColor = true;
//            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);
//            // 
//            // btnDelete
//            // 
//            this.btnDelete.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)));
//            this.btnDelete.Location = new System.Drawing.Point(264, 475);
//            this.btnDelete.Name = "btnDelete";
//            this.btnDelete.Size = new System.Drawing.Size(120, 35);
//            this.btnDelete.TabIndex = 8;
//            this.btnDelete.Text = "Delete Service";
//            this.btnDelete.UseVisualStyleBackColor = true;
//            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);
//            // 
//            // lblServicesCount
//            // 
//            this.lblServicesCount.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Right)));
//            this.lblServicesCount.AutoSize = true;
//            this.lblServicesCount.Location = new System.Drawing.Point(850, 484);
//            this.lblServicesCount.Name = "lblServicesCount";
//            this.lblServicesCount.Size = new System.Drawing.Size(109, 16);
//            this.lblServicesCount.TabIndex = 9;
//            this.lblServicesCount.Text = "Total Services: 0";
//            // 
//            // btnLogout
//            // 
//            this.btnLogout.Anchor = ((System.Windows.Forms.AnchorStyles)((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Right)));
//            this.btnLogout.Location = new System.Drawing.Point(874, 12);
//            this.btnLogout.Name = "btnLogout";
//            this.btnLogout.Size = new System.Drawing.Size(88, 28);
//            this.btnLogout.TabIndex = 10;
//            this.btnLogout.Text = "Logout";
//            this.btnLogout.UseVisualStyleBackColor = true;
//            this.btnLogout.Click += new System.EventHandler(this.btnLogout_Click);
//            // 
//            // AllServicesForm
//            // 
//            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
//            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
//            this.ClientSize = new System.Drawing.Size(974, 522);
//            this.Controls.Add(this.btnLogout);
//            this.Controls.Add(this.lblServicesCount);
//            this.Controls.Add(this.btnDelete);
//            this.Controls.Add(this.btnEdit);
//            this.Controls.Add(this.btnAdd);
//            this.Controls.Add(this.lblCategory);
//            this.Controls.Add(this.cmbCategory);
//            this.Controls.Add(this.btnSearch);
//            this.Controls.Add(this.txtSearch);
//            this.Controls.Add(this.dgvServices);
//            this.Controls.Add(this.lblTitle);
//            this.MinimumSize = new System.Drawing.Size(800, 500);
//            this.Name = "AllServicesForm";
//            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
//            this.Text = "Services";
//            this.Load += new System.EventHandler(this.AllServicesForm_Load);
//            ((System.ComponentModel.ISupportInitialize)(this.dgvServices)).EndInit();
//            this.ResumeLayout(false);
//            this.PerformLayout();
//        }

//        #endregion

//        private System.Windows.Forms.Label lblTitle;
//        private System.Windows.Forms.DataGridView dgvServices;
//        private System.Windows.Forms.TextBox txtSearch;
//        private System.Windows.Forms.Button btnSearch;
//        private System.Windows.Forms.ComboBox cmbCategory;
//        private System.Windows.Forms.Label lblCategory;
//        private System.Windows.Forms.Button btnAdd;
//        private System.Windows.Forms.Button btnEdit;
//        private System.Windows.Forms.Button btnDelete;
//        private System.Windows.Forms.Label lblServicesCount;
//        private System.Windows.Forms.Button btnLogout;
//    }
//}