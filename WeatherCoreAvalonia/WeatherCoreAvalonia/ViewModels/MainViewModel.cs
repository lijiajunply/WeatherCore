using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using WeatherCore.Lib;

namespace WeatherCoreAvalonia.ViewModels;

public class MainViewModel : ViewModelBase
{
     public void Left()
    {
        Index--;
        if (Index <= -1 || Index >= Locations.Count)
        {
            Index++;
            return;
        }

        Location = Locations[Index];
    }

    public void Right()
    {
        Index++;
        if (Index <= -1 || Index >= Locations.Count)
        {
            Index--;
            return;
        }

        Location = Locations[Index];
    }
    
    private int Index { get; set; }
    public ObservableCollection<LocationModel> Locations { get; set; }
    public LocationContext Context { get; set; }

    private LocationModel _location;

    public LocationModel Location
    {
        get => _location;
        set
        {
            if(value == null)return;
            SetField(ref _location, value);
            GetWeatherData();
            var index = Locations.IndexOf(_location);
            if (index != -1 && index >= Locations.Count)
            {
                Index = index;
            }
        }
    }

    public void Add(LocationModel model)
    {
        Context.Locations.Add(model);
        Locations.Add(model);
        Context.SaveChanges();
    }


    public async Task<IEnumerable<LocationModel>> Search(string? s)
    {
        if (string.IsNullOrEmpty(s))
            return Array.Empty<LocationModel>();
        return await Weather.GetLoc(s);
    }
    
    private WeatherList _data = new();

    public WeatherList Data
    {
        get => _data;
        set => SetField(ref _data, value);
    }

    public async void GetWeatherData()
    {
        Data = await Weather.GetData(_location);
    }
    

    public MainViewModel()
    {
        Context = new LocationContext();
        Locations = new ObservableCollection<LocationModel>(Context.Locations);
        if (Locations.Count == 0)
        {
            _location = Weather.DefaultCity;
            Locations.Add(_location);
        }
        else
        {
            _location = Locations.First();
        }
    }
}