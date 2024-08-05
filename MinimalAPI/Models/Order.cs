using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

namespace MinimalAPI.Models
{
    public class Order
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("Date")]
        public DateOnly? Date { get; set; }

        [BsonElement("Status")]
        public bool? Status { get; set; }

        [BsonElement("ClientId")]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? ClientId { get; set; }

        [BsonElement("Products")]
        public List<Product> Products { get; set; } = new List<Product>();

        [BsonElement("ExtraElements")]
        public Dictionary<string, string> AdditionalAttributes { get; set; }

        public Order()
        {
            AdditionalAttributes = new Dictionary<string, string>();
        }
    }
}
