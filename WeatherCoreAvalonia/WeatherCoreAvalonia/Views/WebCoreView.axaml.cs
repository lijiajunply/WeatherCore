using Avalonia;
using Avalonia.Controls;
using Avalonia.Markup.Xaml;
using WeatherCoreAvalonia.ViewModels;

namespace WeatherCoreAvalonia.Views;

public partial class WebCoreView : Window
{
    public WebCoreView(string url)
    {
        InitializeComponent();
        DataContext = new WebCoreViewModel(url);
    }
}