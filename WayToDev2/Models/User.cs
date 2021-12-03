using System;
using System.Collections.Generic;
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

        [BsonElement("Email")]
        public string Email{ get; set; }

        [BsonElement("password")]
        public string password { get; set; }
        public string password { get; set; }

        [BsonElement("picture")] 
        public string picture { get; set; } 
        
        [BsonElement("favourites")]
        public List<Courses> favourites { get; set; }    
    }
}
