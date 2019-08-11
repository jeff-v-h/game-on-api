using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using System;

namespace com.gameon.data.Database.Models
{
    public class DocumentBase
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        [BsonElement("_id")]
        public string Id { get; set; }

        [BsonElement("createdOn")]
        public DateTime CreatedOn { get; set; }

        [BsonElement("modifiedOn")]
        public DateTime ModifiedOn { get; set; }
    }
}
