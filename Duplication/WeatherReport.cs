namespace Duplication;

using System;
using System.Collections.Generic;
using System.Globalization;

public class WeatherReport
{
    public void FormatDailyReport(List<Forecast> forecasts, List<string> output)
    {
        foreach (Forecast forecast in forecasts)
        {
            var label = GetPeriodLabel(forecast);

            string line = label + ": " + forecast.GetTemperature().ToString("0.0", CultureInfo.InvariantCulture) + "°C, "
                          + forecast.GetCondition() + ", wind " + forecast.GetWindSpeed() + "km/h";
            output.Add(line);
        }
    }

    private static string GetPeriodLabel(Forecast forecast)
    {
        string label = forecast.Period switch
        {
            Period.Morning => "Morning",
            Period.Afternoon => "Afternoon",
            Period.Evening => "Evening",
            Period.Night => "Night",
            _ => "Unknown",
        };
        return label;
    }
}

public class Forecast
{
    private readonly Period period;
    private readonly double temperature;
    private readonly string condition;
    private readonly int windSpeed;

    public Forecast(Period period, double temperature, string condition, int windSpeed)
    {
        this.period = period;
        this.temperature = temperature;
        this.condition = condition;
        this.windSpeed = windSpeed;
    }

    public double GetTemperature()
    {
        return temperature;
    }

    public string GetCondition()
    {
        return condition;
    }

    public int GetWindSpeed()
    {
        return windSpeed;
    }

    public Period Period => period;
}

public enum Period
{
    Morning,
    Afternoon,
    Evening,
    Night
}