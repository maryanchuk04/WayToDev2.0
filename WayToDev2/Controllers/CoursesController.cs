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
    [Route("/courses")]
    public class CoursesController : Controller
    {
       private readonly IMongoCollection<Courses> _courses;

       public CoursesController(IMongoClient client)
        {
          var db = client.GetDatabase("WTD");
          _courses = db.GetCollection<Courses>("Courses");
        }

        [HttpGet]
        public List<Courses> Get() => _courses.Find(Courses => true).ToList();

        [HttpGet("/courses/id/{id}")]
        public Courses Get(string id) => _courses.Find(course => course._Id == id).FirstOrDefault();

    }
}
