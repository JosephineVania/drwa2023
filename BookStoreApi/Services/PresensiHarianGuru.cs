using UasDrwaApi.Models;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace UasDrwaApi.Services;

public class PresensiHarianGuruService
{
    private readonly IMongoCollection<PresensiHarianGuru> _presensiharianguruCollection;

    public PresensiHarianGuruService(
        IOptions<PresensiHarianGuruDatabaseSettings> presensiharianguruDatabaseSettings)
    {
        var mongoClient = new MongoClient(
            presensiharianguruDatabaseSettings.Value.ConnectionString);

        var mongoDatabase = mongoClient.GetDatabase(
            presensiharianguruDatabaseSettings.Value.DatabaseName);

        _presensiharianguruCollection = mongoDatabase.GetCollection<PresensiHarianGuru>(
            presensiharianguruDatabaseSettings.Value.PresensiHarianGuruCollectionName);
    }

    public async Task<List<PresensiHarianGuru>> GetAsync() =>
        await _presensiharianguruCollection.Find(_ => true).ToListAsync();

    public async Task<PresensiHarianGuru?> GetAsync(string id) =>
        await _presensiharianguruCollection.Find(x => x.nip == id).FirstOrDefaultAsync();

    public async Task CreateAsync(PresensiHarianGuru newPresensiHarianGuru) =>
        await _presensiharianguruCollection.InsertOneAsync(newPresensiHarianGuru);

    public async Task UpdateAsync(string id, PresensiHarianGuru updatedPresensiHarianGuru) =>
        await _presensiharianguruCollection.ReplaceOneAsync(x => x.nip == id, updatedPresensiHarianGuru);

    public async Task RemoveAsync(string id) =>
        await _presensiharianguruCollection.DeleteOneAsync(x => x.nip == id);
}