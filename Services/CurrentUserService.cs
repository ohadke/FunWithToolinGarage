using CarsAndManufacturers2.Controllers;
using CarsAndManufacturers2.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public class CurrentUserService : ICurrentUserService
    {
        private string _currentUsername { get; }
        private IRepositoryService _repo;

        public CurrentUserService(IRepositoryService repositoryService)
        {
            _repo = repositoryService;
        }

        public Task<IEnumerable<Car>> GetCarsOfCurrentUser()
        {

            var cars = _repo.GetAllCarsOfUser(_currentUsername);
            return cars;
        }

        public Task<User> GetCurrentUser()
        {
            var user = _repo.GetUser(_currentUsername);
            return user;
        }

        public Task SetCurrentUser(string username)
        {
            _currentUsername = username;
            return Task.CompletedTask;
        }
    }
}
