using System;
using System.Collections.Generic;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class DigitalPassForm : Form
    {
        // Data model for travel passes
        private class TravelPass
        {
            public int ID { get; set; }
            public string Type { get; set; }
            public string Title { get; set; }
            public string BookingReference { get; set; }
            public DateTime IssueDate { get; set; }
            public DateTime ValidUntil { get; set; }
            public string Status => DateTime.Now > ValidUntil ? "Expired" : "Valid";
        }

        // List to store travel passes
        private List<TravelPass> allPasses = new List<TravelPass>();
        private List<TravelPass> filteredPasses = new List<TravelPass>();

        public DigitalPassForm()
        {
            InitializeComponent();
        }

        private void DigitalTravelPassForm_Load(object sender, EventArgs e)
        {
            // Set default filter
            cmbFilterType.SelectedIndex = 0;

            // Load sample data
            LoadSampleData();

            // Apply initial filtering and display
            RefreshPassesDisplay();
        }

        private void LoadSampleData()
        {
            // Sample data for demonstration purposes
            allPasses = new List<TravelPass>
            {
                new TravelPass
                {
                    ID = 1,
                    Type = "Flight Ticket",
                    Title = "New York to Los Angeles",
                    BookingReference = "FL38294",
                    IssueDate = DateTime.Now.AddDays(-20),
                    ValidUntil = DateTime.Now.AddDays(15)
                },
                new TravelPass
                {
                    ID = 2,
                    Type = "Hotel Voucher",
                    Title = "Grand Plaza Hotel",
                    BookingReference = "HT57821",
                    IssueDate = DateTime.Now.AddDays(-15),
                    ValidUntil = DateTime.Now.AddDays(17)
                },
                new TravelPass
                {
                    ID = 3,
                    Type = "Activity Pass",
                    Title = "City Museum Tour",
                    BookingReference = "AC12938",
                    IssueDate = DateTime.Now.AddDays(-10),
                    ValidUntil = DateTime.Now.AddDays(-2)
                },
                new TravelPass
                {
                    ID = 4,
                    Type = "Transportation",
                    Title = "City Metro Pass",
                    BookingReference = "TR67429",
                    IssueDate = DateTime.Now.AddDays(-5),
                    ValidUntil = DateTime.Now.AddDays(3)
                },
                new TravelPass
                {
                    ID = 5,
                    Type = "Flight Ticket",
                    Title = "Los Angeles to Chicago",
                    BookingReference = "FL74292",
                    IssueDate = DateTime.Now.AddDays(-30),
                    ValidUntil = DateTime.Now.AddDays(-5)
                }
            };
        }

        private void RefreshPassesDisplay()
        {
            ApplyFilters();
            UpdateDataGrid();
            UpdateSummaryPanel();
            ResetActionButtons();
        }

        private void ApplyFilters()
        {
            // Get selected filter type
            string filterType = cmbFilterType.SelectedItem.ToString();
            string searchText = txtSearch.Text.Trim().ToLower();

            // Apply filters
            if (filterType == "All Passes")
            {
                filteredPasses = allPasses
                    .Where(p => string.IsNullOrEmpty(searchText) ||
                               p.Title.ToLower().Contains(searchText) ||
                               p.BookingReference.ToLower().Contains(searchText))
                    .ToList();
            }
            else
            {
                filteredPasses = allPasses
                    .Where(p => p.Type == filterType &&
                               (string.IsNullOrEmpty(searchText) ||
                                p.Title.ToLower().Contains(searchText) ||
                                p.BookingReference.ToLower().Contains(searchText)))
                    .ToList();
            }
        }

        private void UpdateDataGrid()
        {
            // Clear existing rows
            dgvPasses.Rows.Clear();

            // Add filtered passes to grid
            foreach (var pass in filteredPasses)
            {
                dgvPasses.Rows.Add(
                    pass.ID,
                    pass.Type,
                    pass.Title,
                    pass.BookingReference,
                    pass.IssueDate.ToShortDateString(),
                    pass.ValidUntil.ToShortDateString(),
                    pass.Status
                );
            }

            // Apply conditional formatting
            ApplyDataGridFormatting();
        }

        private void ApplyDataGridFormatting()
        {
            foreach (DataGridViewRow row in dgvPasses.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status == "Expired")
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(255, 243, 224);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(230, 126, 34);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.FromArgb(229, 243, 255);
                    row.DefaultCellStyle.ForeColor = Color.FromArgb(11, 57, 84);
                }
            }
        }

        private void UpdateSummaryPanel()
        {
            // Update summary labels
            int totalPasses = allPasses.Count;
            int upcomingPasses = allPasses.Count(p => p.Status == "Valid");
            int expiredPasses = allPasses.Count(p => p.Status == "Expired");

            lblTotalPasses.Text = totalPasses.ToString();
            lblUpcomingPasses.Text = upcomingPasses.ToString();
            lblExpiredPasses.Text = expiredPasses.ToString();
        }

        private void ResetActionButtons()
        {
            btnViewDetails.Enabled = false;
            btnDownload.Enabled = false;
            btnShare.Enabled = false;
        }

        #region Event Handlers

        private void cmbFilterType_SelectedIndexChanged(object sender, EventArgs e)
        {
            RefreshPassesDisplay();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            // If Enter key is pressed, perform search
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                RefreshPassesDisplay();
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            RefreshPassesDisplay();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Text = string.Empty;
            cmbFilterType.SelectedIndex = 0;
            RefreshPassesDisplay();
        }

        private void dgvPasses_SelectionChanged(object sender, EventArgs e)
        {
            // Enable action buttons when a row is selected
            bool hasSelection = dgvPasses.SelectedRows.Count > 0;
            btnViewDetails.Enabled = hasSelection;
            btnDownload.Enabled = hasSelection;
            btnShare.Enabled = hasSelection;
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvPasses.SelectedRows.Count > 0)
            {
                int passId = Convert.ToInt32(dgvPasses.SelectedRows[0].Cells["ID"].Value);
                TravelPass selectedPass = filteredPasses.FirstOrDefault(p => p.ID == passId);

                if (selectedPass != null)
                {
                    ShowPassDetails(selectedPass);
                }
            }
        }

        private void ShowPassDetails(TravelPass pass)
        {
            // In a real application, this would open a detailed view form
            MessageBox.Show(
                $"Pass Details:\n\n" +
                $"ID: {pass.ID}\n" +
                $"Type: {pass.Type}\n" +
                $"Title: {pass.Title}\n" +
                $"Booking Reference: {pass.BookingReference}\n" +
                $"Issue Date: {pass.IssueDate.ToShortDateString()}\n" +
                $"Valid Until: {pass.ValidUntil.ToShortDateString()}\n" +
                $"Status: {pass.Status}",
                "Pass Details",
                MessageBoxButtons.OK,
                MessageBoxIcon.Information
            );
        }

        private void btnDownload_Click(object sender, EventArgs e)
        {
            if (dgvPasses.SelectedRows.Count > 0)
            {
                int passId = Convert.ToInt32(dgvPasses.SelectedRows[0].Cells["ID"].Value);
                TravelPass selectedPass = filteredPasses.FirstOrDefault(p => p.ID == passId);

                if (selectedPass != null)
                {
                    // In a real application, this would download or export the pass
                    using (SaveFileDialog saveFileDialog = new SaveFileDialog())
                    {
                        saveFileDialog.Filter = "PDF Files (*.pdf)|*.pdf";
                        saveFileDialog.FileName = $"{selectedPass.Type}_{selectedPass.BookingReference}.pdf";

                        if (saveFileDialog.ShowDialog() == DialogResult.OK)
                        {
                            // Simulate download
                            try
                            {
                                // Create an empty file (in a real app, this would generate the PDF)
                                File.Create(saveFileDialog.FileName).Close();

                                MessageBox.Show(
                                    $"Pass downloaded successfully to:\n{saveFileDialog.FileName}",
                                    "Download Complete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                            }
                            catch (Exception ex)
                            {
                                MessageBox.Show(
                                    $"Failed to download pass: {ex.Message}",
                                    "Download Error",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Error
                                );
                            }
                        }
                    }
                }
            }
        }

        private void btnShare_Click(object sender, EventArgs e)
        {
            if (dgvPasses.SelectedRows.Count > 0)
            {
                int passId = Convert.ToInt32(dgvPasses.SelectedRows[0].Cells["ID"].Value);
                TravelPass selectedPass = filteredPasses.FirstOrDefault(p => p.ID == passId);

                if (selectedPass != null)
                {
                    // In a real application, this would open a sharing dialog
                    using (Form shareForm = new Form())
                    {
                        shareForm.Text = "Share Pass";
                        shareForm.Size = new Size(400, 200);
                        shareForm.StartPosition = FormStartPosition.CenterParent;
                        shareForm.FormBorderStyle = FormBorderStyle.FixedDialog;
                        shareForm.MaximizeBox = false;
                        shareForm.MinimizeBox = false;

                        Label lblEmail = new Label
                        {
                            Text = "Email Address:",
                            Location = new Point(30, 30),
                            Size = new Size(100, 20),
                            AutoSize = true
                        };

                        TextBox txtEmail = new TextBox
                        {
                            Location = new Point(30, 55),
                            Size = new Size(320, 25)
                        };

                        Button btnSend = new Button
                        {
                            Text = "Send",
                            Location = new Point(180, 100),
                            Size = new Size(80, 30),
                            BackColor = Color.FromArgb(40, 120, 180),
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat
                        };
                        btnSend.FlatAppearance.BorderSize = 0;

                        Button btnCancel = new Button
                        {
                            Text = "Cancel",
                            Location = new Point(270, 100),
                            Size = new Size(80, 30),
                            BackColor = Color.Gray,
                            ForeColor = Color.White,
                            FlatStyle = FlatStyle.Flat
                        };
                        btnCancel.FlatAppearance.BorderSize = 0;

                        btnSend.Click += (s, args) =>
                        {
                            if (!string.IsNullOrWhiteSpace(txtEmail.Text))
                            {
                                MessageBox.Show(
                                    $"Travel pass '{selectedPass.Title}' has been shared with {txtEmail.Text}",
                                    "Share Complete",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Information
                                );
                                shareForm.Close();
                            }
                            else
                            {
                                MessageBox.Show(
                                    "Please enter a valid email address.",
                                    "Invalid Email",
                                    MessageBoxButtons.OK,
                                    MessageBoxIcon.Warning
                                );
                            }
                        };

                        btnCancel.Click += (s, args) => shareForm.Close();

                        shareForm.Controls.AddRange(new Control[] { lblEmail, txtEmail, btnSend, btnCancel });
                        shareForm.ShowDialog(this);
                    }
                }
            }
        }

        #endregion
    }
}