using System;
using System.Data;
using System.Linq;

public class DataAnalyzer
{
    public static double CalculateAverageTemperature(DataTable dt)
    {
        var temperatureValues = dt.AsEnumerable().Select(row => row.Field<double>("temperature")).ToList();
        return temperatureValues.Average();
    }

    public static double CalculateMaxTemperature(DataTable dt)
    {
        var temperatureValues = dt.AsEnumerable().Select(row => row.Field<double>("temperature")).ToList();
        return temperatureValues.Max();
    }

    public static double CalculateMinTemperature(DataTable dt)
    {
        var temperatureValues = dt.AsEnumerable().Select(row => row.Field<double>("temperature")).ToList();
        return temperatureValues.Min();
    }
}
