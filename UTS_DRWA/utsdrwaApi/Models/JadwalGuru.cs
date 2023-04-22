using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtsDrwaApi.Models;

public class JadwalGuru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? kodeJadwal { get; set; }
    public string? nip { get; set; }

    [BsonElement("kodeMapel")]
    
    public string kodeMapel { get; set; } = null!;

    public string hari { get; set; } = null!;

    public string jam { get; set; } = null!;

    public string ruang { get; set; } = null!;

}