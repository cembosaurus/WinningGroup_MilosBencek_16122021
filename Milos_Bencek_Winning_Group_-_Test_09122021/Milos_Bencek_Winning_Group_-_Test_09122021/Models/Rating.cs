using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Milos_Bencek_Winning_Group___Test_09122021.Models
{
    public class Rating
    {
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
        [BsonElement("type")]
        [JsonProperty("type")]
        public int Type { get; set; }
        [BsonElement("value")]
        [JsonProperty("value")]
        public double Value { get; set; }
    }
}
