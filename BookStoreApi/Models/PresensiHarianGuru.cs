using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UasDrwaApi.Models;

public class PresensiHarianGuru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id {get; set; }
    public string? nip { get; set; }

    [BsonElement("Nama")]
    public string Tgl { get; set; } = null!;
    public string Kehadiran { get; set; } = null!;


}