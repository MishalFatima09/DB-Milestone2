using System;
using System.Drawing;
using System.Windows.Forms;

namespace DB_M2_Chat
{
    partial class EditServiceForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form controls
        private Label lblTitle;
        private Label lblServiceId;
        private Label lblServiceName;
        private TextBox txtServiceName;
        private Label lblField1;
        private TextBox txtField1;
        private Label lblField2;
        private TextBox txtField2;
        private Label lblField3;
        private TextBox txtField3;
        private Label lblField4;
        private TextBox txtField4;
        private Button btnSave;
        private Button btnCancel;
        private Panel panelForm;
        private Panel panelButtons;

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
            // Form title label
            this.lblTitle = new Label
            {
                Text = "✏️ Edit Service",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Service ID label (will be filled dynamically)
            this.lblServiceId = new Label
            {
                Text = $"ID: {serviceID} - Type: {serviceType}",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Form panel
            this.panelForm = new Panel
            {
                Location = new Point(30, 80),
                Size = new Size(420, 350),
                BackColor = Color.White,
                BorderStyle = BorderStyle.FixedSingle
            };

            // Service Name
            this.lblServiceName = new Label
            {
                Text = "Service Name:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 20),
                AutoSize = true
            };

            this.txtServiceName = new TextBox
            {
                Location = new Point(150, 20),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Field 1
            this.lblField1 = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 60),
                AutoSize = true
            };

            this.txtField1 = new TextBox
            {
                Location = new Point(150, 60),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Field 2
            this.lblField2 = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 100),
                AutoSize = true
            };

            this.txtField2 = new TextBox
            {
                Location = new Point(150, 100),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Field 3
            this.lblField3 = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 140),
                AutoSize = true
            };

            this.txtField3 = new TextBox
            {
                Location = new Point(150, 140),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle
            };

            // Field 4 (only for Transport)
            this.lblField4 = new Label
            {
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(20, 180),
                AutoSize = true,
                Visible = serviceType == "Transport" // Only visible for Transport
            };

            this.txtField4 = new TextBox
            {
                Location = new Point(150, 180),
                Size = new Size(250, 25),
                BorderStyle = BorderStyle.FixedSingle,
                Visible = serviceType == "Transport" // Only visible for Transport
            };

            // Set field labels based on service type
            switch (serviceType)
            {
                case "Guide":
                    lblField1.Text = "Experience (Years):";
                    lblField2.Text = "Specialization:";
                    lblField3.Text = "Price Per Day:";
                    break;
                case "Hotel":
                    lblField1.Text = "Address:";
                    lblField2.Text = "Available Rooms:";
                    lblField3.Text = "Facilities:";
                    break;
                case "Transport":
                    lblField1.Text = "Vehicle Number:";
                    lblField2.Text = "Vehicle Type:";
                    lblField3.Text = "Capacity:";
                    lblField4.Text = "Price Per Ticket:";
                    break;
            }

            // Buttons panel
            this.panelButtons = new Panel
            {
                Location = new Point(30, 440),
                Size = new Size(420, 50),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Save button
            this.btnSave = new Button
            {
                Text = "Save",
                BackColor = Color.FromArgb(40, 120, 180),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(200, 10),
                Size = new Size(100, 30)
            };
            this.btnSave.FlatAppearance.BorderSize = 0;
            this.btnSave.Click += new EventHandler(this.btnSave_Click);

            // Cancel button
            this.btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(310, 10),
                Size = new Size(100, 30)
            };
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add controls to panels
            this.panelForm.Controls.AddRange(new Control[]
            {
                this.lblServiceName,
                this.txtServiceName,
                this.lblField1,
                this.txtField1,
                this.lblField2,
                this.txtField2,
                this.lblField3,
                this.txtField3,
                this.lblField4,
                this.txtField4
            });

            this.panelButtons.Controls.AddRange(new Control[]
            {
                this.btnSave,
                this.btnCancel
            });

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(480, 500);
            this.FormBorderStyle = FormBorderStyle.FixedDialog;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.StartPosition = FormStartPosition.CenterParent;
            this.Text = $"Edit {serviceType} Service";

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblServiceId,
                this.panelForm,
                this.panelButtons
            });
        }
    }
}