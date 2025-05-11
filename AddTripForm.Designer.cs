using System;
using System.Drawing;
using System.Windows.Forms;
using System.Data.SqlClient;

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
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccessibility)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSustainability)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.Location = new System.Drawing.Point(0, 0);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(100, 23);
            this.lbl.TabIndex = 0;
            // 
            // lblTitle
            // 
            this.lblTitle.Location = new System.Drawing.Point(30, 80);
            this.lblTitle.Name = "lblTitle";
            this.lblTitle.Size = new System.Drawing.Size(100, 23);
            this.lblTitle.TabIndex = 1;
            this.lblTitle.Text = "Trip Title:";
            // 
            // lblDescription
            // 
            this.lblDescription.Location = new System.Drawing.Point(30, 120);
            this.lblDescription.Name = "lblDescription";
            this.lblDescription.Size = new System.Drawing.Size(100, 23);
            this.lblDescription.TabIndex = 3;
            this.lblDescription.Text = "Description:";
            // 
            // lblPrice
            // 
            this.lblPrice.Location = new System.Drawing.Point(30, 190);
            this.lblPrice.Name = "lblPrice";
            this.lblPrice.Size = new System.Drawing.Size(100, 23);
            this.lblPrice.TabIndex = 5;
            this.lblPrice.Text = "Price:";
            // 
            // lblDuration
            // 
            this.lblDuration.Location = new System.Drawing.Point(30, 230);
            this.lblDuration.Name = "lblDuration";
            this.lblDuration.Size = new System.Drawing.Size(100, 23);
            this.lblDuration.TabIndex = 7;
            this.lblDuration.Text = "Duration (days):";
            // 
            // lblCapacity
            // 
            this.lblCapacity.Location = new System.Drawing.Point(30, 270);
            this.lblCapacity.Name = "lblCapacity";
            this.lblCapacity.Size = new System.Drawing.Size(100, 23);
            this.lblCapacity.TabIndex = 9;
            this.lblCapacity.Text = "Capacity:";
            // 
            // lblTripType
            // 
            this.lblTripType.Location = new System.Drawing.Point(30, 310);
            this.lblTripType.Name = "lblTripType";
            this.lblTripType.Size = new System.Drawing.Size(100, 23);
            this.lblTripType.TabIndex = 11;
            this.lblTripType.Text = "Trip Type:";
            // 
            // lblAccessibility
            // 
            this.lblAccessibility.Location = new System.Drawing.Point(30, 350);
            this.lblAccessibility.Name = "lblAccessibility";
            this.lblAccessibility.Size = new System.Drawing.Size(120, 23);
            this.lblAccessibility.TabIndex = 13;
            this.lblAccessibility.Text = "Accessibility Score:";
            // 
            // lblSustainability
            // 
            this.lblSustainability.Location = new System.Drawing.Point(30, 390);
            this.lblSustainability.Name = "lblSustainability";
            this.lblSustainability.Size = new System.Drawing.Size(120, 23);
            this.lblSustainability.TabIndex = 15;
            this.lblSustainability.Text = "Sustainability Score:";
            // 
            // lblCategory
            // 
            this.lblCategory.Location = new System.Drawing.Point(30, 430);
            this.lblCategory.Name = "lblCategory";
            this.lblCategory.Size = new System.Drawing.Size(100, 23);
            this.lblCategory.TabIndex = 17;
            this.lblCategory.Text = "Tour Category:";
            // 
            // txtTitle
            // 
            this.txtTitle.Location = new System.Drawing.Point(150, 80);
            this.txtTitle.Name = "txtTitle";
            this.txtTitle.Size = new System.Drawing.Size(300, 20);
            this.txtTitle.TabIndex = 2;
            // 
            // txtDescription
            // 
            this.txtDescription.Location = new System.Drawing.Point(150, 120);
            this.txtDescription.Multiline = true;
            this.txtDescription.Name = "txtDescription";
            this.txtDescription.Size = new System.Drawing.Size(300, 60);
            this.txtDescription.TabIndex = 4;
            // 
            // numPrice
            // 
            this.numPrice.DecimalPlaces = 2;
            this.numPrice.Location = new System.Drawing.Point(150, 190);
            this.numPrice.Name = "numPrice";
            this.numPrice.Size = new System.Drawing.Size(300, 20);
            this.numPrice.TabIndex = 6;
            // 
            // numDuration
            // 
            this.numDuration.Location = new System.Drawing.Point(150, 230);
            this.numDuration.Name = "numDuration";
            this.numDuration.Size = new System.Drawing.Size(300, 20);
            this.numDuration.TabIndex = 8;
            // 
            // numCapacity
            // 
            this.numCapacity.Location = new System.Drawing.Point(150, 270);
            this.numCapacity.Name = "numCapacity";
            this.numCapacity.Size = new System.Drawing.Size(300, 20);
            this.numCapacity.TabIndex = 10;
            // 
            // cmbTripType
            // 
            this.cmbTripType.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbTripType.Items.AddRange(new object[] { //'Guided', 'Leisure', 'Adventure', 'Cultural', 'Cruise', 'Wildlife', 'Nature'
            "Guided",
            "Leisure",
            "Adventure",
            "Cultural",
            "Wildlife",
            "Nature",
            "Cruise"});

            this.cmbTripType.Location = new System.Drawing.Point(150, 310);
            this.cmbTripType.Name = "cmbTripType";
            this.cmbTripType.Size = new System.Drawing.Size(300, 21);
            this.cmbTripType.TabIndex = 12;
            // 
            // numAccessibility
            // 
            this.numAccessibility.Location = new System.Drawing.Point(150, 350);
            this.numAccessibility.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numAccessibility.Name = "numAccessibility";
            this.numAccessibility.Size = new System.Drawing.Size(300, 20);
            this.numAccessibility.TabIndex = 14;
            // 
            // numSustainability
            // 
            this.numSustainability.Location = new System.Drawing.Point(150, 390);
            this.numSustainability.Maximum = new decimal(new int[] {
            10,
            0,
            0,
            0});
            this.numSustainability.Name = "numSustainability";
            this.numSustainability.Size = new System.Drawing.Size(300, 20);
            this.numSustainability.TabIndex = 16;
            // 
            // cmbCategory
            // 
            this.cmbCategory.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.cmbCategory.Items.AddRange(new object[] { //'City', 'Food & Wine', 'Adventure', 'Cultural', 'Wildlife', 'Nature', 'History', 'Cruise'
            "City",
            "Food & Wine",
            "History",
            "Wildlife"});
            this.cmbCategory.Location = new System.Drawing.Point(150, 430);
            this.cmbCategory.Name = "cmbCategory";
            this.cmbCategory.Size = new System.Drawing.Size(300, 21);
            this.cmbCategory.TabIndex = 18;
            // 
            // btnAddTrip
            // 
            this.btnAddTrip.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(11)))), ((int)(((byte)(57)))), ((int)(((byte)(84)))));
            this.btnAddTrip.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAddTrip.ForeColor = System.Drawing.Color.White;
            this.btnAddTrip.Location = new System.Drawing.Point(150, 470);
            this.btnAddTrip.Name = "btnAddTrip";
            this.btnAddTrip.Size = new System.Drawing.Size(300, 35);
            this.btnAddTrip.TabIndex = 19;
            this.btnAddTrip.Text = "Add Trip";
            this.btnAddTrip.UseVisualStyleBackColor = false;
            this.btnAddTrip.Click += new System.EventHandler(this.btnAddTrip_Click);
            // 
            // AddTripForm
            // 
            this.ClientSize = new System.Drawing.Size(793, 474);
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
            this.Name = "AddTripForm";
            this.Load += new System.EventHandler(this.AddTripForm_Load_1);
            ((System.ComponentModel.ISupportInitialize)(this.numPrice)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numDuration)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numCapacity)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numAccessibility)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.numSustainability)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

    }
}



