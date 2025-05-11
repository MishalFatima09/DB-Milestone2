using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Configuration;

namespace DB_M2_Chat
{
    public partial class AllServicesForm : Form
    {
        // Connection string
        private readonly string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        private enum ServiceType
        {
            Guide,
            Hotel,
            Transport
        }

        public AllServicesForm()
        {
            InitializeComponent();

            // Check if user is logged in
            if (!UserSession.Instance.IsLoggedIn())
            {
                MessageBox.Show("You must be logged in to view services.", "Not Logged In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Set up the DataGridView
            SetupDataGridView();
        }

        private void SetupDataGridView()
        {
            // Clear any existing columns
            dgvServices.Columns.Clear();

            // Set up basic columns that are common to all service types
            dgvServices.Columns.Add("ServiceID", "Service ID");
            dgvServices.Columns.Add("Type", "Type");
            dgvServices.Columns.Add("Name", "Service Name");
            dgvServices.Columns.Add("Details", "Details");

            // Setup dynamic columns for specific service types
            DataGridViewButtonColumn btnViewDetails = new DataGridViewButtonColumn();
            btnViewDetails.HeaderText = "Action";
            btnViewDetails.Text = "View Details";
            btnViewDetails.Name = "btnViewDetails";
            btnViewDetails.UseColumnTextForButtonValue = true;
            dgvServices.Columns.Add(btnViewDetails);

            // Setup column widths
            dgvServices.Columns["ServiceID"].Width = 80;
            dgvServices.Columns["Type"].Width = 80;
            dgvServices.Columns["Name"].Width = 150;
            dgvServices.Columns["Details"].Width = 250;
            dgvServices.Columns["btnViewDetails"].Width = 100;

            // Add event handler for button clicks
            dgvServices.CellClick += DgvServices_CellClick;
        }

        private void DgvServices_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            // Check if a button cell was clicked
            if (e.RowIndex >= 0 && e.ColumnIndex == dgvServices.Columns["btnViewDetails"].Index)
            {
                string serviceID = dgvServices.Rows[e.RowIndex].Cells["ServiceID"].Value.ToString();
                string serviceType = dgvServices.Rows[e.RowIndex].Cells["Type"].Value.ToString();

                // Open a detailed view of the service
                ShowServiceDetails(serviceID, serviceType);
            }
        }

        private void ShowServiceDetails(string serviceID, string serviceType)
        {
            try
            {
                string detailsMessage = GetServiceDetails(serviceID, serviceType);

                // In a real application, you might open a new form instead
                MessageBox.Show(detailsMessage, "Service Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving service details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private string GetServiceDetails(string serviceID, string serviceType)
        {
            StringBuilder details = new StringBuilder();

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First get basic service info
                    string baseQuery = "SELECT s.ServiceID, s.Name, s.Type, sp.Organisation " +
                                     "FROM Service s " +
                                     "JOIN ServiceProvider sp ON s.ProviderID = sp.ProviderID " +
                                     "WHERE s.ServiceID = @ServiceID";

                    using (SqlCommand command = new SqlCommand(baseQuery, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", serviceID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                details.AppendLine($"Service ID: {reader["ServiceID"]}");
                                details.AppendLine($"Name: {reader["Name"]}");
                                details.AppendLine($"Type: {reader["Type"]}");
                                details.AppendLine($"Provider: {reader["Organisation"]}");
                                details.AppendLine();
                            }
                            else
                            {
                                return "Service not found.";
                            }
                        }
                    }

                    // Now get specific details based on service type
                    string typeSpecificQuery = "";

                    switch (serviceType)
                    {
                        case "Guide":
                            typeSpecificQuery = "SELECT ExperienceYears, Specialization, PricePerDay " +
                                              "FROM Guide WHERE ServiceID = @ServiceID";
                            break;

                        case "Hotel":
                            typeSpecificQuery = "SELECT Address, AvailableRooms, Facilities " +
                                              "FROM Hotel WHERE ServiceID = @ServiceID";
                            break;

                        case "Transport":
                            typeSpecificQuery = "SELECT VehicleNum, VehicleType, Capacity, PricePerTicket " +
                                              "FROM Transport WHERE ServiceID = @ServiceID";
                            break;
                    }

                    if (!string.IsNullOrEmpty(typeSpecificQuery))
                    {
                        using (SqlCommand command = new SqlCommand(typeSpecificQuery, connection))
                        {
                            command.Parameters.AddWithValue("@ServiceID", serviceID);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    details.AppendLine("Type-Specific Details:");

                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        string fieldName = reader.GetName(i);
                                        string value = reader[i].ToString();

                                        // Format currency values
                                        if (fieldName.Contains("Price") && decimal.TryParse(value, out decimal price))
                                        {
                                            value = price.ToString("C");
                                        }

                                        details.AppendLine($"- {fieldName}: {value}");
                                    }
                                }
                            }
                        }
                    }
                }

                return details.ToString();
            }
            catch (Exception ex)
            {
                return $"Error retrieving details: {ex.Message}";
            }
        }

        private void AllServicesForm_Load(object sender, EventArgs e)
        {
            // Set the welcome message with provider name
            this.Text = $"Services - {UserSession.Instance.ProviderName} ({UserSession.Instance.Username})";

            // Set up filter options
            SetupFilterOptions();

            // Load services data for the logged-in provider
            PopulateServicesGrid();
        }

        private void SetupFilterOptions()
        {
            // Clear any existing items
            cmbCategory.Items.Clear();

            // Add filter options
            cmbCategory.Items.Add("All");
            cmbCategory.Items.Add("Guide");
            cmbCategory.Items.Add("Hotel");
            cmbCategory.Items.Add("Transport");

            // Set default selection
            cmbCategory.SelectedIndex = 0;
        }

        private void PopulateServicesGrid()
        {
            // Clear existing rows
            dgvServices.Rows.Clear();

            // Get the provider ID from the session
            string providerID = UserSession.Instance.ProviderID;

            if (string.IsNullOrEmpty(providerID))
            {
                MessageBox.Show("Provider ID not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to fetch data for the specific provider
            string query = @"SELECT s.ServiceID, s.Type, s.Name, 
                                CASE 
                                    WHEN s.Type = 'Guide' THEN 
                                        'Experience: ' + CAST(g.ExperienceYears AS VARCHAR) + ' years, Specialization: ' + g.Specialization + ', Price: ' + CAST(g.PricePerDay AS VARCHAR)
                                    WHEN s.Type = 'Hotel' THEN 
                                        'Address: ' + h.Address + ', Available Rooms: ' + CAST(h.AvailableRooms AS VARCHAR)
                                    WHEN s.Type = 'Transport' THEN 
                                        'Vehicle Type: ' + t.VehicleType + ', Capacity: ' + CAST(t.Capacity AS VARCHAR) + ', Price: ' + CAST(t.PricePerTicket AS VARCHAR)
                                    ELSE ''
                                END AS Details
                            FROM Service s
                            LEFT JOIN Guide g ON s.ServiceID = g.ServiceID AND s.Type = 'Guide'
                            LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID AND s.Type = 'Hotel'
                            LEFT JOIN Transport t ON s.ServiceID = t.ServiceID AND s.Type = 'Transport'
                            WHERE s.ProviderID = @ProviderID";

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", providerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvServices.Rows.Add(
                                    reader["ServiceID"].ToString(),
                                    reader["Type"].ToString(),
                                    reader["Name"].ToString(),
                                    reader["Details"].ToString()
                                );
                            }
                        }
                    }
                }

                // Update the services count
                //lblServicesCount.Text = $"Total Services: {dgvServices.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // If search box is empty, show all services
                PopulateServicesGrid();
                return;
            }

            // Filter the current grid results
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                bool matchFound = false;

                // Check each cell for a match
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        matchFound = true;
                        break;
                    }
                }

                // Set row visibility
                row.Visible = matchFound;
            }

            // Count visible rows
            int visibleCount = dgvServices.Rows.Cast<DataGridViewRow>().Count(r => r.Visible);
            //lblServicesCount.Text = $"Filtered Services: {visibleCount}";
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            // If no category is selected, return
            if (string.IsNullOrEmpty(selectedCategory))
                return;

            // If "All" is selected, show all services
            if (selectedCategory == "All")
            {
                PopulateServicesGrid();
                return;
            }

            // Get provider ID from session
            string providerID = UserSession.Instance.ProviderID;

            if (string.IsNullOrEmpty(providerID))
            {
                MessageBox.Show("Provider ID not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // SQL query to fetch filtered data
            string query = @"SELECT s.ServiceID, s.Type, s.Name, 
                                CASE 
                                    WHEN s.Type = 'Guide' THEN 
                                        'Experience: ' + CAST(g.ExperienceYears AS VARCHAR) + ' years, Specialization: ' + g.Specialization + ', Price: ' + CAST(g.PricePerDay AS VARCHAR)
                                    WHEN s.Type = 'Hotel' THEN 
                                        'Address: ' + h.Address + ', Available Rooms: ' + CAST(h.AvailableRooms AS VARCHAR)
                                    WHEN s.Type = 'Transport' THEN 
                                        'Vehicle Type: ' + t.VehicleType + ', Capacity: ' + CAST(t.Capacity AS VARCHAR) + ', Price: ' + CAST(t.PricePerTicket AS VARCHAR)
                                    ELSE ''
                                END AS Details
                            FROM Service s
                            LEFT JOIN Guide g ON s.ServiceID = g.ServiceID AND s.Type = 'Guide'
                            LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID AND s.Type = 'Hotel'
                            LEFT JOIN Transport t ON s.ServiceID = t.ServiceID AND s.Type = 'Transport'
                            WHERE s.ProviderID = @ProviderID AND s.Type = @Type";

            try
            {
                dgvServices.Rows.Clear();

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", providerID);
                        command.Parameters.AddWithValue("@Type", selectedCategory);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                dgvServices.Rows.Add(
                                    reader["ServiceID"].ToString(),
                                    reader["Type"].ToString(),
                                    reader["Name"].ToString(),
                                    reader["Details"].ToString()
                                );
                            }
                        }
                    }
                }

                // Update the services count
                //lblServicesCount.Text = $"Filtered Services: {dgvServices.Rows.Count}";
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error filtering data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnAdd_Click(object sender, EventArgs e)
        {
            // Open a form to add a new service
            // You'd need to create an AddServiceForm class
            // AddServiceForm addForm = new AddServiceForm(UserSession.Instance.ProviderID);
            // addForm.ShowDialog();

            // Refresh the grid after adding a service
            // if (addForm.DialogResult == DialogResult.OK)
            // {
            //     PopulateServicesGrid();
            // }

            MessageBox.Show("Add Service functionality will be implemented in the next update.",
                "Not Implemented", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceId = dgvServices.SelectedRows[0].Cells["ServiceID"].Value.ToString();
                string serviceType = dgvServices.SelectedRows[0].Cells["Type"].Value.ToString();
                string serviceName = dgvServices.SelectedRows[0].Cells["Name"].Value.ToString();

                // Open edit form for the selected service
                EditServiceForm editForm = new EditServiceForm(serviceId, serviceType);
                editForm.ShowDialog();

                // Refresh the grid after editing
                if (editForm.DialogResult == DialogResult.OK)
                {
                    PopulateServicesGrid();
                }
            }
            else
            {
                MessageBox.Show("Please select a service to edit.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDelete_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceId = dgvServices.SelectedRows[0].Cells["ServiceID"].Value.ToString();
                string serviceName = dgvServices.SelectedRows[0].Cells["Name"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the service: {serviceName}?",
                    "Confirm Delete", MessageBoxButtons.YesNoCancel, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    try
                    {
                        using (SqlConnection connection = new SqlConnection(connectionString))
                        {
                            connection.Open();

                            // Delete the service
                            string query = "DELETE FROM Service WHERE ServiceID = @ServiceID";

                            using (SqlCommand command = new SqlCommand(query, connection))
                            {
                                command.Parameters.AddWithValue("@ServiceID", serviceId);
                                int rowsAffected = command.ExecuteNonQuery();

                                if (rowsAffected > 0)
                                {
                                    MessageBox.Show("Service deleted successfully.",
                                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                                    // Refresh the grid
                                    PopulateServicesGrid();
                                }
                                else
                                {
                                    MessageBox.Show("Failed to delete the service. Please try again.",
                                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error deleting service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service to delete.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            // Clear user session
            UserSession.Instance.ClearUserInfo();

            // Close this form and return to login
            this.Close();
            // You'd need to show the login form again, depending on your app structure
        }
    }
}