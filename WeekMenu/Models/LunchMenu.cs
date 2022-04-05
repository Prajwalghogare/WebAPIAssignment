using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System.Text.Json.Serialization;

namespace WeekMenu.Models
{
    public class LunchMenu
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("day")]
        [JsonPropertyName("day")]
        public string day { get; set; } = null!;

        public string menu { get; set; } = null!;
    }
}
