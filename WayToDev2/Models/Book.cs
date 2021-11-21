using System;
using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev.Model
{
    //coment
    public class Coment {

        public User avtor { get; set; }

        public string text { get; set; }

        public string title { get; set; }

        public DateTime date { get; set; }

        public Like[] like { get; set; }
    }
    public class Like
    {
         User users { get; set; }
    }

    public class Books
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        public string _Id { get; set; }
        [BsonElement("title")]
        public string title { get; set; }
        //hello
        [BsonElement("avtor")]
        public string avtor { get; set; }

        [BsonElement("link")]
        public string link { get; set; }

        [BsonElement("image")]
        public string image { get; set; }

        [BsonElement("description")]
        public string description { get; set; }

        

        [BsonElement("like")]
        public Like[] like { get; set; }

        [BsonElement("comment")]
        public Coment[] comment { get; set; }
         

    }
}
