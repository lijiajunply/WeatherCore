namespace WeatherCore.Lib;

public class WeatherDay
{
    /// <summary>
    /// 日期
    /// </summary>
    public string fxDate { get; set; } = "";
    
    /// <summary>
    /// 日出时间
    /// </summary>
    public string sunrise { get; set; } = "";
    
    /// <summary>
    /// 日落时间
    /// </summary>
    public string sunset { get; set; } = "";
    
    /// <summary>
    /// 月出时间
    /// </summary>
    public string moonrise { get; set; } = "";
    
    /// <summary>
    /// 月落时间
    /// </summary>
    public string moonSet { get; set; } = "";
    
    /// <summary>
    /// 月相
    /// </summary>
    public string moonPhase { get; set; } = "";

    public string moonPhaseIcon { get; set; } = "";
    
    /// <summary>
    /// 最高气温
    /// </summary>
    public string tempMax { get; set; } = "";
    
    /// <summary>
    /// 最低气温
    /// </summary>
    public string tempMin { get; set; } = "";
    
    /// <summary>
    /// 白天天气
    /// </summary>
    public string textDay { get; set; } = "";
    public string iconDay { get; set; } = "";
    
    /// <summary>
    /// 晚上天气
    /// </summary>
    public string textNight { get; set; } = "";
    public string iconNight { get; set; } = "";

}