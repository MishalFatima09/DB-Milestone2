using System;
using System.Windows.Forms;
using TravelEase.Forms;
using System.Data.SqlClient;
using DB_M2_Chat;

namespace TravelEase
{
    public partial class LoginForm : Form
    {
        // Connection string - consider moving to app.config in a real application
        private readonly string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

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
            string username = txtUsername.Text.Trim();
            string password = txtPassword.Text;

            // Validate inputs
            if (string.IsNullOrEmpty(username) || string.IsNullOrEmpty(password))
            {
                MessageBox.Show("Please enter both username and password.", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            // Authentication logic using Users table
            try
            {
                string userId = null;
                string userType = null;
                string fullName = null;

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // First, authenticate the user in the Users table
                    string authQuery = "SELECT UserID, Type FROM Users WHERE Username = @Username AND Password = @Password";

                    if (selectedRole != "Admin") // Add role filter for non-admin roles
                    {
                        authQuery += " AND Type = @Type";
                    }

                    SqlCommand authCommand = new SqlCommand(authQuery, connection);
                    authCommand.Parameters.AddWithValue("@Username", username);
                    authCommand.Parameters.AddWithValue("@Password", password);

                    if (selectedRole != "Admin")
                    {
                        authCommand.Parameters.AddWithValue("@Type", selectedRole);
                    }

                    using (SqlDataReader reader = authCommand.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            userId = reader["UserID"].ToString();
                            userType = reader["Type"].ToString();
                        }
                        else
                        {
                            MessageBox.Show("Invalid username or password.", "Authentication Failed", MessageBoxButtons.OK, MessageBoxIcon.Error);
                            return;
                        }
                    }

                    // If we have a valid UserID, get additional information based on the role
                    if (!string.IsNullOrEmpty(userId))
                    {
                        switch (selectedRole)
                        {
                            case "Provider":
                                string providerQuery = "SELECT Organisation FROM ServiceProvider WHERE ProviderID = @UserID";
                                SqlCommand providerCommand = new SqlCommand(providerQuery, connection);
                                providerCommand.Parameters.AddWithValue("@UserID", userId);

                                using (SqlDataReader reader = providerCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        fullName = reader["Organisation"].ToString();
                                    }
                                }
                                break;

                            case "Admin":
                                // Admin doesn't require additional information for this example
                                fullName = "Administrator";
                                break;

                            case "Operator":
                                // Get operator name if needed
                                string operatorQuery = "SELECT OperatorName FROM Operator WHERE OperatorID = @UserID";
                                SqlCommand operatorCommand = new SqlCommand(operatorQuery, connection);
                                operatorCommand.Parameters.AddWithValue("@UserID", userId);

                                using (SqlDataReader reader = operatorCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        fullName = reader["OperatorName"].ToString();
                                    }
                                }
                                break;

                            case "Traveler":
                                // Get traveler name
                                string travelerQuery = "SELECT FirstName + ' ' + LastName AS TravelerName FROM Traveler WHERE TravelerID = @UserID";
                                SqlCommand travelerCommand = new SqlCommand(travelerQuery, connection);
                                travelerCommand.Parameters.AddWithValue("@UserID", userId);

                                using (SqlDataReader reader = travelerCommand.ExecuteReader())
                                {
                                    if (reader.Read())
                                    {
                                        fullName = reader["TravelerName"].ToString();
                                    }
                                }
                                break;
                        }
                    }
                }

                // Store user information in UserSession for later use
                UserSession.Instance.SetUserInfo(userId, username, fullName ?? username);

                // Login successful
                MessageBox.Show($"Login successful! Welcome {fullName ?? username}.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                // Get form type based on role
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
                    Form targetForm = (Form)Activator.CreateInstance(formType);

                    var t = new System.Threading.Thread(() =>
                    {
                        Application.Run(targetForm);
                    });
                    t.SetApartmentState(System.Threading.ApartmentState.STA);
                    t.Start();
                    this.Close();
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error during login: {ex.Message}", "Login Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
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