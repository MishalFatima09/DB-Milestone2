using System;
using System.Windows.Forms;
using TravelEase.Forms;

namespace TravelEase
{
    public partial class LoginForm : Form
    {
        public LoginForm()
        {
            InitializeComponent();
            RoleChanged(null, null); // Initialize visibility
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {
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
