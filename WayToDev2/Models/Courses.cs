using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev.Model
{
    public class Courses
    {
        [BsonElement("name")]
        public  string Name_course { get; set; }

        [BsonElement("link")]
        public string link { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        [BsonElement("avtor")]
        public  string avtor { get; set; }

        [BsonElement("like")]
        public Like like { get; set; }

        [BsonElement("comment")]
        public Coment[] comment { get; set; }
    }
}
