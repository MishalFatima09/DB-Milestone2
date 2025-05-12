using System;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    partial class EditTripForm : Form // Ensure EditTripForm inherits from Form
    {
        private System.ComponentModel.IContainer components = null;

        private System.Windows.Forms.Label lblTitle;
        private System.Windows.Forms.Label lblDescription;
        private System.Windows.Forms.Label lblPrice;
        private System.Windows.Forms.Label lblDuration;
        private System.Windows.Forms.Label lblCapacity;
        private System.Windows.Forms.Label lblTripType;
        private System.Windows.Forms.Label lblAccessibility;
        private System.Windows.Forms.Label lblSustainability;
        private System.Windows.Forms.Label lblCategory;

        private System.Windows.Forms.TextBox txtTitle;
        private System.Windows.Forms.TextBox txtDescription;
        private System.Windows.Forms.NumericUpDown numPrice;
        private System.Windows.Forms.NumericUpDown numDuration;
        private System.Windows.Forms.NumericUpDown numCapacity;
        private System.Windows.Forms.ComboBox cmbTripType;
        private System.Windows.Forms.NumericUpDown numAccessibility;
        private System.Windows.Forms.NumericUpDown numSustainability;
        private System.Windows.Forms.ComboBox cmbCategory;

        private System.Windows.Forms.Button btnSave;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null)) components.Dispose();
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
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

            this.btnSave = new System.Windows.Forms.Button();

            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccessibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSustainability)).BeginInit();

            this.SuspendLayout();

            int leftLabel = 30, leftControl = 150, width = 300, top = 30, spacing = 40;

            // Labels and controls
            string[] labels = { "Title:", "Description:", "Price:", "Duration (days):", "Capacity:", "Trip Type:",
                                "Accessibility Score:", "Sustainability Score:", "Tour Category:" };
            Control[] controls = {
                txtTitle, txtDescription, numPrice, numDuration, numCapacity,
                cmbTripType, numAccessibility, numSustainability, cmbCategory
            };
            Label[] labelControls = {
                lblTitle, lblDescription, lblPrice, lblDuration, lblCapacity,
                lblTripType, lblAccessibility, lblSustainability, lblCategory
            };

            for (int i = 0; i < labels.Length; i++)
            {
                labelControls[i].Text = labels[i];
                labelControls[i].Location = new System.Drawing.Point(leftLabel, top + spacing * i);
                labelControls[i].Size = new System.Drawing.Size(120, 23);

                controls[i].Location = new System.Drawing.Point(leftControl, top + spacing * i);
                controls[i].Size = new System.Drawing.Size(width, 23);

                this.Controls.Add(labelControls[i]);
                this.Controls.Add(controls[i]);
            }

            txtDescription.Multiline = true;
            txtDescription.Height = 50;

            cmbTripType.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbTripType.Items.AddRange(new object[] {"Guided",
            "Leisure",
            "Adventure",
            "Cultural",
            "Wildlife",
            "Nature",
            "Cruise" });

            cmbCategory.DropDownStyle = ComboBoxStyle.DropDownList;
            cmbCategory.Items.AddRange(new object[] {  "City",
            "Food & Wine",
            "History",
            "Wildlife" });

            numAccessibility.Maximum = 10;
            numSustainability.Maximum = 10;
            numPrice.DecimalPlaces = 2;

            // Save button
            btnSave.Text = "Save Changes";
            btnSave.Size = new System.Drawing.Size(width, 35);
            btnSave.Location = new System.Drawing.Point(leftControl, top + spacing * labels.Length + 10);
            btnSave.BackColor = System.Drawing.Color.FromArgb(11, 57, 84);
            btnSave.ForeColor = System.Drawing.Color.White;
            btnSave.FlatStyle = FlatStyle.Flat;
            btnSave.Click += new System.EventHandler(this.btnSave_Click);

            this.Controls.Add(btnSave);

            // Form settings
            this.ClientSize = new System.Drawing.Size(520, top + spacing * labels.Length + 60);
            this.Name = "EditTripForm";
            this.Text = "Edit Trip";

            this.ResumeLayout(false);
            this.PerformLayout();
        }

        //private void btnSave_Click(object sender, EventArgs e)
        //{
        //    trip.Title = txtTitle.Text;
        //    trip.Description = txtDescription.Text;
        //    trip.Price = numPrice.Value;
        //    trip.Duration = (int)numDuration.Value;
        //    trip.Capacity = (int)numCapacity.Value;
        //    trip.TripType = cmbTripType.SelectedItem?.ToString();
        //    trip.AccessibilityScore = (int)numAccessibility.Value;
        //    trip.Sustainability_Score = (int)numSustainability.Value;
        //    trip.TourCategory = cmbCategory.SelectedItem?.ToString();

        //    this.DialogResult = DialogResult.OK;
        //    this.Close();
        //}
    }
}
