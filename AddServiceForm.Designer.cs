using System.Drawing;
using System.Windows.Forms;
using System;

namespace DB_M2_Chat
{
    partial class AddServiceForm
    {
        private System.ComponentModel.IContainer components = null;

        // Form controls
        private Label lblTitle;
        private Label lblDescription;
        private Label lblServiceName;
        private TextBox txtServiceName;
        private Label lblServiceType;
        private ComboBox cmbServiceType;
        private Label lblServiceDesc;
        private TextBox txtDescription;
        private Label lblPrice;
        private TextBox txtPrice;
        private Panel panelDynamicFields;
        private Button btnAddService;
        private Button btnCancel;
        private Panel panelActions;

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

            int labelX = 40;
            int inputX = 180;
            int width = 300;

            // Title Label
            this.lblTitle = new Label
            {
                Text = "➕ Add New Service",
                Font = new Font("Segoe UI", 14, FontStyle.Bold),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(30, 20),
                AutoSize = true
            };

            // Description Label
            this.lblDescription = new Label
            {
                Text = "Create and publish a new service for travelers",
                Font = new Font("Segoe UI", 10),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(32, 50),
                AutoSize = true
            };

            // Service Name Label
            this.lblServiceName = new Label
            {
                Text = "Service Name:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(labelX, 90),
                Size = new Size(120, 20)
            };

            // Service Name TextBox
            this.txtServiceName = new TextBox
            {
                Location = new Point(inputX, 90),
                Size = new Size(width, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Service Type Label
            this.lblServiceType = new Label
            {
                Text = "Service Type:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(labelX, 125),
                Size = new Size(120, 20)
            };

            // Service Type ComboBox
            this.cmbServiceType = new ComboBox
            {
                Location = new Point(inputX, 125),
                Size = new Size(width, 25),
                DropDownStyle = ComboBoxStyle.DropDownList,
                Font = new Font("Segoe UI", 9)
            };
            this.cmbServiceType.SelectedIndexChanged += new EventHandler(this.cmbServiceType_SelectedIndexChanged);

            // Description Label
            this.lblServiceDesc = new Label
            {
                Text = "Description:",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(labelX, 160),
                Size = new Size(120, 20)
            };

            // Description TextBox
            this.txtDescription = new TextBox
            {
                Location = new Point(inputX, 160),
                Size = new Size(width, 60),
                Multiline = true,
                Font = new Font("Segoe UI", 9)
            };

            // Price Label
            this.lblPrice = new Label
            {
                Text = "Price ($):",
                Font = new Font("Segoe UI", 9),
                ForeColor = Color.FromArgb(11, 57, 84),
                Location = new Point(labelX, 230),
                Size = new Size(120, 20)
            };

            // Price TextBox
            this.txtPrice = new TextBox
            {
                Location = new Point(inputX, 230),
                Size = new Size(150, 25),
                Font = new Font("Segoe UI", 9)
            };

            // Dynamic Fields Panel
            this.panelDynamicFields = new Panel
            {
                Location = new Point(labelX, 270),
                Size = new Size(480, 200),
                BackColor = Color.FromArgb(191, 215, 234),
                BorderStyle = BorderStyle.None,
                AutoScroll = true
            };

            // Actions Panel
            this.panelActions = new Panel
            {
                Location = new Point(30, 480),
                Size = new Size(760, 60),
                BackColor = Color.FromArgb(191, 215, 234)
            };

            // Add Button
            this.btnAddService = new Button
            {
                Text = "Add Service",
                BackColor = Color.FromArgb(40, 167, 69),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(30, 10),
                Size = new Size(120, 35)
            };
            this.btnAddService.FlatAppearance.BorderSize = 0;
            this.btnAddService.Click += new EventHandler(this.btnAddService_Click);

            // Cancel Button
            this.btnCancel = new Button
            {
                Text = "Cancel",
                BackColor = Color.FromArgb(108, 117, 125),
                ForeColor = Color.White,
                FlatStyle = FlatStyle.Flat,
                Location = new Point(160, 10),
                Size = new Size(100, 35)
            };
            this.btnCancel.FlatAppearance.BorderSize = 0;
            this.btnCancel.Click += new EventHandler(this.btnCancel_Click);

            // Add buttons to actions panel
            this.panelActions.Controls.AddRange(new Control[]
            {
                this.btnAddService,
                this.btnCancel
            });

            // Form properties
            this.BackColor = Color.FromArgb(191, 215, 234);
            this.ClientSize = new Size(820, 550);
            this.FormBorderStyle = FormBorderStyle.None;

            // Add controls to form
            this.Controls.AddRange(new Control[]
            {
                this.lblTitle,
                this.lblDescription,
                this.lblServiceName,
                this.txtServiceName,
                this.lblServiceType,
                this.cmbServiceType,
                this.lblServiceDesc,
                this.txtDescription,
                this.lblPrice,
                this.txtPrice,
                this.panelDynamicFields,
                this.panelActions
            });

            this.Load += new EventHandler(this.AddServiceForm_Load);
        }
    }
}
