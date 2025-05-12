using System;
using System.Data.SqlClient;
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

        private string GetOperatorIDFromDatabase(string username, string password)
        {
            string 
                String = "Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;"; 
            string operatorID = null;

            using (SqlConnection conn = new SqlConnection(DbConfig.ConnectionString))
            {
                conn.Open();

                string query = @"
            SELECT U.UserID
            FROM Users U
            WHERE U.Username = @username AND U.Password = @password AND U.Type = 'Operator'
        ";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@username", username);
                    cmd.Parameters.AddWithValue("@password", password);

                    using (SqlDataReader reader = cmd.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            operatorID = reader["UserID"].ToString();
                        }
                    }
                }
            }

            return operatorID;
        }


        private void BtnLogin_Click(object sender, EventArgs e)
        {
            string selectedRole = cmbRole.SelectedItem.ToString();
            Type formType = null;

            if (selectedRole == "Admin")
                formType = typeof(AdminMainForm);
            else if (selectedRole == "Operator")
            {
                // Validate credentials (mock example)
                string enteredUsername = txtUsername.Text;
                string enteredPassword = txtPassword.Text;

                // Replace this with your actual database check logic
                string operatorID = GetOperatorIDFromDatabase(enteredUsername, enteredPassword); // Example

                if (operatorID != null)
                {
                    this.Hide();
                    var t = new System.Threading.Thread(() =>
                    {
                        Application.Run(new OperatorMainForm(operatorID)); 
                    });
                    t.SetApartmentState(System.Threading.ApartmentState.STA);
                    t.Start();
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Invalid login for Operator.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
                return;
            }
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
