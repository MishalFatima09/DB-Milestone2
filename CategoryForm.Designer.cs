using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class CategoryForm
    {
        private Label lblTitle;
        private DataGridView dgvCategories;
        private Button btnAdd;
        private Button btnEdit;
        private Button btnDelete;
        private Button btnRefresh;
        private TextBox txtSearch;
        private Panel panelAddEdit;
        private Label lblAddEditTitle;
        private Label lblCategoryName;
        private TextBox txtCategoryName;
        private Label lblDescription;
        private TextBox txtDescription;
        private Label lblStatus;
        private ComboBox cmbStatus;
        private Button btnSave;
        private Button btnCancel;
        private Label lblSearch;

        private void InitializeComponent()
        {
            this.lblTitle = new Label();
            this.dgvCategories = new DataGridView();
            this.btnAdd = new Button();
            this.btnEdit = new Button();
            this.btnDelete = new Button();
            this.btnRefresh = new Button();
            this.txtSearch = new TextBox();
            this.panelAddEdit = new Panel();
            this.lblAddEditTitle = new Label();
            this.lblCategoryName = new Label();
            this.txtCategoryName = new TextBox();
            this.lblDescription = new Label();
            this.txtDescription = new TextBox();
            this.lblStatus = new Label();
            this.cmbStatus = new ComboBox();
            this.btnSave = new Button();
            this.btnCancel = new Button();
            this.lblSearch = new Label();

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).BeginInit();
            this.panelAddEdit.SuspendLayout();
            this.SuspendLayout();

            // 
            // CategoryForm
            // 
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new System.Drawing.Size(850, 500);
            this.Name = "CategoryForm";
            this.Text = "Category Management";
            this.Load += new System.EventHandler(this.CategoryForm_Load);

            // 
            // lblTitle
            // 
            this.lblTitle.Text = "🗂️ Tour Categories Management";
            this.lblTitle.Font = new Font("Segoe UI", 14, FontStyle.Bold);
            this.lblTitle.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblTitle.Location = new Point(30, 20);
            this.lblTitle.AutoSize = true;

            // 
            // lblSearch
            // 
            this.lblSearch.Text = "🔍 Search:";
            this.lblSearch.Font = new Font("Segoe UI", 10);
            this.lblSearch.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblSearch.Location = new Point(550, 25);
            this.lblSearch.AutoSize = true;

            // 
            // txtSearch
            // 
            this.txtSearch.Location = new Point(625, 25);
            this.txtSearch.Size = new Size(200, 25);
            this.txtSearch.Font = new Font("Segoe UI", 9);
            // Remove the PlaceholderText property and handle it programmatically
            this.txtSearch.TextChanged += new System.EventHandler(this.txtSearch_TextChanged);
            this.txtSearch.Enter += new System.EventHandler(this.txtSearch_Enter);
            this.txtSearch.Leave += new System.EventHandler(this.txtSearch_Leave);

            // 
            // dgvCategories
            // 
            this.dgvCategories.Location = new Point(30, 60);
            this.dgvCategories.Size = new Size(790, 350);
            this.dgvCategories.BackgroundColor = Color.White;
            this.dgvCategories.BorderStyle = BorderStyle.None;
            this.dgvCategories.CellBorderStyle = DataGridViewCellBorderStyle.SingleHorizontal;
            this.dgvCategories.ColumnHeadersHeightSizeMode = DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgvCategories.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            this.dgvCategories.MultiSelect = false;
            this.dgvCategories.ReadOnly = true;
            this.dgvCategories.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            this.dgvCategories.AllowUserToAddRows = false;
            this.dgvCategories.AllowUserToDeleteRows = false;
            this.dgvCategories.AllowUserToResizeRows = false;
            this.dgvCategories.RowHeadersVisible = false;
            this.dgvCategories.AlternatingRowsDefaultCellStyle.BackColor = Color.FromArgb(240, 240, 240);
            this.dgvCategories.DefaultCellStyle.SelectionBackColor = Color.FromArgb(11, 57, 84);
            this.dgvCategories.DefaultCellStyle.SelectionForeColor = Color.White;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.BackColor = Color.FromArgb(11, 57, 84);
            this.dgvCategories.ColumnHeadersDefaultCellStyle.ForeColor = Color.White;
            this.dgvCategories.ColumnHeadersDefaultCellStyle.Font = new Font("Segoe UI", 9, FontStyle.Bold);

            // Add columns
            this.dgvCategories.Columns.Add("ID", "ID");
            this.dgvCategories.Columns.Add("Name", "Category Name");
            this.dgvCategories.Columns.Add("Description", "Description");
            this.dgvCategories.Columns.Add("Status", "Status");
            this.dgvCategories.Columns.Add("TourCount", "Tour Count");

            // Set column widths
            this.dgvCategories.Columns["ID"].Width = 50;
            this.dgvCategories.Columns["Name"].Width = 150;
            this.dgvCategories.Columns["Description"].Width = 300;
            this.dgvCategories.Columns["Status"].Width = 100;
            this.dgvCategories.Columns["TourCount"].Width = 100;

            // 
            // btnAdd
            // 
            //this.btnAdd.Location = new Point(30, 420);
            //this.btnAdd.Size = new Size(100, 35);
            //this.btnAdd.Text = "➕ Add New";
            //this.btnAdd.FlatStyle = FlatStyle.Flat;
            //this.btnAdd.FlatAppearance.BorderSize = 0;
            //this.btnAdd.Font = new Font("Segoe UI", 9);
            //this.btnAdd.BackColor = Color.FromArgb(46, 139, 87); // Green
            //this.btnAdd.ForeColor = Color.White;
            //this.btnAdd.Cursor = Cursors.Hand;
            //this.btnAdd.Click += new System.EventHandler(this.btnAdd_Click);

            // 
            // btnEdit
            // 
            this.btnEdit.Location = new Point(30, 420);
            this.btnEdit.Size = new Size(100, 35);
            this.btnEdit.Text = "✏️ Edit";
            this.btnEdit.FlatStyle = FlatStyle.Flat;
            this.btnEdit.FlatAppearance.BorderSize = 0;
            this.btnEdit.Font = new Font("Segoe UI", 9);
            this.btnEdit.BackColor = Color.FromArgb(70, 130, 180); // Steel Blue
            this.btnEdit.ForeColor = Color.White;
            this.btnEdit.Cursor = Cursors.Hand;
            this.btnEdit.Click += new System.EventHandler(this.btnEdit_Click);

            // 
            // btnDelete
            // 
            this.btnDelete.Location = new Point(140, 420);
            this.btnDelete.Size = new Size(100, 35);
            this.btnDelete.Text = "🗑️ Delete";
            this.btnDelete.FlatStyle = FlatStyle.Flat;
            this.btnDelete.FlatAppearance.BorderSize = 0;
            this.btnDelete.Font = new Font("Segoe UI", 9);
            this.btnDelete.BackColor = Color.FromArgb(178, 34, 34); // Red
            this.btnDelete.ForeColor = Color.White;
            this.btnDelete.Cursor = Cursors.Hand;
            this.btnDelete.Click += new System.EventHandler(this.btnDelete_Click);

            // 
            // btnRefresh
            // 
            this.btnRefresh.Location = new Point(250, 420);
            this.btnRefresh.Size = new Size(100, 35);
            this.btnRefresh.Text = "🔄 Refresh";
            this.btnRefresh.FlatStyle = FlatStyle.Flat;
            this.btnRefresh.FlatAppearance.BorderSize = 0;
            this.btnRefresh.Font = new Font("Segoe UI", 9);
            this.btnRefresh.BackColor = Color.FromArgb(11, 57, 84); // Dark blue
            this.btnRefresh.ForeColor = Color.White;
            this.btnRefresh.Cursor = Cursors.Hand;
            this.btnRefresh.Click += new System.EventHandler(this.btnRefresh_Click);

            // 
            // panelAddEdit
            // 
            this.panelAddEdit.Location = new Point(225, 100);
            this.panelAddEdit.Size = new Size(400, 300);
            this.panelAddEdit.BackColor = Color.White;
            this.panelAddEdit.BorderStyle = BorderStyle.FixedSingle;
            this.panelAddEdit.Visible = false;

            // 
            // lblAddEditTitle
            // 
            this.lblAddEditTitle.Text = "Add New Category";
            this.lblAddEditTitle.Font = new Font("Segoe UI", 12, FontStyle.Bold);
            this.lblAddEditTitle.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblAddEditTitle.Location = new Point(10, 10);
            this.lblAddEditTitle.AutoSize = true;

            // 
            // lblCategoryName
            // 
            this.lblCategoryName.Text = "Category Name:";
            this.lblCategoryName.Font = new Font("Segoe UI", 9);
            this.lblCategoryName.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblCategoryName.Location = new Point(10, 50);
            this.lblCategoryName.AutoSize = true;

            // 
            // txtCategoryName
            // 
            this.txtCategoryName.Location = new Point(10, 75);
            this.txtCategoryName.Size = new Size(380, 25);
            this.txtCategoryName.Font = new Font("Segoe UI", 9);

            // 
            // lblDescription
            // 
            this.lblDescription.Text = "Description:";
            this.lblDescription.Font = new Font("Segoe UI", 9);
            this.lblDescription.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblDescription.Location = new Point(10, 110);
            this.lblDescription.AutoSize = true;

            // 
            // txtDescription
            // 
            this.txtDescription.Location = new Point(10, 135);
            this.txtDescription.Size = new Size(380, 60);
            this.txtDescription.Font = new Font("Segoe UI", 9);
            this.txtDescription.Multiline = true;

            // 
            // lblStatus
            // 
            this.lblStatus.Text = "Status:";
            this.lblStatus.Font = new Font("Segoe UI", 9);
            this.lblStatus.ForeColor = Color.FromArgb(11, 57, 84);
            this.lblStatus.Location = new Point(10, 205);
            this.lblStatus.AutoSize = true;

            // 
            // cmbStatus
            // 
            this.cmbStatus.Location = new Point(10, 230);
            this.cmbStatus.Size = new Size(150, 25);
            this.cmbStatus.Font = new Font("Segoe UI", 9);
            this.cmbStatus.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbStatus.Items.AddRange(new object[] { "Active", "Inactive" });
            this.cmbStatus.SelectedIndex = 0;

            // 
            // btnSave
            // 
            this.btnSave.Location = new Point(190, 250);
            this.btnSave.Size = new Size(90, 30);
            this.btnSave.Text = "✓ Save";
            this.btnSave.FlatStyle = FlatStyle.Flat;
            this.btnSave.Font = new Font("Segoe UI", 9);
            this.btnSave.BackColor = Color.FromArgb(46, 139, 87); // Green
            this.btnSave.ForeColor = Color.White;
            this.btnSave.Cursor = Cursors.Hand;
            this.btnSave.Tag = "Add";
            this.btnSave.Click += new System.EventHandler(this.btnSave_Click);

            // 
            // btnCancel
            // 
            this.btnCancel.Location = new Point(290, 250);
            this.btnCancel.Size = new Size(90, 30);
            this.btnCancel.Text = "✗ Cancel";
            this.btnCancel.FlatStyle = FlatStyle.Flat;
            this.btnCancel.Font = new Font("Segoe UI", 9);
            this.btnCancel.BackColor = Color.FromArgb(169, 169, 169); // Gray
            this.btnCancel.ForeColor = Color.White;
            this.btnCancel.Cursor = Cursors.Hand;
            this.btnCancel.Click += new System.EventHandler(this.btnCancel_Click);

            // Add controls to panel
            this.panelAddEdit.Controls.Add(this.lblAddEditTitle);
            this.panelAddEdit.Controls.Add(this.lblCategoryName);
            this.panelAddEdit.Controls.Add(this.txtCategoryName);
            this.panelAddEdit.Controls.Add(this.lblDescription);
            this.panelAddEdit.Controls.Add(this.txtDescription);
            this.panelAddEdit.Controls.Add(this.lblStatus);
            this.panelAddEdit.Controls.Add(this.cmbStatus);
            this.panelAddEdit.Controls.Add(this.btnSave);
            this.panelAddEdit.Controls.Add(this.btnCancel);

            // Add controls to form
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.lblSearch);
            this.Controls.Add(this.txtSearch);
            this.Controls.Add(this.dgvCategories);
            this.Controls.Add(this.btnAdd);
            this.Controls.Add(this.btnEdit);
            this.Controls.Add(this.btnDelete);
            this.Controls.Add(this.btnRefresh);
            this.Controls.Add(this.panelAddEdit);

            ((System.ComponentModel.ISupportInitialize)(this.dgvCategories)).EndInit();
            this.panelAddEdit.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();
        }
    }
}