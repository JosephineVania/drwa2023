using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UasDrwaApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id {get; set; }
    public string? NIP { get; set; }

    [BsonElement("Nama")]
    public string Nama { get; set; } = null!;

    public string Kelas { get; set; } = null!;

}