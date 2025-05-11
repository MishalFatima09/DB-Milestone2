using System;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    public partial class AddTripForm : Form
    {
        private string _operatorID;

        public AddTripForm(string operatorID)
        {
            InitializeComponent(); // Loads from .Designer.cs
            _operatorID = operatorID;
        }

        private void AddTripForm_Load(object sender, EventArgs e)
        {
            // Optional: Put load-time logic here
        }

        private void AddTripForm_Load_1(object sender, EventArgs e)
        {

        }

        private void btnAddTrip_Click(object sender, EventArgs e)
        {
            // Connection string (adjust for your setup)
            string connectionString = "Data Source=MISHALSLAPPY\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;";

            // Collect data from form
            string title = txtTitle.Text.Trim();
            string description = txtDescription.Text.Trim();
            decimal price = numPrice.Value;
            int duration = (int)numDuration.Value;
            int capacity = (int)numCapacity.Value;
            string tripType = cmbTripType.SelectedItem?.ToString();
            int accessibility = (int)numAccessibility.Value;
            int sustainability = (int)numSustainability.Value;
            string category = cmbCategory.SelectedItem?.ToString();
            string operatorID = _operatorID;
            string tripID = "TP" + Guid.NewGuid().ToString("N").Substring(0, 7).ToUpper();

            // Basic validation
            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(tripType) || string.IsNullOrEmpty(category))
            {
                MessageBox.Show("Please fill in all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Insert into database
            using (SqlConnection conn = new SqlConnection(connectionString))
            {
                string query = @"INSERT INTO Trip 
                (TripID, Title, Description, Price, Duration, Capacity, TripType, AccessibilityScore, Sustainability_Score, TourCategory, OperatorID)
                VALUES 
                (@TripID, @Title, @Description, @Price, @Duration, @Capacity, @TripType, @Accessibility, @Sustainability, @Category, @OperatorID)";

                using (SqlCommand cmd = new SqlCommand(query, conn))
                {
                    cmd.Parameters.AddWithValue("@TripID", tripID);
                    cmd.Parameters.AddWithValue("@Title", title);
                    cmd.Parameters.AddWithValue("@Description", description);
                    cmd.Parameters.AddWithValue("@Price", price);
                    cmd.Parameters.AddWithValue("@Duration", duration);
                    cmd.Parameters.AddWithValue("@Capacity", capacity);
                    cmd.Parameters.AddWithValue("@TripType", tripType);
                    cmd.Parameters.AddWithValue("@Accessibility", accessibility);
                    cmd.Parameters.AddWithValue("@Sustainability", sustainability);
                    cmd.Parameters.AddWithValue("@Category", category);
                    cmd.Parameters.AddWithValue("@OperatorID", operatorID);

                    try
                    {
                        conn.Open();
                        cmd.ExecuteNonQuery();
                        MessageBox.Show("Trip added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);
                        this.Close(); // or clear the form if needed
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

    }
}
