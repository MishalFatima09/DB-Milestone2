//using System;
//using System.Collections.Generic;
//using System.ComponentModel;
//using System.Data;
//using System.Drawing;
//using System.Linq;
//using System.Text;
//using System.Threading.Tasks;
//using System.Windows.Forms;

//namespace DB_M2_Chat
//{
//    public partial class AddServiceForm : Form
//    {
//        public AddServiceForm()
//        {
//            InitializeComponent();
//        }

//        private void AddServiceForm_Load(object sender, EventArgs e)
//        {
//            // Populate service type combobox
//            cmbServiceType.Items.AddRange(new string[] {
//                "Hotel Room",
//                "Transportation",
//                "Tour Package",
//                "Event Ticket",
//                "Restaurant Reservation",
//                "Activity"
//            });

//            // Set default selection
//            cmbServiceType.SelectedIndex = 0;

//            // Update dynamic fields for default selection
//            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
//        }

//        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
//        {
//            string selectedType = cmbServiceType.SelectedItem.ToString();
//            UpdateDynamicFields(selectedType);
//        }

//        private void UpdateDynamicFields(string serviceType)
//        {
//            // Clear existing dynamic fields
//            panelDynamicFields.Controls.Clear();

//            // Common fields - always present at the top
//            int yPosition = 10;

//            // Add dynamic fields based on service type
//            switch (serviceType)
//            {
//                case "Hotel Room":
//                    AddDynamicField("Room Type:", "cmbRoomType", yPosition, true);
//                    yPosition += 40;
//                    string[] roomTypes = { "Standard", "Deluxe", "Suite", "Executive", "Presidential" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbRoomType"]).Items.AddRange(roomTypes);
//                    ((ComboBox)panelDynamicFields.Controls["cmbRoomType"]).SelectedIndex = 0;

//                    AddDynamicField("Bed Configuration:", "cmbBedConfig", yPosition, true);
//                    yPosition += 40;
//                    string[] bedConfigs = { "Single", "Double", "Twin", "King", "Queen" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbBedConfig"]).Items.AddRange(bedConfigs);
//                    ((ComboBox)panelDynamicFields.Controls["cmbBedConfig"]).SelectedIndex = 0;

//                    AddDynamicField("Maximum Occupancy:", "txtMaxOccupancy", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Amenities (comma separated):", "txtAmenities", yPosition);
//                    break;

//                case "Transportation":
//                    AddDynamicField("Vehicle Type:", "cmbVehicleType", yPosition, true);
//                    yPosition += 40;
//                    string[] vehicleTypes = { "Sedan", "SUV", "Van", "Minibus", "Bus", "Luxury Car" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).Items.AddRange(vehicleTypes);
//                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).SelectedIndex = 0;

//                    AddDynamicField("Capacity:", "txtCapacity", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Driver Included:", "chkDriverIncluded", yPosition, false, true);
//                    yPosition += 40;

//                    AddDynamicField("Vehicle Model:", "txtModel", yPosition);
//                    break;

//                case "Tour Package":
//                    AddDynamicField("Duration (hours):", "txtDuration", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Languages Available:", "txtLanguages", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Group Size Limit:", "txtGroupSize", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Includes Meals:", "chkMeals", yPosition, false, true);
//                    break;

//                case "Event Ticket":
//                    AddDynamicField("Event Date:", "dtpEventDate", yPosition, false, false, true);
//                    yPosition += 40;

//                    AddDynamicField("Event Type:", "cmbEventType", yPosition, true);
//                    yPosition += 40;
//                    string[] eventTypes = { "Concert", "Sports", "Theater", "Exhibition", "Festival" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbEventType"]).Items.AddRange(eventTypes);
//                    ((ComboBox)panelDynamicFields.Controls["cmbEventType"]).SelectedIndex = 0;

//                    AddDynamicField("Venue:", "txtVenue", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Seat Category:", "cmbSeatCategory", yPosition, true);
//                    string[] seatCategories = { "General", "VIP", "Premium", "Standard", "Economy" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbSeatCategory"]).Items.AddRange(seatCategories);
//                    ((ComboBox)panelDynamicFields.Controls["cmbSeatCategory"]).SelectedIndex = 0;
//                    break;

//                case "Restaurant Reservation":
//                    AddDynamicField("Cuisine Type:", "cmbCuisine", yPosition, true);
//                    yPosition += 40;
//                    string[] cuisines = { "Italian", "Chinese", "Indian", "French", "Japanese", "Mexican", "Mediterranean" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbCuisine"]).Items.AddRange(cuisines);
//                    ((ComboBox)panelDynamicFields.Controls["cmbCuisine"]).SelectedIndex = 0;

//                    AddDynamicField("Maximum Party Size:", "txtPartySize", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Dress Code:", "cmbDressCode", yPosition, true);
//                    string[] dressCodes = { "Casual", "Smart Casual", "Business Casual", "Formal" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbDressCode"]).Items.AddRange(dressCodes);
//                    ((ComboBox)panelDynamicFields.Controls["cmbDressCode"]).SelectedIndex = 0;
//                    yPosition += 40;

//                    AddDynamicField("Special Accommodations:", "txtSpecial", yPosition);
//                    break;

//                case "Activity":
//                    AddDynamicField("Activity Type:", "cmbActivityType", yPosition, true);
//                    yPosition += 40;
//                    string[] activityTypes = { "Adventure", "Cultural", "Educational", "Relaxation", "Water Sports", "Winter Sports" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbActivityType"]).Items.AddRange(activityTypes);
//                    ((ComboBox)panelDynamicFields.Controls["cmbActivityType"]).SelectedIndex = 0;

//                    AddDynamicField("Difficulty Level:", "cmbDifficulty", yPosition, true);
//                    yPosition += 40;
//                    string[] difficulties = { "Easy", "Moderate", "Challenging", "Expert" };
//                    ((ComboBox)panelDynamicFields.Controls["cmbDifficulty"]).Items.AddRange(difficulties);
//                    ((ComboBox)panelDynamicFields.Controls["cmbDifficulty"]).SelectedIndex = 0;

//                    AddDynamicField("Age Restriction:", "txtAgeRestriction", yPosition);
//                    yPosition += 40;

//                    AddDynamicField("Equipment Provided:", "chkEquipment", yPosition, false, true);
//                    break;
//            }
//        }

//        private void AddDynamicField(string labelText, string controlName, int yPosition, bool isComboBox = false, bool isCheckBox = false, bool isDatePicker = false)
//        {
//            // Create label
//            Label lbl = new Label
//            {
//                Text = labelText,
//                Location = new Point(10, yPosition + 5),
//                Size = new Size(150, 20),
//                Name = "lbl" + controlName,
//                Font = new Font("Segoe UI", 9),
//                ForeColor = Color.FromArgb(11, 57, 84)
//            };

//            // Create input control based on type
//            Control inputControl;

//            if (isCheckBox)
//            {
//                inputControl = new CheckBox
//                {
//                    Location = new Point(170, yPosition + 5),
//                    Size = new Size(300, 20),
//                    Name = controlName,
//                    Font = new Font("Segoe UI", 9)
//                };
//            }
//            else if (isComboBox)
//            {
//                inputControl = new ComboBox
//                {
//                    Location = new Point(170, yPosition),
//                    Size = new Size(300, 25),
//                    Name = controlName,
//                    Font = new Font("Segoe UI", 9),
//                    DropDownStyle = ComboBoxStyle.DropDownList
//                };
//            }
//            else if (isDatePicker)
//            {
//                inputControl = new DateTimePicker
//                {
//                    Location = new Point(170, yPosition),
//                    Size = new Size(300, 25),
//                    Name = controlName,
//                    Font = new Font("Segoe UI", 9),
//                    Format = DateTimePickerFormat.Short
//                };
//            }
//            else
//            {
//                inputControl = new TextBox
//                {
//                    Location = new Point(170, yPosition),
//                    Size = new Size(300, 25),
//                    Name = controlName,
//                    Font = new Font("Segoe UI", 9)
//                };
//            }

//            // Add controls to panel
//            panelDynamicFields.Controls.Add(lbl);
//            panelDynamicFields.Controls.Add(inputControl);
//        }

//        private void btnAddService_Click(object sender, EventArgs e)
//        {
//            // Validate inputs
//            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
//            {
//                MessageBox.Show("Please enter a service name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
//            {
//                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
//                return;
//            }

//            // In a real application, this would save to a database
//            // For now, just show a success message
//            MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

//            // Clear form
//            txtServiceName.Clear();
//            txtDescription.Clear();
//            txtPrice.Clear();
//            cmbServiceType.SelectedIndex = 0;

//            // Reset dynamic fields
//            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
//        }

//        private void btnCancel_Click(object sender, EventArgs e)
//        {
//            // Clear form
//            txtServiceName.Clear();
//            txtDescription.Clear();
//            txtPrice.Clear();
//            cmbServiceType.SelectedIndex = 0;

//            // Reset dynamic fields
//            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
//        }
//    }
//}


using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    public partial class AddServiceForm : Form
    {
        // Database connection string
        private readonly string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
        {
            // Populate service type combobox with the three service types from the database schema
            cmbServiceType.Items.AddRange(new string[] {
                "Guide",
                "Hotel",
                "Transport"
            });

            // Set default selection
            cmbServiceType.SelectedIndex = 0;

            // Update dynamic fields for default selection
            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());

            // Generate new Service ID based on selected service type
            txtServiceID.Text = GenerateNewServiceID();

            // Set provider ID from current session
            txtProviderID.Text = UserSession.Instance.ProviderID;
            txtProviderID.Enabled = false; // Make it read-only
        }

        private string GenerateNewServiceID()
        {
            // Get the selected service type
            string serviceType = cmbServiceType.SelectedItem?.ToString() ?? "Guide";

            // Determine the prefix based on service type
            string prefix;
            switch (serviceType)
            {
                case "Transport":
                    prefix = "TR";
                    break;
                case "Hotel":
                    prefix = "HT";
                    break;
                case "Guide":
                    prefix = "GD";
                    break;
                default:
                    prefix = "SV";
                    break;
            }

            string newID = prefix + "001";
            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open();
                    // Find the last ID with the same prefix
                    string sql = $"SELECT TOP 1 ServiceID FROM Service WHERE ServiceID LIKE '{prefix}%' ORDER BY ServiceID DESC";
                    using (SqlCommand command = new SqlCommand(sql, connection))
                    {
                        var result = command.ExecuteScalar();
                        if (result != null)
                        {
                            string lastID = result.ToString();
                            // Extract the numeric part (last 3 characters)
                            int number = int.Parse(lastID.Substring(2)) + 1;
                            newID = prefix + number.ToString("D3");
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Error generating Service ID: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            return newID;
        }

        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbServiceType.SelectedItem.ToString();
            UpdateDynamicFields(selectedType);

            // Update the Service ID when service type changes
            txtServiceID.Text = GenerateNewServiceID();
        }

        private void UpdateDynamicFields(string serviceType)
        {
            // Clear existing dynamic fields
            panelDynamicFields.Controls.Clear();

            // Common fields - always present at the top
            int yPosition = 10;

            // Add dynamic fields based on service type
            switch (serviceType)
            {
                case "Guide":
                    AddDynamicField("Experience Years:", "txtExperienceYears", yPosition);
                    yPosition += 40;

                    AddDynamicField("Specialization:", "cmbSpecialization", yPosition, true);
                    yPosition += 40;
                    string[] specializations = { "History", "Culture", "Wildlife", "Adventure", "Cuisine", "Architecture", "Art", "Religious Sites" };
                    ((ComboBox)panelDynamicFields.Controls["cmbSpecialization"]).Items.AddRange(specializations);
                    ((ComboBox)panelDynamicFields.Controls["cmbSpecialization"]).SelectedIndex = 0;

                    AddDynamicField("Price Per Day ($):", "txtPricePerDay", yPosition);
                    break;

                case "Hotel":
                    AddDynamicField("Address:", "txtAddress", yPosition);
                    yPosition += 40;

                    AddDynamicField("Available Rooms:", "txtAvailableRooms", yPosition);
                    yPosition += 40;

                    AddDynamicField("Facilities (comma separated):", "txtFacilities", yPosition);
                    break;

                case "Transport":
                    AddDynamicField("Vehicle Number:", "txtVehicleNum", yPosition);
                    yPosition += 40;

                    AddDynamicField("Vehicle Type:", "cmbVehicleType", yPosition, true);
                    yPosition += 40;
                    string[] vehicleTypes = { "Bus", "Train", "Car", "Airplane", "Shuttle", "Taxi", "Van", "Limo", "Boat", "Cruise Ship", "Metro", "Truck" };
                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).Items.AddRange(vehicleTypes);
                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).SelectedIndex = 0;

                    AddDynamicField("Capacity:", "txtCapacity", yPosition);
                    yPosition += 40;

                    AddDynamicField("Price Per Ticket ($):", "txtPricePerTicket", yPosition);
                    break;
            }
        }

        private void AddDynamicField(string labelText, string controlName, int yPosition, bool isComboBox = false)
        {
            // Create label
            Label lbl = new Label
            {
                Text = labelText,
                Location = new Point(10, yPosition + 5),
                Size = new Size(150, 20),
                Name = "lbl" + controlName,
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84)
            };

            // Create input control based on type
            Control inputControl;

            if (isComboBox)
            {
                inputControl = new ComboBox
                {
                    Location = new Point(170, yPosition),
                    Size = new Size(300, 25),
                    Name = controlName,
                    Font = new Font("Segoe UI", 9),
                    DropDownStyle = ComboBoxStyle.DropDownList
                };
            }
            else
            {
                inputControl = new TextBox
                {
                    Location = new Point(170, yPosition),
                    Size = new Size(300, 25),
                    Name = controlName,
                    Font = new Font("Segoe UI", 9)
                };
            }

            // Add controls to panel
            panelDynamicFields.Controls.Add(lbl);
            panelDynamicFields.Controls.Add(inputControl);
        }

        private void btnAddService_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtServiceID.Text) ||
                string.IsNullOrWhiteSpace(txtProviderID.Text) ||
                string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Please fill all required fields.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // Begin database transaction to add service
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlTransaction transaction = connection.BeginTransaction();

                try
                {
                    // 1. Insert into Service table
                    string serviceType = cmbServiceType.SelectedItem.ToString();
                    string insertServiceSql = "INSERT INTO Service (ServiceID, ProviderID, Type, Name) VALUES (@ServiceID, @ProviderID, @Type, @Name)";

                    using (SqlCommand cmd = new SqlCommand(insertServiceSql, connection, transaction))
                    {
                        cmd.Parameters.AddWithValue("@ServiceID", txtServiceID.Text);
                        cmd.Parameters.AddWithValue("@ProviderID", txtProviderID.Text);
                        cmd.Parameters.AddWithValue("@Type", serviceType);
                        cmd.Parameters.AddWithValue("@Name", txtServiceName.Text);
                        cmd.ExecuteNonQuery();
                    }

                    // 2. Insert into specific service type table
                    switch (serviceType)
                    {
                        case "Guide":
                            InsertGuideService(connection, transaction);
                            break;
                        case "Hotel":
                            InsertHotelService(connection, transaction);
                            break;
                        case "Transport":
                            InsertTransportService(connection, transaction);
                            break;
                    }

                    // Commit the transaction
                    transaction.Commit();
                    MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

                    // Clear the form for next entry
                    ClearForm();

                    // Generate new Service ID for next entry
                    txtServiceID.Text = GenerateNewServiceID();
                }
                catch (Exception ex)
                {
                    // Roll back the transaction if something goes wrong
                    transaction.Rollback();
                    MessageBox.Show("Error adding service: " + ex.Message, "Database Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private void InsertGuideService(SqlConnection connection, SqlTransaction transaction)
        {
            // Validation
            if (!int.TryParse(GetDynamicFieldValue("txtExperienceYears"), out int experienceYears))
            {
                throw new Exception("Experience years must be a valid number.");
            }

            if (!decimal.TryParse(GetDynamicFieldValue("txtPricePerDay"), out decimal pricePerDay))
            {
                throw new Exception("Price per day must be a valid number.");
            }

            string specialization = GetDynamicFieldValue("cmbSpecialization");
            if (string.IsNullOrWhiteSpace(specialization))
            {
                throw new Exception("Specialization is required.");
            }

            // Insert into Guide table
            string insertGuideSql = "INSERT INTO Guide (ServiceID, ExperienceYears, Specialization, PricePerDay) " +
                                   "VALUES (@ServiceID, @ExperienceYears, @Specialization, @PricePerDay)";

            using (SqlCommand cmd = new SqlCommand(insertGuideSql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ServiceID", txtServiceID.Text);
                cmd.Parameters.AddWithValue("@ExperienceYears", experienceYears);
                cmd.Parameters.AddWithValue("@Specialization", specialization);
                cmd.Parameters.AddWithValue("@PricePerDay", pricePerDay);
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertHotelService(SqlConnection connection, SqlTransaction transaction)
        {
            // Validation
            string address = GetDynamicFieldValue("txtAddress");
            if (string.IsNullOrWhiteSpace(address))
            {
                throw new Exception("Address is required.");
            }

            if (!int.TryParse(GetDynamicFieldValue("txtAvailableRooms"), out int availableRooms))
            {
                throw new Exception("Available rooms must be a valid number.");
            }

            string facilities = GetDynamicFieldValue("txtFacilities");
            if (string.IsNullOrWhiteSpace(facilities))
            {
                throw new Exception("Facilities information is required.");
            }

            // Insert into Hotel table
            string insertHotelSql = "INSERT INTO Hotel (ServiceID, Address, AvailableRooms, Facilities) " +
                                   "VALUES (@ServiceID, @Address, @AvailableRooms, @Facilities)";

            using (SqlCommand cmd = new SqlCommand(insertHotelSql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ServiceID", txtServiceID.Text);
                cmd.Parameters.AddWithValue("@Address", address);
                cmd.Parameters.AddWithValue("@AvailableRooms", availableRooms);
                cmd.Parameters.AddWithValue("@Facilities", facilities);
                cmd.ExecuteNonQuery();
            }
        }

        private void InsertTransportService(SqlConnection connection, SqlTransaction transaction)
        {
            // Validation
            if (!int.TryParse(GetDynamicFieldValue("txtVehicleNum"), out int vehicleNum))
            {
                throw new Exception("Vehicle number must be a valid number.");
            }

            string vehicleType = GetDynamicFieldValue("cmbVehicleType");
            if (string.IsNullOrWhiteSpace(vehicleType))
            {
                throw new Exception("Vehicle type is required.");
            }

            if (!int.TryParse(GetDynamicFieldValue("txtCapacity"), out int capacity))
            {
                throw new Exception("Capacity must be a valid number.");
            }

            if (!decimal.TryParse(GetDynamicFieldValue("txtPricePerTicket"), out decimal pricePerTicket))
            {
                throw new Exception("Price per ticket must be a valid number.");
            }

            // Insert into Transport table
            string insertTransportSql = "INSERT INTO Transport (ServiceID, VehicleNum, VehicleType, Capacity, PricePerTicket) " +
                                      "VALUES (@ServiceID, @VehicleNum, @VehicleType, @Capacity, @PricePerTicket)";

            using (SqlCommand cmd = new SqlCommand(insertTransportSql, connection, transaction))
            {
                cmd.Parameters.AddWithValue("@ServiceID", txtServiceID.Text);
                cmd.Parameters.AddWithValue("@VehicleNum", vehicleNum);
                cmd.Parameters.AddWithValue("@VehicleType", vehicleType);
                cmd.Parameters.AddWithValue("@Capacity", capacity);
                cmd.Parameters.AddWithValue("@PricePerTicket", pricePerTicket);
                cmd.ExecuteNonQuery();
            }
        }

        private string GetDynamicFieldValue(string controlName)
        {
            if (panelDynamicFields.Controls.ContainsKey(controlName))
            {
                if (panelDynamicFields.Controls[controlName] is TextBox textBox)
                {
                    return textBox.Text;
                }
                else if (panelDynamicFields.Controls[controlName] is ComboBox comboBox)
                {
                    return comboBox.SelectedItem?.ToString() ?? string.Empty;
                }
            }
            return string.Empty;
        }

        private void ClearForm()
        {
            txtServiceName.Clear();
            txtDescription.Clear();
            cmbServiceType.SelectedIndex = 0;

            // Reset dynamic fields
            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear form
            ClearForm();

            // Reset Service ID
            txtServiceID.Text = GenerateNewServiceID();
        }
    }
}