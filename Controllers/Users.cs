using CarsAndManufacturers2.Model;
using CarsAndManufacturers2.Services;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace CarsAndManufacturers2.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class Users : ControllerBase
    {
        private IRepositoryService _repo;

        public Users(IRepositoryService repo)
        {
            _repo = repo;
        }

        // GET api/<Users>/5
        [HttpGet("{username}")]
        public async Task<ActionResult<User>> GetUser(string username)
        {
            try
            {
                var user = await _repo.GetUser(username);
                return Ok(user);
            }
            catch
            {
                return NotFound();
            }

            
        }

        // POST api/<Users>
        [HttpPost]
        public async Task<ActionResult<string>> AddUser(User user)
        {
            try
            {
                var res = await _repo.AddUser(new User(UserName: username, FirstName: name, LastName: lastName));
                return CreatedAtRoute(nameof(GetUser), new { UserName = res.UserName }, res);
            }
            catch
            {
                return BadRequest();
            }
        }

        // DELETE api/<Users>/5
        [HttpDelete("{id}")]
        public void DeleteUser(int id)
        {
        }
    }
}
