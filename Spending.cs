using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Microsoft.Reporting.WinForms;
using TravelEase;

namespace DB_M2_Chat
{
    public partial class Spending : Form
    {
        public Spending()
        {
            InitializeComponent();
        }

        private void Spending_Load(object sender, EventArgs e)
        {
            //Spending

            string connectionString = DbConfig.ConnectionString;

            string query = "SELECT * FROM TravelerSpendingHabits";

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                SqlDataAdapter adapter = new SqlDataAdapter(query, connection);
                DataSet ds = new DataSet();
                adapter.Fill(ds, "Spending");

                ReportDataSource rds = new ReportDataSource("Spending", ds.Tables["Spending"]);

                reportViewer1.LocalReport.DataSources.Clear();
                reportViewer1.LocalReport.DataSources.Add(rds);

                this.reportViewer1.RefreshReport();
            }

            this.reportViewer1.RefreshReport();
            this.reportViewer1.RefreshReport();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Preferred tp = new Preferred();
            tp.Show();  // Show the new form normally
            this.Hide();
        }
    }
}
