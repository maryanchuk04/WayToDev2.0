using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WayToDev2.Models
{
    public class Languages
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _Id { get; set; }
        [BsonElement("name")]
        public string name { get; set; }

        [BsonElement("text")]
        public string text { get; set; }           
    }
}
