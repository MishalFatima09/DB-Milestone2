using System;
using System.Drawing;
using System.Windows.Forms;
using TravelEase.Forms;

namespace TravelEase
{
    public class LoginForm : Form
    {
        private ComboBox cmbRole;
        private TextBox txtUsername, txtPassword;
        private Button btnLogin, btnRegister;
        private Label lblTitle;

        public LoginForm()
        {
            this.Text = "Login";
            this.Size = new Size(400, 350);
            this.StartPosition = FormStartPosition.CenterScreen;
            this.BackColor = Color.White;

            lblTitle = new Label
            {
                Text = "TravelEase Login",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = Color.FromArgb(30, 30, 60),
                AutoSize = true,
                Location = new Point(110, 20)
            };

            Label lblRole = new Label
            {
                Text = "Select Role:",
                Location = new Point(50, 80),
                Font = new Font("Segoe UI", 10),
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
                Font = new Font("Segoe UI", 10),
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
                Font = new Font("Segoe UI", 10),
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
                Text = "🔐 Login",
                Location = new Point(150, 200),
                Width = 180,
                BackColor = Color.FromArgb(50, 50, 90),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnLogin.FlatAppearance.BorderSize = 0;
            btnLogin.Click += BtnLogin_Click;

            btnRegister = new Button
            {
                Text = "📝 Register",
                Location = new Point(150, 240),
                Width = 180,
                BackColor = Color.FromArgb(30, 130, 76),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat
            };
            btnRegister.FlatAppearance.BorderSize = 0;
            btnRegister.Click += BtnRegister_Click;

            this.Controls.AddRange(new Control[] {
                lblTitle, lblRole, cmbRole, lblUsername, txtUsername,
                lblPassword, txtPassword, btnLogin, btnRegister
            });

            RoleChanged(null, null); // Initialize
        }

        private void RoleChanged(object sender, EventArgs e)
        {
            string selected = cmbRole.SelectedItem.ToString();
            btnRegister.Visible = selected != "Admin";
        }

        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem.ToString();
            Type formType = null;

            if (selectedRole == "Admin")
                formType = typeof(AdminMainForm);
            else if (selectedRole == "Operator")
                formType = typeof(OperatorMainForm);
            else if (selectedRole == "Traveler")
                formType = typeof(TravelerMainForm);
            else if (selectedRole == "Provider")
                formType = typeof(ProviderMainForm);

            if (formType != null)
            {
                this.Hide();
                var t = new System.Threading.Thread(() =>
                {
                    Application.Run((Form)Activator.CreateInstance(formType));
                });
                t.SetApartmentState(System.Threading.ApartmentState.STA);
                t.Start();
                this.Close();
            }
        }


        private void BtnRegister_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem.ToString();
            var regForm = new RegisterForm(selectedRole);
            regForm.ShowDialog();
        }
    }
}
