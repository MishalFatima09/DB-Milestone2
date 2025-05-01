using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public class EditProfileForm : Form
    {
        public EditProfileForm()
        {
            this.Dock = DockStyle.Fill;
            this.BackColor = Color.White;

            Label lbl = new Label
            {
                Text = "✏️ Edit Profile",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                Location = new Point(30, 20),
                AutoSize = true
            };

            Label lblName = new Label { Text = "Full Name:", Location = new Point(30, 70), AutoSize = true };
            TextBox txtName = new TextBox { Location = new Point(150, 68), Width = 200 };

            Label lblEmail = new Label { Text = "Email:", Location = new Point(30, 110), AutoSize = true };
            TextBox txtEmail = new TextBox { Location = new Point(150, 108), Width = 200 };

            Label lblPhone = new Label { Text = "Phone:", Location = new Point(30, 150), AutoSize = true };
            TextBox txtPhone = new TextBox { Location = new Point(150, 148), Width = 200 };

            Button btnSave = new Button
            {
                Text = "💾 Save",
                Location = new Point(150, 200),
                Width = 100,
                BackColor = Color.FromArgb(50, 150, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSave.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[] { lbl, lblName, txtName, lblEmail, txtEmail, lblPhone, txtPhone, btnSave });
        }
    }
}
