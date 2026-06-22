namespace Duplication.Test;

using NUnit.Framework;
using System.Collections.Generic;

[TestFixture]
public class WeatherReportTest
{
    [Test]
    public void FormatsMorningForecastCorrectly()
    {
        var report = new WeatherReport();

        var forecast = new Forecast(Period.Morning, 12.5, "Cloudy", 10);

        var output = new List<string>();
        report.FormatDailyReport(new List<Forecast> { forecast }, output);

        Assert.That(output.Count, Is.EqualTo(1));
        Assert.That(
            output[0],
            Is.EqualTo("Morning: 12.5°C, Cloudy, wind 10km/h")
        );
    }

    [Test]
    public void FormatsAfternoonForecastCorrectly()
    {
        var report = new WeatherReport();

        var forecast = new Forecast(Period.Afternoon, 8.0, "Rain", 20);

        var output = new List<string>();
        report.FormatDailyReport(new List<Forecast> { forecast }, output);

        Assert.That(output.Count, Is.EqualTo(1));
        Assert.That(
            output[0],
            Is.EqualTo("Afternoon: 8.0°C, Rain, wind 20km/h")
        );
    }

    [Test]
    public void FormatsEveningForecastCorrectly()
    {
        var report = new WeatherReport();

        var forecast = new Forecast(Period.Evening, 8.0, "Rain", 20);

        var output = new List<string>();
        report.FormatDailyReport(new List<Forecast> { forecast }, output);

        Assert.That(output.Count, Is.EqualTo(1));
        Assert.That(
            output[0],
            Is.EqualTo("Evening: 8.0°C, Rain, wind 20km/h")
        );
    }

    [Test]
    public void FormatsMultipleForecastsInOrder()
    {
        var report = new WeatherReport();

        var forecasts = new List<Forecast>
        {
            new Forecast(Period.Morning, 10.0, "Sunny", 5),
            new Forecast(Period.Night, 3.0, "Clear", 2)
        };

        var output = new List<string>();
        report.FormatDailyReport(forecasts, output);

        Assert.That(output.Count, Is.EqualTo(2));

        Assert.That(
            output[0],
            Is.EqualTo("Morning: 10.0°C, Sunny, wind 5km/h")
        );

        Assert.That(
            output[1],
            Is.EqualTo("Night: 3.0°C, Clear, wind 2km/h")
        );
    }
}