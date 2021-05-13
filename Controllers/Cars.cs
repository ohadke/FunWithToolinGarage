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
    public class Cars : ControllerBase
    {
        private IRepositoryService _repo;

        public Cars(IRepositoryService repo)
        {
            _repo = repo;
        }
        // GET: api/<Cars>
        [HttpGet]
        public async Task<ActionResult<List<Car>>> GetAllCars([FromServices] ICurrentUserService user, [FromQuery] string make)
        {
            var username = user.getCurrentUserName();
            IEnumerable<Car> res = Enumerable.Empty<Car>();

            if (string.IsNullOrWhiteSpace(username))
            {
                res = await _repo.GetAllCars();
            }
            else
            {
                res = await _repo.GetAllCarsOfUser(username);
            }

            if (!string.IsNullOrWhiteSpace(make))
            {
                res = res.Where(c => c.Make == make);
            }

            return Ok(res);
        }

        // GET api/<Cars>/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Car>> GetCarById(Guid id)
        {
            var car = await _repo.GetCar(id);

            if(car == null)
            {
                return NotFound();
            }

            return Ok(car);
        }
    }
}
