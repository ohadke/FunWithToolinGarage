using CarsAndManufacturers2.Model;
using CarsAndManufacturers2.Model.Entities;
using CarsAndManufacturers2.Services;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public class DataReader : IDataReader
    {
        // TODO: This should be moved to an external config file
        private const string _basePath = "Data";
        private const string _carsFile = "Cars.csv";
        private const string _mfgFile = "Manufacturers.csv";

        public string[] ToColumns(string source)
        {
            return source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();
        }

        public Car ToCar(string source)
        {
            var cols = ToColumns(source);
            return new Car
            (
                Year : int.Parse(cols[0]),
                Make : cols[1],
                Model : cols[2],
                Displacement : double.Parse(cols[3]),
                Cylinders : int.Parse(cols[4]),
                CityFe : int.Parse(cols[5]),
                HighwayFe : int.Parse(cols[6]),
                CombinedFe : int.Parse(cols[7]),
                Id : Guid.NewGuid()
            );         
        }

        public Manufacturer ToManufacturer(string source)
        {
            var cols = source
                .Split(',')
                .Select(s => s.Trim())
                .ToArray();

            return new Manufacturer
            (
                Name : cols[0],
                Country : cols[1],
                Year : int.Parse(cols[2])
            );
        }

        public Task<IEnumerable<Car>> GetAllCars()
        {
            return Task.FromResult(File
                .ReadAllLines($"{_basePath}/{_carsFile}")
                .Skip(1)
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => ToCar(str)));
        }

        public Task<IEnumerable<Manufacturer>> GetAllManufacturers()
        {
            return Task.FromResult(File
                .ReadAllLines($"{_basePath}/{_mfgFile}")
                .Where(str => !string.IsNullOrWhiteSpace(str))
                .Select(str => ToManufacturer(str)));
        }
    }
}

