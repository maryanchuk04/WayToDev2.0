using MongoDB.Bson.Serialization.Attributes;

namespace WayToDev2.Models
{
    public class Like
    {
        [BsonId]
        [BsonRepresentation(MongoDB.Bson.BsonType.ObjectId)]
        [BsonIgnoreIfNull]
        public string _Id { get; set; }

        [BsonIgnore]
        public string post_id { get; set; }
        //[Required]

        public bool IsLike { get; set; }


        public string user_id { get; set; }

    }
}
