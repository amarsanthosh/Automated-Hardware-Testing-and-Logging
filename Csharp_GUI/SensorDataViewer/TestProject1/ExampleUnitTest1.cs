using NUnit.Framework;
using System.Data;

[TestFixture]
public class ExampleUnitTest
{
    private DataTable CreateSampleData()
    {
        DataTable dt = new DataTable();
        dt.Columns.Add("temperature", typeof(double));
        dt.Columns.Add("voltage", typeof(double));
        dt.Columns.Add("current", typeof(double));

        dt.Rows.Add(70.5, 3.3, 1.2);
        dt.Rows.Add(75.0, 3.5, 1.3);
        dt.Rows.Add(80.2, 3.7, 1.4);

        return dt;
    }

    [Test]
    public void TestCalculateAverageTemperature()
    {
        DataTable dt = CreateSampleData();
        double averageTemperature = DataAnalyzer.CalculateAverageTemperature(dt);
        Assert.AreEqual(75.23, averageTemperature, 0.01);
    }

    [Test]
    public void TestCalculateMaxTemperature()
    {
        DataTable dt = CreateSampleData();
        double maxTemperature = DataAnalyzer.CalculateMaxTemperature(dt);
        Assert.AreEqual(80.2, maxTemperature);
    }

    [Test]
    public void TestCalculateMinTemperature()
    {
        DataTable dt = CreateSampleData();
        double minTemperature = DataAnalyzer.CalculateMinTemperature(dt);
        Assert.AreEqual(70.5, minTemperature);
    }
}
