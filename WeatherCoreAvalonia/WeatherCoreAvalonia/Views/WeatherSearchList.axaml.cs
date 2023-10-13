using System.Collections.Generic;
using Avalonia.Controls;
using Avalonia.Interactivity;
using WeatherCore.Lib;
using WeatherCoreAvalonia.ViewModels;

namespace WeatherCoreAvalonia.Views;

public partial class WeatherSearchList : UserControl
{
    public WeatherSearchList(IEnumerable<LocationModel> models)
    {
        InitializeComponent();
        ItemsControl = this.FindControl<ListBox>("ItemsControl");
        ItemsControl.ItemsSource = models;
    }

    private void SearchItemAddClick(object? sender, RoutedEventArgs e)
    {
        if(sender is not Control control)return;
        if(control.DataContext is not LocationModel loc)return;
        if(DataContext is not MainViewModel model)return;
        model.Add(loc);
    }

    private void SearchItemChange(object? sender, SelectionChangedEventArgs e)
    {
        if(ItemsControl.SelectedItem is not LocationModel loc)return;
        if(DataContext is not MainViewModel model)return;
        model.Location = loc;
    }
}