using Microsoft.EntityFrameworkCore;

namespace WeatherCore.Lib;

public class LocationContext : DbContext
{
    public DbSet<LocationModel> Locations { get; set; }
    public string DbPath { get; }

    public LocationContext()
    {
        var folder = Environment.SpecialFolder.LocalApplicationData;
        var path = Environment.GetFolderPath(folder);
        DbPath = Path.Join(path, "Loc.db");
    }

    protected override void OnConfiguring(DbContextOptionsBuilder options)
        => options.UseSqlite($"Data Source={DbPath}");
}

public class LocationModel
{
    public string name { get; set; }

    public string id { get; set; }
}