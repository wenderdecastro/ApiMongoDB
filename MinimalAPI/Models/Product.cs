using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalAPI.Models
{
    public class Product
    {

        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Name")]
        public string? Name { get; set; }

        [BsonElement("Price")]
        public decimal Price { get; set; }

        [BsonElement("ExtraElements")]
        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Product()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
