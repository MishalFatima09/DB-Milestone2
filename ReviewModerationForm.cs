using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class ReviewModerationForm : Form
    {
        public ReviewModerationForm()
        {
            InitializeComponent();
        }

        private void ReviewModerationForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            LoadReviews();
        }

        private void LoadReviews()
        {
            // Clear existing data
            dgvReviews.Rows.Clear();

            // In a real application, you would fetch this data from a database
            // For now, let's add sample data
            string filterStatus = cmbFilterStatus.SelectedItem.ToString();
            string searchText = txtSearch.Text.ToLower();

            // Sample data - would come from database in real implementation
            if (filterStatus == "All Reviews" || filterStatus == "Pending Review")
            {
                AddReviewRow(1, "Bali Beach Resort", "JohnDoe123", 4, "Beautiful resort with amazing views! The staff was very friendly and helpful.", "2023-05-10", "Pending");
                AddReviewRow(2, "Tokyo City Tour", "TravelFan22", 5, "Incredible experience exploring Tokyo! Our guide was knowledgeable and fun.", "2023-05-11", "Pending");
                AddReviewRow(3, "Paris Food Tour", "FoodLover", 3, "Decent food but the tour felt rushed. Would have liked more time at each stop.", "2023-05-12", "Pending");
            }

            if (filterStatus == "All Reviews" || filterStatus == "Flagged")
            {
                AddReviewRow(4, "Adventure Sports Package", "Mountain_Climber", 2, "The equipment provided was old and potentially dangerous. I wouldn't recommend this to anyone!", "2023-05-09", "Flagged");
                AddReviewRow(5, "NYC Night Tour", "NightOwl", 1, "Terrible experience. Guide was rude and used inappropriate language. [Profanity removed]", "2023-05-08", "Flagged");
            }

            if (filterStatus == "All Reviews" || filterStatus == "Approved")
            {
                AddReviewRow(6, "Greek Island Hopping", "SunSeeker", 5, "Absolutely fantastic trip! Every island was unique and beautiful.", "2023-05-07", "Approved");
                AddReviewRow(7, "Rome Historical Tour", "HistoryBuff", 4, "Very informative and well-organized tour of ancient Rome sites.", "2023-05-06", "Approved");
            }

            if (filterStatus == "All Reviews" || filterStatus == "Rejected")
            {
                AddReviewRow(8, "Safari Adventure", "WildlifeWatcher", 1, "[Content removed due to policy violation]", "2023-05-05", "Rejected");
                AddReviewRow(9, "Mountain Resort Stay", "SkiEnthusiast", 2, "[Spam content removed]", "2023-05-04", "Rejected");
            }

            // Apply search filter if text is entered
            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = dgvReviews.Rows.Count - 1; i >= 0; i--)
                {
                    bool match = false;
                    for (int j = 0; j < dgvReviews.Columns.Count; j++)
                    {
                        if (dgvReviews.Rows[i].Cells[j].Value != null &&
                            dgvReviews.Rows[i].Cells[j].Value.ToString().ToLower().Contains(searchText))
                        {
                            match = true;
                            break;
                        }
                    }
                    if (!match)
                    {
                        dgvReviews.Rows.RemoveAt(i);
                    }
                }
            }

            UpdateStatusCounts();
        }

        private void AddReviewRow(int id, string tour, string user, int rating, string content, string date, string status)
        {
            int rowIndex = dgvReviews.Rows.Add(id, tour, user, rating, content, date, status);

            // Color-code the status column
            DataGridViewCell cell = dgvReviews.Rows[rowIndex].Cells["Status"];
            switch (status)
            {
                case "Approved":
                    cell.Style.ForeColor = Color.Green;
                    break;
                case "Rejected":
                    cell.Style.ForeColor = Color.Red;
                    break;
                case "Flagged":
                    cell.Style.ForeColor = Color.Orange;
                    cell.Style.Font = new Font(dgvReviews.Font, FontStyle.Bold);
                    break;
                case "Pending":
                    cell.Style.ForeColor = Color.Blue;
                    break;
            }
        }

        private void UpdateStatusCounts()
        {
            int totalReviews = dgvReviews.Rows.Count;
            lblTotalReviews.Text = totalReviews.ToString();

            int flaggedCount = 0;
            int pendingCount = 0;

            foreach (DataGridViewRow row in dgvReviews.Rows)
            {
                string status = row.Cells["Status"].Value.ToString();
                if (status == "Flagged")
                    flaggedCount++;
                else if (status == "Pending")
                    pendingCount++;
            }

            lblFlaggedReviews.Text = flaggedCount.ToString();
            lblPendingReviews.Text = pendingCount.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void txtSearch_KeyPress(object sender, KeyPressEventArgs e)
        {
            if (e.KeyChar == (char)Keys.Enter)
            {
                e.Handled = true;
                btnSearch_Click(sender, e);
            }
        }

        private void cmbFilterStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadReviews();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterStatus.SelectedIndex = 0;
            LoadReviews();
        }

        private void dgvReviews_SelectionChanged(object sender, EventArgs e)
        {
            bool rowSelected = dgvReviews.SelectedRows.Count > 0;
            btnApprove.Enabled = rowSelected;
            btnReject.Enabled = rowSelected;
            btnViewDetails.Enabled = rowSelected;
        }

        private void btnApprove_Click(object sender, EventArgs e)
        {
            if (dgvReviews.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvReviews.SelectedRows[0];
                string currentStatus = row.Cells["Status"].Value.ToString();

                // Only allow approving reviews that are Pending or Flagged
                if (currentStatus == "Pending" || currentStatus == "Flagged")
                {
                    row.Cells["Status"].Value = "Approved";
                    row.Cells["Status"].Style.ForeColor = Color.Green;
                    row.Cells["Status"].Style.Font = new Font(dgvReviews.Font, FontStyle.Regular);

                    MessageBox.Show("Review has been approved and published.", "Review Approved",
                        MessageBoxButtons.OK, MessageBoxIcon.Information);

                    UpdateStatusCounts();
                }
                else
                {
                    MessageBox.Show("Only pending or flagged reviews can be approved.", "Action Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnReject_Click(object sender, EventArgs e)
        {
            if (dgvReviews.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvReviews.SelectedRows[0];
                string currentStatus = row.Cells["Status"].Value.ToString();

                // Only allow rejecting reviews that are Pending or Flagged
                if (currentStatus == "Pending" || currentStatus == "Flagged")
                {
                    using (var reasonForm = new RejectReasonForm())
                    {
                        if (reasonForm.ShowDialog() == DialogResult.OK)
                        {
                            row.Cells["Status"].Value = "Rejected";
                            row.Cells["Status"].Style.ForeColor = Color.Red;
                            row.Cells["Status"].Style.Font = new Font(dgvReviews.Font, FontStyle.Regular);
                            row.Cells["Content"].Value = "[Content removed due to policy violation]";

                            MessageBox.Show("Review has been rejected and will not be published.", "Review Rejected",
                                MessageBoxButtons.OK, MessageBoxIcon.Information);

                            UpdateStatusCounts();
                        }
                    }
                }
                else
                {
                    MessageBox.Show("Only pending or flagged reviews can be rejected.", "Action Not Allowed",
                        MessageBoxButtons.OK, MessageBoxIcon.Warning);
                }
            }
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvReviews.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvReviews.SelectedRows[0];
                int reviewId = Convert.ToInt32(row.Cells["ID"].Value);
                string tour = row.Cells["Tour"].Value.ToString();
                string user = row.Cells["User"].Value.ToString();
                string content = row.Cells["Content"].Value.ToString();
                string date = row.Cells["Date"].Value.ToString();
                int rating = Convert.ToInt32(row.Cells["Rating"].Value);

                MessageBox.Show(
                    $"Review ID: {reviewId}\n" +
                    $"Tour: {tour}\n" +
                    $"User: {user}\n" +
                    $"Rating: {rating} / 5\n" +
                    $"Date: {date}\n\n" +
                    $"Content:\n{content}",
                    "Review Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information
                );
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx",
                Title = "Export Reviews"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Reviews exported to {saveDialog.FileName} successfully!", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }
    }

    // Helper form for collecting rejection reason
    public class RejectReasonForm : Form
    {
        private TextBox txtReason;
        private Button btnSubmit;
        private Button btnCancel;
        private Label lblInstruction;

        public string ReasonText => txtReason.Text;

        public RejectReasonForm()
        {
            this.Text = "Rejection Reason";
            this.Width = 400;
            this.Height = 240;
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.BackColor = Color.FromArgb(191, 215, 234);

            lblInstruction = new Label
            {
                Text = "Please provide a reason for rejecting this review:",
                Location = new Point(20, 20),
                Size = new Size(350, 20),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            txtReason = new TextBox
            {
                Multiline = true,
                Location = new Point(20, 50),
                Size = new Size(345, 100),
                Font = new Font("Segoe UI", 9, FontStyle.Regular)
            };

            btnSubmit = new Button
            {
                Text = "Submit",
                Location = new Point(185, 160),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(46, 139, 87),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.OK
            };
            btnSubmit.FlatAppearance.BorderSize = 0;

            btnCancel = new Button
            {
                Text = "Cancel",
                Location = new Point(285, 160),
                Size = new Size(80, 30),
                BackColor = Color.FromArgb(220, 53, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                DialogResult = DialogResult.Cancel
            };
            btnCancel.FlatAppearance.BorderSize = 0;

            this.Controls.Add(lblInstruction);
            this.Controls.Add(txtReason);
            this.Controls.Add(btnSubmit);
            this.Controls.Add(btnCancel);

            this.AcceptButton = btnSubmit;
            this.CancelButton = btnCancel;
        }
    }
}