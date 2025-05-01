using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class AddTripForm : Form
    {
        public AddTripForm()
        {
            this.Text = "AddTripForm";
            this.FormBorderStyle = FormBorderStyle.None;
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "➕ Operator - Add Trip",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                Location = new Point(30, 30),
                AutoSize = true
            };

            this.Controls.Add(lbl);
        }
    }
}
