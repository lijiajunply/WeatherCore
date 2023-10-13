namespace WeatherCore.Lib;

public class WeatherToday : WeatherDay
{
    public List<WeatherSuggestion> Suggestions { get; set; } = new();

    public static TChild AutoCopy<TParent, TChild>(TParent parent) where TChild : TParent, new()
    {
        var child = new TChild();
        var ParentType = typeof(TParent);
        var Properties = ParentType.GetProperties();
        foreach (var property in Properties)
        {
            //循环遍历属性
            if (property is { CanRead: true, CanWrite: true })
            {
                //进行属性拷贝
                property.SetValue(child, property.GetValue(parent, null), null);
            }
        }

        return child;
    }
}

public class WeatherSuggestion
{
    /// <summary>
    /// 运动指数
    /// </summary>
    public string name { get; set; }

    /// <summary>
    /// 
    /// </summary>
    public string level { get; set; }

    /// <summary>
    /// 适宜
    /// </summary>
    public string category { get; set; }

    /// <summary>
    /// 天气较好，赶快投身大自然参与户外运动，尽情感受运动的快乐吧。
    /// </summary>
    public string text { get; set; }
}