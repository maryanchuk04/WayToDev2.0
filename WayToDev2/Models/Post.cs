using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev.Model
{
    public class Post
    {
        [BsonElement("title")]
        public string title { get; set; }

        [BsonElement("name")]
        public string name_user { get; set; }

        [BsonElement("text")]
        public string text { get; set; }

        [BsonElement("like")]
        public Like like { get; set; }

        [BsonElement("comment")]
        public Coment comment { get; set; }
    }
}
