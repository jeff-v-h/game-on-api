using MongoDB.Bson.Serialization.Attributes;

namespace com.gameon.data.Models
{
    public class Tournament
    {
        [BsonId]
        [BsonElement("id")]
        public string Id { get; set; }
        [BsonElement("name")]
        public string Name { get; set; }
        [BsonElement("year")]
        public int Year { get; set; }
    }
}
