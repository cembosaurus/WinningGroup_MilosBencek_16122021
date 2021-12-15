using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Milos_Bencek_Winning_Group___Test_09122021.Models
{
    public class Product
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        [JsonProperty("_id")]
        public string? id { get; set; } = null!;
        [BsonElement("id")]
        [JsonProperty("id")]
        public int Id { get; set; }
        [BsonElement("sku")]
        [JsonProperty("sku")]
        public string SKU { get; set; } = null!;
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [BsonElement("price")]
        [JsonProperty("price")]
        public double Price { get; set; }
        [BsonElement("attribute")]
        [JsonProperty("attribute")]
        public ProductAttribute Attribute { get; set; } = null!;
    }
}
