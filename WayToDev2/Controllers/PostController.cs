using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WayToDev.Model;


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

    }
}
