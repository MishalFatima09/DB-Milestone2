using System;
using System.Windows.Forms;
using TravelEase.Forms;

namespace TravelEase
{
    static class Program
    {
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new LoginForm());
        }

        public static void LaunchRoleForm(string role, Form currentForm)
        {
            Form roleForm = null;

            if (role == "Admin")
            {
                roleForm = new AdminMainForm();
            }
            else if (role == "Operator")
            {
                roleForm = new OperatorMainForm();
            }
            else if (role == "Traveler")
            {
                roleForm = new TravelerMainForm();
            }
            else if (role == "Provider")
            {
                roleForm = new ProviderMainForm();
            }
            else
            {
                throw new InvalidOperationException($"Unknown role: {role}");
                
            }


            if (roleForm != null)
            {
                currentForm.Hide();
                roleForm.FormClosed += (s, args) => currentForm.Close();
                roleForm.Show();
            }
        }

    }
}
