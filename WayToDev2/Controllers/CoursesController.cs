using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using WayToDev.Model;

/*

namespace WayToDev2.Controllers
{
    [ApiController]
    [Route("/course")]

    public class CoursesController : Controller
    {
            private readonly IMongoCollection<Courses> _courses;


            public CoursesController(IMongoClient client)
            {
                var db = client.GetDatabase("WTD");
                _courses = db.GetCollection<Courses>("Courses");

            }
            //get all books
            [HttpGet]
            public List<Courses> Get() => _courses.Find(Courses => true).ToList();
        // GET: /<controller>/

        [HttpGet]
        public Courses Get(string id) => _courses.Find(course => course._Id == id).FirstOrDefault();

    }
}
*/