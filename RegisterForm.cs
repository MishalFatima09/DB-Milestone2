using System;
using System.Windows.Forms;

namespace TravelEase
{
    public partial class RegisterForm : Form
    {
        public RegisterForm(string role)
        {
            InitializeComponent();
            lblHeader.Text = $"📝 {role} Registration";
        }

        private void RegisterForm_Load(object sender, EventArgs e)
        {
            // any startup logic
        }
    }
}
