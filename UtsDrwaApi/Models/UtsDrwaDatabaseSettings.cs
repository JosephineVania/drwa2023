namespace UtsDrwaApi.Models;

public class UtsDrwaDatabaseSettings
{
    public string ConnectionString { get; set; } = null!;

    public string DatabaseName { get; set; } = null!;

    public string GuruCollectionName { get; set; } = null!;
}