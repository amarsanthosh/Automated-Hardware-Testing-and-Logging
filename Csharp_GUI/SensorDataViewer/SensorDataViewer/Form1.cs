using System;
using System.Data;
using System.Threading;
using System.Windows.Forms;

namespace SensorDataViewer
{
    public partial class Form1 : Form
    {
        private Thread loggingThread;
        private bool isLogging = false;

        public Form1()
        {
            InitializeComponent();
            LoadData();
        }

        private void LoadData()
        {
            DataTable dt = DatabaseHelper.GetSensorData();
            dataGridView1.DataSource = dt;
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
                Invoke(new Action(() => dataGridView1.DataSource = dt));
                Thread.Sleep(1000); // 1-second delay
            }
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {
            // Handle cell content click event here
        }

    }
}
