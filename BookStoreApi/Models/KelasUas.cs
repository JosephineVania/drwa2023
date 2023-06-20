using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UasDrwaApi.Models;

public class KelasUas
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id {get; set; }

    [BsonElement("Nama")]
    public string Nama { get; set; } = null!;


}