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
            string periodLabel = forecast.GetPeriodLabel();
            string temperature = forecast.GetTemperature().ToString("0.0", CultureInfo.InvariantCulture) + "°C";
            string condition = forecast.GetCondition();
            string windSpeed = "wind " + forecast.GetWindSpeed().ToString("0", CultureInfo.InvariantCulture) + "km/h";;
            
            string line =  periodLabel + ": " + temperature + ", " + condition + ", " + windSpeed;
            output.Add(line);
        }
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

    public string GetPeriodLabel()
    {
        string label = period switch
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

public enum Period
{
    Morning,
    Afternoon,
    Evening,
    Night
}