using System;
using System.Data;
using System.Drawing;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;
using System.Data.SqlClient;

namespace TravelEase.Forms
{
    public partial class AnalyticsForm : Form
    {
        // Database connection string - MUST BE REPLACED
        private string connectionString = "Data Source=ALEENA-LAPTOP\\SQLEXPRESS;Initial Catalog=TravelEase;Integrated Security=True;TrustServerCertificate=True";

        public AnalyticsForm()
        {
            InitializeComponent();
        }

        private void AnalyticsForm_Load(object sender, EventArgs e)
        {
            cmbTimeFrame.SelectedIndex = 0; // Default to "Last 30 Days"
            cmbChartType.SelectedIndex = 0; // Default to "Line Chart"
            LoadData();
        }

        private void LoadData()
        {
            try
            {
                // Separate method calls to isolate potential errors
                UpdateSummaryCards();
                LoadBookingTrendsChart();
                LoadUserTrafficChart();
                LoadRevenueData();
                LoadTopDestinations();
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error loading analytics: {ex.Message}", "Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void UpdateSummaryCards()
        {
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();

                // Total Bookings in last 30 days
                string bookingsQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Total Revenue in last 30 days
                string revenueQuery = @"
                    SELECT ISNULL(SUM(TotalCost), 0) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Active Users in last 30 days
                string usersQuery = @"
                    SELECT COUNT(DISTINCT TravelerID) 
                    FROM Booking 
                    WHERE BookingDate >= DATEADD(day, -30, GETDATE())";

                // Completed Tours in last 30 days
                string toursQuery = @"
                    SELECT COUNT(*) 
                    FROM Booking 
                    WHERE Status = 'Completed' 
                    AND BookingDate >= DATEADD(day, -30, GETDATE())";

                using (SqlCommand cmd = new SqlCommand(bookingsQuery, connection))
                    lblTotalBookings.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");

                using (SqlCommand cmd = new SqlCommand(revenueQuery, connection))
                    lblTotalRevenue.Text = Convert.ToDecimal(cmd.ExecuteScalar()).ToString("C0");

                using (SqlCommand cmd = new SqlCommand(usersQuery, connection))
                    lblActiveUsers.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");

                using (SqlCommand cmd = new SqlCommand(toursQuery, connection))
                    lblCompletedTours.Text = Convert.ToInt32(cmd.ExecuteScalar()).ToString("N0");
            }
        }

        private void LoadBookingTrendsChart()
        {
            chartBookings.Series.Clear();
            chartBookings.ChartAreas[0].AxisY.Title = "Number of Bookings";
            chartBookings.Titles.Clear();
            chartBookings.Titles.Add("Booking Trends");

            var bookingSeries = new Series("Bookings")
            {
                ChartType = GetSelectedChartType(),
                Color = Color.FromArgb(11, 57, 84),
                BorderWidth = 3
            };

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        CONVERT(VARCHAR(7), BookingDate, 120) AS BookingMonth, 
                        COUNT(*) AS BookingCount
                    FROM Booking
                    WHERE BookingDate >= DATEADD(month, -12, GETDATE())
                    GROUP BY CONVERT(VARCHAR(7), BookingDate, 120)
                    ORDER BY BookingMonth";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        bookingSeries.Points.AddXY(
                            reader["BookingMonth"].ToString(),
                            Convert.ToInt32(reader["BookingCount"])
                        );
                    }
                }
            }

            chartBookings.Series.Add(bookingSeries);
        }

        private void LoadUserTrafficChart()
        {
            chartUserTraffic.Series.Clear();
            chartUserTraffic.Titles.Clear();
            chartUserTraffic.Titles.Add("User Traffic Distribution");

            var trafficSeries = new Series("Traffic")
            {
                ChartType = SeriesChartType.Pie,
                IsValueShownAsLabel = true,
                LabelFormat = "{0}%"
            };

            // Mock data since we don't have platform tracking
            trafficSeries.Points.AddXY("Web Bookings", 45);
            trafficSeries.Points.AddXY("Mobile Bookings", 35);
            trafficSeries.Points.AddXY("Direct Bookings", 20);

            // Color each slice
            trafficSeries.Points[0].Color = Color.FromArgb(46, 139, 87);
            trafficSeries.Points[1].Color = Color.FromArgb(70, 130, 180);
            trafficSeries.Points[2].Color = Color.FromArgb(255, 127, 80);

            chartUserTraffic.Series.Add(trafficSeries);
        }

        private void LoadRevenueData()
        {
            dgvRevenue.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT 
                        TourCategory,
                        SUM(t.Price) AS CategoryRevenue,
                        ROUND(SUM(t.Price) * 100.0 / (SELECT SUM(Price) FROM Trip), 2) AS Percentage
                    FROM Trip t
                    JOIN Booking b ON t.TripID = b.TripID
                    GROUP BY t.TourCategory
                    ORDER BY CategoryRevenue DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        int rowIndex = dgvRevenue.Rows.Add(
                            reader["TourCategory"].ToString(),
                            Convert.ToDecimal(reader["CategoryRevenue"]).ToString("C0"),
                            reader["Percentage"].ToString() + "%",
                            "+5.2%" // Mock growth rate
                        );

                        // Color code growth
                        dgvRevenue.Rows[rowIndex].Cells["Growth"].Style.ForeColor = Color.Green;
                    }
                }
            }
        }

        private void LoadTopDestinations()
        {
            dgvTopDestinations.Rows.Clear();

            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                string query = @"
                    SELECT TOP 5 
                        td.Destination, 
                        COUNT(b.BookingID) AS BookingCount,
                        ROUND(AVG(CAST(t.Sustainability_Score AS FLOAT)), 1) AS AvgRating
                    FROM TripDestination td
                    JOIN Trip t ON td.TripID = t.TripID
                    JOIN Booking b ON t.TripID = b.TripID
                    GROUP BY td.Destination
                    ORDER BY BookingCount DESC";

                using (SqlCommand cmd = new SqlCommand(query, connection))
                using (SqlDataReader reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        dgvTopDestinations.Rows.Add(
                            reader["Destination"].ToString(),
                            reader["BookingCount"].ToString(),
                            reader["AvgRating"].ToString()
                        );
                    }
                }
            }
        }

        // Utility method for chart type selection
        private SeriesChartType GetSelectedChartType()
        {
            switch (cmbChartType.SelectedIndex)
            {
                case 0:
                    return SeriesChartType.Line;
                case 1:
                    return SeriesChartType.Column;
                case 2:
                    return SeriesChartType.Area;
                default:
                    return SeriesChartType.Line;
            }
        }

        // Event handlers for time frame and chart type changes
        private void cmbTimeFrame_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadData();
        }

        private void cmbChartType_SelectedIndexChanged(object sender, EventArgs e)
        {
            LoadBookingTrendsChart();
        }

        // Export methods
        private void btnExportPDF_Click(object sender, EventArgs e)
        {
            MessageBox.Show("PDF Export functionality to be implemented", "Export PDF",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void btnExportCSV_Click(object sender, EventArgs e)
        {
            try
            {
                using (SaveFileDialog saveDialog = new SaveFileDialog())
                {
                    saveDialog.Filter = "CSV files (*.csv)|*.csv";
                    saveDialog.Title = "Export Analytics to CSV";
                    saveDialog.FileName = $"TravelEase_Analytics_{DateTime.Now:yyyyMMdd}.csv";

                    if (saveDialog.ShowDialog() == DialogResult.OK)
                    {
                        ExportToCSV(saveDialog.FileName);
                        MessageBox.Show("CSV Export completed successfully!", "Export Complete",
                            MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Export failed: {ex.Message}", "Export Error",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void ExportToCSV(string filePath)
        {
            using (System.IO.StreamWriter writer = new System.IO.StreamWriter(filePath))
            {
                // Write summary data
                writer.WriteLine("TravelEase Platform Analytics");
                writer.WriteLine($"Generated on,{DateTime.Now}");
                writer.WriteLine($"Total Bookings,{lblTotalBookings.Text}");
                writer.WriteLine($"Total Revenue,{lblTotalRevenue.Text}");
                writer.WriteLine($"Active Users,{lblActiveUsers.Text}");
                writer.WriteLine($"Completed Tours,{lblCompletedTours.Text}");

                // Revenue by Category
                writer.WriteLine("\nRevenue by Category");
                writer.WriteLine("Category,Revenue,Percentage,Growth");
                foreach (DataGridViewRow row in dgvRevenue.Rows)
                {
                    writer.WriteLine(string.Join(",",
                        row.Cells[0].Value?.ToString() ?? "",
                        row.Cells[1].Value?.ToString() ?? "",
                        row.Cells[2].Value?.ToString() ?? "",
                        row.Cells[3].Value?.ToString() ?? ""));
                }

                // Top Destinations
                writer.WriteLine("\nTop Destinations");
                writer.WriteLine("Destination,Bookings,Rating");
                foreach (DataGridViewRow row in dgvTopDestinations.Rows)
                {
                    writer.WriteLine(string.Join(",",
                        row.Cells[0].Value?.ToString() ?? "",
                        row.Cells[1].Value?.ToString() ?? "",
                        row.Cells[2].Value?.ToString() ?? ""));
                }
            }
        }

        private void btnRefresh_Click(object sender, EventArgs e)
        {
            LoadData();
        }
    }
}