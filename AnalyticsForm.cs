using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class AnalyticsForm : Form
    {
        public AnalyticsForm()
        {
            InitializeComponent();
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            cmbTimeFrame.SelectedIndex = 0;
            cmbChartType.SelectedIndex = 0;
            LoadData();
        }

        private void LoadData()
        {
            LoadRevenueData();
            LoadTopDestinations();
            UpdateSummaryCards();
        }

        private void UpdateSummaryCards()
        {
            lblTotalBookings.Text = "1,245";
            lblTotalRevenue.Text = "$149,750";
            lblActiveUsers.Text = "3,210";
            lblCompletedTours.Text = "987";
        }

        private void LoadRevenueData()
        {
            dgvRevenue.Rows.Clear();
            dgvRevenue.Rows.Add("Beach Resorts", "$54,320", "36.3%", "+12.5%");
            dgvRevenue.Rows.Add("Mountain Retreats", "$32,150", "21.5%", "+8.2%");
            dgvRevenue.Rows.Add("City Tours", "$28,970", "19.3%", "+5.7%");
            dgvRevenue.Rows.Add("Cultural Experiences", "$19,840", "13.2%", "+15.3%");
            dgvRevenue.Rows.Add("Adventure Sports", "$14,470", "9.7%", "-2.1%");

            for (int i = 0; i < dgvRevenue.Rows.Count; i++)
            {
                string growth = dgvRevenue.Rows[i].Cells["Growth"].Value.ToString();
                dgvRevenue.Rows[i].Cells["Growth"].Style.ForeColor =
                    growth.StartsWith("+") ? Color.Green : Color.Red;
            }
        }

        private void LoadTopDestinations()
        {
            dgvTopDestinations.Rows.Clear();
            dgvTopDestinations.Rows.Add("Bali, Indonesia", "245", "4.8");
            dgvTopDestinations.Rows.Add("Paris, France", "198", "4.7");
            dgvTopDestinations.Rows.Add("Santorini, Greece", "176", "4.9");
            dgvTopDestinations.Rows.Add("Tokyo, Japan", "165", "4.6");
            dgvTopDestinations.Rows.Add("New York, USA", "154", "4.5");
        }

        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            // No chart to update
        }

        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Analytics data exported to PDF successfully!", "Export Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Analytics data exported to CSV successfully!", "Export Complete",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}
