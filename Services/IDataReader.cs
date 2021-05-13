using CarsAndManufacturers2.Model;
using CarsAndManufacturers2.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public interface IDataReader
    {
        public Task<IEnumerable<Manufacturer>> GetAllManufacturers();

        public Task<IEnumerable<Car>> GetAllCars();
    }
}
