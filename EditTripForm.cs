using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System;
using System.Windows.Forms;
using TravelEase.Forms;
//using TravelEase.Models; // Adjust if Trip class is elsewhere

namespace DB_M2_Chat
{
    public partial class EditTripForm : Form
    {
        private Trip trip;

        public EditTripForm(Trip selectedTrip)
        {
            InitializeComponent();
            this.trip = selectedTrip;

            // Prefill the controls
            txtTitle.Text = trip.Title;
            txtDescription.Text = trip.Description;
            numPrice.Value = trip.Price;
            numDuration.Value = trip.Duration;
            numCapacity.Value = trip.Capacity;
            cmbTripType.SelectedItem = trip.TripType;
            numAccessibility.Value = trip.AccessibilityScore;
            numSustainability.Value = trip.SustainabilityScore;
            cmbCategory.SelectedItem = trip.TourCategory;
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    // Update the trip object with edited values
        //    trip.Title = txtTitle.Text;
        //    trip.Description = txtDescription.Text;
        //    trip.Price = numPrice.Value;
        //    trip.Duration = (int)numDuration.Value;
        //    trip.Capacity = (int)numCapacity.Value;
        //    trip.TripType = cmbTripType.SelectedItem?.ToString();
        //    trip.AccessibilityScore = (int)numAccessibility.Value;
        //    trip.SustainabilityScore = (int)numSustainability.Value;
        //    trip.TourCategory = cmbCategory.SelectedItem?.ToString();

        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}
    }
}
