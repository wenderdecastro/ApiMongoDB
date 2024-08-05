using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalAPI.Models
{
    public class Fruit
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; } = null!;
        [BsonElement("Flavor")]

        public string Flavor { get; set; } = null!;
        [BsonElement("Color")]

        public string Color { get; set; } = null!;

        [BsonElement("ExtraElements")]
        public Dictionary<string, string> ExtraElements { get; set; }


        public Fruit()
        {
            ExtraElements = new Dictionary<string, string>();
        }
    }
}
