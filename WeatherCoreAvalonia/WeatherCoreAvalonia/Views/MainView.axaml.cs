using System;
using Avalonia;
using Avalonia.Controls;
using Avalonia.Controls.Primitives;
using Avalonia.Input;
using WeatherCoreAvalonia.ViewModels;

namespace WeatherCoreAvalonia.Views;

public partial class MainView : UserControl
{
    public MainView()
    {
        InitializeComponent();
    }
    
    protected override void OnAttachedToVisualTree(VisualTreeAttachmentEventArgs e)
    {
        base.OnAttachedToVisualTree(e);
        if(DataContext is not MainViewModel model)return;
        model.GetWeatherData();
    }

    private async void SearchDown(object? sender, KeyEventArgs e)
    {
        if (e.Key != Key.Enter) return;
        if(DataContext is not MainViewModel model)return;
        var fl = new Flyout() { Content = new WeatherSearchList(await model.Search(SearchBox.Text)){DataContext = DataContext} };
        FlyoutBase.SetAttachedFlyout(SearchBox,fl);
        FlyoutBase.ShowAttachedFlyout(SearchBox);
    }

    private void WeatherSuggestionChanged(object? sender, SelectionChangedEventArgs e)
    {
        if(sender is not ListBox box)return;
        SuggestionControl.Content = box.SelectedItem;
    }

    private void SuggestionListInitialized(object? sender, EventArgs e)
    {
        if(sender is not ListBox box)return;
        box.SelectedIndex = 0;
    }
}