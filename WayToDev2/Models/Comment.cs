using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WayToDev2.Models
{
    public class Comment
    {

       
        [BsonIgnoreIfNull]
        public  string post_id { get; set; }
        
        [BsonElement("user_id")]
        public string user_id { get; set; }

        [BsonElement("text")]
        public string text { get; set; }
    }   
}
