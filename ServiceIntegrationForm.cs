//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DB_M2_Chat
//{
//    public partial class ServiceIntegrationForm : Form
//    {
//        public ServiceIntegrationForm()
//        {
//            InitializeComponent();
//        }

//        private void ServiceIntegrationForm_Load(object sender, EventArgs e)
//        {
//            Example data for demonstration
//            In a real application, this would be loaded from a database

//           PopulateServiceRequests();
//        }

//        private void PopulateServiceRequests()
//        {
//            Clear existing items
//            dgvServiceRequests.Rows.Clear();

//            Add sample data
//            dgvServiceRequests.Rows.Add("SR001", "City Tour Package", "Assign new tour guide", "05/10/2025", "Pending");
//            dgvServiceRequests.Rows.Add("SR002", "Airport Transfer", "Add vehicle for VIP client", "05/09/2025", "Pending");
//            dgvServiceRequests.Rows.Add("SR003", "Hotel Luxury Suite", "Room upgrade request", "05/08/2025", "Pending");
//        }

//        private void btnAccept_Click(object sender, EventArgs e)
//        {
//            if (dgvServiceRequests.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
//                row.Cells["Status"].Value = "Accepted";
//                MessageBox.Show("Service request accepted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnReject_Click(object sender, EventArgs e)
//        {
//            if (dgvServiceRequests.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
//                row.Cells["Status"].Value = "Rejected";
//                MessageBox.Show("Service request rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnDetails_Click(object sender, EventArgs e)
//        {
//            if (dgvServiceRequests.SelectedRows.Count > 0)
//            {
//                In a real application, this would open a details dialog
//                For now, we'll just show a message
//                MessageBox.Show("Service request details would open here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }
//    }
//}


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
using TravelEase;

namespace DB_M2_Chat
{
    public partial class ServiceIntegrationForm : Form
    {
        // Connection string
      //  private readonly string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        public ServiceIntegrationForm()
        {
            InitializeComponent();
        }

        private void ServiceIntegrationForm_Load(object sender, EventArgs e)
        {
            // Check if user is logged in
            if (!UserSession.Instance.IsLoggedIn())
            {
                MessageBox.Show("You must be logged in to view service assignments.", "Not Logged In", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                this.Close();
                return;
            }

            // Update the title with provider name if available
            if (!string.IsNullOrEmpty(UserSession.Instance.ProviderName))
            {
                lblTitle.Text = $"📨 Service Integration - {UserSession.Instance.ProviderName}";
            }

            // Load real data from database
            LoadAssignedServices();
        }

        private void LoadAssignedServices()
        {
            try
            {
                // Clear existing items
                dgvServiceRequests.Rows.Clear();

                // Get provider ID from session
                string providerID = UserSession.Instance.ProviderID;

                if (string.IsNullOrEmpty(providerID))
                {
                    MessageBox.Show("Provider ID not found. Please log in again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    return;
                }

                // SQL query to fetch assigned services for the logged-in provider
                string query = @"
                    SELECT 
                        a.AssignmentID, 
                        s.Name AS ServiceName,
                        b.BookingID,
                        a.Status,
                        a.ScheduledDeparture,
                        a.ScheduledArrival,
                        CASE 
                            WHEN s.Type = 'Guide' THEN 'Guide Service' 
                            WHEN s.Type = 'Hotel' THEN 'Accommodation'
                            WHEN s.Type = 'Transport' THEN 'Transportation'
                            ELSE 'Other'
                        END AS ServiceDescription
                    FROM AssignedService a
                    JOIN Service s ON a.ServiceID = s.ServiceID
                    JOIN Booking b ON a.BookingID = b.BookingID
                    WHERE s.ProviderID = @ProviderID
                    ORDER BY 
                        CASE WHEN a.Status = 'Pending' THEN 0
                             WHEN a.Status = 'Confirmed' THEN 1
                             WHEN a.Status = 'Cancelled' THEN 2
                        END,
                        a.ScheduledDeparture";

                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))

                {
                    connection.Open();

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ProviderID", providerID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string assignmentID = reader["AssignmentID"].ToString();
                                string serviceName = reader["ServiceName"].ToString();
                                string serviceDesc = reader["ServiceDescription"].ToString();

                                // Format the date if available
                                string scheduledDate = reader["ScheduledDeparture"] != DBNull.Value
                                    ? Convert.ToDateTime(reader["ScheduledDeparture"]).ToString("MM/dd/yyyy")
                                    : "Not specified";

                                string status = reader["Status"].ToString();

                                // Add row with color coding based on status
                                DataGridViewRow row = new DataGridViewRow();
                                row.CreateCells(dgvServiceRequests, assignmentID, serviceName, serviceDesc, scheduledDate, status);

                                // Color code rows based on status
                                if (status == "Confirmed")
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(209, 240, 209); // Light green
                                }
                                else if (status == "Cancelled")
                                {
                                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 213, 213); // Light red
                                }

                                dgvServiceRequests.Rows.Add(row);
                            }
                        }
                    }
                }

                // Update status counts
                UpdateStatusCounts();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading data: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateStatusCounts()
        {
            int pendingCount = 0;
            int confirmedCount = 0;
            int cancelledCount = 0;

            foreach (DataGridViewRow row in dgvServiceRequests.Rows)
            {
                string status = row.Cells["Status"].Value?.ToString();

                if (status == "Pending")
                    pendingCount++;
                else if (status == "Confirmed")
                    confirmedCount++;
                else if (status == "Cancelled")
                    cancelledCount++;
            }

            lblDescription.Text = $"Assignments: {pendingCount} pending, {confirmedCount} confirmed, {cancelledCount} cancelled";
        }

        private void btnAccept_Click(object sender, EventArgs e)
        {
            if (dgvServiceRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
                string assignmentID = row.Cells["ID"].Value.ToString();

                // Check if already confirmed or cancelled
                string status = row.Cells["Status"].Value.ToString();
                if (status == "Confirmed")
                {
                    MessageBox.Show("This service is already confirmed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }
                else if (status == "Cancelled")
                {
                    MessageBox.Show("This service was cancelled and cannot be accepted.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Update the database
                if (UpdateServiceStatus(assignmentID, "Confirmed"))
                {
                    row.Cells["Status"].Value = "Confirmed";
                    row.DefaultCellStyle.BackColor = Color.FromArgb(209, 240, 209); // Light green
                    MessageBox.Show("Service request accepted successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    UpdateStatusCounts();
                }
                else
                {
                    MessageBox.Show("Failed to accept service request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
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
                string assignmentID = row.Cells["ID"].Value.ToString();

                // Check if already confirmed or cancelled
                string status = row.Cells["Status"].Value.ToString();
                if (status == "Cancelled")
                {
                    MessageBox.Show("This service is already cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    return;
                }

                // Ask for confirmation
                DialogResult result = MessageBox.Show(
                    "Are you sure you want to reject this service request?",
                    "Confirm Rejection",
                    MessageBoxButtons.YesNo,
                    MessageBoxIcon.Question);

                if (result == DialogResult.Yes)
                {
                    // Update the database
                    if (UpdateServiceStatus(assignmentID, "Cancelled"))
                    {
                        row.Cells["Status"].Value = "Cancelled";
                        row.DefaultCellStyle.BackColor = Color.FromArgb(255, 213, 213); // Light red
                        MessageBox.Show("Service request rejected.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        UpdateStatusCounts();
                    }
                    else
                    {
                        MessageBox.Show("Failed to reject service request. Please try again.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private bool UpdateServiceStatus(string assignmentID, string newStatus)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))

                {
                    connection.Open();

                    string query = "UPDATE AssignedService SET Status = @Status WHERE AssignmentID = @AssignmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Status", newStatus);
                        command.Parameters.AddWithValue("@AssignmentID", assignmentID);

                        int rowsAffected = command.ExecuteNonQuery();
                        return rowsAffected > 0;
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Database error: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return false;
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvServiceRequests.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvServiceRequests.SelectedRows[0];
                string assignmentID = row.Cells["ID"].Value.ToString();

                // Get detailed information about the assignment
                ShowAssignmentDetails(assignmentID);
            }
            else
            {
                MessageBox.Show("Please select a service request.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void ShowAssignmentDetails(string assignmentID)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))

                {
                    connection.Open();

                    string query = @"
                        SELECT 
                            a.AssignmentID,
                            a.Status,
                            a.ScheduledDeparture,
                            a.ActualDeparture,
                            a.ScheduledArrival,
                            a.ActualArrival,
                            s.ServiceID,
                            s.Name AS ServiceName,
                            s.Type AS ServiceType,
                            b.BookingID,
                            u.Username AS TravelerUsername
                        FROM AssignedService a
                        JOIN Service s ON a.ServiceID = s.ServiceID
                        JOIN Booking b ON a.BookingID = b.BookingID
                        JOIN Users u ON b.TravelerID = u.UserID
                        WHERE a.AssignmentID = @AssignmentID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@AssignmentID", assignmentID);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                // Build detailed information string
                                StringBuilder details = new StringBuilder();
                                details.AppendLine($"Assignment ID: {reader["AssignmentID"]}");
                                details.AppendLine($"Status: {reader["Status"]}");
                                details.AppendLine($"Service: {reader["ServiceName"]} ({reader["ServiceType"]})");
                                details.AppendLine($"Booking ID: {reader["BookingID"]}");
                                details.AppendLine($"Traveler: {reader["TravelerUsername"]}");
                                details.AppendLine();

                                // Add schedule information
                                details.AppendLine("Schedule Information:");

                                if (reader["ScheduledDeparture"] != DBNull.Value)
                                    details.AppendLine($"Scheduled Departure: {Convert.ToDateTime(reader["ScheduledDeparture"]):MM/dd/yyyy hh:mm tt}");
                                else
                                    details.AppendLine("Scheduled Departure: Not specified");

                                if (reader["ActualDeparture"] != DBNull.Value)
                                    details.AppendLine($"Actual Departure: {Convert.ToDateTime(reader["ActualDeparture"]):MM/dd/yyyy hh:mm tt}");

                                if (reader["ScheduledArrival"] != DBNull.Value)
                                    details.AppendLine($"Scheduled Arrival: {Convert.ToDateTime(reader["ScheduledArrival"]):MM/dd/yyyy hh:mm tt}");
                                else
                                    details.AppendLine("Scheduled Arrival: Not specified");

                                if (reader["ActualArrival"] != DBNull.Value)
                                    details.AppendLine($"Actual Arrival: {Convert.ToDateTime(reader["ActualArrival"]):MM/dd/yyyy hh:mm tt}");

                                // Show details in message box
                                MessageBox.Show(details.ToString(), "Assignment Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                            else
                            {
                                MessageBox.Show("Assignment details not found.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error retrieving assignment details: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
