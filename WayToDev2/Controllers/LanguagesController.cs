using Microsoft.AspNetCore.Mvc;
using MongoDB.Driver;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WayToDev2.Models;

namespace WayToDev2.Controllers
{
    //[ApiController]
    //[Route("/languages")]
    /*
    public class LanguagesController : Controller
    {
        private readonly IMongoCollection<Languages> _languages;

        public LanguagesController(IMongoClient client)
        {
            var db = client.GetDatabase("WTD");
            _languages = db.GetCollection<Languages>("Languages");
        }
        [HttpGet("/languages/name/")]
        public List<String> GetName() => (List<string>)_languages.Find(language => true).ToList();
    }*/
}
