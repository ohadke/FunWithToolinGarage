using CarsAndManufacturers2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public interface ICarServices
    {
        public Task<IEnumerable<Car>> GetAllCars();

    }
}
