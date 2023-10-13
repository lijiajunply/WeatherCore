using System.IO.Compression;
using System.Text;
using Newtonsoft.Json.Linq;

namespace WeatherCore.Lib;

public class WeatherList
{
    public string UpdateTime { get; set; } = "";
    public string FxLink { get; set; } = "";
    public List<WeatherDay> Days { get; set; } = new();
    public List<WeatherHour> Hours { get; set; } = new();
    public WeatherHour Now { get; set; } = new();
    public string CityName { get; set; } = "";
    public WeatherToday Today { get; set; } = new();
}

public static class Weather
{
    private const string ApiKey = "def33e7b79464f0e8e22aae135ec13c6";
    private const string ApiBaseUrl = "https://devapi.qweather.com/v7/weather/";
    private const string LocApi = "https://geoapi.qweather.com/v2/city/lookup";
    private const string SuggestionApi = "https://devapi.qweather.com/v7/indices/1d?";

    public static async Task<WeatherList> GetData(LocationModel city)
    {
        var nowKey = $"{ApiBaseUrl}now?location={city.id}&key={ApiKey}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(nowKey);
        var context = await response.Content.ReadAsByteArrayAsync();
        var b = Decompress(context);

        var jsonObj = JObject.Parse(Encoding.UTF8.GetString(b));

        var data = new WeatherList()
        {
            FxLink = jsonObj["fxLink"]?.ToObject<string>()!,
            UpdateTime = jsonObj["updateTime"]?.ToObject<string>()!,
            CityName = city.name
        };

        var now = jsonObj["now"]?.ToObject<WeatherHour>();
        if (now != null) data.Now = now;

        data.Days = await GetSeverDay(city.id);
        data.Hours = await GetHours(city.id);

        data.Today = await GetToday(data.Days[0], city.id);

        return data;
    }

    private static async Task<List<WeatherDay>> GetSeverDay(string city)
    {
        var severDayKey = $"{ApiBaseUrl}7d?location={city}&key={ApiKey}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(severDayKey);
        var context = await response.Content.ReadAsByteArrayAsync();

        var b = Decompress(context);
        var jsonObj = JObject.Parse(Encoding.UTF8.GetString(b));

        var data = new List<WeatherDay>();
        var array = jsonObj["daily"];
        if (array is null) return data;
        data.AddRange(array.Select(item => item.ToObject<WeatherDay>()).Where(i => i != null)!);

        return data;
    }

    private static async Task<List<WeatherHour>> GetHours(string city)
    {
        var hourKey = $"{ApiBaseUrl}24h?location={city}&key={ApiKey}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(hourKey);
        var context = await response.Content.ReadAsByteArrayAsync();

        var b = Decompress(context);
        var jsonObj = JObject.Parse(Encoding.UTF8.GetString(b));

        var data = new List<WeatherHour>();
        var array = jsonObj["hourly"];
        if (array is null) return data;
        data.AddRange(array.Select(item => item.ToObject<WeatherHour>()).Where(i => i != null)!);

        return data;
    }

    private static byte[] Decompress(byte[] bytes)
    {
        using var compressStream = new MemoryStream(bytes);
        using var zipStream = new GZipStream(compressStream, CompressionMode.Decompress);
        using var resultStream = new MemoryStream();
        zipStream.CopyTo(resultStream);
        return resultStream.ToArray();
    }

    public static async Task<LocationModel[]> GetLoc(string city)
    {
        var nowKey = $"{LocApi}?location={city}&key={ApiKey}";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(nowKey);
        var context = await response.Content.ReadAsByteArrayAsync();
        var b = Decompress(context);

        var resultJson = JObject.Parse(Encoding.UTF8.GetString(b));
        var array = Array.Empty<LocationModel>();
        var arrayJson = resultJson["location"];
        return arrayJson == null ? array : arrayJson.ToObject<LocationModel[]>()!;
    }

    private static async Task<WeatherToday> GetToday(WeatherDay day, string city)
    {
        WeatherToday today = WeatherToday.AutoCopy<WeatherDay, WeatherToday>(day);
        var todayKey = $"{SuggestionApi}location={city}&key={ApiKey}&type=0";
        using var httpClient = new HttpClient();
        var response = await httpClient.GetAsync(todayKey);
        var context = await response.Content.ReadAsByteArrayAsync();
        var b = Decompress(context);

        var resultJson = JObject.Parse(Encoding.UTF8.GetString(b));
        var array = new List<WeatherSuggestion>();
        var arrayJson = resultJson["daily"];
        array = arrayJson == null ? array : arrayJson.ToObject<List<WeatherSuggestion>>()!;
        
        today.Suggestions = array;
        return today;
    }

    public static LocationModel DefaultCity => new() { name = "北京", id = "101010100" };
}