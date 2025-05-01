using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class ManageTripsForm : Form
    {
        public ManageTripsForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "📋 Manage Trips",
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
            dgv.Columns.Add("TripName", "Trip Name");
            dgv.Columns.Add("Destination", "Destination");
            dgv.Columns.Add("Price", "Price");
            dgv.Columns.Add("Capacity", "Capacity");

            dgv.Rows.Add("Safari Adventure", "Kenya", "$1800", "15");
            dgv.Rows.Add("Ski Resort", "Switzerland", "$3000", "10");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }
    }
}
