using System;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace TravelEase.Forms
{
    public partial class CategoryForm : Form
    {
        // Flag to track if form is being loaded
        private bool isLoading = true;

        public CategoryForm()
        {
            InitializeComponent();
        }

        private void CategoryForm_Load(object sender, EventArgs e)
        {
            // Set default placeholder text manually instead of using PlaceholderText property
            txtSearch.Text = "Search by name or description...";
            txtSearch.ForeColor = Color.Gray;

            LoadCategories();
            isLoading = false;
        }

        private void LoadCategories()
        {
            // In a real application, this would load categories from a database
            // For now, we'll add sample data
            dgvCategories.Rows.Clear();
            dgvCategories.Rows.Add("1", "Beach Resorts", "Popular beach destinations and resorts", "Active", "25");
            dgvCategories.Rows.Add("2", "Mountain Retreats", "Serene mountain getaways and hiking spots", "Active", "18");
            dgvCategories.Rows.Add("3", "City Tours", "Guided tours of popular cities", "Active", "30");
            dgvCategories.Rows.Add("4", "Cultural Experiences", "Immersive cultural activities and heritage sites", "Active", "15");
            dgvCategories.Rows.Add("5", "Adventure Sports", "Thrilling outdoor activities and extreme sports", "Active", "22");
            dgvCategories.Rows.Add("6", "Wildlife Safaris", "Wildlife viewing and safari experiences", "Inactive", "10");
            dgvCategories.Rows.Add("7", "Desert Expeditions", "Tours to desert locations", "Active", "8");
            dgvCategories.Rows.Add("8", "Luxury Cruises", "Premium cruise experiences", "Inactive", "5");
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Show the add category dialog
            ShowAddEditPanel("Add New Category", null, "Add");
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCategories.SelectedRows[0];
                ShowAddEditPanel("Edit Category", row, "Edit");
            }
            else
            {
                MessageBox.Show("Please select a category to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        // New method to show add/edit panel with appropriate values
        private void ShowAddEditPanel(string title, DataGridViewRow row, string mode)
        {
            panelAddEdit.Visible = true;
            lblAddEditTitle.Text = title;

            if (row != null)
            {
                txtCategoryName.Text = row.Cells["Name"].Value.ToString();
                txtDescription.Text = row.Cells["Description"].Value.ToString();
                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
            }
            else
            {
                txtCategoryName.Text = "";
                txtDescription.Text = "";
                cmbStatus.SelectedIndex = 0;
            }

            btnSave.Tag = mode;
            txtCategoryName.Focus();
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvCategories.Rows.RemoveAt(dgvCategories.SelectedRows[0].Index);
                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveCategory();
            }
        }

        // Extracted method for saving category data
        private void SaveCategory()
        {
            string mode = btnSave.Tag.ToString();

            if (mode == "Add")
            {
                // Generate a new ID (in a real app, this would be handled by the database)
                int newId = dgvCategories.Rows.Count + 1;

                // Add the new category to the grid
                dgvCategories.Rows.Add(newId.ToString(), txtCategoryName.Text, txtDescription.Text,
                    cmbStatus.SelectedItem.ToString(), "0");

                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else // Edit
            {
                DataGridViewRow row = dgvCategories.SelectedRows[0];
                row.Cells["Name"].Value = txtCategoryName.Text;
                row.Cells["Description"].Value = txtDescription.Text;
                row.Cells["Status"].Value = cmbStatus.SelectedItem.ToString();

                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }

            panelAddEdit.Visible = false;
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtDescription.Focus();
                return false;
            }

            return true;
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            panelAddEdit.Visible = false;
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadCategories();
            ResetSearchBox();
        }

        private void txtSearch_TextChanged(object sender, EventArgs e)
        {
            // Skip search during initial loading or if it's the placeholder text
            if (isLoading || (txtSearch.Text == "Search by name or description..." && txtSearch.ForeColor == Color.Gray))
                return;

            SearchCategories();
        }

        private void SearchCategories()
        {
            // If the search box has placeholder text or is empty, show all rows
            if (txtSearch.Text == "Search by name or description..." || string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                foreach (DataGridViewRow row in dgvCategories.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            string searchText = txtSearch.Text.ToLower();
            foreach (DataGridViewRow row in dgvCategories.Rows)
            {
                bool matchFound = false;

                if (row.Cells["Name"].Value != null &&
                    row.Cells["Name"].Value.ToString().ToLower().Contains(searchText))
                {
                    matchFound = true;
                }
                else if (row.Cells["Description"].Value != null &&
                         row.Cells["Description"].Value.ToString().ToLower().Contains(searchText))
                {
                    matchFound = true;
                }

                row.Visible = matchFound;
            }
        }

        // Handle placeholder text in search box
        private void txtSearch_Enter(object sender, EventArgs e)
        {
            if (txtSearch.Text == "Search by name or description...")
            {
                txtSearch.Text = "";
                txtSearch.ForeColor = Color.Black;
            }
        }

        private void txtSearch_Leave(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtSearch.Text))
            {
                ResetSearchBox();
            }
        }

        private void ResetSearchBox()
        {
            txtSearch.Text = "Search by name or description...";
            txtSearch.ForeColor = Color.Gray;
        }
    }
}