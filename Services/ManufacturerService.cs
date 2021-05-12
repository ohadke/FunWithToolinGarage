using CarsAndManufacturers2.Model.Entities;
using Project1Solution;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public class ManufacturerService : IManufacturerService
    {
        public IEnumerable<Manufacturer> _manufacturers = new List<Manufacturer>();
        public async Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            if (_manufacturers == null)
            {
                _manufacturers = (IEnumerable<Manufacturer>)await Task.FromResult(DataReader.GetAllManufacturers());
            }

            return _manufacturers;
        }
    }
}
