using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using Homework.Class2.Classes;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;

namespace Homework.Class2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        public static List<User> users = new List<User>()
        {
            new User() { FirstName = "Bob", LastName = "Bobsky", Age = 23},
            new User() { FirstName = "John", LastName = "Johnson", Age = 26},
            new User() { FirstName = "Steve", LastName = "Stevenson", Age = 20},
        };

        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return users;
        }
        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {

            try
            {
                bool isAdult = users[id - 1].Age >= 21 ? true : false;
                return users[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"There is no user with id:{id}");
            }
        }
        [HttpPost]
        public IActionResult CreateNewUser()
        {
            string body;
            using (StreamReader sr = new StreamReader(Request.Body))
            {
                body = sr.ReadToEnd();
            }
            User user = JsonConvert.DeserializeObject<User>(body);
            users.Add(user);
            return Ok("Successfully created user");
        }
    }
}