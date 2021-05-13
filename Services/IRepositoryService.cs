using CarsAndManufacturers2.Model;
using CarsAndManufacturers2.Model.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public interface IRepositoryService
    {
        public Task<Car> GetCar(Guid id);
        public Task<Manufacturer> GetManufacturer(string name);
        public Task<User> GetUser(string userName);
        public Task<List<Car>> GetAllCars();
        public Task<List<Manufacturer>> GetAllManufacturers();
        public Task<List<User>> GetAllUsers();
        public Task<List<UserCar>> GetAllUserCars();
        public Task<User> AddUser(User user);
        public Task<User> UpdateUser(string username, User user);
        public Task DeleteUser(string username);
        public Task<UserCar> AddUserCar(string username, Guid carId);
        public Task DeleteUserCar(string username, Guid carId);
        public Task<IEnumerable<Car>> GetAllCarsOfUser(string username);
        public Task<IEnumerable<User>> GetAllUsersOfCar(Guid id);

    }
}