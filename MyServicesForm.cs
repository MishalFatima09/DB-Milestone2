using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class MyServicesForm : Form
    {
        public MyServicesForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "🏷️ My Services",
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

            dgv.Columns.Add("ServiceID", "Service ID");
            dgv.Columns.Add("ServiceName", "Service Name");
            dgv.Columns.Add("Type", "Type");

            dgv.Rows.Add("S001", "Oceanview Hotel", "Accommodation");
            dgv.Rows.Add("S002", "City Van", "Transport");

            this.Controls.Add(lbl);
            this.Controls.Add(dgv);
        }
    }
}
