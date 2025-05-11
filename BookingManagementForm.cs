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
    public partial class BookingManagementForm : Form
    {
        public BookingManagementForm()
        {
            InitializeComponent();
        }

        private void BookingManagementForm_Load(object sender, EventArgs e)
        {
            // Load sample data for demonstration
            PopulateBookings();

            // Initialize availability combobox
            cmbRoomStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance", "Reserved" });
            cmbRoomStatus.SelectedIndex = 0;
        }

        private void PopulateBookings()
        {
            // Clear existing items
            dgvBookings.Rows.Clear();

            // Add sample data
            dgvBookings.Rows.Add("BK001", "John Smith", "Luxury Suite", "05/12/2025", "05/15/2025", "Pending", "$450.00", "50% Paid");
            dgvBookings.Rows.Add("BK002", "Emma Johnson", "City Tour", "05/14/2025", "05/14/2025", "Confirmed", "$120.00", "Fully Paid");
            dgvBookings.Rows.Add("BK003", "Michael Davis", "Standard Room", "05/20/2025", "05/22/2025", "Pending", "$200.00", "Not Paid");
            dgvBookings.Rows.Add("BK004", "Sarah Wilson", "Airport Transfer", "05/18/2025", "05/18/2025", "Pending", "$35.00", "Fully Paid");
            dgvBookings.Rows.Add("BK005", "Robert Brown", "Deluxe Room", "05/25/2025", "05/28/2025", "Confirmed", "$350.00", "25% Paid");
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBookings.SelectedRows[0];
                row.Cells["Status"].Value = "Confirmed";
                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a booking to confirm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                DataGridViewRow row = dgvBookings.SelectedRows[0];
                row.Cells["Status"].Value = "Cancelled";
                MessageBox.Show("Booking cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a booking to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                using (PaymentUpdateDialog dialog = new PaymentUpdateDialog())
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        DataGridViewRow row = dgvBookings.SelectedRows[0];
                        row.Cells["PaymentStatus"].Value = dialog.PaymentStatus;
                        MessageBox.Show("Payment status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdateAvailability_Click(object sender, EventArgs e)
        {
            if (!string.IsNullOrWhiteSpace(txtRoomId.Text) && cmbRoomStatus.SelectedIndex >= 0)
            {
                // In a real application, this would update the database
                MessageBox.Show($"Room/Seat {txtRoomId.Text} status updated to {cmbRoomStatus.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                txtRoomId.Text = "";
                cmbRoomStatus.SelectedIndex = 0;
            }
            else
            {
                MessageBox.Show("Please enter a Room/Seat ID and select a status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                // In a real application, this would open a details dialog
                MessageBox.Show("Booking details would display here.", "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            else
            {
                MessageBox.Show("Please select a booking to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            // This would typically reload data from the database
            PopulateBookings();
            MessageBox.Show("Booking list refreshed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                PopulateBookings();
                return;
            }

            foreach (DataGridViewRow row in dgvBookings.Rows)
            {
                bool matchFound = false;

                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
                    {
                        matchFound = true;
                        break;
                    }
                }

                row.Visible = matchFound;
            }
        }
    }

    // Simple dialog for updating payment status
    public class PaymentUpdateDialog : Form
    {
        private ComboBox cmbPaymentStatus;
        private Button btnOk;
        private Button btnCancel;

        public string PaymentStatus { get; private set; }

        public PaymentUpdateDialog()
        {
            this.Text = "Update Payment Status";
            this.Size = new Size(300, 150);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.StartPosition = FormStartPosition.CenterParent;
            this.MaximizeBox = false;
            this.MinimizeBox = false;

            Label lblStatus = new Label
            {
                Text = "Payment Status:",
                Location = new Point(20, 20),
                AutoSize = true
            };

            cmbPaymentStatus = new ComboBox
            {
                Location = new Point(120, 20),
                Size = new Size(150, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentStatus.Items.AddRange(new string[] { "Not Paid", "25% Paid", "50% Paid", "75% Paid", "Fully Paid" });
            cmbPaymentStatus.SelectedIndex = 0;

            btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(110, 70),
                Size = new Size(80, 30)
            };
            btnOk.Click += (s, e) =>
            {
                PaymentStatus = cmbPaymentStatus.Text;
                this.DialogResult = DialogResult.OK;
                this.Close();
            };

            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(200, 70),
                Size = new Size(80, 30)
            };

            this.Controls.AddRange(new Control[] { lblStatus, cmbPaymentStatus, btnOk, btnCancel });
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;
        }
    }
}