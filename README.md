# Sensor Data Viewer

## Overview
Sensor Data Viewer is a comprehensive application designed to monitor, analyze, and visualize sensor data in real-time. The project includes features such as data analysis, reporting, notification services, and an enhanced graphical user interface (GUI). It is built using C# and WinForms, with integration of external APIs and notification services.


![sensor1](https://github.com/user-attachments/assets/5fd5fd84-c700-4eb4-b735-e59b0e635225)
## Features

1. **Data Analysis and Reporting**:
   - Calculate metrics such as average, maximum, and minimum values for temperature, voltage, and current.
   - Generate reports in CSV and Excel formats.

2. **Notification Services**:
   - Integrate with Twilio to send SMS alerts when certain thresholds are exceeded.

3. **Enhanced GUI Features**:
   - Improve the user interface and user experience using WinForms.
   - Interactive charts and graphs for data visualization.

4. **Integration with External APIs**:
   - Fetch data from external APIs and integrate it into the application.

## Technologies Used

- **C#**
- **WinForms**
- **Twilio API**
- **LiveCharts**
- **NUnit** (for automated testing)
- **GitHub Actions** (for CI/CD)

## Installation

1. Clone the repository:
   ```sh
   git clone https://github.com/your-username/SensorDataViewer.git
   cd SensorDataViewer
    ```
2. Open the solution in Visual Studio.
   ```sh
   dotnet restore
   dotnet build
    ```

Usage
-----

1.  **Run the Application**:
    
    *   shdotnet run
        
2.  **Data Logging**:
    
    *   The application logs sensor data and displays it in a DataGridView.
        
    *   Real-time data visualization using interactive charts.
        
3.  **Notification Services**:
    
    *   Configure Twilio with your account SID, auth token, and phone number.
        
    *   Receive SMS alerts when sensor data exceeds predefined thresholds.
        
4.  **Data Analysis and Reporting**:
    
    *   Calculate average, maximum, and minimum values for sensor data.
        
    *   Export reports in CSV and Excel formats.
        

Configuration
-------------

1.  **Twilio Configuration**:
    
    *   Sign up for a Twilio account and get your Account SID, Auth Token, and a Twilio phone number.
        
    *   Update the TwilioService.cs file with your Twilio credentials.
        
2.  **External API Integration**:
    
    *   Configure external API keys and endpoints as needed.
        

Contributing
------------

Contributions are welcome! Please fork the repository and create a pull request with your changes.

License
-------

This project is licensed under the MIT License. See the LICENSE file for details.

Acknowledgements
----------------

*   Thanks to the developers of Twilio, LiveCharts, and NUnit for their excellent libraries and tools.
    
