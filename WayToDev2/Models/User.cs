using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev.Model
{
    public class User
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _Id { get; set; }

        [BsonElement("Name")]
        public string Name { get; set; }

        [BsonElement("login")]
        public string login { get; set; }

        [BsonElement("password")]
        public string password { get; set; }

        [BsonElement("picture")]
        public string picture { get; set; }

        [BsonElement("date")]
        public DateTime date { get; set; }

    }
}
