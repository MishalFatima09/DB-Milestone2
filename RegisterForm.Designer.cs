using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase
{
    partial class RegisterForm
    {
        private Label lblHeader;
        private Label lblUsername;
        private TextBox txtUsername;
        private Label lblPassword;
        private TextBox txtPassword;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Button btnSubmit;

        private void InitializeComponent()
        {
            // Form properties
            this.Text = "Register";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;
            this.Load += RegisterForm_Load;

            // Header label
            lblHeader = new Label
            {
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                AutoSize = true,
                Location = new Point(90, 20)
            };

            // Username
            lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(40, 80),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };
            txtUsername = new TextBox
            {
                Location = new Point(150, 78),
                Width = 180
            };

            // Password
            lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(40, 120),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };
            txtPassword = new TextBox
            {
                Location = new Point(150, 118),
                Width = 180,
                UseSystemPasswordChar = true
            };

            // Email
            lblEmail = new Label
            {
                Text = "Email:",
                Location = new Point(40, 160),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };
            txtEmail = new TextBox
            {
                Location = new Point(150, 158),
                Width = 180
            };

            // Phone
            lblPhone = new Label
            {
                Text = "Phone:",
                Location = new Point(40, 200),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };
            txtPhone = new TextBox
            {
                Location = new Point(150, 198),
                Width = 180
            };

            // Submit button
            btnSubmit = new Button
            {
                Text = "Register",
                Location = new Point(150, 250),
                Width = 180,
                BackColor = Color.FromArgb(50, 90, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSubmit.FlatAppearance.BorderSize = 0;

            // Add controls
            this.Controls.AddRange(new Control[]
            {
                lblHeader,
                lblUsername, txtUsername,
                lblPassword, txtPassword,
                lblEmail, txtEmail,
                lblPhone, txtPhone,
                btnSubmit
            });
        }
    }
}
