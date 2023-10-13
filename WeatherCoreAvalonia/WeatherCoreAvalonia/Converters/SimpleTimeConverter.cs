using System;
using System.Globalization;
using System.Text.RegularExpressions;
using Avalonia.Data.Converters;

namespace WeatherCoreAvalonia.Converters;

public class SimpleTimeConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            var match = Regex.Match(s, "(.*)T(.*)\\+(.*)");
            if (match.Groups.Count < 3) return value;
            var result = match.Groups[2];
            return result.Value;

        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}

public class SimpleDayConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            var match = Regex.Match(s, "(.*?)-(.*)");
            if (match.Groups.Count < 3) return value;
            var result = match.Groups[2];
            return result.Value;

        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}