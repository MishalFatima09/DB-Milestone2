using System;
using System.Drawing;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    partial class EditProfileForm : Form
    {
        private System.ComponentModel.IContainer components = null;

        // Form controls
        private Label lblTitle;
        private Label lblDescription;
        private Panel panelPersonalInfo;
        private Label lblPersonalInfo;
        private Label lblName;
        private TextBox txtName;
        private Label lblEmail;
        private TextBox txtEmail;
        private Label lblPhone;
        private TextBox txtPhone;
        private Label lblDOB;
        private DateTimePicker dtpDOB;
        private Panel panelPreferences;
        private Label lblPreferences;
        private Label lblPrefLanguage;
        private ComboBox cmbLanguage;
        private Label lblPrefCurrency;
        private ComboBox cmbCurrency;
        private CheckBox chkNotifications;
        private Label lblNotifications;
        private Panel panelSecurity;
        private Label lblSecurity;
        private Label lblCurrentPassword;
        private TextBox txtCurrentPassword;
        private Label lblNewPassword;
        private TextBox txtNewPassword;
        private Label lblConfirmPassword;
        private TextBox txtConfirmPassword;
        private Panel panelTravelPrefs;
        private Label lblTravelPrefs;
        private Label lblSeatPref;
        private ComboBox cmbSeatPref;
        private Label lblMealPref;
        private ComboBox cmbMealPref;
        private Label lblAccommodationPref;
        private ComboBox cmbAccommodationPref;
        private Button btnUpdate;
        private Button btnCancel;
        private PictureBox picProfile;
        private Button btnUploadPhoto;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();

            // Color scheme based on provided code
            Color primaryColor = Color.FromArgb(11, 57, 84);       // Dark blue
            Color secondaryColor = Color.FromArgb(191, 215, 234);  // Light blue background
            Color accentColor = Color.FromArgb(40, 167, 69);       // Green accent

            // Title Label
            this.lblTitle = new Label
            {
                Text = "Edit Profile",
                Font = new Font("Segoe UI", 16, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Update your personal information and preferences",
                Font = new Font("Segoe UI", 10),
                ForeColor = primaryColor,
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Profile Picture
            this.picProfile = new PictureBox
            {
                Size = new Size(120, 120),
                Location = new Point(650, 30),
                BorderStyle = BorderStyle.FixedSingle,
                SizeMode = PictureBoxSizeMode.StretchImage,
                BackColor = Color.White
            };

            // Upload Photo Button
            this.btnUploadPhoto = new Button
            {
                Text = "Upload Photo",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(650, 160),
                Size = new Size(120, 30)
            };
            this.btnUploadPhoto.FlatAppearance.BorderSize = 0;
            this.btnUploadPhoto.Click += new EventHandler(this.btnUploadPhoto_Click);

            // Personal Information Panel
            this.panelPersonalInfo = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(600, 180),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Personal Info Header
            this.lblPersonalInfo = new Label
            {
                Text = "Personal Information",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(15, 10),
                AutoSize = true
            };

            // Name Label
            this.lblName = new Label
            {
                Text = "Full Name:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 45),
                Size = new Size(120, 20)
            };

            // Name TextBox
            this.txtName = new TextBox
            {
                Location = new Point(150, 45),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Email Label
            this.lblEmail = new Label
            {
                Text = "Email Address:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 80),
                Size = new Size(120, 20)
            };

            // Email TextBox
            this.txtEmail = new TextBox
            {
                Location = new Point(150, 80),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Phone Label
            this.lblPhone = new Label
            {
                Text = "Phone Number:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 115),
                Size = new Size(120, 20)
            };

            // Phone TextBox
            this.txtPhone = new TextBox
            {
                Location = new Point(150, 115),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Date of Birth Label
            this.lblDOB = new Label
            {
                Text = "Date of Birth:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 150),
                Size = new Size(120, 20)
            };

            // Date of Birth DateTimePicker
            this.dtpDOB = new DateTimePicker
            {
                Location = new Point(150, 150),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                Format = DateTimePickerFormat.Short
            };

            // Add controls to personal info panel
            this.panelPersonalInfo.Controls.AddRange(new Control[]
            {
                this.lblPersonalInfo,
                this.lblName,
                this.txtName,
                this.lblEmail,
                this.txtEmail,
                this.lblPhone,
                this.txtPhone,
                this.lblDOB,
                this.dtpDOB
            });

            // Preferences Panel
            this.panelPreferences = new Panel
            {
                Location = new Point(30, 270),
                Size = new Size(600, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Preferences Header
            this.lblPreferences = new Label
            {
                Text = "Account Preferences",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(15, 10),
                AutoSize = true
            };

            // Preferred Language Label
            this.lblPrefLanguage = new Label
            {
                Text = "Language:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 45),
                Size = new Size(120, 20)
            };

            // Preferred Language ComboBox
            this.cmbLanguage = new ComboBox
            {
                Location = new Point(150, 45),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbLanguage.Items.AddRange(new string[] { "English", "Spanish", "French", "German", "Chinese", "Japanese", "Arabic" });

            // Preferred Currency Label
            this.lblPrefCurrency = new Label
            {
                Text = "Currency:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 80),
                Size = new Size(120, 20)
            };

            // Preferred Currency ComboBox
            this.cmbCurrency = new ComboBox
            {
                Location = new Point(150, 80),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbCurrency.Items.AddRange(new string[] { "USD ($)", "EUR (€)", "GBP (£)", "JPY (¥)", "CAD (C$)", "AUD (A$)" });

            // Notifications Label
            this.lblNotifications = new Label
            {
                Text = "Email Notifications:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 115),
                Size = new Size(120, 20)
            };

            // Notifications CheckBox
            this.chkNotifications = new CheckBox
            {
                Text = "Receive promotional emails and travel deals",
                Location = new Point(150, 115),
                Size = new Size(280, 20),
                Font = new Font("Segoe UI", 9),
                Checked = true
            };

            // Add controls to preferences panel
            this.panelPreferences.Controls.AddRange(new Control[]
            {
                this.lblPreferences,
                this.lblPrefLanguage,
                this.cmbLanguage,
                this.lblPrefCurrency,
                this.cmbCurrency,
                this.lblNotifications,
                this.chkNotifications
            });

            // Travel Preferences Panel
            this.panelTravelPrefs = new Panel
            {
                Location = new Point(30, 420),
                Size = new Size(600, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Travel Preferences Header
            this.lblTravelPrefs = new Label
            {
                Text = "Travel Preferences",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(15, 10),
                AutoSize = true
            };

            // Seat Preference Label
            this.lblSeatPref = new Label
            {
                Text = "Seat Preference:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 45),
                Size = new Size(120, 20)
            };

            // Seat Preference ComboBox
            this.cmbSeatPref = new ComboBox
            {
                Location = new Point(150, 45),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbSeatPref.Items.AddRange(new string[] { "No Preference", "Window", "Aisle", "Middle" });

            // Meal Preference Label
            this.lblMealPref = new Label
            {
                Text = "Meal Preference:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 80),
                Size = new Size(120, 20)
            };

            // Meal Preference ComboBox
            this.cmbMealPref = new ComboBox
            {
                Location = new Point(150, 80),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbMealPref.Items.AddRange(new string[] { "Regular", "Vegetarian", "Vegan", "Kosher", "Halal", "Gluten-Free" });

            // Accommodation Preference Label
            this.lblAccommodationPref = new Label
            {
                Text = "Accommodation:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 115),
                Size = new Size(120, 20)
            };

            // Accommodation Preference ComboBox
            this.cmbAccommodationPref = new ComboBox
            {
                Location = new Point(150, 115),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                DropDownStyle = ComboBoxStyle.DropDownList
            };
            this.cmbAccommodationPref.Items.AddRange(new string[] { "No Preference", "Hotel", "Resort", "Apartment", "Hostel", "B&B" });

            // Add controls to travel preferences panel
            this.panelTravelPrefs.Controls.AddRange(new Control[]
            {
                this.lblTravelPrefs,
                this.lblSeatPref,
                this.cmbSeatPref,
                this.lblMealPref,
                this.cmbMealPref,
                this.lblAccommodationPref,
                this.cmbAccommodationPref
            });

            // Security Panel
            this.panelSecurity = new Panel
            {
                Location = new Point(30, 570),
                Size = new Size(600, 140),
                BackColor = Color.White,
                BorderStyle = BorderStyle.None
            };

            // Security Header
            this.lblSecurity = new Label
            {
                Text = "Security Settings",
                Font = new Font("Segoe UI", 11, FontStyle.Bold),
                ForeColor = primaryColor,
                Location = new Point(15, 10),
                AutoSize = true
            };

            // Current Password Label
            this.lblCurrentPassword = new Label
            {
                Text = "Current Password:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 45),
                Size = new Size(120, 20)
            };

            // Current Password TextBox
            this.txtCurrentPassword = new TextBox
            {
                Location = new Point(150, 45),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                PasswordChar = '•'
            };

            // New Password Label
            this.lblNewPassword = new Label
            {
                Text = "New Password:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 80),
                Size = new Size(120, 20)
            };

            // New Password TextBox
            this.txtNewPassword = new TextBox
            {
                Location = new Point(150, 80),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                PasswordChar = '•'
            };

            // Confirm Password Label
            this.lblConfirmPassword = new Label
            {
                Text = "Confirm Password:",
                Font = new Font("Segoe UI", 9),
                ForeColor = primaryColor,
                Location = new Point(20, 115),
                Size = new Size(120, 20)
            };

            // Confirm Password TextBox
            this.txtConfirmPassword = new TextBox
            {
                Location = new Point(150, 115),
                Size = new Size(200, 25),
                Font = new Font("Segoe UI", 9),
                PasswordChar = '•'
            };

            // Add controls to security panel
            this.panelSecurity.Controls.AddRange(new Control[]
            {
                this.lblSecurity,
                this.lblCurrentPassword,
                this.txtCurrentPassword,
                this.lblNewPassword,
                this.txtNewPassword,
                this.lblConfirmPassword,
                this.txtConfirmPassword
            });

            // Update Button
            this.btnUpdate = new Button
            {
                Text = "Update Profile",
                BackColor = accentColor,
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(30, 720),
                Size = new Size(120, 35)
            };
            this.btnUpdate.FlatAppearance.BorderSize = 0;
            this.btnUpdate.Click += new EventHandler(this.btnUpdate_Click);

            // Cancel Button
            this.btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(160, 720),
                Size = new Size(100, 35)
            };
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Form properties
            this.BackColor = secondaryColor;
            this.ClientSize = new Size(820, 770);
            this.FormBorderStyle = FormBorderStyle.None;
            this.AutoScroll = true;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.panelPersonalInfo,
                this.panelPreferences,
                this.panelTravelPrefs,
                this.panelSecurity,
                this.btnUpdate,
                this.btnCancel,
                this.picProfile,
                this.btnUploadPhoto
            });

            this.Load += new EventHandler(this.EditProfileForm_Load);
        }
    }
}