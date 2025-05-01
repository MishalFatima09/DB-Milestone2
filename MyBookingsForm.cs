using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class MyBookingsForm : Form
    {
        public MyBookingsForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.FromArgb(191, 215, 234);

            Label lbl = new Label
            {
                Text = "📅 My Bookings",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
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

            dgv.Columns.Add("Trip", "Trip Name");
            dgv.Columns.Add("BookingDate", "Booking Date");
            dgv.Columns.Add("Status", "Status");

            dgv.Rows.Add("Cultural Tour", "2025-05-01", "Confirmed");
            dgv.Rows.Add("Mountain Hiking", "2025-05-05", "Pending");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // MyBookingsForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "MyBookingsForm";
            this.Load += new System.EventHandler(this.MyBookingsForm_Load);
            this.ResumeLayout(false);

        }

        private void MyBookingsForm_Load(object sender, EventArgs e)
        {

        }
    }
}
