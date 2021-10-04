using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WayToDev.Model;

// For more information on enabling MVC for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace WayToDev2.Controllers
{
    [ApiController]
    [Route("/user")]
    public class PostController : Controller
    {
        private readonly IMongoCollection<Post> _post;

        public PostController(IMongoClient client)
        {
            var database = client.GetDatabase("WTD");
            _post = database.GetCollection<Post>("Post");
        }

        [HttpGet]
        public IEnumerable<Post> getAllposts ()
        {
            return _post;
        }
        
    }
}
