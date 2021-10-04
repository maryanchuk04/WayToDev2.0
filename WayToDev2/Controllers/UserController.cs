using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MongoDB.Driver;
using WayToDev.Model;

namespace WayToDev.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<User> userscollectoin;

        public UsersController(IMongoClient client)
        {
            var database = client.GetDatabase("WTD");
            userscollectoin = database.GetCollection<User>("User");
        }
        [HttpGet]
        public IEnumerable<User> GetUser()
        {
            return userscollectoin.Find(u => u.Name == "Maks").ToList();
        }
        [HttpPost("/add")]
        public void Addnew(User _newuser)
        {
            userscollectoin.InsertOne(_newuser);
        }



    }
}