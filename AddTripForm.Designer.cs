using System;
using System.Drawing;
using System.Windows.Forms;

namespace TravelEase.Forms
{
    partial class AddTripForm
    {
        private System.Windows.Forms.Label lbl;
        private System.Windows.Forms.Label lblTitle, lblDescription, lblPrice, lblDuration, lblCapacity, lblTripType, lblAccessibility, lblSustainability, lblCategory;
        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.ComboBox cmbTripType;
        private System.Windows.Forms.NumericUpDown numAccessibility;
        private System.Windows.Forms.NumericUpDown numSustainability;
        private System.Windows.Forms.ComboBox cmbCategory;
        private System.Windows.Forms.Button btnAddTrip;

        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.lblTitle = new System.Windows.Forms.Label();
            this.lblDescription = new System.Windows.Forms.Label();
            this.lblPrice = new System.Windows.Forms.Label();
            this.lblDuration = new System.Windows.Forms.Label();
            this.lblCapacity = new System.Windows.Forms.Label();
            this.lblTripType = new System.Windows.Forms.Label();
            this.lblAccessibility = new System.Windows.Forms.Label();
            this.lblSustainability = new System.Windows.Forms.Label();
            this.lblCategory = new System.Windows.Forms.Label();

            this.txtTitle = new System.Windows.Forms.TextBox();
            this.txtDescription = new System.Windows.Forms.TextBox();
            this.numPrice = new System.Windows.Forms.NumericUpDown();
            this.numDuration = new System.Windows.Forms.NumericUpDown();
            this.numCapacity = new System.Windows.Forms.NumericUpDown();
            this.cmbTripType = new System.Windows.Forms.ComboBox();
            this.numAccessibility = new System.Windows.Forms.NumericUpDown();
            this.numSustainability = new System.Windows.Forms.NumericUpDown();
            this.cmbCategory = new System.Windows.Forms.ComboBox();
            this.btnAddTrip = new System.Windows.Forms.Button();

            // ... rest of your layout code ...


            // Other components initialized here...

            // Example: Title label and textbox
            this.lblTitle.Text = "Trip Title:";
            this.lblTitle.Location = new System.Drawing.Point(30, 80);
            this.lblTitle.Size = new System.Drawing.Size(100, 23);

            this.txtTitle.Location = new System.Drawing.Point(150, 80);
            this.txtTitle.Size = new System.Drawing.Size(300, 23);

            // Description
            this.lblDescription.Text = "Description:";
            this.lblDescription.Location = new System.Drawing.Point(30, 120);
            this.lblDescription.Size = new System.Drawing.Size(100, 23);

            this.txtDescription.Location = new System.Drawing.Point(150, 120);
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.Multiline = true;

            // Price
            this.lblPrice.Text = "Price:";
            this.lblPrice.Location = new System.Drawing.Point(30, 190);
            this.lblPrice.Size = new System.Drawing.Size(100, 23);

            this.numPrice.Location = new System.Drawing.Point(150, 190);
            this.numPrice.Size = new System.Drawing.Size(300, 23);
            this.numPrice.DecimalPlaces = 2;

            // Duration
            this.lblDuration.Text = "Duration (days):";
            this.lblDuration.Location = new System.Drawing.Point(30, 230);
            this.lblDuration.Size = new System.Drawing.Size(100, 23);

            this.numDuration.Location = new System.Drawing.Point(150, 230);
            this.numDuration.Size = new System.Drawing.Size(300, 23);

            // Capacity
            this.lblCapacity.Text = "Capacity:";
            this.lblCapacity.Location = new System.Drawing.Point(30, 270);
            this.lblCapacity.Size = new System.Drawing.Size(100, 23);

            this.numCapacity.Location = new System.Drawing.Point(150, 270);
            this.numCapacity.Size = new System.Drawing.Size(300, 23);

            // Trip Type
            this.lblTripType.Text = "Trip Type:";
            this.lblTripType.Location = new System.Drawing.Point(30, 310);
            this.lblTripType.Size = new System.Drawing.Size(100, 23);

            this.cmbTripType.Location = new System.Drawing.Point(150, 310);
            this.cmbTripType.Size = new System.Drawing.Size(300, 23);
            this.cmbTripType.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbTripType.Items.AddRange(new object[] { "Adventure", "Cultural", "Relaxation", "Wildlife", "Historical" });

            // Accessibility
            this.lblAccessibility.Text = "Accessibility Score:";
            this.lblAccessibility.Location = new System.Drawing.Point(30, 350);
            this.lblAccessibility.Size = new System.Drawing.Size(120, 23);

            this.numAccessibility.Location = new System.Drawing.Point(150, 350);
            this.numAccessibility.Size = new System.Drawing.Size(300, 23);
            this.numAccessibility.Maximum = 10;

            // Sustainability
            this.lblSustainability.Text = "Sustainability Score:";
            this.lblSustainability.Location = new System.Drawing.Point(30, 390);
            this.lblSustainability.Size = new System.Drawing.Size(120, 23);

            this.numSustainability.Location = new System.Drawing.Point(150, 390);
            this.numSustainability.Size = new System.Drawing.Size(300, 23);
            this.numSustainability.Maximum = 10;

            // Category
            this.lblCategory.Text = "Tour Category:";
            this.lblCategory.Location = new System.Drawing.Point(30, 430);
            this.lblCategory.Size = new System.Drawing.Size(100, 23);

            this.cmbCategory.Location = new System.Drawing.Point(150, 430);
            this.cmbCategory.Size = new System.Drawing.Size(300, 23);
            this.cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { "Eco", "Luxury", "Budget", "Family", "Solo" });

            // Button
            this.btnAddTrip.Location = new System.Drawing.Point(150, 470);
            this.btnAddTrip.Size = new System.Drawing.Size(300, 35);
            this.btnAddTrip.Text = "Add Trip";
            this.btnAddTrip.BackColor = System.Drawing.Color.FromArgb(11, 57, 84);
            this.btnAddTrip.ForeColor = System.Drawing.Color.White;
            this.btnAddTrip.FlatStyle = FlatStyle.Flat;
            this.btnAddTrip.Click += new System.EventHandler(this.btnAddTrip_Click);

            // Add all controls to the form
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.lblTitle);
            this.Controls.Add(this.txtTitle);
            this.Controls.Add(this.lblDescription);
            this.Controls.Add(this.txtDescription);
            this.Controls.Add(this.lblPrice);
            this.Controls.Add(this.numPrice);
            this.Controls.Add(this.lblDuration);
            this.Controls.Add(this.numDuration);
            this.Controls.Add(this.lblCapacity);
            this.Controls.Add(this.numCapacity);
            this.Controls.Add(this.lblTripType);
            this.Controls.Add(this.cmbTripType);
            this.Controls.Add(this.lblAccessibility);
            this.Controls.Add(this.numAccessibility);
            this.Controls.Add(this.lblSustainability);
            this.Controls.Add(this.numSustainability);
            this.Controls.Add(this.lblCategory);
            this.Controls.Add(this.cmbCategory);
            this.Controls.Add(this.btnAddTrip);

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private void btnAddTrip_Click(object sender, EventArgs e)
        {
            throw new NotImplementedException();
        }
    }
}



