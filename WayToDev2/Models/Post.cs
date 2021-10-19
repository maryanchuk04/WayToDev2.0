using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev.Model
{
    public class Post
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _Id { get; set; }

        [BsonElement("title")]
        public string title { get; set; }

        [BsonElement("name_user")]
        public string name_user { get; set; }

        [BsonElement("text")]
        public string text { get; set; }
        [BsonElement("short_text")]
        public string short_text { get; set; }
        [BsonElement("picture")]
        public string picture { get; set; }
        [BsonElement("like")]
        public Like[] like { get; set; }
        [BsonElement("coment")]
        public Coment[] comment { get; set; }
    }
}
