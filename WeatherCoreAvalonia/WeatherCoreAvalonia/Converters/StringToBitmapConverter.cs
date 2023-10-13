using System;
using System.Globalization;
using Avalonia.Data.Converters;
using Avalonia.Media.Imaging;
using Avalonia.Platform;

namespace WeatherCoreAvalonia.Converters;

public class StringToBitmapConverter : IValueConverter
{
    public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        try
        {
            using var s = AssetLoader.Open(new Uri(value?.ToString()!));
            return new Bitmap(s);
        }
        catch
        {
            using var s = AssetLoader.Open(new Uri("avares://WeatherCoreAvalonia/Assets/avalonia-logo.ico"));
            return new Bitmap(s);
        }
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}