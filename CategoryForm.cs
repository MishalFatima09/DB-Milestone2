//using System;
//using System.Drawing;
//using System.Windows.Forms;
//using System.IO;

//namespace TravelEase.Forms
//{
//    public partial class CategoryForm : Form
//    {
//        // Flag to track if form is being loaded
//        private bool isLoading = true;

//        public CategoryForm()
//        {
//            InitializeComponent();
//        }

//        private void CategoryForm_Load(object sender, EventArgs e)
//        {
//            // Set default placeholder text manually instead of using PlaceholderText property
//            txtSearch.Text = "Search by name or description...";
//            txtSearch.ForeColor = Color.Gray;

//            LoadCategories();
//            isLoading = false;
//        }

//        private void LoadCategories()
//        {
//            // In a real application, this would load categories from a database
//            // For now, we'll add sample data
//            dgvCategories.Rows.Clear();
//            dgvCategories.Rows.Add("1", "Beach Resorts", "Popular beach destinations and resorts", "Active", "25");
//            dgvCategories.Rows.Add("2", "Mountain Retreats", "Serene mountain getaways and hiking spots", "Active", "18");
//            dgvCategories.Rows.Add("3", "City Tours", "Guided tours of popular cities", "Active", "30");
//            dgvCategories.Rows.Add("4", "Cultural Experiences", "Immersive cultural activities and heritage sites", "Active", "15");
//            dgvCategories.Rows.Add("5", "Adventure Sports", "Thrilling outdoor activities and extreme sports", "Active", "22");
//            dgvCategories.Rows.Add("6", "Wildlife Safaris", "Wildlife viewing and safari experiences", "Inactive", "10");
//            dgvCategories.Rows.Add("7", "Desert Expeditions", "Tours to desert locations", "Active", "8");
//            dgvCategories.Rows.Add("8", "Luxury Cruises", "Premium cruise experiences", "Inactive", "5");
//        }

//        private void btnAdd_Click(object sender, EventArgs e)
//        {
//            // Show the add category dialog
//            ShowAddEditPanel("Add New Category", null, "Add");
//        }

//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (dgvCategories.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvCategories.SelectedRows[0];
//                ShowAddEditPanel("Edit Category", row, "Edit");
//            }
//            else
//            {
//                MessageBox.Show("Please select a category to edit.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        // New method to show add/edit panel with appropriate values
//        private void ShowAddEditPanel(string title, DataGridViewRow row, string mode)
//        {
//            panelAddEdit.Visible = true;
//            lblAddEditTitle.Text = title;

//            if (row != null)
//            {
//                txtCategoryName.Text = row.Cells["Name"].Value.ToString();
//                txtDescription.Text = row.Cells["Description"].Value.ToString();
//                cmbStatus.SelectedItem = row.Cells["Status"].Value.ToString();
//            }
//            else
//            {
//                txtCategoryName.Text = "";
//                txtDescription.Text = "";
//                cmbStatus.SelectedIndex = 0;
//            }

//            btnSave.Tag = mode;
//            txtCategoryName.Focus();
//        }

//        private void btnDelete_Click(object sender, EventArgs e)
//        {
//            if (dgvCategories.SelectedRows.Count > 0)
//            {
//                if (MessageBox.Show("Are you sure you want to delete this category?", "Confirm Delete",
//                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
//                {
//                    dgvCategories.Rows.RemoveAt(dgvCategories.SelectedRows[0].Index);
//                    MessageBox.Show("Category deleted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a category to delete.", "Selection Required", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private void btnSave_Click(object sender, EventArgs e)
//        {
//            if (ValidateInputs())
//            {
//                SaveCategory();
//            }
//        }

//        // Extracted method for saving category data
//        private void SaveCategory()
//        {
//            string mode = btnSave.Tag.ToString();

//            if (mode == "Add")
//            {
//                // Generate a new ID (in a real app, this would be handled by the database)
//                int newId = dgvCategories.Rows.Count + 1;

//                // Add the new category to the grid
//                dgvCategories.Rows.Add(newId.ToString(), txtCategoryName.Text, txtDescription.Text,
//                    cmbStatus.SelectedItem.ToString(), "0");

//                MessageBox.Show("Category added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else // Edit
//            {
//                DataGridViewRow row = dgvCategories.SelectedRows[0];
//                row.Cells["Name"].Value = txtCategoryName.Text;
//                row.Cells["Description"].Value = txtDescription.Text;
//                row.Cells["Status"].Value = cmbStatus.SelectedItem.ToString();

//                MessageBox.Show("Category updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }

//            panelAddEdit.Visible = false;
//        }

//        private bool ValidateInputs()
//        {
//            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
//            {
//                MessageBox.Show("Category name is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtCategoryName.Focus();
//                return false;
//            }

//            if (string.IsNullOrWhiteSpace(txtDescription.Text))
//            {
//                MessageBox.Show("Description is required.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                txtDescription.Focus();
//                return false;
//            }

//            return true;
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            panelAddEdit.Visible = false;
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadCategories();
//            ResetSearchBox();
//        }

//        private void txtSearch_TextChanged(object sender, EventArgs e)
//        {
//            // Skip search during initial loading or if it's the placeholder text
//            if (isLoading || (txtSearch.Text == "Search by name or description..." && txtSearch.ForeColor == Color.Gray))
//                return;

//            SearchCategories();
//        }

//        private void SearchCategories()
//        {
//            // If the search box has placeholder text or is empty, show all rows
//            if (txtSearch.Text == "Search by name or description..." || string.IsNullOrWhiteSpace(txtSearch.Text))
//            {
//                foreach (DataGridViewRow row in dgvCategories.Rows)
//                {
//                    row.Visible = true;
//                }
//                return;
//            }

//            string searchText = txtSearch.Text.ToLower();
//            foreach (DataGridViewRow row in dgvCategories.Rows)
//            {
//                bool matchFound = false;

//                if (row.Cells["Name"].Value != null &&
//                    row.Cells["Name"].Value.ToString().ToLower().Contains(searchText))
//                {
//                    matchFound = true;
//                }
//                else if (row.Cells["Description"].Value != null &&
//                         row.Cells["Description"].Value.ToString().ToLower().Contains(searchText))
//                {
//                    matchFound = true;
//                }

//                row.Visible = matchFound;
//            }
//        }

//        // Handle placeholder text in search box
//        private void txtSearch_Enter(object sender, EventArgs e)
//        {
//            if (txtSearch.Text == "Search by name or description...")
//            {
//                txtSearch.Text = "";
//                txtSearch.ForeColor = Color.Black;
//            }
//        }

//        private void txtSearch_Leave(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtSearch.Text))
//            {
//                ResetSearchBox();
//            }
//        }

//        private void ResetSearchBox()
//        {
//            txtSearch.Text = "Search by name or description...";
//            txtSearch.ForeColor = Color.Gray;
//        }
//    }
//}


using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Configuration;

namespace TravelEase.Forms
{
    public partial class CategoryForm : Form
    {
        // Connection string - consider moving to configuration file
        private string connectionString;

        // Flag to track if form is being loaded
        private bool isLoading = true;

        public CategoryForm()
        {
            // Retrieve connection string from app configuration
            connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

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
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Query to get unique categories and their tour counts
                    string query = @"
                        SELECT 
                            TourCategory AS Name, 
                            COUNT(TripID) AS TourCount, 
                            'Active' AS Status, 
                            'Tour categories from trips' AS Description
                        FROM Trip
                        GROUP BY TourCategory";

                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                    DataTable dtCategories = new DataTable();
                    adapter.Fill(dtCategories);

                    // Clear existing rows
                    dgvCategories.Rows.Clear();

                    // Populate DataGridView
                    foreach (DataRow row in dtCategories.Rows)
                    {
                        dgvCategories.Rows.Add(
                            row.Table.Rows.IndexOf(row) + 1, // ID
                            row["Name"],
                            row["Description"],
                            row["Status"],
                            row["TourCount"]
                        );
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            ShowAddEditPanel("Add New Category", null, "Add");
        }

        //private void btnEdit_Click(object sender, EventArgs e)
        //{
        //    if (dgvCategories.SelectedRows.Count > 0)
        //    {
        //        DataGridViewRow row = dgvCategories.SelectedRows[0];
        //        ShowAddEditPanel("Edit Category", row, "Edit");
        //    }
        //    else
        //    {
        //        MessageBox.Show("Please select a category to edit.", "Selection Required",
        //            MessageBoxButtons.OK, MessageBoxIcon.Warning);
        //    }
        //}

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

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvCategories.SelectedRows[0];
                ShowEditCategoryDialog(row);
            }
            else
            {
                MessageBox.Show("Please select a category to edit.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void ShowEditCategoryDialog(DataGridViewRow row)
        {
            // Create a custom dialog for editing category name
            Form editDialog = new Form
            {
                Text = "Edit Category",
                Size = new Size(400, 200),
                FormBorderStyle = FormBorderStyle.FixedDialog,
                StartPosition = FormStartPosition.CenterScreen,
                MaximizeBox = false,
                MinimizeBox = false
            };

            // Current category name
            string currentCategoryName = row.Cells["Name"].Value.ToString();

            // Labels
            Label lblCurrentName = new Label
            {
                Text = $"Current Category: {currentCategoryName}",
                Location = new Point(20, 20),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            Label lblNewName = new Label
            {
                Text = "New Category Name:",
                Location = new Point(20, 60),
                AutoSize = true,
                Font = new Font("Segoe UI", 10)
            };

            // Text box for new category name
            TextBox txtNewCategoryName = new TextBox
            {
                Location = new Point(20, 85),
                Size = new Size(350, 25),
                Text = currentCategoryName,
                Font = new Font("Segoe UI", 10)
            };

            // Buttons
            Button btnSave = new Button
            {
                Text = "Save",
                Location = new Point(200, 130),
                DialogResult = DialogResult.OK,
                Font = new Font("Segoe UI", 9)
            };

            Button btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(280, 130),
                DialogResult = DialogResult.Cancel,
                Font = new Font("Segoe UI", 9)
            };

            // Add controls to dialog
            editDialog.Controls.Add(lblCurrentName);
            editDialog.Controls.Add(lblNewName);
            editDialog.Controls.Add(txtNewCategoryName);
            editDialog.Controls.Add(btnSave);
            editDialog.Controls.Add(btnCancel);

            // Set Accept and Cancel buttons
            editDialog.AcceptButton = btnSave;
            editDialog.CancelButton = btnCancel;

            // Show dialog and handle result
            if (editDialog.ShowDialog() == DialogResult.OK)
            {
                string newCategoryName = txtNewCategoryName.Text.Trim();

                // Validate new category name
                if (string.IsNullOrWhiteSpace(newCategoryName))
                {
                    MessageBox.Show("Category name cannot be empty.", "Validation Error",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                // Check if new name is different from current name
                if (newCategoryName.Equals(currentCategoryName, StringComparison.OrdinalIgnoreCase))
                {
                    MessageBox.Show("No changes made.", "No Change",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Perform the category name update
                UpdateCategoryName(currentCategoryName, newCategoryName);
            }
        }

        private void UpdateCategoryName(string oldCategoryName, string newCategoryName)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Start a transaction
                    using (SqlTransaction transaction = connection.BeginTransaction())
                    {
                        try
                        {
                            // Update all trips with the old category name to the new category name
                            string updateQuery = @"
                                        UPDATE Trip 
                                        SET TourCategory = @NewCategoryName 
                                        WHERE TourCategory = @OldCategoryName";

                            using (SqlCommand cmd = new SqlCommand(updateQuery, connection, transaction))
                            {
                                cmd.Parameters.AddWithValue("@NewCategoryName", newCategoryName);
                                cmd.Parameters.AddWithValue("@OldCategoryName", oldCategoryName);

                                int rowsAffected = cmd.ExecuteNonQuery();

                                // Commit the transaction
                                transaction.Commit();

                                // Show success message
                                MessageBox.Show($"Category '{oldCategoryName}' updated to '{newCategoryName}'. " +
                                    $"{rowsAffected} trips were updated.",
                                    "Category Updated",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information);

                                // Refresh the categories grid
                                LoadCategories();
                            }
                        }
                        catch (Exception)
                        {
                            // Rollback the transaction in case of error
                            transaction.Rollback();
                            throw;
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating category: {ex.Message}",
                    "Database Error",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Error);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvCategories.SelectedRows.Count > 0)
            {
                string categoryName = dgvCategories.SelectedRows[0].Cells["Name"].Value.ToString();

                if (MessageBox.Show($"Are you sure you want to delete the category '{categoryName}'?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    try
                    {
                        // Note: In this implementation, we're not actually deleting from database
                        // as categories are derived from Trip table
                        MessageBox.Show("Cannot delete categories directly. " +
                            "Categories are derived from existing trips.",
                            "Delete Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting category: {ex.Message}",
                            "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a category to delete.", "Selection Required",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            if (ValidateInputs())
            {
                SaveCategory();
            }
        }

        private void SaveCategory()
        {
            string mode = btnSave.Tag.ToString();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    if (mode == "Add")
                    {
                        // Note: In this implementation, categories are derived from Trip table
                        // We cannot directly add a new category here
                        MessageBox.Show("Cannot add new categories directly. " +
                            "Categories are automatically created when adding trips.",
                            "Add Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    else // Edit
                    {
                        // Note: Editing categories is not directly supported 
                        // as they are derived from Trip table
                        MessageBox.Show("Cannot edit categories directly. " +
                            "Categories are automatically managed based on trips.",
                            "Edit Restricted", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }

                panelAddEdit.Visible = false;
                LoadCategories(); // Refresh the grid
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error saving category: {ex.Message}",
                    "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private bool ValidateInputs()
        {
            if (string.IsNullOrWhiteSpace(txtCategoryName.Text))
            {
                MessageBox.Show("Category name is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
                txtCategoryName.Focus();
                return false;
            }

            if (string.IsNullOrWhiteSpace(txtDescription.Text))
            {
                MessageBox.Show("Description is required.", "Validation Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
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

//using System;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Windows.Forms;
//using System.Configuration;

//namespace TravelEase.Forms
//{
//    public partial class CategoryForm : Form
//    {
//        // Connection string - consider moving to configuration file
//        private string connectionString;

//        // Flag to track if form is being loaded
//        private bool isLoading = true;

//        public CategoryForm()
//        {
//            // Retrieve connection string from app configuration
//            connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

//            InitializeComponent();
//        }

//        private void CategoryForm_Load(object sender, EventArgs e)
//        {
//            // Set default placeholder text manually instead of using PlaceholderText property
//            txtSearch.Text = "Search by name or description...";
//            txtSearch.ForeColor = Color.Gray;

//            LoadCategories();
//            isLoading = false;
//        }

//        private void LoadCategories()
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    // Query to get unique categories and their tour counts
//                    string query = @"
//                        SELECT 
//                            TourCategory AS Name, 
//                            COUNT(TripID) AS TourCount, 
//                            'Active' AS Status, 
//                            'Tour categories from trips' AS Description
//                        FROM Trip
//                        GROUP BY TourCategory";

//                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
//                    DataTable dtCategories = new DataTable();
//                    adapter.Fill(dtCategories);

//                    // Clear existing rows
//                    dgvCategories.Rows.Clear();

//                    // Populate DataGridView
//                    foreach (DataRow row in dtCategories.Rows)
//                    {
//                        dgvCategories.Rows.Add(
//                            row.Table.Rows.IndexOf(row) + 1, // ID
//                            row["Name"],
//                            row["Description"],
//                            row["Status"],
//                            row["TourCount"]
//                        );
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error loading categories: {ex.Message}", "Database Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnEdit_Click(object sender, EventArgs e)
//        {
//            if (dgvCategories.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvCategories.SelectedRows[0];
//                ShowEditCategoryDialog(row);
//            }
//            else
//            {
//                MessageBox.Show("Please select a category to edit.", "Selection Required",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private void ShowEditCategoryDialog(DataGridViewRow row)
//        {
//            // Create a custom dialog for editing category name
//            Form editDialog = new Form
//            {
//                Text = "Edit Category",
//                Size = new Size(400, 200),
//                FormBorderStyle = FormBorderStyle.FixedDialog,
//                StartPosition = FormStartPosition.CenterScreen,
//                MaximizeBox = false,
//                MinimizeBox = false
//            };

//            // Current category name
//            string currentCategoryName = row.Cells["Name"].Value.ToString();

//            // Labels
//            Label lblCurrentName = new Label
//            {
//                Text = $"Current Category: {currentCategoryName}",
//                Location = new Point(20, 20),
//                AutoSize = true,
//                Font = new Font("Segoe UI", 10)
//            };

//            Label lblNewName = new Label
//            {
//                Text = "New Category Name:",
//                Location = new Point(20, 60),
//                AutoSize = true,
//                Font = new Font("Segoe UI", 10)
//            };

//            // Text box for new category name
//            TextBox txtNewCategoryName = new TextBox
//            {
//                Location = new Point(20, 85),
//                Size = new Size(350, 25),
//                Text = currentCategoryName,
//                Font = new Font("Segoe UI", 10)
//            };

//            // Buttons
//            Button btnSave = new Button
//            {
//                Text = "Save",
//                Location = new Point(200, 130),
//                DialogResult = DialogResult.OK,
//                Font = new Font("Segoe UI", 9)
//            };

//            Button btnCancel = new Button
//            {
//                Text = "Cancel",
//                Location = new Point(280, 130),
//                DialogResult = DialogResult.Cancel,
//                Font = new Font("Segoe UI", 9)
//            };

//            // Add controls to dialog
//            editDialog.Controls.Add(lblCurrentName);
//            editDialog.Controls.Add(lblNewName);
//            editDialog.Controls.Add(txtNewCategoryName);
//            editDialog.Controls.Add(btnSave);
//            editDialog.Controls.Add(btnCancel);

//            // Set Accept and Cancel buttons
//            editDialog.AcceptButton = btnSave;
//            editDialog.CancelButton = btnCancel;

//            // Show dialog and handle result
//            if (editDialog.ShowDialog() == DialogResult.OK)
//            {
//                string newCategoryName = txtNewCategoryName.Text.Trim();

//                // Validate new category name
//                if (string.IsNullOrWhiteSpace(newCategoryName))
//                {
//                    MessageBox.Show("Category name cannot be empty.", "Validation Error",
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                // Check if new name is different from current name
//                if (newCategoryName.Equals(currentCategoryName, StringComparison.OrdinalIgnoreCase))
//                {
//                    MessageBox.Show("No changes made.", "No Change",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    return;
//                }

//                // Perform the category name update
//                UpdateCategoryName(currentCategoryName, newCategoryName);
//            }
//        }

//        private void UpdateCategoryName(string oldCategoryName, string newCategoryName)
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    // Start a transaction
//                    using (SqlTransaction transaction = connection.BeginTransaction())
//                    {
//                        try
//                        {
//                            // Update all trips with the old category name to the new category name
//                            string updateQuery = @"
//                                UPDATE Trip 
//                                SET TourCategory = @NewCategoryName 
//                                WHERE TourCategory = @OldCategoryName";

//                            using (SqlCommand cmd = new SqlCommand(updateQuery, connection, transaction))
//                            {
//                                cmd.Parameters.AddWithValue("@NewCategoryName", newCategoryName);
//                                cmd.Parameters.AddWithValue("@OldCategoryName", oldCategoryName);

//                                int rowsAffected = cmd.ExecuteNonQuery();

//                                // Commit the transaction
//                                transaction.Commit();

//                                // Show success message
//                                MessageBox.Show($"Category '{oldCategoryName}' updated to '{newCategoryName}'. " +
//                                    $"{rowsAffected} trips were updated.",
//                                    "Category Updated",
//                                    MessageBoxButtons.OK,
//                                    MessageBoxIcon.Information);

//                                // Refresh the categories grid
//                                LoadCategories();
//                            }
//                        }
//                        catch (Exception)
//                        {
//                            // Rollback the transaction in case of error
//                            transaction.Rollback();
//                            throw;
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error updating category: {ex.Message}",
//                    "Database Error",
//                    MessageBoxButtons.OK,
//                    MessageBoxIcon.Error);
//            }
//        }

//        // ... (rest of the previous code remains the same)
//    }
//}