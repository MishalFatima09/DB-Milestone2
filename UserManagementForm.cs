using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.IO;

namespace DB_M2_Chat
{
    public partial class UserManagementForm : Form
    {
        // Dummy data for demonstration
        private List<User> userList = new List<User>();

        public UserManagementForm()
        {
            InitializeComponent();

            // Add some sample data
            LoadSampleData();
        }

        private void UserManagementForm_Load(object sender, EventArgs e)
        {
            RefreshUserGrid();
        }

        private void LoadSampleData()
        {
            userList.Add(new User(1, "John Smith", "Traveler", "john.smith@email.com", "Pending"));
            userList.Add(new User(2, "Alice Johnson", "Provider", "alice.j@company.com", "Active"));
            userList.Add(new User(3, "Robert Brown", "Operator", "robert.b@transit.org", "Pending"));
            userList.Add(new User(4, "Emily Davis", "Traveler", "emily.davis@email.com", "Rejected"));
            userList.Add(new User(5, "Michael Wilson", "Provider", "michael.w@company.com", "Active"));
            userList.Add(new User(6, "Sarah Thompson", "Traveler", "sarah.t@email.com", "Inactive"));
        }

        private void RefreshUserGrid(string userType = "All Users", string searchText = "")
        {
            dgvUsers.Rows.Clear();

            foreach (var user in userList)
            {
                bool typeMatch = userType == "All Users" || user.Type == userType;
                bool searchMatch = string.IsNullOrEmpty(searchText)
                    || user.Name.ToLower().Contains(searchText.ToLower())
                    || user.Email.ToLower().Contains(searchText.ToLower());

                if (typeMatch && searchMatch)
                {
                    dgvUsers.Rows.Add(user.ID, user.Name, user.Type, user.Email, user.Status);

                    // Apply color coding based on status
                    int rowIndex = dgvUsers.Rows.Count - 1;
                    switch (user.Status)
                    {
                        case "Active":
                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Green;
                            break;
                        case "Pending":
                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Orange;
                            break;
                        case "Rejected":
                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Red;
                            break;
                        case "Inactive":
                            dgvUsers.Rows[rowIndex].Cells["Status"].Style.ForeColor = Color.Gray;
                            break;
                    }
                }
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
            RefreshUserGrid();
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            try
            {
                // Create a SaveFileDialog to let the user specify where to save the CSV
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
                                string line = $"{row.Cells["ID"].Value}," +
                                              $"\"{row.Cells["Name"].Value}\"," +
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
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
                User user = userList.Find(u => u.ID == userId);

                if (user != null)
                {
                    // Only allow approving pending users
                    if (user.Status == "Pending")
                    {
                        user.Status = "Active";
                        MessageBox.Show($"User '{user.Name}' has been approved!", "Approval",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                        RefreshUserGrid(cmbUserType.Text);
                    }
                    else
                    {
                        MessageBox.Show("Only pending users can be approved.", "Cannot Approve",
                            MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    }
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
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
                User user = userList.Find(u => u.ID == userId);

                if (user != null && user.Status == "Pending")
                {
                    user.Status = "Rejected";
                    MessageBox.Show($"User '{user.Name}' has been rejected.", "Rejection",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserGrid(cmbUserType.Text);
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
                int userId = Convert.ToInt32(dgvUsers.SelectedRows[0].Cells["ID"].Value);
                User user = userList.Find(u => u.ID == userId);

                if (user != null && user.Status == "Active")
                {
                    user.Status = "Inactive";
                    MessageBox.Show($"User '{user.Name}' has been deactivated.", "Deactivation",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);
                    RefreshUserGrid(cmbUserType.Text);
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
    }

    // Simple User class for demonstration
    public class User
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public string Email { get; set; }
        public string Status { get; set; }

        public User(int id, string name, string type, string email, string status)
        {
            ID = id;
            Name = name;
            Type = type;
            Email = email;
            Status = status;
        }
    }
}