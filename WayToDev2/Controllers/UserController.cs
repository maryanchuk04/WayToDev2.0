using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using MongoDB.Driver;
using WayToDev.Model;
using WayToDev2;
using WayToDev2.Models;

namespace WayToDev.Controllers
{
    [ApiController]
    [Route("/user")]
    public class UsersController : ControllerBase
    {
        private readonly IMongoCollection<User> userscollectoin;

        private readonly IOptions<AuthOption> authOptions;

        public UsersController(IMongoClient client, IOptions<AuthOption> authOptions)
        {
            var database = client.GetDatabase("WTD");
            userscollectoin = database.GetCollection<User>("User");
            this.authOptions = authOptions;
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
        [HttpGet]
        [Route("/user/all")]
        public List<User>Get() => userscollectoin.Find(user => true).ToList();

        
        [HttpPost("/user/registr")]
        public IActionResult Create([FromBody] User user)
        {
            var chyvak = AuthenticateUser(user.Email, user.password);
            if (chyvak!= null)
            {
                var token = GenerateJWT(user);
                user.picture = "https://herrmans.eu/wp-content/uploads/2019/01/765-default-avatar.png";
                return Ok(new { 
                    access_token = token,
                    user_id = user._Id
                });

            }
            
            userscollectoin.InsertOne(user);
            return NotFound();
        }

        [HttpGet("/user/id/{id}")]
        public User GetId(string id) => userscollectoin.Find(user => user._Id == id).FirstOrDefault();

        
       
        [HttpPost]
        [Route("/user/login/")]
        public IActionResult Login([FromBody] Login request)
        {
            var user = AuthenticateUser(request.Email, request.Password);
            if (user!=null)
            {
                var token = GenerateJWT(user);
                return Ok(new { access_token = token,
                    user_id = user._Id
                });
            }
            return Unauthorized();
        }
        
        private User AuthenticateUser(string email, string password)
        {
            return userscollectoin.Find(u => u.Email == email && u.password == password).FirstOrDefault();
        }
        private string GenerateJWT(User user)
        {
            var authParams = authOptions.Value;
            var securityKey = authParams.GetSymmetricSecurityKey();
            var credentials = new SigningCredentials(securityKey, SecurityAlgorithms.HmacSha256);
            var claims = new List<Claim>()
            {
                new Claim(JwtRegisteredClaimNames.Email,user.Email),
               // new Claim(JwtRegisteredClaimNames.Sub, user._Id.ToString())
            };
            var token = new JwtSecurityToken(authParams.Issuer,
                authParams.Audience,
                claims,
                expires: DateTime.Now.AddSeconds(authParams.TokenLifetime),
                signingCredentials: credentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }
    }   
}