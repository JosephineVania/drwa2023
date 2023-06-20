using UasDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UasDrwaApi.Services;

public class KelasUasService
{
    private readonly IMongoCollection<KelasUas> _kelasCollection;

    public KelasUasService(
        IOptions<KelasUasDatabaseSettings> kelasDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            kelasDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            kelasDatabaseSettings.Value.DatabaseName);

        _kelasCollection = mongoDatabase.GetCollection<KelasUas>(
            kelasDatabaseSettings.Value.KelasCollectionName);
    }

    public async Task<List<KelasUas>> GetAsync() =>
        await _kelasCollection.Find(_ => true).ToListAsync();

    public async Task<KelasUas?> GetAsync(string id) =>
        await _kelasCollection.Find(x => x.id == id).FirstOrDefaultAsync();

    public async Task CreateAsync(KelasUas newKelas) =>
        await _kelasCollection.InsertOneAsync(newKelas);

    public async Task UpdateAsync(string id, KelasUas updatedKelas) =>
        await _kelasCollection.ReplaceOneAsync(x => x.id == id, updatedKelas);

    public async Task RemoveAsync(string id) =>
        await _kelasCollection.DeleteOneAsync(x => x.id == id);
}