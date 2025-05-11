using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    public partial class ServiceIntegrationForm : Form
    {
        public ServiceIntegrationForm()
        {
            InitializeComponent();
        }

        private void ServiceIntegrationForm_Load(object sender, EventArgs e)
        {
            // Example data for demonstration
            // In a real application, this would be loaded from a database
            PopulateServiceRequests();
        }

        private void PopulateServiceRequests()
        {
            // Clear existing items
            dgvServiceRequests.Rows.Clear();

            // Add sample data
            dgvServiceRequests.Rows.Add("SR001", "City Tour Package", "Assign new tour guide", "05/10/2025", "Pending");
            dgvServiceRequests.Rows.Add("SR002", "Airport Transfer", "Add vehicle for VIP client", "05/09/2025", "Pending");
            dgvServiceRequests.Rows.Add("SR003", "Hotel Luxury Suite", "Room upgrade request", "05/08/2025", "Pending");
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvServiceRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
                row.Cells["Status"].Value = "Accepted";
                MessageBox.Show("Service request accepted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvServiceRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
                row.Cells["Status"].Value = "Rejected";
                MessageBox.Show("Service request rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvServiceRequests.SelectedRows.Count > 0)
            {
                // In a real application, this would open a details dialog
                // For now, we'll just show a message
                MessageBox.Show("Service request details would open here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }
}
