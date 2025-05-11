using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    public partial class AddServiceForm : Form
    {
        public AddServiceForm()
        {
            InitializeComponent();
        }

        private void AddServiceForm_Load(object sender, EventArgs e)
        {
            // Populate service type combobox
            cmbServiceType.Items.AddRange(new string[] {
                "Hotel Room",
                "Transportation",
                "Tour Package",
                "Event Ticket",
                "Restaurant Reservation",
                "Activity"
            });

            // Set default selection
            cmbServiceType.SelectedIndex = 0;

            // Update dynamic fields for default selection
            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
        }

        private void cmbServiceType_SelectedIndexChanged(object sender, EventArgs e)
        {
            string selectedType = cmbServiceType.SelectedItem.ToString();
            UpdateDynamicFields(selectedType);
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
                case "Hotel Room":
                    AddDynamicField("Room Type:", "cmbRoomType", yPosition, true);
                    yPosition += 40;
                    string[] roomTypes = { "Standard", "Deluxe", "Suite", "Executive", "Presidential" };
                    ((ComboBox)panelDynamicFields.Controls["cmbRoomType"]).Items.AddRange(roomTypes);
                    ((ComboBox)panelDynamicFields.Controls["cmbRoomType"]).SelectedIndex = 0;

                    AddDynamicField("Bed Configuration:", "cmbBedConfig", yPosition, true);
                    yPosition += 40;
                    string[] bedConfigs = { "Single", "Double", "Twin", "King", "Queen" };
                    ((ComboBox)panelDynamicFields.Controls["cmbBedConfig"]).Items.AddRange(bedConfigs);
                    ((ComboBox)panelDynamicFields.Controls["cmbBedConfig"]).SelectedIndex = 0;

                    AddDynamicField("Maximum Occupancy:", "txtMaxOccupancy", yPosition);
                    yPosition += 40;

                    AddDynamicField("Amenities (comma separated):", "txtAmenities", yPosition);
                    break;

                case "Transportation":
                    AddDynamicField("Vehicle Type:", "cmbVehicleType", yPosition, true);
                    yPosition += 40;
                    string[] vehicleTypes = { "Sedan", "SUV", "Van", "Minibus", "Bus", "Luxury Car" };
                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).Items.AddRange(vehicleTypes);
                    ((ComboBox)panelDynamicFields.Controls["cmbVehicleType"]).SelectedIndex = 0;

                    AddDynamicField("Capacity:", "txtCapacity", yPosition);
                    yPosition += 40;

                    AddDynamicField("Driver Included:", "chkDriverIncluded", yPosition, false, true);
                    yPosition += 40;

                    AddDynamicField("Vehicle Model:", "txtModel", yPosition);
                    break;

                case "Tour Package":
                    AddDynamicField("Duration (hours):", "txtDuration", yPosition);
                    yPosition += 40;

                    AddDynamicField("Languages Available:", "txtLanguages", yPosition);
                    yPosition += 40;

                    AddDynamicField("Group Size Limit:", "txtGroupSize", yPosition);
                    yPosition += 40;

                    AddDynamicField("Includes Meals:", "chkMeals", yPosition, false, true);
                    break;

                case "Event Ticket":
                    AddDynamicField("Event Date:", "dtpEventDate", yPosition, false, false, true);
                    yPosition += 40;

                    AddDynamicField("Event Type:", "cmbEventType", yPosition, true);
                    yPosition += 40;
                    string[] eventTypes = { "Concert", "Sports", "Theater", "Exhibition", "Festival" };
                    ((ComboBox)panelDynamicFields.Controls["cmbEventType"]).Items.AddRange(eventTypes);
                    ((ComboBox)panelDynamicFields.Controls["cmbEventType"]).SelectedIndex = 0;

                    AddDynamicField("Venue:", "txtVenue", yPosition);
                    yPosition += 40;

                    AddDynamicField("Seat Category:", "cmbSeatCategory", yPosition, true);
                    string[] seatCategories = { "General", "VIP", "Premium", "Standard", "Economy" };
                    ((ComboBox)panelDynamicFields.Controls["cmbSeatCategory"]).Items.AddRange(seatCategories);
                    ((ComboBox)panelDynamicFields.Controls["cmbSeatCategory"]).SelectedIndex = 0;
                    break;

                case "Restaurant Reservation":
                    AddDynamicField("Cuisine Type:", "cmbCuisine", yPosition, true);
                    yPosition += 40;
                    string[] cuisines = { "Italian", "Chinese", "Indian", "French", "Japanese", "Mexican", "Mediterranean" };
                    ((ComboBox)panelDynamicFields.Controls["cmbCuisine"]).Items.AddRange(cuisines);
                    ((ComboBox)panelDynamicFields.Controls["cmbCuisine"]).SelectedIndex = 0;

                    AddDynamicField("Maximum Party Size:", "txtPartySize", yPosition);
                    yPosition += 40;

                    AddDynamicField("Dress Code:", "cmbDressCode", yPosition, true);
                    string[] dressCodes = { "Casual", "Smart Casual", "Business Casual", "Formal" };
                    ((ComboBox)panelDynamicFields.Controls["cmbDressCode"]).Items.AddRange(dressCodes);
                    ((ComboBox)panelDynamicFields.Controls["cmbDressCode"]).SelectedIndex = 0;
                    yPosition += 40;

                    AddDynamicField("Special Accommodations:", "txtSpecial", yPosition);
                    break;

                case "Activity":
                    AddDynamicField("Activity Type:", "cmbActivityType", yPosition, true);
                    yPosition += 40;
                    string[] activityTypes = { "Adventure", "Cultural", "Educational", "Relaxation", "Water Sports", "Winter Sports" };
                    ((ComboBox)panelDynamicFields.Controls["cmbActivityType"]).Items.AddRange(activityTypes);
                    ((ComboBox)panelDynamicFields.Controls["cmbActivityType"]).SelectedIndex = 0;

                    AddDynamicField("Difficulty Level:", "cmbDifficulty", yPosition, true);
                    yPosition += 40;
                    string[] difficulties = { "Easy", "Moderate", "Challenging", "Expert" };
                    ((ComboBox)panelDynamicFields.Controls["cmbDifficulty"]).Items.AddRange(difficulties);
                    ((ComboBox)panelDynamicFields.Controls["cmbDifficulty"]).SelectedIndex = 0;

                    AddDynamicField("Age Restriction:", "txtAgeRestriction", yPosition);
                    yPosition += 40;

                    AddDynamicField("Equipment Provided:", "chkEquipment", yPosition, false, true);
                    break;
            }
        }

        private void AddDynamicField(string labelText, string controlName, int yPosition, bool isComboBox = false, bool isCheckBox = false, bool isDatePicker = false)
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

            if (isCheckBox)
            {
                inputControl = new CheckBox
                {
                    Location = new Point(170, yPosition + 5),
                    Size = new Size(300, 20),
                    Name = controlName,
                    Font = new Font("Segoe UI", 9)
                };
            }
            else if (isComboBox)
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
            else if (isDatePicker)
            {
                inputControl = new DateTimePicker
                {
                    Location = new Point(170, yPosition),
                    Size = new Size(300, 25),
                    Name = controlName,
                    Font = new Font("Segoe UI", 9),
                    Format = DateTimePickerFormat.Short
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
            if (string.IsNullOrWhiteSpace(txtServiceName.Text))
            {
                MessageBox.Show("Please enter a service name.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPrice.Text) || !decimal.TryParse(txtPrice.Text, out decimal price))
            {
                MessageBox.Show("Please enter a valid price.", "Validation Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            // In a real application, this would save to a database
            // For now, just show a success message
            MessageBox.Show("Service added successfully!", "Success", MessageBoxButtons.OK, MessageBoxIcon.Information);

            // Clear form
            txtServiceName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            cmbServiceType.SelectedIndex = 0;

            // Reset dynamic fields
            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Clear form
            txtServiceName.Clear();
            txtDescription.Clear();
            txtPrice.Clear();
            cmbServiceType.SelectedIndex = 0;

            // Reset dynamic fields
            UpdateDynamicFields(cmbServiceType.SelectedItem.ToString());
        }
    }
}