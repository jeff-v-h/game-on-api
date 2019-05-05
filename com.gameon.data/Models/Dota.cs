using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace com.gameon.data.Models
{
    public class Dota
    {
        [BsonId]
        [BsonElement("id")]
        public ObjectId Id { get; set; }
        [BsonElement("tournament")]
        public Tournament Tournament { get; set; }
        [BsonElement("startDate")]
        public DateTime StartDate { get; set; }
        [BsonElement("endDate")]
        public DateTime EndDate { get; set; }
        [BsonElement("isCompleted")]
        public bool IsCompleted { get; set; }
    }
}
