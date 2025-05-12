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
//    public partial class BookingManagementForm : Form
//    {
//        public BookingManagementForm()
//        {
//            InitializeComponent();
//        }

//        private void BookingManagementForm_Load(object sender, EventArgs e)
//        {
//            // Load sample data for demonstration
//            PopulateBookings();

//            // Initialize availability combobox
//            cmbRoomStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance", "Reserved" });
//            cmbRoomStatus.SelectedIndex = 0;
//        }

//        private void PopulateBookings()
//        {
//            // Clear existing items
//            dgvBookings.Rows.Clear();

//            // Add sample data
//            dgvBookings.Rows.Add("BK001", "John Smith", "Luxury Suite", "05/12/2025", "05/15/2025", "Pending", "$450.00", "50% Paid");
//            dgvBookings.Rows.Add("BK002", "Emma Johnson", "City Tour", "05/14/2025", "05/14/2025", "Confirmed", "$120.00", "Fully Paid");
//            dgvBookings.Rows.Add("BK003", "Michael Davis", "Standard Room", "05/20/2025", "05/22/2025", "Pending", "$200.00", "Not Paid");
//            dgvBookings.Rows.Add("BK004", "Sarah Wilson", "Airport Transfer", "05/18/2025", "05/18/2025", "Pending", "$35.00", "Fully Paid");
//            dgvBookings.Rows.Add("BK005", "Robert Brown", "Deluxe Room", "05/25/2025", "05/28/2025", "Confirmed", "$350.00", "25% Paid");
//        }

//        private void btnConfirm_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvBookings.SelectedRows[0];
//                row.Cells["Status"].Value = "Confirmed";
//                MessageBox.Show("Booking confirmed successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a booking to confirm.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.SelectedRows.Count > 0)
//            {
//                DataGridViewRow row = dgvBookings.SelectedRows[0];
//                row.Cells["Status"].Value = "Cancelled";
//                MessageBox.Show("Booking cancelled.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a booking to cancel.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnUpdatePayment_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.SelectedRows.Count > 0)
//            {
//                using (PaymentUpdateDialog dialog = new PaymentUpdateDialog())
//                {
//                    if (dialog.ShowDialog() == DialogResult.OK)
//                    {
//                        DataGridViewRow row = dgvBookings.SelectedRows[0];
//                        row.Cells["PaymentStatus"].Value = dialog.PaymentStatus;
//                        MessageBox.Show("Payment status updated successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                    }
//                }
//            }
//            else
//            {
//                MessageBox.Show("Please select a booking to update payment.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnUpdateAvailability_Click(object sender, EventArgs e)
//        {
//            if (!string.IsNullOrWhiteSpace(txtRoomId.Text) && cmbRoomStatus.SelectedIndex >= 0)
//            {
//                // In a real application, this would update the database
//                MessageBox.Show($"Room/Seat {txtRoomId.Text} status updated to {cmbRoomStatus.Text}", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
//                txtRoomId.Text = "";
//                cmbRoomStatus.SelectedIndex = 0;
//            }
//            else
//            {
//                MessageBox.Show("Please enter a Room/Seat ID and select a status.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnDetails_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.SelectedRows.Count > 0)
//            {
//                // In a real application, this would open a details dialog
//                MessageBox.Show("Booking details would display here.", "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//            else
//            {
//                MessageBox.Show("Please select a booking to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//            }
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            // This would typically reload data from the database
//            PopulateBookings();
//            MessageBox.Show("Booking list refreshed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            string searchTerm = txtSearch.Text.Trim().ToLower();

//            if (string.IsNullOrEmpty(searchTerm))
//            {
//                PopulateBookings();
//                return;
//            }

//            foreach (DataGridViewRow row in dgvBookings.Rows)
//            {
//                bool matchFound = false;

//                foreach (DataGridViewCell cell in row.Cells)
//                {
//                    if (cell.Value != null && cell.Value.ToString().ToLower().Contains(searchTerm))
//                    {
//                        matchFound = true;
//                        break;
//                    }
//                }

//                row.Visible = matchFound;
//            }
//        }
//    }

//    // Simple dialog for updating payment status
//    public class PaymentUpdateDialog : Form
//    {
//        private ComboBox cmbPaymentStatus;
//        private Button btnOk;
//        private Button btnCancel;

//        public string PaymentStatus { get; private set; }

//        public PaymentUpdateDialog()
//        {
//            this.Text = "Update Payment Status";
//            this.Size = new Size(300, 150);
//            this.FormBorderStyle = FormBorderStyle.FixedDialog;
//            this.StartPosition = FormStartPosition.CenterParent;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;

//            Label lblStatus = new Label
//            {
//                Text = "Payment Status:",
//                Location = new Point(20, 20),
//                AutoSize = true
//            };

//            cmbPaymentStatus = new ComboBox
//            {
//                Location = new Point(120, 20),
//                Size = new Size(150, 25),
//                DropDownStyle = ComboBoxStyle.DropDownList
//            };
//            cmbPaymentStatus.Items.AddRange(new string[] { "Not Paid", "25% Paid", "50% Paid", "75% Paid", "Fully Paid" });
//            cmbPaymentStatus.SelectedIndex = 0;

//            btnOk = new Button
//            {
//                Text = "OK",
//                DialogResult = DialogResult.OK,
//                Location = new Point(110, 70),
//                Size = new Size(80, 30)
//            };
//            btnOk.Click += (s, e) =>
//            {
//                PaymentStatus = cmbPaymentStatus.Text;
//                this.DialogResult = DialogResult.OK;
//                this.Close();
//            };

//            btnCancel = new Button
//            {
//                Text = "Cancel",
//                DialogResult = DialogResult.Cancel,
//                Location = new Point(200, 70),
//                Size = new Size(80, 30)
//            };

//            this.Controls.AddRange(new Control[] { lblStatus, cmbPaymentStatus, btnOk, btnCancel });
//            this.AcceptButton = btnOk;
//            this.CancelButton = btnCancel;
//        }
//    }
//}


//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Data.SqlClient;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DB_M2_Chat
//{
//    public partial class BookingManagementForm : Form
//    {
//        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";
//        private DataTable bookingsTable = new DataTable();

//        public BookingManagementForm()
//        {
//            InitializeComponent();
//        }

//        private void BookingManagementForm_Load(object sender, EventArgs e)
//        {
//            // Initialize room status combobox
//            cmbRoomStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance", "Reserved" });
//            cmbRoomStatus.SelectedIndex = 0;

//            // Initialize booking status filter combobox
//            cmbStatusFilter.Items.AddRange(new string[] { "All", "Confirmed", "Pending", "Cancelled", "Completed" });
//            cmbStatusFilter.SelectedIndex = 0;

//            // Load bookings from database
//            LoadBookings();
//        }

//        private void LoadBookings()
//        {
//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    string query = @"
//                        SELECT b.BookingID, u.FirstName + ' ' + u.LastName AS CustomerName, 
//                               s.ServiceName, t.StartDate, t.EndDate, b.Status, 
//                               b.TotalCost, 
//                               CASE 
//                                   WHEN SUM(p.Amount) IS NULL THEN 'Not Paid'
//                                   WHEN SUM(p.Amount) >= b.TotalCost THEN 'Fully Paid'
//                                   WHEN SUM(p.Amount) >= b.TotalCost * 0.75 THEN '75% Paid'
//                                   WHEN SUM(p.Amount) >= b.TotalCost * 0.5 THEN '50% Paid'
//                                   WHEN SUM(p.Amount) >= b.TotalCost * 0.25 THEN '25% Paid'
//                                   ELSE 'Partially Paid'
//                               END AS PaymentStatus
//                        FROM Booking b
//                        JOIN Users u ON b.TravelerID = u.UserID
//                        JOIN Trip t ON b.TripID = t.TripID
//                        JOIN AssignedService ass ON t.TripID = ass.TripID
//                        JOIN Service s ON ass.ServiceID = s.ServiceID
//                        LEFT JOIN Payment p ON b.BookingID = p.BookingID AND p.Status = 'Completed'
//                        GROUP BY b.BookingID, u.FirstName, u.LastName, s.ServiceName, 
//                                 t.StartDate, t.EndDate, b.Status, b.TotalCost";

//                    SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
//                    bookingsTable.Clear();
//                    adapter.Fill(bookingsTable);

//                    dgvBookings.DataSource = bookingsTable;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error loading bookings: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);

//                // Load sample data if database connection fails
//                LoadSampleData();
//            }
//        }

//        private void LoadSampleData()
//        {
//            // Clear existing items
//            dgvBookings.DataSource = null;
//            bookingsTable.Clear();

//            // Create columns
//            if (bookingsTable.Columns.Count == 0)
//            {
//                bookingsTable.Columns.Add("BookingID");
//                bookingsTable.Columns.Add("CustomerName");
//                bookingsTable.Columns.Add("ServiceType");
//                bookingsTable.Columns.Add("CheckIn", typeof(DateTime));
//                bookingsTable.Columns.Add("CheckOut", typeof(DateTime));
//                bookingsTable.Columns.Add("Status");
//                bookingsTable.Columns.Add("Amount");
//                bookingsTable.Columns.Add("PaymentStatus");
//            }

//            // Add sample data
//            bookingsTable.Rows.Add("BK001", "John Smith", "Luxury Suite", DateTime.Parse("05/12/2025"),
//                DateTime.Parse("05/15/2025"), "Pending", "$450.00", "50% Paid");
//            bookingsTable.Rows.Add("BK002", "Emma Johnson", "City Tour", DateTime.Parse("05/14/2025"),
//                DateTime.Parse("05/14/2025"), "Confirmed", "$120.00", "Fully Paid");
//            bookingsTable.Rows.Add("BK003", "Michael Davis", "Standard Room", DateTime.Parse("05/20/2025"),
//                DateTime.Parse("05/22/2025"), "Pending", "$200.00", "Not Paid");
//            bookingsTable.Rows.Add("BK004", "Sarah Wilson", "Airport Transfer", DateTime.Parse("05/18/2025"),
//                DateTime.Parse("05/18/2025"), "Pending", "$35.00", "Fully Paid");
//            bookingsTable.Rows.Add("BK005", "Robert Brown", "Deluxe Room", DateTime.Parse("05/25/2025"),
//                DateTime.Parse("05/28/2025"), "Confirmed", "$350.00", "25% Paid");

//            dgvBookings.DataSource = bookingsTable;
//        }

//        private void btnConfirm_Click(object sender, EventArgs e)
//        {
//            UpdateBookingStatus("Confirmed");
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            UpdateBookingStatus("Cancelled");
//        }

//        private void UpdateBookingStatus(string status)
//        {
//            if (dgvBookings.CurrentRow == null)
//            {
//                MessageBox.Show("Please select a booking first.", "Information",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            string bookingID = dgvBookings.CurrentRow.Cells["BookingID"].Value.ToString();

//            try
//            {
//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();
//                    string query = "UPDATE Booking SET Status = @Status WHERE BookingID = @BookingID";

//                    using (SqlCommand command = new SqlCommand(query, connection))
//                    {
//                        command.Parameters.AddWithValue("@Status", status);
//                        command.Parameters.AddWithValue("@BookingID", bookingID);
//                        int result = command.ExecuteNonQuery();

//                        if (result > 0)
//                        {
//                            dgvBookings.CurrentRow.Cells["Status"].Value = status;
//                            MessageBox.Show($"Booking status updated to {status}.", "Success",
//                                MessageBoxButtons.OK, MessageBoxIcon.Information);
//                        }
//                    }
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error updating booking: " + ex.Message, "Error",
//                    MessageBoxButtons.OK, MessageBoxIcon.Error);

//                // Update UI only if database update fails
//                dgvBookings.CurrentRow.Cells["Status"].Value = status;
//            }
//        }

//        private void btnUpdatePayment_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.CurrentRow == null)
//            {
//                MessageBox.Show("Please select a booking first.", "Information",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            using (PaymentUpdateDialog dialog = new PaymentUpdateDialog())
//            {
//                if (dialog.ShowDialog() == DialogResult.OK)
//                {
//                    string bookingID = dgvBookings.CurrentRow.Cells["BookingID"].Value.ToString();
//                    decimal totalCost = decimal.Parse(dgvBookings.CurrentRow.Cells["Amount"].Value.ToString()
//                        .Replace("$", ""));
//                    decimal paymentAmount = CalculatePaymentAmount(dialog.PaymentStatus, totalCost);

//                    try
//                    {
//                        using (SqlConnection connection = new SqlConnection(connectionString))
//                        {
//                            connection.Open();
//                            string paymentID = GeneratePaymentID(connection);
//                            string query = @"
//                                INSERT INTO Payment (Payment_ID, BookingID, PaymentDate, Amount, Status, Method)
//                                VALUES (@PaymentID, @BookingID, @PaymentDate, @Amount, @Status, @Method)";

//                            using (SqlCommand command = new SqlCommand(query, connection))
//                            {
//                                command.Parameters.AddWithValue("@PaymentID", paymentID);
//                                command.Parameters.AddWithValue("@BookingID", bookingID);
//                                command.Parameters.AddWithValue("@PaymentDate", DateTime.Now);
//                                command.Parameters.AddWithValue("@Amount", paymentAmount);
//                                command.Parameters.AddWithValue("@Status", "Completed");
//                                command.Parameters.AddWithValue("@Method", dialog.PaymentMethod);

//                                command.ExecuteNonQuery();
//                                dgvBookings.CurrentRow.Cells["PaymentStatus"].Value = dialog.PaymentStatus;

//                                MessageBox.Show("Payment recorded successfully!", "Success",
//                                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                            }
//                        }
//                    }
//                    catch (Exception ex)
//                    {
//                        MessageBox.Show("Error updating payment: " + ex.Message, "Error",
//                            MessageBoxButtons.OK, MessageBoxIcon.Error);

//                        // Update UI only if database update fails
//                        dgvBookings.CurrentRow.Cells["PaymentStatus"].Value = dialog.PaymentStatus;
//                    }
//                }
//            }
//        }

//        private string GeneratePaymentID(SqlConnection connection)
//        {
//            // Get the highest payment ID number
//            string query = "SELECT TOP 1 Payment_ID FROM Payment ORDER BY Payment_ID DESC";
//            using (SqlCommand command = new SqlCommand(query, connection))
//            {
//                object result = command.ExecuteScalar();
//                int nextNumber = 1;

//                if (result != null)
//                {
//                    string lastID = result.ToString();
//                    if (lastID.StartsWith("PM") && int.TryParse(lastID.Substring(2), out int lastNumber))
//                    {
//                        nextNumber = lastNumber + 1;
//                    }
//                }

//                return "PM" + nextNumber.ToString("D3");
//            }
//        }

//        private decimal CalculatePaymentAmount(string paymentStatus, decimal totalCost)
//        {
//            switch (paymentStatus)
//            {
//                case "Fully Paid": return totalCost;
//                case "75% Paid": return totalCost * 0.75m;
//                case "50% Paid": return totalCost * 0.50m;
//                case "25% Paid": return totalCost * 0.25m;
//                default: return 0;
//            }
//        }

//        private void btnUpdateAvailability_Click(object sender, EventArgs e)
//        {
//            if (string.IsNullOrWhiteSpace(txtRoomId.Text) || txtRoomId.Text == "Room/Seat ID")
//            {
//                MessageBox.Show("Please enter a Room/Seat ID.", "Information",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            if (rdoHotel.Checked)
//            {
//                UpdateHotelRoomAvailability();
//            }
//            else if (rdoTransport.Checked)
//            {
//                UpdateTransportSeatAvailability();
//            }
//        }

//        private void UpdateHotelRoomAvailability()
//        {
//            try
//            {
//                string[] roomInfo = txtRoomId.Text.Split('-');
//                if (roomInfo.Length != 2 || !int.TryParse(roomInfo[1], out int roomNum))
//                {
//                    MessageBox.Show("Invalid room format. Use HotelID-RoomNumber (e.g., H001-101)",
//                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                string hotelID = roomInfo[0];
//                string status = cmbRoomStatus.Text;
//                bool isAvailable = (status == "Available");

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    // Update the room availability in the Rooms table logic would go here
//                    // For now, just show a success message
//                    MessageBox.Show($"Room {roomNum} in hotel {hotelID} status updated to {status}.",
//                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    txtRoomId.Text = "Room/Seat ID";
//                    cmbRoomStatus.SelectedIndex = 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error updating room availability: " + ex.Message,
//                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void UpdateTransportSeatAvailability()
//        {
//            try
//            {
//                string[] seatInfo = txtRoomId.Text.Split('-');
//                if (seatInfo.Length != 2 || !int.TryParse(seatInfo[1], out int seatNum))
//                {
//                    MessageBox.Show("Invalid seat format. Use TransportID-SeatNumber (e.g., T001-15)",
//                        "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                    return;
//                }

//                string transportID = seatInfo[0];
//                string status = cmbRoomStatus.Text;

//                using (SqlConnection connection = new SqlConnection(connectionString))
//                {
//                    connection.Open();

//                    // Update the seat availability in the Transport table logic would go here
//                    // For now, just show a success message
//                    MessageBox.Show($"Seat {seatNum} in transport {transportID} status updated to {status}.",
//                        "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//                    txtRoomId.Text = "Room/Seat ID";
//                    cmbRoomStatus.SelectedIndex = 0;
//                }
//            }
//            catch (Exception ex)
//            {
//                MessageBox.Show("Error updating seat availability: " + ex.Message,
//                    "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
//            }
//        }

//        private void btnDetails_Click(object sender, EventArgs e)
//        {
//            if (dgvBookings.CurrentRow == null)
//            {
//                MessageBox.Show("Please select a booking first.", "Information",
//                    MessageBoxButtons.OK, MessageBoxIcon.Information);
//                return;
//            }

//            string bookingID = dgvBookings.CurrentRow.Cells["BookingID"].Value.ToString();

//            // In a real application, this would fetch detailed booking information
//            // and display it in a separate form or dialog
//            MessageBox.Show($"Viewing details for booking {bookingID}.\nThis would show complete booking information including services, room details, and payment history.",
//                "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
//        }

//        private void btnRefresh_Click(object sender, EventArgs e)
//        {
//            LoadBookings();
//            ApplyFilters();
//        }

//        private void btnSearch_Click(object sender, EventArgs e)
//        {
//            ApplyFilters();
//        }

//        private void cmbStatusFilter_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            ApplyFilters();
//        }

//        //private void ApplyFilters()
//        //{
//        //    string searchTerm = txtSearch.Text.Trim().ToLower();
//        //    string statusFilter = cmbStatusFilter.SelectedItem.ToString();

//        //    if (statusFilter == "All" && string.IsNullOrEmpty(searchTerm))
//        //    {
//        //        // No filters active, show all data
//        //        (dgvBookings.DataSource as DataTable).DefaultView.RowFilter = "";
//        //        return;
//        //    }

//        //    // Construct filter expression
//        //    StringBuilder filterExpression = new StringBuilder();

//        //    // Add status filter if not "All"
//        //    if (statusFilter != "All")
//        //    {
//        //        filterExpression.Append($"Status = '{statusFilter}'");
//        //    }

//        //    // Add search term filter if provided
//        //    if (!string.IsNullOrEmpty(searchTerm) && searchTerm != "search bookings...")
//        //    {
//        //        if (filterExpression.Length > 0)
//        //            filterExpression.Append(" AND ");

//        //        filterExpression.Append($"(BookingID LIKE '%{searchTerm}%' OR " +
//        //                              $"CustomerName LIKE '%{searchTerm}%' OR " +
//        //                              $"ServiceType LIKE '%{searchTerm}%')");
//        //    }

//        //    // Apply filter
//        //    (dgvBookings.DataSource as DataTable).DefaultView.RowFilter = filterExpression.ToString();
//        //}

//        private void ApplyFilters()
//        {
//            // Safeguard check to prevent NullReferenceException
//            if (dgvBookings.DataSource == null || !(dgvBookings.DataSource is DataTable dt))
//                return;

//            string searchTerm = txtSearch.Text.Trim().ToLower();
//            string statusFilter = cmbStatusFilter.SelectedItem?.ToString() ?? "All";

//            if (statusFilter == "All" && string.IsNullOrEmpty(searchTerm))
//            {
//                dt.DefaultView.RowFilter = "";
//                return;
//            }

//            StringBuilder filterExpression = new StringBuilder();

//            if (statusFilter != "All")
//            {
//                filterExpression.Append($"Status = '{statusFilter}'");
//            }

//            if (!string.IsNullOrEmpty(searchTerm) && searchTerm != "search bookings...")
//            {
//                if (filterExpression.Length > 0)
//                    filterExpression.Append(" AND ");

//                filterExpression.Append($"(BookingID LIKE '%{searchTerm}%' OR " +
//                                         $"CustomerName LIKE '%{searchTerm}%' OR " +
//                                         $"ServiceType LIKE '%{searchTerm}%')");
//            }

//            dt.DefaultView.RowFilter = filterExpression.ToString();
//        }


//    }

//    // Simple dialog for updating payment status
//    public class PaymentUpdateDialog : Form
//    {
//        private ComboBox cmbPaymentStatus;
//        private ComboBox cmbPaymentMethod;
//        private Button btnOk;
//        private Button btnCancel;

//        public string PaymentStatus { get; private set; }
//        public string PaymentMethod { get; private set; }

//        public PaymentUpdateDialog()
//        {
//            this.Text = "Update Payment";
//            this.Size = new Size(350, 200);
//            this.FormBorderStyle = FormBorderStyle.FixedDialog;
//            this.StartPosition = FormStartPosition.CenterParent;
//            this.MaximizeBox = false;
//            this.MinimizeBox = false;
//            this.BackColor = Color.FromArgb(191, 215, 234);

//            Label lblStatus = new Label
//            {
//                Text = "Payment Status:",
//                Location = new Point(20, 20),
//                AutoSize = true,
//                Font = new Font("Segoe UI", 9)
//            };

//            cmbPaymentStatus = new ComboBox
//            {
//                Location = new Point(150, 20),
//                Size = new Size(160, 25),
//                DropDownStyle = ComboBoxStyle.DropDownList,
//                Font = new Font("Segoe UI", 9)
//            };
//            cmbPaymentStatus.Items.AddRange(new string[] { "Not Paid", "25% Paid", "50% Paid", "75% Paid", "Fully Paid" });
//            cmbPaymentStatus.SelectedIndex = 4; // Default to "Fully Paid"

//            Label lblMethod = new Label
//            {
//                Text = "Payment Method:",
//                Location = new Point(20, 60),
//                AutoSize = true,
//                Font = new Font("Segoe UI", 9)
//            };

//            cmbPaymentMethod = new ComboBox
//            {
//                Location = new Point(150, 60),
//                Size = new Size(160, 25),
//                DropDownStyle = ComboBoxStyle.DropDownList,
//                Font = new Font("Segoe UI", 9)
//            };
//            cmbPaymentMethod.Items.AddRange(new string[] { "Credit Card", "PayPal", "Bank Transfer" });
//            cmbPaymentMethod.SelectedIndex = 0;

//            btnOk = new Button
//            {
//                Text = "Update",
//                DialogResult = DialogResult.OK,
//                Location = new Point(130, 110),
//                Size = new Size(100, 35),
//                BackColor = Color.FromArgb(40, 167, 69),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("Segoe UI", 9, FontStyle.Bold)
//            };
//            btnOk.FlatAppearance.BorderSize = 0;
//            btnOk.Click += (s, e) =>
//            {
//                PaymentStatus = cmbPaymentStatus.Text;
//                PaymentMethod = cmbPaymentMethod.Text;
//                this.DialogResult = DialogResult.OK;
//                this.Close();
//            };

//            btnCancel = new Button
//            {
//                Text = "Cancel",
//                DialogResult = DialogResult.Cancel,
//                Location = new Point(240, 110),
//                Size = new Size(80, 35),
//                BackColor = Color.FromArgb(108, 117, 125),
//                ForeColor = Color.White,
//                FlatStyle = FlatStyle.Flat,
//                Font = new Font("Segoe UI", 9)
//            };
//            btnCancel.FlatAppearance.BorderSize = 0;

//            this.Controls.AddRange(new Control[] {
//                lblStatus, cmbPaymentStatus,
//                lblMethod, cmbPaymentMethod,
//                btnOk, btnCancel
//            });

//            this.AcceptButton = btnOk;
//            this.CancelButton = btnCancel;
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

namespace DB_M2_Chat
{
    public partial class BookingManagementForm : Form
    {
        // Replace with your actual connection string
        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";
        private DataTable bookingsTable = new DataTable();

        public BookingManagementForm()
        {
            InitializeComponent();
        }

        private void BookingManagementForm_Load(object sender, EventArgs e)
        {
            // Load data from database
            LoadBookings();

            // Initialize status comboboxes
            cmbBookingStatus.Items.AddRange(new string[] { "Confirmed", "Pending", "Cancelled" });
            cmbBookingStatus.SelectedIndex = 0;

            cmbRoomStatus.Items.AddRange(new string[] { "Available", "Occupied", "Maintenance", "Reserved" });
            cmbRoomStatus.SelectedIndex = 0;

            // Initialize service type filter
            cmbServiceTypeFilter.Items.AddRange(new string[] { "All", "Guide", "Hotel", "Transport" });
            cmbServiceTypeFilter.SelectedIndex = 0;

            // Add handler for room/seat type selection
            cmbAccommodationType.SelectedIndexChanged += CmbAccommodationType_SelectedIndexChanged;
            cmbAccommodationType.Items.AddRange(new string[] { "Hotel Room", "Transport Seat" });
            cmbAccommodationType.SelectedIndex = 0;
        }

        private void CmbAccommodationType_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbAccommodationType.SelectedIndex == 0) // Hotel Room
            {
                LoadHotels();
                lblRoomSeatId.Text = "Room Number:";
            }
            else // Transport Seat
            {
                LoadTransports();
                lblRoomSeatId.Text = "Seat Number:";
            }
        }

        private void LoadHotels()
        {
            try
            {
                cmbServiceId.Items.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT h.ServiceID, s.Name 
                                    FROM Hotel h
                                    JOIN Service s ON h.ServiceID = s.ServiceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string serviceId = reader["ServiceID"].ToString();
                                string name = reader["Name"].ToString();
                                cmbServiceId.Items.Add(new ComboBoxItem { Value = serviceId, Display = $"{serviceId} - {name}" });
                            }
                        }
                    }
                }

                if (cmbServiceId.Items.Count > 0)
                    cmbServiceId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading hotels: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTransports()
        {
            try
            {
                cmbServiceId.Items.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"SELECT t.ServiceID, s.Name, t.VehicleType 
                                    FROM Transport t
                                    JOIN Service s ON t.ServiceID = s.ServiceID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string serviceId = reader["ServiceID"].ToString();
                                string name = reader["Name"].ToString();
                                string vehicleType = reader["VehicleType"].ToString();
                                cmbServiceId.Items.Add(new ComboBoxItem { Value = serviceId, Display = $"{serviceId} - {name} ({vehicleType})" });
                            }
                        }
                    }
                }

                if (cmbServiceId.Items.Count > 0)
                    cmbServiceId.SelectedIndex = 0;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading transports: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        //private void LoadBookings()
        //{
        //    try
        //    {
        //        bookingsTable.Clear();
        //        using (SqlConnection connection = new SqlConnection(connectionString))
        //        {
        //            connection.Open();
        //            string query = @"
        //                SELECT 
        //                    ass.AssignmentID,
        //                    b.TravelerID,
        //                    CONCAT(t.FirstName, ' ', t.LastName) AS CustomerName,
        //                    s.Type AS ServiceType,
        //                    s.Name AS ServiceName,
        //                    ass.Status,
        //                    ass.ScheduledDeparture AS CheckIn,
        //                    ass.ScheduledArrival AS CheckOut,
        //                    CASE 
        //                        WHEN s.Type = 'Hotel' THEN h.PricePerNight * DATEDIFF(day, ass.ScheduledDeparture, ass.ScheduledArrival)
        //                        WHEN s.Type = 'Transport' THEN trp.PricePerTicket
        //                        WHEN s.Type = 'Guide' THEN g.PricePerDay * DATEDIFF(day, ass.ScheduledDeparture, ass.ScheduledArrival)
        //                        ELSE 0
        //                    END AS Amount,
        //                    p.Status AS PaymentStatus,
        //                    p.Amount AS PaidAmount,
        //                    b.BookingID
        //                FROM AssignedService ass
        //                JOIN Booking b ON ass.BookingID = b.BookingID
        //                JOIN Traveler t ON b.TravelerID = t.TravelerID
        //                JOIN Service s ON ass.ServiceID = s.ServiceID
        //                LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID
        //                LEFT JOIN Transport trp ON s.ServiceID = trp.ServiceID
        //                LEFT JOIN Guide g ON s.ServiceID = g.ServiceID
        //                LEFT JOIN Payment p ON b.BookingID = p.BookingID
        //                WHERE (@ServiceType = 'All' OR s.Type = @ServiceType)
        //                ORDER BY ass.ScheduledDeparture DESC";

        //            SqlDataAdapter adapter = new SqlDataAdapter();
        //            adapter.SelectCommand = new SqlCommand(query, connection);
        //            adapter.SelectCommand.Parameters.AddWithValue("@ServiceType", cmbServiceTypeFilter.Text);
        //            adapter.Fill(bookingsTable);
        //        }

        //        // Bind to DataGridView
        //        dgvBookings.DataSource = bookingsTable;

        //        // Format currency columns
        //        dgvBookings.Columns["Amount"].DefaultCellStyle.Format = "C2";
        //        if (dgvBookings.Columns.Contains("PaidAmount"))
        //            dgvBookings.Columns["PaidAmount"].DefaultCellStyle.Format = "C2";

        //        // Format date columns
        //        dgvBookings.Columns["CheckIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
        //        dgvBookings.Columns["CheckOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";

        //        // Hide BookingID column
        //        dgvBookings.Columns["BookingID"].Visible = false;
        //        dgvBookings.Columns["TravelerID"].Visible = false;

        //        // Set column order for better visibility
        //        dgvBookings.Columns["AssignmentID"].DisplayIndex = 0;
        //        dgvBookings.Columns["CustomerName"].DisplayIndex = 1;
        //        dgvBookings.Columns["ServiceType"].DisplayIndex = 2;
        //        dgvBookings.Columns["ServiceName"].DisplayIndex = 3;
        //        dgvBookings.Columns["CheckIn"].DisplayIndex = 4;
        //        dgvBookings.Columns["CheckOut"].DisplayIndex = 5;
        //        dgvBookings.Columns["Status"].DisplayIndex = 6;
        //        dgvBookings.Columns["Amount"].DisplayIndex = 7;
        //        dgvBookings.Columns["PaymentStatus"].DisplayIndex = 8;
        //    }
        //    catch (Exception ex)
        //    {
        //        MessageBox.Show($"Error loading bookings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
        //    }
        //}

        private void LoadBookings()
        {
            try
            {
                bookingsTable.Clear();
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = @"
                        SELECT 
                            ass.AssignmentID,
                            s.Type AS ServiceType,
                            s.Name AS ServiceName,
                            ass.Status,
                            ass.ScheduledDeparture AS CheckIn,
                            ass.ScheduledArrival AS CheckOut,
                            CASE 
                                WHEN s.Type = 'Hotel' THEN r.PricePerNight * DATEDIFF(day, ass.ScheduledDeparture, ass.ScheduledArrival)
                                WHEN s.Type = 'Transport' THEN trp.PricePerTicket
                                WHEN s.Type = 'Guide' THEN g.PricePerDay * DATEDIFF(day, ass.ScheduledDeparture, ass.ScheduledArrival)
                                ELSE 0
                            END AS Amount,
                            p.Status AS PaymentStatus,
                            p.Amount AS PaidAmount
                        FROM AssignedService ass
                        JOIN Service s ON ass.ServiceID = s.ServiceID
                        LEFT JOIN Hotel h ON s.ServiceID = h.ServiceID
                        LEFT JOIN Rooms r ON r.HotelID = h.ServiceID
                        LEFT JOIN Transport trp ON s.ServiceID = trp.ServiceID
                        LEFT JOIN Guide g ON s.ServiceID = g.ServiceID
                        LEFT JOIN Booking b ON ass.BookingID = b.BookingID
                        LEFT JOIN Payment p ON b.BookingID = p.BookingID
                        WHERE ass.Status = 'Confirmed'
                        AND (@ServiceType = 'All' OR s.Type = @ServiceType)
                        ORDER BY ass.ScheduledDeparture DESC";

                    SqlDataAdapter adapter = new SqlDataAdapter();
                    adapter.SelectCommand = new SqlCommand(query, connection);
                    adapter.SelectCommand.Parameters.AddWithValue("@ServiceType", cmbServiceTypeFilter.Text);
                    adapter.Fill(bookingsTable);
                }

                // Bind to DataGridView
                dgvBookings.DataSource = bookingsTable;

                // Format currency columns
                dgvBookings.Columns["Amount"].DefaultCellStyle.Format = "C2";
                if (dgvBookings.Columns.Contains("PaidAmount"))
                    dgvBookings.Columns["PaidAmount"].DefaultCellStyle.Format = "C2";

                // Format date columns
                dgvBookings.Columns["CheckIn"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";
                dgvBookings.Columns["CheckOut"].DefaultCellStyle.Format = "MM/dd/yyyy HH:mm";

                // Set column order for better visibility
                dgvBookings.Columns["AssignmentID"].DisplayIndex = 0;
                dgvBookings.Columns["ServiceType"].DisplayIndex = 1;
                dgvBookings.Columns["ServiceName"].DisplayIndex = 2;
                dgvBookings.Columns["Status"].DisplayIndex = 3;
                dgvBookings.Columns["CheckIn"].DisplayIndex = 4;
                dgvBookings.Columns["CheckOut"].DisplayIndex = 5;
                dgvBookings.Columns["Amount"].DisplayIndex = 6;
                dgvBookings.Columns["PaymentStatus"].DisplayIndex = 7;
                dgvBookings.Columns["PaidAmount"].DisplayIndex = 8;
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading bookings: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnConfirm_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Confirmed");
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Cancelled");
        }

        private void btnPending_Click(object sender, EventArgs e)
        {
            UpdateBookingStatus("Pending");
        }

        private void UpdateBookingStatus(string status)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                try
                {
                    string assignmentId = dgvBookings.SelectedRows[0].Cells["AssignmentID"].Value.ToString();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = "UPDATE AssignedService SET Status = @Status WHERE AssignmentID = @AssignmentID";

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@Status", status);
                            command.Parameters.AddWithValue("@AssignmentID", assignmentId);
                            int result = command.ExecuteNonQuery();

                            if (result > 0)
                            {
                                MessageBox.Show($"Booking {assignmentId} status updated to {status}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                                LoadBookings();
                            }
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error updating status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to update.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void btnUpdatePayment_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                string bookingId = dgvBookings.SelectedRows[0].Cells["AssignmentID"].Value.ToString();
                decimal totalAmount = Convert.ToDecimal(dgvBookings.SelectedRows[0].Cells["Amount"].Value);

                using (PaymentUpdateDialog dialog = new PaymentUpdateDialog(bookingId, totalAmount))
                {
                    if (dialog.ShowDialog() == DialogResult.OK)
                    {
                        //LoadBookings();
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
            if (cmbServiceId.SelectedItem == null || string.IsNullOrWhiteSpace(txtRoomId.Text))
            {
                MessageBox.Show("Please select a service and enter a room/seat ID.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            string serviceId = ((ComboBoxItem)cmbServiceId.SelectedItem).Value;
            string roomSeatId = txtRoomId.Text.Trim();
            string status = cmbRoomStatus.Text;

            try
            {
                if (cmbAccommodationType.SelectedIndex == 0) // Hotel Room
                {
                    UpdateHotelRoomStatus(serviceId, roomSeatId, status);
                }
                else // Transport Seat
                {
                    UpdateTransportSeatStatus(serviceId, roomSeatId, status);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating availability: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateHotelRoomStatus(string hotelId, string roomNum, string status)
        {
            try
            {
                int roomNumber;
                if (!int.TryParse(roomNum, out roomNumber))
                {
                    MessageBox.Show("Room number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First check if the room exists
                    string checkQuery = "SELECT COUNT(*) FROM Rooms WHERE RoomNum = @RoomNum AND HotelID = @HotelID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@RoomNum", roomNumber);
                        checkCommand.Parameters.AddWithValue("@HotelID", hotelId);

                        int roomCount = (int)checkCommand.ExecuteScalar();
                        if (roomCount == 0)
                        {
                            MessageBox.Show($"Room {roomNumber} does not exist in hotel {hotelId}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // Now update the room status in a real system this would be in a RoomStatus table
                    // For now, we'll just show a success message
                    MessageBox.Show($"Room {roomNumber} in hotel {hotelId} status updated to {status}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Update hotel available rooms count if needed
                    if (status == "Available")
                    {
                        string updateQuery = @"
                            UPDATE Hotel 
                            SET AvailableRooms = AvailableRooms + 1 
                            WHERE ServiceID = @HotelID AND 
                                  (SELECT COUNT(*) FROM BookedRooms br 
                                   JOIN AssignedService ass ON br.AssignmentID = ass.AssignmentID 
                                   WHERE br.HotelID = @HotelID AND br.RoomNum = @RoomNum 
                                   AND ass.Status = 'Confirmed') = 0";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@HotelID", hotelId);
                            updateCommand.Parameters.AddWithValue("@RoomNum", roomNumber);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                    else if (status == "Occupied" || status == "Maintenance" || status == "Reserved")
                    {
                        string updateQuery = @"
                            UPDATE Hotel 
                            SET AvailableRooms = CASE WHEN AvailableRooms > 0 THEN AvailableRooms - 1 ELSE 0 END 
                            WHERE ServiceID = @HotelID";

                        using (SqlCommand updateCommand = new SqlCommand(updateQuery, connection))
                        {
                            updateCommand.Parameters.AddWithValue("@HotelID", hotelId);
                            updateCommand.ExecuteNonQuery();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating room status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTransportSeatStatus(string transportId, string seatNum, string status)
        {
            try
            {
                int seatNumber;
                if (!int.TryParse(seatNum, out seatNumber))
                {
                    MessageBox.Show("Seat number must be numeric.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First check if the seat number is valid (within capacity)
                    string checkQuery = "SELECT Capacity FROM Transport WHERE ServiceID = @TransportID";
                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@TransportID", transportId);

                        int capacity = (int)checkCommand.ExecuteScalar();
                        if (seatNumber <= 0 || seatNumber > capacity)
                        {
                            MessageBox.Show($"Seat {seatNumber} is invalid. Capacity is {capacity}.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // In a real system, you would update a TransportSeat table
                    // For now, we'll just show a success message
                    MessageBox.Show($"Seat {seatNumber} in transport {transportId} status updated to {status}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating seat status: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btnDetails_Click(object sender, EventArgs e)
        {
            if (dgvBookings.SelectedRows.Count > 0)
            {
                string assignmentId = dgvBookings.SelectedRows[0].Cells["AssignmentID"].Value.ToString();
                string serviceType = dgvBookings.SelectedRows[0].Cells["ServiceType"].Value.ToString();

                try
                {
                    StringBuilder details = new StringBuilder();

                    using (SqlConnection connection = new SqlConnection(connectionString))
                    {
                        connection.Open();
                        string query = string.Empty;

                        if (serviceType == "Hotel")
                        {
                            query = @"
                                SELECT 
                                    br.RoomNum,
                                    r.RoomType,
                                    r.PricePerNight,
                                    h.Address,
                                    h.Facilities
                                FROM BookedRooms br
                                JOIN Rooms r ON br.RoomNum = r.RoomNum AND br.HotelID = r.HotelID
                                JOIN Hotel h ON br.HotelID = h.ServiceID
                                WHERE br.AssignmentID = @AssignmentID";
                        }
                        else if (serviceType == "Transport")
                        {
                            query = @"
                                SELECT 
                                    t.VehicleNum,
                                    t.VehicleType,
                                    t.PricePerTicket,
                                    ass.ScheduledDeparture,
                                    ass.ScheduledArrival,
                                    ass.ActualDeparture,
                                    ass.ActualArrival
                                FROM AssignedService ass
                                JOIN Transport t ON ass.ServiceID = t.ServiceID
                                WHERE ass.AssignmentID = @AssignmentID";
                        }
                        else if (serviceType == "Guide")
                        {
                            query = @"
                                SELECT 
                                    g.ExperienceYears,
                                    g.Specialization,
                                    g.PricePerDay,
                                    ass.ScheduledDeparture,
                                    ass.ScheduledArrival
                                FROM AssignedService ass
                                JOIN Guide g ON ass.ServiceID = g.ServiceID
                                WHERE ass.AssignmentID = @AssignmentID";
                        }

                        using (SqlCommand command = new SqlCommand(query, connection))
                        {
                            command.Parameters.AddWithValue("@AssignmentID", assignmentId);

                            using (SqlDataReader reader = command.ExecuteReader())
                            {
                                if (reader.Read())
                                {
                                    details.AppendLine($"Assignment ID: {assignmentId}");
                                    details.AppendLine($"Service Type: {serviceType}");

                                    for (int i = 0; i < reader.FieldCount; i++)
                                    {
                                        string columnName = reader.GetName(i);
                                        object value = reader[i];

                                        if (columnName.Contains("Price"))
                                            details.AppendLine($"{FormatColumnName(columnName)}: {string.Format("{0:C}", value)}");
                                        else if (value is DateTime)
                                            details.AppendLine($"{FormatColumnName(columnName)}: {((DateTime)value).ToString("MM/dd/yyyy HH:mm")}");
                                        else
                                            details.AppendLine($"{FormatColumnName(columnName)}: {value}");
                                    }
                                }
                                else
                                {
                                    details.AppendLine("No detailed information found for this booking.");
                                }
                            }
                        }
                    }

                    MessageBox.Show(details.ToString(), "Booking Details", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Error loading details: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
            else
            {
                MessageBox.Show("Please select a booking to view details.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private string FormatColumnName(string columnName)
        {
            // Convert camelCase or PascalCase to spaces
            StringBuilder result = new StringBuilder();
            foreach (char c in columnName)
            {
                if (char.IsUpper(c) && result.Length > 0)
                    result.Append(' ');
                result.Append(c);
            }
            return result.ToString();
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadBookings();
            MessageBox.Show("Booking list refreshed.", "Information", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            string searchTerm = txtSearch.Text.Trim().ToLower();

            if (string.IsNullOrEmpty(searchTerm))
            {
                // Reset to show all rows
                bookingsTable.DefaultView.RowFilter = "";
                return;
            }

            // Create filter for DataView
            StringBuilder filter = new StringBuilder();
            foreach (DataColumn column in bookingsTable.Columns)
            {
                // Skip binary columns or complex data types that can't be converted to string
                if (column.DataType == typeof(byte[]) || column.DataType == typeof(Object))
                    continue;

                if (filter.Length > 0)
                    filter.Append(" OR ");

                filter.Append($"CONVERT({column.ColumnName}, System.String) LIKE '%{searchTerm}%'");
            }

            // Apply the filter
            bookingsTable.DefaultView.RowFilter = filter.ToString();
        }

        private void cmbServiceTypeFilter_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookings();
        }
    }

    // Simple dialog for updating payment status
    public class PaymentUpdateDialog : Form
    {
        private ComboBox cmbPaymentStatus;
        private TextBox txtAmount;
        private Label lblTotalAmount;
        private Button btnOk;
        private Button btnCancel;
        private string connectionString = "Data Source=YourServer;Initial Catalog=YourDatabase;Integrated Security=True";
        private string bookingId;
        private decimal totalAmount;

        public string PaymentStatus { get; private set; }
        public decimal PaymentAmount { get; private set; }

        public PaymentUpdateDialog(string bookingId, decimal totalAmount)
        {
            this.bookingId = bookingId;
            this.totalAmount = totalAmount;
            InitializeDialog();
        }

        private void InitializeDialog()
        {
            this.Text = "Update Payment Status";
            this.Size = new Size(350, 200);
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
                Size = new Size(200, 25),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbPaymentStatus.Items.AddRange(new string[] { "Not Paid", "Partially Paid", "Fully Paid" });
            cmbPaymentStatus.SelectedIndex = 0;
            cmbPaymentStatus.SelectedIndexChanged += CmbPaymentStatus_SelectedIndexChanged;

            Label lblAmount = new Label
            {
                Text = "Amount Paid:",
                Location = new Point(20, 55),
                AutoSize = true
            };

            txtAmount = new TextBox
            {
                Location = new Point(120, 55),
                Size = new Size(200, 25),
                Text = "0.00"
            };

            lblTotalAmount = new Label
            {
                Text = $"Total Amount: {totalAmount:C}",
                Location = new Point(120, 85),
                AutoSize = true,
                ForeColor = Color.DarkBlue
            };

            btnOk = new Button
            {
                Text = "OK",
                DialogResult = DialogResult.OK,
                Location = new Point(150, 120),
                Size = new Size(80, 30)
            };
            btnOk.Click += BtnOk_Click;

            btnCancel = new Button
            {
                Text = "Cancel",
                DialogResult = DialogResult.Cancel,
                Location = new Point(240, 120),
                Size = new Size(80, 30)
            };

            this.Controls.AddRange(new Control[] { lblStatus, cmbPaymentStatus, lblAmount, txtAmount, lblTotalAmount, btnOk, btnCancel });
            this.AcceptButton = btnOk;
            this.CancelButton = btnCancel;

            // Load current payment info
           // LoadPaymentInfo();
        }

        private void LoadPaymentInfo()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    string query = "SELECT Status, Amount FROM Payment WHERE BookingID = @BookingID";

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", bookingId);

                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                string status = reader["Status"].ToString();
                                decimal amount = Convert.ToDecimal(reader["Amount"]);

                                // Set the combobox
                                for (int i = 0; i < cmbPaymentStatus.Items.Count; i++)
                                {
                                    if (cmbPaymentStatus.Items[i].ToString() == status)
                                    {
                                        cmbPaymentStatus.SelectedIndex = i;
                                        break;
                                    }
                                }

                                txtAmount.Text = amount.ToString("0.00");
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading payment information: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void CmbPaymentStatus_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (cmbPaymentStatus.Text == "Fully Paid")
            {
                txtAmount.Text = totalAmount.ToString("0.00");
                txtAmount.Enabled = false;
            }
            else if (cmbPaymentStatus.Text == "Not Paid")
            {
                txtAmount.Text = "0.00";
                txtAmount.Enabled = false;
            }
            else
            {
                txtAmount.Enabled = true;
            }
        }

        private void BtnOk_Click(object sender, EventArgs e)
        {
            if (!decimal.TryParse(txtAmount.Text, out decimal amount))
            {
                MessageBox.Show("Please enter a valid amount.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (amount < 0 || amount > totalAmount)
            {
                MessageBox.Show($"Amount must be between 0 and {totalAmount}.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Ensure payment status is consistent with amount
            if (amount == 0 && cmbPaymentStatus.Text != "Not Paid")
            {
                cmbPaymentStatus.SelectedText = "Not Paid";
            }
            else if (amount == totalAmount && cmbPaymentStatus.Text != "Fully Paid")
            {
                cmbPaymentStatus.SelectedText = "Fully Paid";
            }
            else if (amount > 0 && amount < totalAmount && cmbPaymentStatus.Text != "Partially Paid")
            {
                cmbPaymentStatus.SelectedText = "Partially Paid";
            }

            // Save to database
            try
            {
                PaymentStatus = cmbPaymentStatus.Text;
                PaymentAmount = amount;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Check if payment record exists
                    string checkQuery = "SELECT COUNT(*) FROM Payment WHERE BookingID = @BookingID";
                    bool paymentExists = false;

                    using (SqlCommand checkCommand = new SqlCommand(checkQuery, connection))
                    {
                        checkCommand.Parameters.AddWithValue("@BookingID", bookingId);
                        paymentExists = (int)checkCommand.ExecuteScalar() > 0;
                    }

                    string query;
                    if (paymentExists)
                    {
                        query = "UPDATE Payment SET Status = @Status, Amount = @Amount WHERE BookingID = @BookingID";
                    }
                    else
                    {
                        query = "INSERT INTO Payment (BookingID, Status, Amount) VALUES (@BookingID, @Status, @Amount)";
                    }

                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@BookingID", bookingId);
                        command.Parameters.AddWithValue("@Status", PaymentStatus);
                        command.Parameters.AddWithValue("@Amount", PaymentAmount);
                        command.ExecuteNonQuery();
                    }
                }

                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating payment: {ex.Message}", "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }

    // Helper class for combo box items with display text and actual value
    public class ComboBoxItem
    {
        public string Value { get; set; }
        public string Display { get; set; }

        public override string ToString()
        {
            return Display;
        }
    }
}