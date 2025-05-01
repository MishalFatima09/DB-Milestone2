using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class AddServiceForm : Form
    {
        public AddServiceForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "➕ Add Service",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            Label lblName = new Label { Text = "Service Name:", Location = new Point(30, 70), AutoSize = true };
            TextBox txtName = new TextBox { Location = new Point(150, 68), Width = 250 };

            Label lblType = new Label { Text = "Type:", Location = new Point(30, 110), AutoSize = true };
            ComboBox cmbType = new ComboBox
            {
                Location = new Point(150, 108),
                Width = 250,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbType.Items.AddRange(new string[] { "Accommodation", "Transport", "Guide", "Other" });
            cmbType.SelectedIndex = 0;

            Button btnSubmit = new Button
            {
                Text = "Add",
                Location = new Point(150, 160),
                Width = 100,
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSubmit.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lbl, lblName, txtName, lblType, cmbType, btnSubmit });
        }
    }
}
