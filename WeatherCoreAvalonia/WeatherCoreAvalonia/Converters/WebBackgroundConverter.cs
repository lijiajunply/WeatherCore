using System;
using System.Globalization;
using System.Net.Http;
using Avalonia.Data.Converters;
using Avalonia.Media;
using Avalonia.Media.Imaging;

namespace WeatherCoreAvalonia.Converters;

public class WebBackgroundConverter : IValueConverter
{
    public object? Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        if (value is string s)
        {
            var client = new HttpClient(){BaseAddress = new Uri("https://cn.bing.com/")};
            var context = client.GetAsync(s).Result;
            return new ImageBrush() { Source = new Bitmap(context.Content.ReadAsStream())};
        }
        return value;
    }

    public object? ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
    {
        return value;
    }
}