using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtsDrwaApi.Models;

public class Mapel
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? id { get; set; }
    public string? kodeMapel { get; set; }


    [BsonElement("namaMapel")]
    public string namaMapel { get; set; } = null!;

    public string nip { get; set; } = null!;

    public string sks { get; set; } = null!;

}