using CarsAndManufacturers2.Model;
using Project1Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public class CarService : ICarServices 
    {
        public IEnumerable<Car> _cars = new List<Car>();
        public async Task<IEnumerable<Car>> GetAllCars()
        {
            if (_cars == null)
            {
                _cars = (IEnumerable<Car>)await Task.FromResult(DataReader.GetAllCars());
            }

            return _cars;
        }
    }
}
