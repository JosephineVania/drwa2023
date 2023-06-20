using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UasDrwaApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id {get; set; }

    [BsonElement("Name")]
    public string Nama { get; set; } = null!;

    public string Kelas { get; set; } = null!;

}