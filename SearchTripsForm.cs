using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class SearchTripsForm : Form
    {
        public SearchTripsForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "🔍 Search Trips",
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

            dgv.Columns.Add("Trip", "Trip Name");
            dgv.Columns.Add("Destination", "Destination");
            dgv.Columns.Add("Date", "Date");
            dgv.Columns.Add("Price", "Price");

            dgv.Rows.Add("Cultural Tour", "Italy", "2025-06-10", "$1500");
            dgv.Rows.Add("Mountain Hiking", "Nepal", "2025-07-22", "$2200");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }
    }
}
