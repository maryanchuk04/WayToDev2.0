﻿using MongoDB.Bson.Serialization.Attributes;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace WayToDev2.Models
{
    public class Like
    {
      
      
       [BsonIgnore]
        public string post_id { get; set; }
        //[Required]
        
        public bool IsLike { get; set; }
     
        public string user_id { get; set; }

    }
}
