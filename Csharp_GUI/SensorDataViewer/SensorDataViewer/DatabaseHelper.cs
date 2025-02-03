using System;
using System.Data;
using System.Data.SQLite;

public class DatabaseHelper
{
    private static string connectionString = "Data Source=C:\\Users\\sandyman\\playground\\AutomatedTestingProject\\Automated-Hardware-Testing-and-Logging\\python_scripts\\sensor_data.db;Version=3;";

    public static DataTable GetSensorData()
    {
        using (SQLiteConnection conn = new SQLiteConnection(connectionString))
        {
            conn.Open();
            string query = "SELECT timestamp, temperature, voltage, current FROM SensorReadings ORDER BY id DESC LIMIT 13"; // Fetch last 13 entries

            using (SQLiteCommand cmd = new SQLiteCommand(query, conn))
            {
                using (SQLiteDataAdapter adapter = new SQLiteDataAdapter(cmd))
                {
                    DataTable dt = new DataTable();
                    adapter.Fill(dt);
                    return dt;
                }
            }
        }
    }
}