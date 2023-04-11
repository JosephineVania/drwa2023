using UtsDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UtsDrwaApi.Services;

public class MapelService
{
    private readonly IMongoCollection<Guru> _guruCollection;

    public MapelService(
        IOptions<GuruDatabaseSettings> guruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            guruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            guruDatabaseSettings.Value.DatabaseName);

        _guruCollection = mongoDatabase.GetCollection<Guru>(
            guruDatabaseSettings.Value.GuruCollectionName);
    }

    public async Task<List<Guru>> GetAsync() =>
        await _guruCollection.Find(_ => true).ToListAsync();

    public async Task<Guru?> GetAsync(string mapel) =>
        await _guruCollection.Find(x => x.Mapel == mapel).FirstOrDefaultAsync();

    public async Task CreateAsync(Guru newMapel) =>
        await _guruCollection.InsertOneAsync(newMapel);
}