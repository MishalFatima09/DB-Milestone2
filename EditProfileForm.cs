using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Xml.Linq;

namespace DB_M2_Chat
{
    public partial class EditProfileForm : Form
    {
        // Sample traveler data - in a real application, this would come from a database
        private string currentImagePath = null;

        public EditProfileForm()
        {
            InitializeComponent();
        }

        private void EditProfileForm_Load(object sender, EventArgs e)
        {
            // Set default values (in a real app, these would be loaded from the database)
            LoadSampleData();

            // Set default image
            try
            {
                // This would be the user's profile image in a real application
                //picProfile.Image = Properties.Resources.DefaultUserIcon;
            }
            catch
            {
                // If the default image isn't available, use a placeholder
                picProfile.BackColor = Color.LightGray;
            }
        }

        private void LoadSampleData()
        {
            // Personal Information
            txtName.Text = "John Doe";
            txtEmail.Text = "john.doe@example.com";
            txtPhone.Text = "+1 (123) 456-7890";
            dtpDOB.Value = new DateTime(1985, 6, 15);

            // Account Preferences
            cmbLanguage.SelectedIndex = 0; // English
            cmbCurrency.SelectedIndex = 0; // USD
            chkNotifications.Checked = true;

            // Travel Preferences
            cmbSeatPref.SelectedIndex = 1; // Window
            cmbMealPref.SelectedIndex = 0; // Regular
            cmbAccommodationPref.SelectedIndex = 1; // Hotel

            // Security - password fields are empty by default for security reasons
        }

        private void btnUploadPhoto_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Title = "Select Profile Picture";
                openFileDialog.Filter = "Image Files|*.jpg;*.jpeg;*.png;*.gif;*.bmp";

                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    try
                    {
                        // Save the path of the selected image
                        currentImagePath = openFileDialog.FileName;

                        // Load and display the selected image
                        using (var stream = new FileStream(currentImagePath, FileMode.Open, FileAccess.Read))
                        {
                            picProfile.Image = Image.FromStream(stream);
                        }
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show($"Error loading image: {ex.Message}", "Error",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
        }

        private void btnUpdate_Click(object sender, EventArgs e)
        {
            // Validate inputs
            if (string.IsNullOrWhiteSpace(txtName.Text))
            {
                ShowError("Please enter your full name.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtEmail.Text) || !IsValidEmail(txtEmail.Text))
            {
                ShowError("Please enter a valid email address.");
                return;
            }

            if (string.IsNullOrWhiteSpace(txtPhone.Text))
            {
                ShowError("Please enter your phone number.");
                return;
            }

            // Validate password fields if the user wants to change password
            if (!string.IsNullOrEmpty(txtNewPassword.Text) || !string.IsNullOrEmpty(txtConfirmPassword.Text))
            {
                if (string.IsNullOrEmpty(txtCurrentPassword.Text))
                {
                    ShowError("Current password is required to change your password.");
                    return;
                }

                if (txtNewPassword.Text != txtConfirmPassword.Text)
                {
                    ShowError("New password and confirmation do not match.");
                    return;
                }

                if (txtNewPassword.Text.Length < 8)
                {
                    ShowError("New password must be at least 8 characters long.");
                    return;
                }

                // In a real application, you would verify the current password against the stored hash
                // For this demo, we'll assume "password123" is the current password
                if (txtCurrentPassword.Text != "password123")
                {
                    ShowError("Current password is incorrect.");
                    return;
                }
            }

            // In a real application, this would save to a database
            // For now, just show a success message
            MessageBox.Show("Profile updated successfully!", "Success",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            // Reset form to original values
            LoadSampleData();

            // Clear password fields
            txtCurrentPassword.Clear();
            txtNewPassword.Clear();
            txtConfirmPassword.Clear();
        }

        // Helper method to show error messages
        private void ShowError(string message)
        {
            MessageBox.Show(message, "Validation Error",
                MessageBoxButtons.OK, MessageBoxIcon.Warning);
        }

        // Helper method to validate email format
        private bool IsValidEmail(string email)
        {
            try
            {
                var addr = new System.Net.Mail.MailAddress(email);
                return addr.Address == email;
            }
            catch
            {
                return false;
            }
        }
    }
}