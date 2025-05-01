using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase
{
    public class RegisterForm : Form
    {
        public RegisterForm(string role)
        {
            this.Text = "Register";
            this.Size = new Size(400, 400);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            Label lblHeader = new Label
            {
                Text = $"📝 {role} Registration",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                AutoSize = true,
                Location = new Point(90, 20)
            };

            Label lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(40, 80),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            TextBox txtUsername = new TextBox
            {
                Location = new Point(150, 78),
                Width = 180
            };

            Label lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(40, 120),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            TextBox txtPassword = new TextBox
            {
                Location = new Point(150, 118),
                Width = 180,
                UseSystemPasswordChar = true
            };

            Label lblEmail = new Label
            {
                Text = "Email:",
                Location = new Point(40, 160),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            TextBox txtEmail = new TextBox
            {
                Location = new Point(150, 158),
                Width = 180
            };

            Label lblPhone = new Label
            {
                Text = "Phone:",
                Location = new Point(40, 200),
                Font = new Font("Segoe UI", 10),
                AutoSize = true
            };

            TextBox txtPhone = new TextBox
            {
                Location = new Point(150, 198),
                Width = 180
            };

            Button btnSubmit = new Button
            {
                Text = "Register",
                Location = new Point(150, 250),
                Width = 180,
                BackColor = Color.FromArgb(50, 90, 50),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnSubmit.FlatAppearance.BorderSize = 0;

            this.Controls.AddRange(new Control[]
            {
                lblHeader, lblUsername, txtUsername, lblPassword, txtPassword,
                lblEmail, txtEmail, lblPhone, txtPhone, btnSubmit
            });
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // RegisterForm
            // 
            this.ClientSize = new System.Drawing.Size(284, 261);
            this.Name = "RegisterForm";
            this.Load += new System.EventHandler(this.RegisterForm_Load);
            this.ResumeLayout(false);

        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {

        }
    }
}
