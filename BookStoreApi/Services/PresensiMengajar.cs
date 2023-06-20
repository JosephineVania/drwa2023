using UasDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UasDrwaApi.Services;

public class PresensiMengajarService
{
    private readonly IMongoCollection<PresensiMengajar> _presensimengajarCollection;

    public PresensiMengajarService(
        IOptions<PresensiMengajarDatabaseSettings> presensimengajarDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            presensimengajarDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            presensimengajarDatabaseSettings.Value.DatabaseName);

        _presensimengajarCollection = mongoDatabase.GetCollection<PresensiMengajar>(
            presensimengajarDatabaseSettings.Value.PresensiMengajarCollectionName);
    }

    public async Task<List<PresensiMengajar>> GetAsync() =>
        await _presensimengajarCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiMengajar?> GetAsync(string id) =>
        await _presensimengajarCollection.Find(x => x.NIP == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiMengajar newPresensiMengajar) =>
        await _presensimengajarCollection.InsertOneAsync(newPresensiMengajar);

    public async Task UpdateAsync(string id, PresensiMengajar updatedPresensiMengajar) =>
        await _presensimengajarCollection.ReplaceOneAsync(x => x.NIP == id, updatedPresensiMengajar);

    public async Task RemoveAsync(string id) =>
        await _presensimengajarCollection.DeleteOneAsync(x => x.NIP == id);
}