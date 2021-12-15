using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Milos_Bencek_Winning_Group___Test_09122021.Models
{
    public class Fantastic
    {
        [BsonElement("value")]
        [JsonProperty("value")]
        public bool Value { get; set; }
        [BsonElement("type")]
        [JsonProperty("type")]
        public int Type { get; set; }
        [BsonElement("name")]
        [JsonProperty("name")]
        public string Name { get; set; } = null!;
    }
}
