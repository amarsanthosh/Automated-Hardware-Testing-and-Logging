import sqlite3
import random
import time
from datetime import datetime

# Database setup
DB_NAME = "sensor_data.db"

def create_database():
    """Create the database and table if not exists."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    cursor.execute("""
        CREATE TABLE IF NOT EXISTS SensorReadings (
            id INTEGER PRIMARY KEY AUTOINCREMENT,
            timestamp TEXT,
            temperature REAL,
            voltage REAL,
            current REAL
        )
    """)
    conn.commit()
    conn.close()

def generate_sensor_data():
    """Simulate random sensor readings."""
    temperature = round(random.uniform(20, 80), 2)  # °C
    voltage = round(random.uniform(3.0, 5.0), 2)   # Volts
    current = round(random.uniform(0.5, 2.5), 2)   # Amperes
    return temperature, voltage, current

def log_sensor_data():
    """Continuously generate and log sensor data."""
    conn = sqlite3.connect(DB_NAME)
    cursor = conn.cursor()
    
    try:
        while True:
            timestamp = datetime.now().strftime("%Y-%m-%d %H:%M:%S")
            temperature, voltage, current = generate_sensor_data()
            
            cursor.execute("INSERT INTO SensorReadings (timestamp, temperature, voltage, current) VALUES (?, ?, ?, ?)", 
                           (timestamp, temperature, voltage, current))
            conn.commit()
            
            print(f"[{timestamp}] Temp: {temperature}°C | Voltage: {voltage}V | Current: {current}A")
            
            time.sleep(1)  # Simulate real-time logging (1 sec delay)
    
    except KeyboardInterrupt:
        print("\nLogging stopped by user.")
        conn.close()

# Run the script
if __name__ == "__main__":
    create_database()
    log_sensor_data()