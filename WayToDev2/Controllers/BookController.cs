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
    [Route("/book")]
    public class BookController : Controller
    {

        private readonly IMongoCollection<Books> _book;

        public BookController(IMongoClient client)
        {
            var db = client.GetDatabase("WTD");
            _book = db.GetCollection<Books>("Books");

        }
        //get all books
        [HttpGet]
        public List<Books> Get() => _book.Find(book => true).ToList();
        // GET: /<controller>/
        [HttpGet("/book/id/{id}")]
        public Books Get(string id) => _book.Find(book => book._Id == id).FirstOrDefault();
    }
}
