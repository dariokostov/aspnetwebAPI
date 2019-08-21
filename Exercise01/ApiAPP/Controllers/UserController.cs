using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using ApiAPP.Domain;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace ApiAPP.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        public static List<User> Users = new List<User>()
        {
            new User("Dario", "Kostov", 15),
            new User("Martin", "Petrovski", 25),
            new User("Petar", "Donevski", 32),
            new User("Dragana", "Siskovska", 20),
            new User("Goran", "Todorovski", 29)
        };
        [HttpGet]
        public ActionResult<List<User>> Get()
        {
            return Users;
        }

        [HttpGet("{id}")]
        public ActionResult<User> Get(int id)
        {
            try
            {
                return Users[id - 1];
            }
            catch (ArgumentOutOfRangeException)
            {
                return NotFound($"Note with id {id} is not found");
            }
            catch (Exception ex)
            {
                return BadRequest($"Bad request: {ex.Message}");
            }
        }

    }

}