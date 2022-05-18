using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WayToDev.Model;

namespace WayToDev2.Models
{
    public class Comment
    {
        [BsonIgnoreIfNull]
        public string post_id { get; set; }

        [BsonElement("user")]
        public User user { get; set; }

        [BsonElement("text")]
        public string text { get; set; }

    }
}
