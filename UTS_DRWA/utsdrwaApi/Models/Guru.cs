using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace UtsDrwaApi.Models;

public class Guru
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? nip { get; set; }
    public string? kodeMapel { get; set; }

    [BsonElement("Name")]
    public string Nama { get; set; } = null!;

    public string Kota { get; set; } = null!;

    public string Mapel { get; set; } = null!;

    public string JadwalHari { get; set; } = null!;

    public string JadwalJam { get; set; } = null!;

    public string JadwalRuang { get; set; } = null!;
}