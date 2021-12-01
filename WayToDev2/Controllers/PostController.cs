using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Bson.IO;
using MongoDB.Driver;
using Newtonsoft.Json.Linq;
using WayToDev.Model;
using WayToDev2.Models;

namespace WayToDev2.Controllers
{
    [ApiController]
    [Route("/post")]
    public class PostController : Controller
    {
        private readonly IMongoCollection<Post> _post;

        public PostController(IMongoClient client)
        {
            var database = client.GetDatabase("WTD");
            _post = database.GetCollection<Post>("Post");
        }

        [HttpGet]
        public List<Post> Get() => _post.Find(post => true).ToList();

        [HttpGet("/post/id/{id}")]
        public Post Get(string id) => _post.Find(post => post._Id == id).FirstOrDefault();

        [HttpPost("/post/like")]
        public ActionResult Like([FromBody]Like like)
        {          
            if (like.IsLike == "like")
            {
                Post post = _post.Find(p => p._Id == like.Id).FirstOrDefault();
                post.like += 1;
                _post.FindOneAndUpdate(p => p._Id == like.Id, Builders<Post>.Update.Set(p => p.like, post.like));
                return Ok(post);
            }
            else if(like.IsLike == "dislike")
            {
                Post post = _post.Find(p => p._Id == like.Id).FirstOrDefault();
                post.like -= 1;
                _post.FindOneAndUpdate(p => p._Id == like.Id, Builders<Post>.Update.Set(p => p.like, post.like));
                return Ok(post);
            }
            return Ok();
        }
        
    }
}
