using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace WeatherCoreAvalonia.Converters;

public class WeatherSvgConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            try
            {
                return $"avares://WeatherCoreAvalonia/Assets/WeatherIcon/{s}.svg";
            }
            catch
            {
                return value;
            }
        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}