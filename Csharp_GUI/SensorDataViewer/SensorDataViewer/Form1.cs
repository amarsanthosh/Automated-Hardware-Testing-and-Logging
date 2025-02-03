using System;
using System.IO;
using System.Data;
using System.Threading;
using System.Windows.Forms;
using ClosedXML.Excel;
using LiveCharts;
using LiveCharts.Wpf;
using LiveCharts.WinForms;
using System.Linq;

namespace SensorDataViewer
{
    public partial class Form1 : Form
    {
        private Thread loggingThread;
        private bool isLogging = false;
        private ChartValues<double> temperatureValues;
        private ChartValues<double> voltageValues;
        private ChartValues<double> currentValues;

        public Form1()
        {
            InitializeComponent();
            LoadData();
            InitializeChart();
        }

        private void LoadData()
        {
            DataTable dt = DatabaseHelper.GetSensorData();
            dataGridView1.DataSource = dt;
        }

        private void InitializeChart()
        {
            temperatureValues = new ChartValues<double>();
            voltageValues = new ChartValues<double>();
            currentValues = new ChartValues<double>();

            cartesianChart1.Series = new SeriesCollection
            {
                new LineSeries
                {
                    Title = "Temperature",
                    Values = temperatureValues
                },
                new LineSeries
                {
                    Title = "Voltage",
                    Values = voltageValues
                },
                new LineSeries
                {
                    Title = "Current",
                    Values = currentValues
                }
            };

            cartesianChart1.AxisX.Add(new Axis
            {
                Title = "Time",
                Labels = new[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9" }
            });

            cartesianChart1.AxisY.Add(new Axis
            {
                Title = "Values",
                LabelFormatter = value => value.ToString("N")
            });
        }
        private void btnStartTest_Click(object sender, EventArgs e)
        {
            if (!isLogging)
            {
                isLogging = true;
                loggingThread = new Thread(new ThreadStart(LogData));
                loggingThread.Start();
                MessageBox.Show("Logging started.");
            }
        }

        private void btnStopTest_Click(object sender, EventArgs e)
        {
            if (isLogging)
            {
                isLogging = false;
                loggingThread.Join();
                MessageBox.Show("Logging stopped.");
            }
        }

        private void LogData()
        {
            while (isLogging)
            {
                // Fetch the latest data from the database
                DataTable dt = DatabaseHelper.GetSensorData();
                Invoke(new Action(() =>
                {
                    dataGridView1.DataSource = dt;
                    UpdateChart(dt);
                    //CheckThresholds(dt);
                    Console.WriteLine("DataGridView updated with " + dt.Rows.Count + " rows");
                }));
                Thread.Sleep(1000); // 1-second delay
            }
        }

        private void UpdateChart(DataTable dt)
        {
            temperatureValues.Clear();
            voltageValues.Clear();
            currentValues.Clear();

            foreach (DataRow row in dt.Rows)
            {
                temperatureValues.Add(Convert.ToDouble(row["temperature"]));
                voltageValues.Add(Convert.ToDouble(row["voltage"]));
                currentValues.Add(Convert.ToDouble(row["current"]));
            }

            cartesianChart1.Update(true, true);
        }

        private void btnExportReport_Click(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Report";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".csv")
                {
                    ExportToCSV(dt, filePath);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    GenerateReport(dt, filePath);
                }
            }
        }



        private void ExportToCSV(DataTable dt, string filePath)
        {
            using (StreamWriter sw = new StreamWriter(filePath))
            {
                // Write column headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    sw.Write(dt.Columns[i]);
                    if (i < dt.Columns.Count - 1)
                    {
                        sw.Write(",");
                    }
                }
                sw.WriteLine();

                // Write data rows
                foreach (DataRow row in dt.Rows)
                {
                    for (int i = 0; i < dt.Columns.Count; i++)
                    {
                        sw.Write(row[i].ToString());
                        if (i < dt.Columns.Count - 1)
                        {
                            sw.Write(",");
                        }
                    }
                    sw.WriteLine();
                }
            }
        }
        private void ExportToExcel(DataTable dt, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sensor Data");

                // Add column headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                }

                // Add data rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dt.Rows[i][j].ToString(); // Explicitly convert to string
                    }
                }

                // Save the workbook
                workbook.SaveAs(filePath);
            }
        }
        private void GenerateReport(DataTable dt, string filePath)
        {
            using (var workbook = new XLWorkbook())
            {
                var worksheet = workbook.Worksheets.Add("Sensor Data Report");

                // Add column headers
                for (int i = 0; i < dt.Columns.Count; i++)
                {
                    worksheet.Cell(1, i + 1).Value = dt.Columns[i].ColumnName;
                }

                // Add data rows
                for (int i = 0; i < dt.Rows.Count; i++)
                {
                    for (int j = 0; j < dt.Columns.Count; j++)
                    {
                        worksheet.Cell(i + 2, j + 1).Value = dt.Rows[i][j].ToString();
                    }
                }

                // Add temperature metrics
                worksheet.Cell(dt.Rows.Count + 3, 1).Value = "Average Temperature";
                worksheet.Cell(dt.Rows.Count + 3, 2).Value = dt.AsEnumerable().Average(row => row.Field<double>("temperature"));

                worksheet.Cell(dt.Rows.Count + 4, 1).Value = "Max Temperature";
                worksheet.Cell(dt.Rows.Count + 4, 2).Value = dt.AsEnumerable().Max(row => row.Field<double>("temperature"));

                worksheet.Cell(dt.Rows.Count + 5, 1).Value = "Min Temperature";
                worksheet.Cell(dt.Rows.Count + 5, 2).Value = dt.AsEnumerable().Min(row => row.Field<double>("temperature"));

                // Add voltage metrics
                worksheet.Cell(dt.Rows.Count + 6, 1).Value = "Average Voltage";
                worksheet.Cell(dt.Rows.Count + 6, 2).Value = dt.AsEnumerable().Average(row => row.Field<double>("voltage"));

                worksheet.Cell(dt.Rows.Count + 7, 1).Value = "Max Voltage";
                worksheet.Cell(dt.Rows.Count + 7, 2).Value = dt.AsEnumerable().Max(row => row.Field<double>("voltage"));

                worksheet.Cell(dt.Rows.Count + 8, 1).Value = "Min Voltage";
                worksheet.Cell(dt.Rows.Count + 8, 2).Value = dt.AsEnumerable().Min(row => row.Field<double>("voltage"));

                // Add current metrics
                worksheet.Cell(dt.Rows.Count + 9, 1).Value = "Average Current";
                worksheet.Cell(dt.Rows.Count + 9, 2).Value = dt.AsEnumerable().Average(row => row.Field<double>("current"));

                worksheet.Cell(dt.Rows.Count + 10, 1).Value = "Max Current";
                worksheet.Cell(dt.Rows.Count + 10, 2).Value = dt.AsEnumerable().Max(row => row.Field<double>("current"));

                worksheet.Cell(dt.Rows.Count + 11, 1).Value = "Min Current";
                worksheet.Cell(dt.Rows.Count + 11, 2).Value = dt.AsEnumerable().Min(row => row.Field<double>("current"));

                // Save the workbook
                workbook.SaveAs(filePath);
            }
        }
        private void CheckThresholds(DataTable dt)
        {
            var twilioService = new TwilioService();

            foreach (DataRow row in dt.Rows)
            {
                double temperature = Convert.ToDouble(row["temperature"]);
                double voltage = Convert.ToDouble(row["voltage"]);
                double current = Convert.ToDouble(row["current"]);

                if (temperature > 75)
                {
                    twilioService.SendSms("+917339442985", $"Alert: High temperature detected: {temperature}C");
                }

                if (voltage > 4.5)
                {
                    twilioService.SendSms("+917339442985", $"Alert: High voltage detected: {voltage}V");
                }

                if (current > 2.0)
                {
                    twilioService.SendSms("+917339442985", $"Alert: High current detected: {current}A");
                }
            }
        }


        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event here
        }

        private void cartesianChart1_ChildChanged(object sender, System.Windows.Forms.Integration.ChildChangedEventArgs e)
        {

        }


        private void btnExportReport_Click_1(object sender, EventArgs e)
        {
            DataTable dt = (DataTable)dataGridView1.DataSource;
            SaveFileDialog saveFileDialog = new SaveFileDialog();
            saveFileDialog.Filter = "CSV files (*.csv)|*.csv|Excel files (*.xlsx)|*.xlsx";
            saveFileDialog.Title = "Save Report";

            if (saveFileDialog.ShowDialog() == DialogResult.OK)
            {
                string filePath = saveFileDialog.FileName;
                if (Path.GetExtension(filePath).ToLower() == ".csv")
                {
                    ExportToCSV(dt, filePath);
                }
                else if (Path.GetExtension(filePath).ToLower() == ".xlsx")
                {
                    GenerateReport(dt, filePath);
                }
            }
        }

        private void btnStartTest_Click_1(object sender, EventArgs e)
        {
            if (!isLogging)
            {
                isLogging = true;
                loggingThread = new Thread(new ThreadStart(LogData));
                loggingThread.Start();
                MessageBox.Show("Logging started.");
            }
        }

        private void btnStopTest_Click_1(object sender, EventArgs e)
        {
            if (isLogging)
            {
                isLogging = false;
                loggingThread.Join();
                MessageBox.Show("Logging stopped.");
            }
        }
    }
}
