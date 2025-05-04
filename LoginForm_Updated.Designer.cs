using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase
{
    public partial class LoginForm : Form
    {
        private ComboBox cmbRole;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnRegister;
        private Label lblTitle;

        private void InitializeComponent()
        {
            this.Text = "Login";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = ColorTranslator.FromHtml("#BFD7EA");

            lblTitle = new Label
            {
                Text = "TravelEase Login",
                Font = new Font("Tahoma", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                AutoSize = true,
                Location = new Point(110, 20)
            };

            Label lblRole = new Label
            {
                Text = "Select Role:",
                Location = new Point(50, 80),
                Font = new Font("Calibri", 10),
                AutoSize = true
            };

            cmbRole = new ComboBox
            {
                Location = new Point(150, 78),
                Width = 180,
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            cmbRole.Items.AddRange(new string[] { "Admin", "Operator", "Traveler", "Provider" });
            cmbRole.SelectedIndex = 0;
            cmbRole.SelectedIndexChanged += RoleChanged;

            Label lblUsername = new Label
            {
                Text = "Username:",
                Location = new Point(50, 120),
                Font = new Font("Calibri ", 10),
                AutoSize = true
            };

            txtUsername = new TextBox
            {
                Location = new Point(150, 118),
                Width = 180
            };

            Label lblPassword = new Label
            {
                Text = "Password:",
                Location = new Point(50, 160),
                Font = new Font("Calibri", 10),
                AutoSize = true
            };

            txtPassword = new TextBox
            {
                Location = new Point(150, 158),
                Width = 180,
                UseSystemPasswordChar = true
            };

            btnLogin = new Button
            {
                Text = "LOGIN",
                Location = new Point(150, 200),
                Width = 180,
                BackColor = Color.FromArgb(11, 57, 84),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            btnRegister = new Button
            {
                Text = "REGISTER",
                Location = new Point(150, 240),
                Width = 180,
                BackColor = Color.FromArgb(11, 57, 84),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblRole, cmbRole, lblUsername, txtUsername,
                lblPassword, txtPassword, btnLogin, btnRegister
            });

            this.Load += new EventHandler(LoginForm_Load);
        }
    }
}
