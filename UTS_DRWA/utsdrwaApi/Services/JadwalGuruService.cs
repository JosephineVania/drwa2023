using UtsDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UtsDrwaApi.Services;

public class JadwalGuruService
{
    private readonly IMongoCollection<JadwalGuru> _jadwalCollection;

    public JadwalGuruService(
        IOptions<JadwalDatabaseSettings> jadwalDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            jadwalDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            jadwalDatabaseSettings.Value.DatabaseName);

        _jadwalCollection = mongoDatabase.GetCollection<JadwalGuru>(
            jadwalDatabaseSettings.Value.JadwalCollectionName);
    }

    public async Task<List<JadwalGuru>> GetAsync() =>
        await _jadwalCollection.Find(_ => true).ToListAsync();

    public async Task<JadwalGuru?> GetAsync(string id) =>
        await _jadwalCollection.Find(x => x.nip == id).FirstOrDefaultAsync();

    public async Task CreateAsync(JadwalGuru newGuru) =>
        await _jadwalCollection.InsertOneAsync(newGuru);

    public async Task UpdateAsync(string id, JadwalGuru updatedGuru) =>
        await _jadwalCollection.ReplaceOneAsync(x => x.nip == id, updatedGuru);

    public async Task RemoveAsync(string id) =>
        await _jadwalCollection.DeleteOneAsync(x => x.nip == id);
}