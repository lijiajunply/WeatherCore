namespace WeatherCore.Lib;

public class WeatherHour
{
    public string? fxTime { get; set; }
    
    /// <summary>
    /// 温度
    /// </summary>
    public string? temp { get; set; }
    
    /// <summary>
    /// 图像
    /// </summary>
    public string? icon { get; set; }
    
    /// <summary>
    /// 天气
    /// </summary>
    public string? text { get; set; }
    
    /// <summary>
    /// 粗略风向
    /// </summary>
    public string? windDir { get; set; }
    
    /// <summary>
    /// 风级
    /// </summary>
    public string? windScale { get; set; }
    
    /// <summary>
    /// 空气质量
    /// </summary>
    public string? humidity { get; set; }
    
    /// <summary>
    /// 降水量
    /// </summary>
    public string? precip { get; set; }
    
    /// <summary>
    /// 气压
    /// </summary>
    public string? pressure { get; set; }
    
    /// <summary>
    /// 能见度
    /// </summary>
    public string? vis { get; set; }
    
    /// <summary>
    /// 
    /// </summary>
    public string? feelsLike { get; set; }
}