using MongoDB.Bson.Serialization.Attributes;
using Newtonsoft.Json;

namespace Milos_Bencek_Winning_Group___Test_09122021.Models
{
    public class ProductAttribute
    {

        [BsonElement("fantastic")]
        [JsonProperty("fantastic")]
        public Fantastic Fantastic { get; set; }
        [BsonElement("rating")]
        [JsonProperty("rating")]
        public Rating Rating { get; set; }

    }
}
