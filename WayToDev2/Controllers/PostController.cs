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
        /*For like
          {
                "post_Id" : "615c6dab3462270fc84f87cf",
                "IsLike" : true,
                "user_id" : "61547667734b00fa4024879f"
           }
         */
        //Likes
        [HttpPost("/post/like")]
        public ActionResult Like([FromBody]Like like)
        {
            Post postevich = _post.Find(p => p._Id == like.post_id).FirstOrDefault();

            if (postevich.like.Find(p => p.user_id == like.user_id) == null)
            {
                if (like.IsLike)
                {
                    Post post = _post.Find(p => p._Id == like.post_id).FirstOrDefault();
                    post.like.Add(like);
                    _post.FindOneAndUpdate(p => p._Id == like.post_id, Builders<Post>.Update.Set(p => p.like, post.like));
                    return Ok(post);
                }
                else if (!like.IsLike)
                {                
                    return Ok();
                }
            }
            else if(postevich.like.Find(p => p.user_id == like.user_id) != null)
            {
                if (like.IsLike)
                {                 
                    return Ok();
                }
                else if (!like.IsLike)
                {
                    Post post = _post.Find(p => p._Id == like.post_id).FirstOrDefault();
                    post.like.Remove(like);
                    _post.FindOneAndUpdate(p => p._Id == like.post_id, Builders<Post>.Update.Set(p => p.like, post.like));
                    return Ok(post);
                }
            }
            return Ok();
        }

        //Comments
        [HttpPost("/post/comment")]
        /*For comment
         {
             "post_Id" : "615c6dab3462270fc84f87cf",       
              "user_id" : "61547667734b00fa4024879f"
              "text" : "Bla bla bla bla"
          }
         */
        public ActionResult WriteComment([FromBody] Comment comment)
        {
            Post post  = _post.Find(p => p._Id == comment.post_id).FirstOrDefault();
            post.comment.Add(comment);
            _post.FindOneAndUpdate(p => p._Id == comment.post_id, Builders<Post>.Update.Set(p => p.comment, post.comment));
            return Ok(post);
        }
        
    }
}
