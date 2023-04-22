using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtsDrwaApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    public string? nip { get; set; }

    [BsonElement("nama")]
    public string nama { get; set; } = null!;

    public string kota { get; set; } = null!;

    
}