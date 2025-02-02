using System;
using System.Data;
using System.Linq;

public class DataAnalyzer
{
    public static void AnalyzeData(DataTable dt)
    {
        var temperatureValues = dt.AsEnumerable().Select(row => row.Field<double>("temperature")).ToList();
        var voltageValues = dt.AsEnumerable().Select(row => row.Field<double>("voltage")).ToList();
        var currentValues = dt.AsEnumerable().Select(row => row.Field<double>("current")).ToList();

        double avgTemperature = temperatureValues.Average();
        double maxTemperature = temperatureValues.Max();
        double minTemperature = temperatureValues.Min();

        double avgVoltage = voltageValues.Average();
        double maxVoltage = voltageValues.Max();
        double minVoltage = voltageValues.Min();

        double avgCurrent = currentValues.Average();
        double maxCurrent = currentValues.Max();
        double minCurrent = currentValues.Min();

        Console.WriteLine($"Average Temperature: {avgTemperature}");
        Console.WriteLine($"Max Temperature: {maxTemperature}");
        Console.WriteLine($"Min Temperature: {minTemperature}");

        Console.WriteLine($"Average Voltage: {avgVoltage}");
        Console.WriteLine($"Max Voltage: {maxVoltage}");
        Console.WriteLine($"Min Voltage: {minVoltage}");

        Console.WriteLine($"Average Current: {avgCurrent}");
        Console.WriteLine($"Max Current: {maxCurrent}");
        Console.WriteLine($"Min Current: {minCurrent}");
    }
}
