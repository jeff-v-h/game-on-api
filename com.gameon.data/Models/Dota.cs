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
        public Tournament Tournament { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        public bool IsCompleted { get; set; }
    }
}
