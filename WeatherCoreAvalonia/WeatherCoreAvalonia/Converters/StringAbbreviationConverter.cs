using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace WeatherCoreAvalonia.Converters;

public class StringAbbreviationConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string context)
        {
            if (parameter is int a) return context[..a] + "...";
            var s = parameter as string ?? "10";
            if (!int.TryParse(s, out a)) return value;
            if (context.Length < a) return context;
            return context[..a] + "...";
        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}