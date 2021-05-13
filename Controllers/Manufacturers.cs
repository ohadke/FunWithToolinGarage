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
    public class Manufacturers : ControllerBase
    {
        private IRepositoryService _repo;

        public Manufacturers(IRepositoryService repo)
        {
            _repo = repo;
        }

        // GET: api/<Manufacturers>
        [HttpGet]
        public IEnumerable<string> Get()
        {
            var all = _repo.GetAllManufacturers();
        }

        // GET api/<Manufacturers>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<Manufacturers>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<Manufacturers>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<Manufacturers>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
