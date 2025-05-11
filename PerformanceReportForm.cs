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
    public partial class PerformanceReportForm : Form
    {
        public PerformanceReportForm()
        {
            InitializeComponent();
        }

        private void PerformanceReportForm_Load(object sender, EventArgs e)
        {
            // Load data for all report sections
            LoadOccupancyData();
            LoadRevenueData();
            LoadReviewsData();
        }

        private void LoadOccupancyData()
        {
            // Clear existing items
            dgvOccupancy.Rows.Clear();

            // Add sample data
            dgvOccupancy.Rows.Add("January", "75%", "62%", "+13%");
            dgvOccupancy.Rows.Add("February", "82%", "68%", "+14%");
            dgvOccupancy.Rows.Add("March", "78%", "76%", "+2%");
            dgvOccupancy.Rows.Add("April", "85%", "80%", "+5%");
            dgvOccupancy.Rows.Add("May", "90%", "77%", "+13%");
        }

        private void LoadRevenueData()
        {
            // Clear existing items
            dgvRevenue.Rows.Clear();

            // Add sample data
            dgvRevenue.Rows.Add("January", "$15,250", "$12,800", "+19%");
            dgvRevenue.Rows.Add("February", "$17,620", "$14,500", "+21%");
            dgvRevenue.Rows.Add("March", "$16,900", "$15,800", "+7%");
            dgvRevenue.Rows.Add("April", "$18,750", "$16,400", "+14%");
            dgvRevenue.Rows.Add("May", "$22,400", "$18,200", "+23%");
        }

        private void LoadReviewsData()
        {
            // Clear existing items
            dgvReviews.Rows.Clear();

            // Add sample data
            dgvReviews.Rows.Add("TR001", "John Smith", "Excellent service, would recommend!", "05/08/2025", "5/5");
            dgvReviews.Rows.Add("TR002", "Alice Johnson", "Room was clean but service was slow", "05/05/2025", "3/5");
            dgvReviews.Rows.Add("TR003", "David Williams", "Amazing experience overall", "05/01/2025", "5/5");
            dgvReviews.Rows.Add("TR004", "Sarah Brown", "Good value for money", "04/28/2025", "4/5");
            dgvReviews.Rows.Add("TR005", "Michael Davis", "Staff was very helpful", "04/25/2025", "4/5");
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report would be exported to PDF here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Report would be exported to Excel here.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnViewReviewDetails_Click(object sender, EventArgs e)
        {
            if (dgvReviews.SelectedRows.Count > 0)
            {
                string reviewer = dgvReviews.SelectedRows[0].Cells["ReviewerName"].Value.ToString();
                string review = dgvReviews.SelectedRows[0].Cells["ReviewText"].Value.ToString();
                string rating = dgvReviews.SelectedRows[0].Cells["Rating"].Value.ToString();

                MessageBox.Show($"Reviewer: {reviewer}\n\nFeedback: {review}\n\nRating: {rating}",
                    "Review Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a review first.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void cmbTimePeriod_SelectedIndexChanged(object sender, EventArgs e)
        {
            // In a real app, this would reload data based on the selected time period
            MessageBox.Show($"Data would be updated for {cmbTimePeriod.SelectedItem} time period.",
                "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // Reload all data
            LoadOccupancyData();
            LoadRevenueData();
            LoadReviewsData();

            MessageBox.Show("Performance data refreshed successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }
    }
}