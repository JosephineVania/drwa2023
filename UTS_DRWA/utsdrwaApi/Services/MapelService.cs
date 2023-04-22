using UtsDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UtsDrwaApi.Services;

public class MapelService
{
    private readonly IMongoCollection<Mapel> _mapelCollection;

    public MapelService(
        IOptions<MapelDatabaseSettings> mapelDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            mapelDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            mapelDatabaseSettings.Value.DatabaseName);

        _mapelCollection = mongoDatabase.GetCollection<Mapel>(
            mapelDatabaseSettings.Value.MapelCollectionName);
    }

    public async Task<List<Mapel>> GetAsync() =>
        await _mapelCollection.Find(_ => true).ToListAsync();

    public async Task<Mapel?> GetAsync(string mapel) =>
        await _mapelCollection.Find(x => x.kodeMapel == mapel).FirstOrDefaultAsync();

    public async Task CreateAsync(Mapel newMapel) =>
        await _mapelCollection.InsertOneAsync(newMapel);
}