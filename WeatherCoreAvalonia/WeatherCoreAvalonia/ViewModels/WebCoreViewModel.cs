namespace WeatherCoreAvalonia.ViewModels;

public class WebCoreViewModel : ViewModelBase
{
    private string currentAddress;

    public WebCoreViewModel(string url)
    {
        CurrentAddress = url;
    }
    
    public string CurrentAddress
    {
        get => currentAddress;
        set => SetField(ref currentAddress, value);
    }
}