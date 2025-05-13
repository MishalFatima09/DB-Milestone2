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
    public partial class TravelerReviewsForm : Form
    {
        public TravelerReviewsForm()
        {
            InitializeComponent();
        }

        private void TravelerReviewsForm_Load(object sender, EventArgs e)
        {
            // Load sample data for demonstration
            PopulateReviewHistory();

            // Initialize rating combobox
            cmbRating.Items.AddRange(new string[] { "5 - Excellent", "4 - Very Good", "3 - Good", "2 - Fair", "1 - Poor" });
            cmbRating.SelectedIndex = 0;

            // Initialize service type combobox
            cmbServiceType.Items.AddRange(new string[] { "Hotel", "Tour", "Transport", "Restaurant", "Activity" });
            cmbServiceType.SelectedIndex = 0;
        }

        private void PopulateReviewHistory()
        {
            // Clear existing items
            dgvReviewHistory.Rows.Clear();

            // Add sample data
            dgvReviewHistory.Rows.Add("RV001", "Luxury Resort & Spa", "Hotel", "5 - Excellent", "05/01/2025", "Amazing stay with excellent service!");
            dgvReviewHistory.Rows.Add("RV002", "City Sightseeing Tour", "Tour", "4 - Very Good", "04/15/2025", "Great tour, knowledgeable guide, but a bit rushed.");
            dgvReviewHistory.Rows.Add("RV003", "Premium Airport Transfer", "Transport", "5 - Excellent", "04/10/2025", "On time, comfortable and professional driver.");
            dgvReviewHistory.Rows.Add("RV004", "Oceanside Restaurant", "Restaurant", "3 - Good", "03/22/2025", "Food was good but service was slow.");
            dgvReviewHistory.Rows.Add("RV005", "Scuba Diving Experience", "Activity", "4 - Very Good", "03/15/2025", "Great experience, would recommend to others!");
        }

        private void btnSubmitReview_Click(object sender, EventArgs e)
        {
            if (string.IsNullOrWhiteSpace(txtServiceName.Text) || string.IsNullOrWhiteSpace(txtReviewText.Text))
            {
                MessageBox.Show("Please enter service name and review text.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // Generate a review ID (in a real app, this would come from the database)
            string reviewId = "RV" + (dgvReviewHistory.Rows.Count + 1).ToString("000");

            // Add to grid
            dgvReviewHistory.Rows.Add(
                reviewId,
                txtServiceName.Text,
                cmbServiceType.Text,
                cmbRating.Text,
                DateTime.Now.ToString("MM/dd/yyyy"),
                txtReviewText.Text
            );

            // Clear inputs
            txtServiceName.Text = "";
            txtReviewText.Text = "";
            cmbRating.SelectedIndex = 0;
            cmbServiceType.SelectedIndex = 0;

            MessageBox.Show("Thank you! Your review has been submitted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnEditReview_Click(object sender, EventArgs e)
        {
            if (dgvReviewHistory.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvReviewHistory.SelectedRows[0];

                // Populate form fields with selected review data
                txtServiceName.Text = row.Cells["ServiceName"].Value.ToString();
                txtReviewText.Text = row.Cells["ReviewText"].Value.ToString();

                // Select the matching items in comboboxes
                string rating = row.Cells["Rating"].Value.ToString();
                string serviceType = row.Cells["ServiceType"].Value.ToString();

                for (int i = 0; i < cmbRating.Items.Count; i++)
                {
                    if (cmbRating.Items[i].ToString() == rating)
                    {
                        cmbRating.SelectedIndex = i;
                        break;
                    }
                }

                for (int i = 0; i < cmbServiceType.Items.Count; i++)
                {
                    if (cmbServiceType.Items[i].ToString() == serviceType)
                    {
                        cmbServiceType.SelectedIndex = i;
                        break;
                    }
                }

                // Change button text to indicate update mode
                btnSubmitReview.Text = "Update Review";
                lblNewReview.Text = "Edit Review";

                // Store the review ID for update reference
                btnSubmitReview.Tag = row.Cells["ReviewID"].Value.ToString();
            }
            else
            {
                MessageBox.Show("Please select a review to edit.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDeleteReview_Click(object sender, EventArgs e)
        {
            if (dgvReviewHistory.SelectedRows.Count > 0)
            {
                if (MessageBox.Show("Are you sure you want to delete this review?", "Confirm Delete",
                    MessageBoxButtons.YesNo, MessageBoxIcon.Question) == DialogResult.Yes)
                {
                    dgvReviewHistory.Rows.Remove(dgvReviewHistory.SelectedRows[0]);
                    MessageBox.Show("Review deleted successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            else
            {
                MessageBox.Show("Please select a review to delete.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnClear_Click(object sender, EventArgs e)
        {
            // Reset the form to add mode
            txtServiceName.Text = "";
            txtReviewText.Text = "";
            cmbRating.SelectedIndex = 0;
            cmbServiceType.SelectedIndex = 0;
            btnSubmitReview.Text = "Submit Review";
            lblNewReview.Text = "Write a New Review";
            btnSubmitReview.Tag = null;
        }

        private void btnFilter_Click(object sender, EventArgs e)
        {
            string filterText = txtFilter.Text.Trim().ToLower();
            string filterType = cmbFilterType.Text;

            if (string.IsNullOrEmpty(filterText) && filterType == "All Types")
            {
                // Reset all rows to visible
                foreach (DataGridViewRow row in dgvReviewHistory.Rows)
                {
                    row.Visible = true;
                }
                return;
            }

            foreach (DataGridViewRow row in dgvReviewHistory.Rows)
            {
                bool matchFound = false;

                // Check for type filter first
                if (filterType != "All Types")
                {
                    if (row.Cells["ServiceType"].Value.ToString() != filterType)
                    {
                        row.Visible = false;
                        continue;
                    }
                }

                // Then check text filter if supplied
                if (!string.IsNullOrEmpty(filterText))
                {
                    foreach (DataGridViewCell cell in row.Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(filterText))
                        {
                            matchFound = true;
                            break;
                        }
                    }
                    row.Visible = matchFound;
                }
                else
                {
                    row.Visible = true;
                }
            }
        }

        private void btnResetFilter_Click(object sender, EventArgs e)
        {
            txtFilter.Text = "";
            cmbFilterType.SelectedIndex = 0;

            // Reset all rows to visible
            foreach (DataGridViewRow row in dgvReviewHistory.Rows)
            {
                row.Visible = true;
            }
        }
    }
}