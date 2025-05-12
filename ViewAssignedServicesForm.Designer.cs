namespace TravelEase.Forms
{
    partial class ViewAssignedServicesForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.lbl = new System.Windows.Forms.Label();
            this.dgv = new System.Windows.Forms.DataGridView();
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).BeginInit();
            this.SuspendLayout();
            // 
            // lbl
            // 
            this.lbl.AutoSize = true;
            this.lbl.Font = new System.Drawing.Font("Segoe UI", 14F, System.Drawing.FontStyle.Bold);
            this.lbl.Location = new System.Drawing.Point(30, 20);
            this.lbl.Name = "lbl";
            this.lbl.Size = new System.Drawing.Size(196, 25);
            this.lbl.TabIndex = 0;
            this.lbl.Text = "📋 Assigned Services";
            // 
            // dgv
            // 
            this.dgv.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.dgv.Location = new System.Drawing.Point(30, 60);
            this.dgv.Name = "dgv";
            this.dgv.ReadOnly = true;
            this.dgv.Size = new System.Drawing.Size(800, 280);
            this.dgv.TabIndex = 1;
            // 
            // ViewAssignedServicesForm
            // 
            this.ClientSize = new System.Drawing.Size(955, 496);
            this.Controls.Add(this.lbl);
            this.Controls.Add(this.dgv);
            this.Name = "ViewAssignedServicesForm";
            this.Load += new System.EventHandler(this.ViewAssignedServicesForm_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
    }
}