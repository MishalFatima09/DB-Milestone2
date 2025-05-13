using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class MyBookingsForm : Form
    {
        public MyBookingsForm()
        {
            InitializeComponent();
        }

        private void MyBookingsForm_Load(object sender, EventArgs e)
        {
            cmbFilterStatus.SelectedIndex = 0;
            LoadBookings();
        }

        private void LoadBookings()
        {
            dgvBookings.Rows.Clear();

            string filterStatus = cmbFilterStatus.SelectedItem?.ToString() ?? "All";
            string searchText = txtSearch.Text.ToLower();

            if (filterStatus == "All" || filterStatus == "Upcoming")
            {
                AddBookingRow(1, "Maldives Package", "JaneDoe", "2025-06-01", "Upcoming");
                AddBookingRow(2, "Swiss Alps Tour", "TravelerX", "2025-06-15", "Upcoming");
            }

            if (filterStatus == "All" || filterStatus == "Completed")
            {
                AddBookingRow(3, "Dubai Desert Safari", "Ali123", "2025-04-10", "Completed");
                AddBookingRow(4, "Rome Culture Trip", "GlobeTrekker", "2025-03-22", "Completed");
            }

            if (filterStatus == "All" || filterStatus == "Canceled")
            {
                AddBookingRow(5, "Bali Getaway", "NomadLife", "2025-05-01", "Canceled");
                AddBookingRow(6, "Tokyo Spring Tour", "CherryBlossom", "2025-04-05", "Canceled");
            }

            if (!string.IsNullOrEmpty(searchText))
            {
                for (int i = dgvBookings.Rows.Count - 1; i >= 0; i--)
                {
                    bool match = false;
                    foreach (DataGridViewCell cell in dgvBookings.Rows[i].Cells)
                    {
                        if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchText))
                        {
                            match = true;
                            break;
                        }
                    }
                    if (!match)
                        dgvBookings.Rows.RemoveAt(i);
                }
            }

            UpdateBookingCounts();
        }

        private void AddBookingRow(int id, string packageName, string username, string date, string status)
        {
            int rowIndex = dgvBookings.Rows.Add(id, packageName, username, date, status);

            var cell = dgvBookings.Rows[rowIndex].Cells["Status"];
            switch (status)
            {
                case "Upcoming":
                    cell.Style.ForeColor = Color.Blue;
                    break;
                case "Completed":
                    cell.Style.ForeColor = Color.Green;
                    break;
                case "Canceled":
                    cell.Style.ForeColor = Color.Red;
                    break;
            }
        }

        private void UpdateBookingCounts()
        {
            lblTotalBookings.Text = dgvBookings.Rows.Count.ToString();
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            LoadBookings();
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
            LoadBookings();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            txtSearch.Clear();
            cmbFilterStatus.SelectedIndex = 0;
            LoadBookings();
        }

        private void dgvBookings_SelectionChanged(object sender, EventArgs e)
        {
            btnViewDetails.Enabled = dgvBookings.SelectedRows.Count > 0;
        }

        private void dgvBookings_CellDoubleClick(object sender, DataGridViewCellEventArgs e)
        {
            btnViewDetails_Click(sender, e);
        }

        private void btnViewDetails_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var row = dgvBookings.SelectedRows[0];
                int bookingId = Convert.ToInt32(row.Cells["ID"].Value);
                string packageName = row.Cells["Package"].Value.ToString();
                string user = row.Cells["User"].Value.ToString();
                string date = row.Cells["Date"].Value.ToString();
                string status = row.Cells["Status"].Value.ToString();

                MessageBox.Show(
                    $"Booking ID: {bookingId}\n" +
                    $"Package: {packageName}\n" +
                    $"User: {user}\n" +
                    $"Date: {date}\n" +
                    $"Status: {status}",
                    "Booking Details",
                    MessageBoxButtons.OK,
                    MessageBoxIcon.Information);
            }
        }

        private void btnExport_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveDialog = new SaveFileDialog
            {
                Filter = "CSV Files (*.csv)|*.csv|Excel Files (*.xlsx)|*.xlsx",
                Title = "Export Bookings"
            };

            if (saveDialog.ShowDialog() == DialogResult.OK)
            {
                MessageBox.Show($"Bookings exported to {saveDialog.FileName} successfully!", "Export Complete",
                    MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancelBooking_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                var row = dgvBookings.SelectedRows[0];
                row.Cells["Status"].Value = "Canceled";
                LoadBookings();
            }
        }

        private void btnLeaveReview_Click(object sender, EventArgs e)
        {
            MessageBox.Show("Leave Review clicked!", "Review", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCloseDetails_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
