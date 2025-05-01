using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class BookingRequestsForm : Form
    {
        public BookingRequestsForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "📩 Booking Requests",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            DataGridView dgv = new DataGridView
            {
                Location = new Point(30, 60),
                Size = new Size(800, 300),
                ReadOnly = true,
                AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill
            };

            dgv.Columns.Add("RequestID", "Request ID");
            dgv.Columns.Add("Service", "Service");
            dgv.Columns.Add("RequestedBy", "Requested By");
            dgv.Columns.Add("Date", "Date");
            dgv.Columns.Add("Status", "Status");

            dgv.Rows.Add("BR101", "Hotel Paradise", "Ali Raza", "2025-06-01", "Pending");
            dgv.Rows.Add("BR102", "Local Transport", "Sana Khan", "2025-06-03", "Confirmed");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }
    }
}
