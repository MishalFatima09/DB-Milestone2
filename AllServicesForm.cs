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
using System.Data.SqlClient;


namespace DB_M2_Chat
{
    public partial class AllServicesForm : Form
    {
        public AllServicesForm()
        {
            InitializeComponent();
        }

        private void AllServicesForm_Load(object sender, EventArgs e)
        {
            // Load services data
            // In a real application, this would be loaded from a database
            PopulateServicesGrid();
        }

        private void PopulateServicesGrid()
        {
            //// Clear existing items
            dgvServices.Rows.Clear();

            // Add sample data
            dgvServices.Rows.Add("S001", "Luxury Suite", "Hotel", "$250", "Available", "4.8");
            dgvServices.Rows.Add("S002", "City Tour", "Tour", "$45", "Available", "4.5");
            dgvServices.Rows.Add("S003", "Airport Shuttle", "Transport", "$30", "Limited", "4.3");
            dgvServices.Rows.Add("S004", "Adventure Package", "Package", "$399", "Available", "4.7");
            dgvServices.Rows.Add("S005", "Standard Room", "Hotel", "$120", "Limited", "4.2");
            dgvServices.Rows.Add("S006", "Beachfront Villa", "Hotel", "$400", "Available", "4.9");
            dgvServices.Rows.Add("S007", "Wine Tasting Tour", "Tour", "$75", "Limited", "4.6");

            //// Clear existing rows
            //dgvServices.Rows.Clear();

            //// Get the connection string from App.config
            //string connectionString = ConfigurationManager.ConnectionStrings["DBConnection"].ConnectionString;

            //// SQL query to fetch data
            //string query = "SELECT ID, ServiceName, Category, Price, Availability, Rating FROM Services";

            //try
            //{
            //    using (SqlConnection connection = new SqlConnection(connectionString))
            //    {
            //        connection.Open();

            //        using (SqlCommand command = new SqlCommand(query, connection))
            //        {
            //            using (SqlDataReader reader = command.ExecuteReader())
            //            {
            //                while (reader.Read())
            //                {
            //                    dgvServices.Rows.Add(
            //                        reader["ID"].ToString(),
            //                        reader["ServiceName"].ToString(),
            //                        reader["Category"].ToString(),
            //                        $"${reader["Price"]:0.00}",
            //                        reader["Availability"].ToString(),
            //                        reader["Rating"].ToString()
            //                    );
            //                }
            //            }
            //        }
            //    }
            //}
            //catch (Exception ex)
            //{
            //    MessageBox.Show($"Error loading data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
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

            // Hide rows that don't match the search term
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                bool matchFound = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        matchFound = true;
                        break;
                    }
                }

                row.Visible = matchFound;
            }
        }

        private void cmbCategory_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedCategory = cmbCategory.SelectedItem.ToString();

            // If "All" is selected, show all services
            if (selectedCategory == "All")
            {
                foreach (DataGridViewRow row in dgvServices.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            // Filter by selected category
            foreach (DataGridViewRow row in dgvServices.Rows)
            {
                if (row.Cells["Category"].Value != null)
                {
                    row.Visible = row.Cells["Category"].Value.ToString() == selectedCategory;
                }
            }
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceId = dgvServices.SelectedRows[0].Cells["ID"].Value.ToString();
                string serviceName = dgvServices.SelectedRows[0].Cells["Service Name"].Value.ToString();

                // In a real application, this would open a form to edit the service
                MessageBox.Show($"Opening edit form for service: {serviceName} (ID: {serviceId})",
                    "Edit Service", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Here you would normally open an edit form
                // AddServiceForm editForm = new AddServiceForm(serviceId);
                // editForm.ShowDialog();

                // After editing, refresh the grid
                // PopulateServicesGrid();
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
                string serviceId = dgvServices.SelectedRows[0].Cells["ID"].Value.ToString();
                string serviceName = dgvServices.SelectedRows[0].Cells["Service Name"].Value.ToString();

                DialogResult result = MessageBox.Show($"Are you sure you want to delete the service: {serviceName}?",
                    "Confirm Delete", MessageBoxButtons.YesNo, MessageBoxIcon.Warning);

                if (result == DialogResult.Yes)
                {
                    // In a real application, this would delete from the database
                    dgvServices.Rows.Remove(dgvServices.SelectedRows[0]);
                    MessageBox.Show("Service deleted successfully.",
                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a service to delete.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvServices.SelectedRows.Count > 0)
            {
                string serviceId = dgvServices.SelectedRows[0].Cells["ID"].Value.ToString();
                string serviceName = dgvServices.SelectedRows[0].Cells["Service Name"].Value.ToString();

                // In a real application, this would open a details form
                MessageBox.Show($"Viewing details for service: {serviceName} (ID: {serviceId})\n\n" +
                    $"Category: {dgvServices.SelectedRows[0].Cells["Category"].Value}\n" +
                    $"Price: {dgvServices.SelectedRows[0].Cells["Price"].Value}\n" +
                    $"Availability: {dgvServices.SelectedRows[0].Cells["Availability"].Value}\n" +
                    $"Rating: {dgvServices.SelectedRows[0].Cells["Rating"].Value}",
                    "Service Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a service to view details.",
                    "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}