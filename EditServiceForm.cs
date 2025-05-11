using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    public partial class EditServiceForm : Form
    {
        private readonly string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";
        private readonly string serviceID;
        private readonly string serviceType;
        private readonly string providerID;

        public EditServiceForm(string serviceID, string serviceType)
        {
            InitializeComponent();
            this.serviceID = serviceID;
            this.serviceType = serviceType;
            this.providerID = UserSession.Instance.ProviderID;
            LoadServiceData();
        }

        private void LoadServiceData()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Load base service data
                    string query = "SELECT Name FROM Service WHERE ServiceID = @ServiceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        using (SqlDataReader reader = command.ExecuteReader())
                        {
                            if (reader.Read())
                            {
                                txtServiceName.Text = reader["Name"].ToString();
                            }
                        }
                    }

                    // Load service-specific data
                    LoadTypeSpecificData(connection);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading service data: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void LoadTypeSpecificData(SqlConnection connection)
        {
            string query = "";

            switch (serviceType)
            {
                case "Guide":
                    query = "SELECT ExperienceYears, Specialization, PricePerDay FROM Guide WHERE ServiceID = @ServiceID";
                    break;
                case "Hotel":
                    query = "SELECT Address, AvailableRooms, Facilities FROM Hotel WHERE ServiceID = @ServiceID";
                    break;
                case "Transport":
                    query = "SELECT VehicleNum, VehicleType, Capacity, PricePerTicket FROM Transport WHERE ServiceID = @ServiceID";
                    break;
            }

            if (!string.IsNullOrEmpty(query))
            {
                using (SqlCommand command = new SqlCommand(query, connection))
                {
                    command.Parameters.AddWithValue("@ServiceID", serviceID);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            switch (serviceType)
                            {
                                case "Guide":
                                    txtField1.Text = reader["ExperienceYears"].ToString();
                                    txtField2.Text = reader["Specialization"].ToString();
                                    txtField3.Text = reader["PricePerDay"].ToString();
                                    break;
                                case "Hotel":
                                    txtField1.Text = reader["Address"].ToString();
                                    txtField2.Text = reader["AvailableRooms"].ToString();
                                    txtField3.Text = reader["Facilities"].ToString();
                                    break;
                                case "Transport":
                                    txtField1.Text = reader["VehicleNum"].ToString();
                                    txtField2.Text = reader["VehicleType"].ToString();
                                    txtField3.Text = reader["Capacity"].ToString();
                                    txtField4.Text = reader["PricePerTicket"].ToString();
                                    break;
                            }
                        }
                    }
                }
            }
        }

        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                if (string.IsNullOrWhiteSpace(txtServiceName.Text))
                {
                    MessageBox.Show("Service name cannot be empty.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                    return;
                }

                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();

                    // Update base service data
                    using (SqlCommand command = new SqlCommand("UPDATE Service SET Name = @Name WHERE ServiceID = @ServiceID", connection))
                    {
                        command.Parameters.AddWithValue("@Name", txtServiceName.Text);
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        command.ExecuteNonQuery();
                    }

                    // Update service-specific data
                    UpdateTypeSpecificData(connection);
                }

                MessageBox.Show("Service updated successfully.", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                this.DialogResult = DialogResult.OK;
                this.Close();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error updating service: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateTypeSpecificData(SqlConnection connection)
        {
            string query = "";

            switch (serviceType)
            {
                case "Guide":
                    if (!int.TryParse(txtField1.Text, out int experienceYears) || experienceYears < 0)
                    {
                        throw new Exception("Experience years must be a valid positive number.");
                    }
                    if (!decimal.TryParse(txtField3.Text, out decimal pricePerDay) || pricePerDay < 0)
                    {
                        throw new Exception("Price per day must be a valid positive number.");
                    }

                    query = "UPDATE Guide SET ExperienceYears = @Field1, Specialization = @Field2, PricePerDay = @Field3 WHERE ServiceID = @ServiceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Field1", experienceYears);
                        command.Parameters.AddWithValue("@Field2", txtField2.Text);
                        command.Parameters.AddWithValue("@Field3", pricePerDay);
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        command.ExecuteNonQuery();
                    }
                    break;

                case "Hotel":
                    if (!int.TryParse(txtField2.Text, out int availableRooms) || availableRooms < 0)
                    {
                        throw new Exception("Available rooms must be a valid positive number.");
                    }

                    query = "UPDATE Hotel SET Address = @Field1, AvailableRooms = @Field2, Facilities = @Field3 WHERE ServiceID = @ServiceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Field1", txtField1.Text);
                        command.Parameters.AddWithValue("@Field2", availableRooms);
                        command.Parameters.AddWithValue("@Field3", txtField3.Text);
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        command.ExecuteNonQuery();
                    }
                    break;

                case "Transport":
                    if (!int.TryParse(txtField3.Text, out int capacity) || capacity < 0)
                    {
                        throw new Exception("Capacity must be a valid positive number.");
                    }
                    if (!decimal.TryParse(txtField4.Text, out decimal pricePerTicket) || pricePerTicket < 0)
                    {
                        throw new Exception("Price per ticket must be a valid positive number.");
                    }

                    query = "UPDATE Transport SET VehicleNum = @Field1, VehicleType = @Field2, Capacity = @Field3, PricePerTicket = @Field4 WHERE ServiceID = @ServiceID";
                    using (SqlCommand command = new SqlCommand(query, connection))
                    {
                        command.Parameters.AddWithValue("@Field1", txtField1.Text);
                        command.Parameters.AddWithValue("@Field2", txtField2.Text);
                        command.Parameters.AddWithValue("@Field3", capacity);
                        command.Parameters.AddWithValue("@Field4", pricePerTicket);
                        command.Parameters.AddWithValue("@ServiceID", serviceID);
                        command.ExecuteNonQuery();
                    }
                    break;
            }
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            this.DialogResult = DialogResult.Cancel;
            this.Close();
        }
    }
}