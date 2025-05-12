//using System;
//using System.Collections.Generic;
//using System.Data;
//using System.Drawing;
//using System.Windows.Forms;
//using System.IO;

//namespace DB_M2_Chat
//{
//    public partial class UserManagementForm : Form
//    {
//        // Dummy data for demonstration
//        private List<User> userList = new List<User>();

//        public UserManagementForm()
//        {
//            InitializeComponent();

//            // Add some sample data
//            LoadSampleData();
//        }

//        private void UserManagementForm_Load(object sender, EventArgs e)
//        {
//            RefreshUserGrid();
//        }

//        private void LoadSampleData()
//        {
//            userList.Add(new User(1, "John Smith", "Traveler", "john.smith@email.com", "Pending"));
//            userList.Add(new User(2, "Alice Johnson", "Provider", "alice.j@company.com", "Active"));
//            userList.Add(new User(3, "Robert Brown", "Operator", "robert.b@transit.org", "Pending"));
//            userList.Add(new User(4, "Emily Davis", "Traveler", "emily.davis@email.com", "Rejected"));
//            userList.Add(new User(5, "Michael Wilson", "Provider", "michael.w@company.com", "Active"));
//            userList.Add(new User(6, "Sarah Thompson", "Traveler", "sarah.t@email.com", "Inactive"));
//        }

//        private void RefreshUserGrid(string userType = "All Users", string searchText = "")
//        {
//            dgvUsers.Rows.Clear();

//            foreach (var user in userList)
//            {
//                bool typeMatch = userType == "All Users" || user.Type == userType;
//                bool searchMatch = string.IsNullOrEmpty(searchText)
//                    || user.Name.ToLower().Contains(searchText.ToLower())
//                    || user.Email.ToLower().Contains(searchText.ToLower());

//                if (typeMatch && searchMatch)
//                {
//                    dgvUsers.Rows.Add(user.ID, user.Name, user.Type, user.Email, user.Status);

//                    // Apply color coding based on status
//                    int rowIndex = dgvUsers.Rows.Count - 1;
//                    switch (user.Status)
//                    {
//                        case "Active":
//                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Green;
//                            break;
//                        case "Pending":
//                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Orange;
//                            break;
//                        case "Rejected":
//                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Red;
//                            break;
//                        case "Inactive":
//                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Gray;
//                            break;
//                    }
//                }
//            }
//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            string searchText = txtSearch.Text;
//            if (searchText == "Search by name or email...")
//            {
//                searchText = "";
//            }

//            RefreshUserGrid(cmbUserType.Text, searchText);
//        }

//        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            string searchText = txtSearch.Text;
//            if (searchText == "Search by name or email...")
//            {
//                searchText = "";
//            }

//            RefreshUserGrid(cmbUserType.Text, searchText);
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            txtSearch.Text = "Search by name or email...";
//            cmbUserType.SelectedIndex = 0;
//            RefreshUserGrid();
//        }

//        private void btnExport_Click(object sender, EventArgs e)
//        {
//            try
//            {
//                // Create a SaveFileDialog to let the user specify where to save the CSV
//                SaveFileDialog saveDialog = new SaveFileDialog
//                {
//                    Filter = "CSV File (*.csv)|*.csv",
//                    Title = "Export User Data",
//                    FileName = "UserData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
//                };

//                if (saveDialog.ShowDialog() == DialogResult.OK)
//                {
//                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
//                    {
//                        // Write CSV header
//                        sw.WriteLine("ID,Full Name,User Type,Email,Status");

//                        // Export visible users (filtered data)
//                        foreach (DataGridViewRow row in dgvUsers.Rows)
//                        {
//                            if (!row.IsNewRow)
//                            {
//                                string line = $"{row.Cells["ID"].Value}," +
//                                              $"\"{row.Cells["Name"].Value}\"," +
//                                              $"{row.Cells["Type"].Value}," +
//                                              $"{row.Cells["Email"].Value}," +
//                                              $"{row.Cells["Status"].Value}";
//                                sw.WriteLine(line);
//                            }
//                        }
//                    }

//                    MessageBox.Show("Export completed successfully!", "Export",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnApprove_Click(object sender, EventArgs e)
//        {
//            if (dgvUsers.SelectedRows.Count > 0)
//            {
//                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
//                User user = userList.Find(u => u.ID == userId);

//                if (user != null)
//                {
//                    // Only allow approving pending users
//                    if (user.Status == "Pending")
//                    {
//                        user.Status = "Active";
//                        MessageBox.Show($"User '{user.Name}' has been approved!", "Approval",
//                            MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        RefreshUserGrid(cmbUserType.Text);
//                    }
//                    else
//                    {
//                        MessageBox.Show("Only pending users can be approved.", "Cannot Approve",
//                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    }
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a user to approve.", "No Selection",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private void btnReject_Click(object sender, EventArgs e)
//        {
//            if (dgvUsers.SelectedRows.Count > 0)
//            {
//                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
//                User user = userList.Find(u => u.ID == userId);

//                if (user != null && user.Status == "Pending")
//                {
//                    user.Status = "Rejected";
//                    MessageBox.Show($"User '{user.Name}' has been rejected.", "Rejection",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    RefreshUserGrid(cmbUserType.Text);
//                }
//                else
//                {
//                    MessageBox.Show("Only pending users can be rejected.", "Cannot Reject",
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a user to reject.", "No Selection",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }

//        private void btnDeactivate_Click(object sender, EventArgs e)
//        {
//            if (dgvUsers.SelectedRows.Count > 0)
//            {
//                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
//                User user = userList.Find(u => u.ID == userId);

//                if (user != null && user.Status == "Active")
//                {
//                    user.Status = "Inactive";
//                    MessageBox.Show($"User '{user.Name}' has been deactivated.", "Deactivation",
//                        MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    RefreshUserGrid(cmbUserType.Text);
//                }
//                else
//                {
//                    MessageBox.Show("Only active users can be deactivated.", "Cannot Deactivate",
//                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a user to deactivate.", "No Selection",
//                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
//            }
//        }
//    }

//    // Simple User class for demonstration
//    public class User
//    {
//        public int ID { get; set; }
//        public string Name { get; set; }
//        public string Type { get; set; }
//        public string Email { get; set; }
//        public string Status { get; set; }

//        public User(int id, string name, string type, string email, string status)
//        {
//            ID = id;
//            Name = name;
//            Type = type;
//            Email = email;
//            Status = status;
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DB_M2_Chat
{
    public partial class UserManagementForm : Form
    {
        // Database connection string - replace with your actual connection string
        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        public UserManagementForm()
        {
            InitializeComponent();

            // Set initial selection for user type filter
            cmbUserType.SelectedIndex = 0;
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            // Load users data when form loads
            LoadUsers();
        }

        private void LoadUsers()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // SQL query to retrieve users with type-specific information
                    string query = @"
                    SELECT 
                        u.UserID, 
                        u.Username, 
                        u.Email, 
                        u.Type,
                        CASE 
                            WHEN u.Type = 'Traveler' THEN t.Name
                            WHEN u.Type = 'Operator' THEN o.CompanyName
                            WHEN u.Type = 'Provider' THEN p.Organisation
                            ELSE u.Username
                        END AS DisplayName
                    FROM Users u
                    LEFT JOIN Traveler t ON u.UserID = t.TravelerID AND u.Type = 'Traveler'
                    LEFT JOIN TourOperator o ON u.UserID = o.OperatorID AND u.Type = 'Operator'
                    LEFT JOIN ServiceProvider p ON u.UserID = p.ProviderID AND u.Type = 'Provider'";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        dgvUsers.Rows.Clear();
                        //EnsureColumnsExist();  // Add this line before loading rows

                        while (reader.Read())
                        {
                            string userId = reader["UserID"].ToString();
                            string displayName = reader["DisplayName"].ToString();
                            string userType = reader["Type"].ToString();
                            string email = reader["Email"].ToString();

                            // For demonstration, assign random statuses
                            // In a real system, this would be stored in the database
                            string status = GetSampleStatus(userId);

                            dgvUsers.Rows.Add(userId, displayName, userType, email, status);

                            // Apply color coding based on status
                            int rowIndex = dgvUsers.Rows.Count - 1;
                            ApplyStatusColor(dgvUsers.Rows[rowIndex], status);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading users: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        // Sample status assignment (for demonstration)
        private string GetSampleStatus(string userId)
        {
            // In a real implementation, this would be fetched from a database column
            // For now, we'll use a simple algorithm based on UserID
            if (userId.EndsWith("1") || userId.EndsWith("5"))
                return "Pending";
            else if (userId.EndsWith("2") || userId.EndsWith("6"))
                return "Active";
            else if (userId.EndsWith("3") || userId.EndsWith("7"))
                return "Rejected";
            else
                return "Inactive";
        }

        private void ApplyStatusColor(DataGridViewRow row, string status)
        {
            switch (status)
            {
                case "Active":
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                    break;
                case "Pending":
                    row.Cells["Status"].Style.ForeColor = Color.Orange;
                    break;
                case "Rejected":
                    row.Cells["Status"].Style.ForeColor = Color.Red;
                    break;
                case "Inactive":
                    row.Cells["Status"].Style.ForeColor = Color.Gray;
                    break;
            }
        }

        private void RefreshUserGrid(string userType = "All Users", string searchText = "")
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Base query to get users with type-specific information
                    string query = @"
                    SELECT 
                        u.UserID, 
                        u.Username, 
                        u.Email, 
                        u.Type,
                        CASE 
                            WHEN u.Type = 'Traveler' THEN t.Name
                            WHEN u.Type = 'Operator' THEN o.CompanyName
                            WHEN u.Type = 'Provider' THEN p.Organisation
                            ELSE u.Username
                        END AS DisplayName
                    FROM Users u
                    LEFT JOIN Traveler t ON u.UserID = t.TravelerID AND u.Type = 'Traveler'
                    LEFT JOIN TourOperator o ON u.UserID = o.OperatorID AND u.Type = 'Operator'
                    LEFT JOIN ServiceProvider p ON u.UserID = p.ProviderID AND u.Type = 'Provider'
                    WHERE 1=1";

                    // Apply user type filter if not "All Users"
                    if (userType != "All Users")
                    {
                        query += " AND u.Type = @UserType";
                    }

                    // Apply search filter if search text provided
                    if (!string.IsNullOrEmpty(searchText) && searchText != "Search by name or email...")
                    {
                        query += @" AND (
                            u.Username LIKE @SearchText OR 
                            u.Email LIKE @SearchText OR
                            t.Name LIKE @SearchText OR
                            o.CompanyName LIKE @SearchText OR
                            p.Organisation LIKE @SearchText
                        )";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        // Add parameters for filters
                        if (userType != "All Users")
                        {
                            command.Parameters.AddWithValue("@UserType", userType);
                        }

                        if (!string.IsNullOrEmpty(searchText) && searchText != "Search by name or email...")
                        {
                            command.Parameters.AddWithValue("@SearchText", "%" + searchText + "%");
                        }

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            dgvUsers.Rows.Clear();
                            //EnsureColumnsExist();  // Add this line before loading rows

                            while (reader.Read())
                            {
                                string userId = reader["UserID"].ToString();
                                string displayName = reader["DisplayName"].ToString();
                                string type = reader["Type"].ToString();
                                string email = reader["Email"].ToString();

                                // For demonstration, assign sample statuses
                                string status = GetSampleStatus(userId);

                                dgvUsers.Rows.Add(userId, displayName, type, email, status);

                                // Apply color coding based on status
                                int rowIndex = dgvUsers.Rows.Count - 1;
                                ApplyStatusColor(dgvUsers.Rows[rowIndex], status);
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error refreshing users: {ex.Message}", "Database Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (searchText == "Search by name or email...")
            {
                searchText = "";
            }

            RefreshUserGrid(cmbUserType.Text, searchText);
        }

        private void cmbUserType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string searchText = txtSearch.Text;
            if (searchText == "Search by name or email...")
            {
                searchText = "";
            }

            RefreshUserGrid(cmbUserType.Text, searchText);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = "Search by name or email...";
            cmbUserType.SelectedIndex = 0;
            LoadUsers();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                SaveFileDialog saveDialog = new SaveFileDialog
                {
                    Filter = "CSV File (*.csv)|*.csv",
                    Title = "Export User Data",
                    FileName = "UserData_" + DateTime.Now.ToString("yyyyMMdd_HHmmss") + ".csv"
                };

                if (saveDialog.ShowDialog() == DialogResult.OK)
                {
                    using (StreamWriter sw = new StreamWriter(saveDialog.FileName))
                    {
                        // Write CSV header
                        sw.WriteLine("ID,Full Name,User Type,Email,Status");

                        // Export visible users (filtered data)
                        foreach (DataGridViewRow row in dgvUsers.Rows)
                        {
                            if (!row.IsNewRow)
                            {
                                string line = $"{row.Cells["ID"].Value}," + // changed id to userid
                                              $"\"{row.Cells["FullName"].Value}\"," +
                                              $"{row.Cells["Type"].Value}," +
                                              $"{row.Cells["Email"].Value}," +
                                              $"{row.Cells["Status"].Value}";
                                sw.WriteLine(line);
                            }
                        }
                    }

                    MessageBox.Show("Export completed successfully!", "Export",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error exporting data: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string userId = dgvUsers.SelectedRows[0].Cells["ID"].Value.ToString();  /////changed id to userid
                string currentStatus = dgvUsers.SelectedRows[0].Cells["Status"].Value.ToString();
                string name = dgvUsers.SelectedRows[0].Cells["FullName"].Value.ToString();

                // Only allow approving pending users
                if (currentStatus == "Pending")
                {
                    // In a real implementation, update the status column in the database
                    // For now, just update the UI
                    dgvUsers.SelectedRows[0].Cells["Status"].Value = "Active";
                    dgvUsers.SelectedRows[0].Cells["Status"].Style.ForeColor = Color.Green;

                    MessageBox.Show($"User '{name}' has been approved!", "Approval",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Only pending users can be approved.", "Cannot Approve",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to approve.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string userId = dgvUsers.SelectedRows[0].Cells["ID"].Value.ToString(); ///changed id to userid
                string currentStatus = dgvUsers.SelectedRows[0].Cells["Status"].Value.ToString();
                string name = dgvUsers.SelectedRows[0].Cells["FullName"].Value.ToString();

                // Only allow rejecting pending users
                if (currentStatus == "Pending")
                {
                    // In a real implementation, update the status column in the database
                    // For now, just update the UI
                    dgvUsers.SelectedRows[0].Cells["Status"].Value = "Rejected";
                    dgvUsers.SelectedRows[0].Cells["Status"].Style.ForeColor = Color.Red;

                    MessageBox.Show($"User '{name}' has been rejected.", "Rejection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Only pending users can be rejected.", "Cannot Reject",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to reject.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeactivate_Click(object sender, EventArgs e)
        {
            if (dgvUsers.SelectedRows.Count > 0)
            {
                string userId = dgvUsers.SelectedRows[0].Cells["ID"].Value.ToString();  /////////changed id to userid
                string currentStatus = dgvUsers.SelectedRows[0].Cells["Status"].Value.ToString();
                string name = dgvUsers.SelectedRows[0].Cells["FullName"].Value.ToString();

                // Only allow deactivating active users
                if (currentStatus == "Active")
                {
                    // In a real implementation, update the status column in the database
                    // For now, just update the UI
                    dgvUsers.SelectedRows[0].Cells["Status"].Value = "Inactive";
                    dgvUsers.SelectedRows[0].Cells["Status"].Style.ForeColor = Color.Gray;

                    MessageBox.Show($"User '{name}' has been deactivated.", "Deactivation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                else
                {
                    MessageBox.Show("Only active users can be deactivated.", "Cannot Deactivate",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
            else
            {
                MessageBox.Show("Please select a user to deactivate.", "No Selection",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        //private void EnsureColumnsExist()
        //{
        //    if (dgvUsers.Columns.Count == 0)
        //    {
        //        dgvUsers.Columns.Add("ID", "User ID");
        //        dgvUsers.Columns.Add("DisplayName", "Name");
        //        dgvUsers.Columns.Add("Type", "User Type");
        //        dgvUsers.Columns.Add("Email", "Email");
        //        dgvUsers.Columns.Add("Status", "Status");
        //    }
        //}
    }
}
