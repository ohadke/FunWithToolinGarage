using CarsAndManufacturers2.Model;
using CarsAndManufacturers2.Model.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace CarsAndManufacturers2.Services
{
    public class RepositoryService : IRepositoryService
    {
        private Dictionary<string, User> _users = new();
        private Dictionary<string ,Manufacturer> _manufacturers = new();
        private Dictionary<Guid, Car> _cars = new();
        private List<UserCar> _userCar = new();
        public IManufacturerService _manufacturerService { get; }
        public ICarServices _carService { get; }

        public RepositoryService(IManufacturerService manufacturerServices, ICarServices carServices)
        {
            _manufacturerService =  manufacturerServices;
            _carService = carServices;
        }

        public Task<User> AddUser(User user)
        {
            _users.Add(user.UserName, user);
            return Task.FromResult(user);
        }

        public Task<UserCar> AddUserCar(string username, Guid carId)
        {
            checkIfCarsExists();
            checkIfManufacturersExists();

            UserCar temp;
            if (!_users.ContainsKey(username))
            {
                throw new ArgumentException("User does not exist yet!");
            }

            if (!_cars.ContainsKey(carId))
            {
                throw new ArgumentException("Car does not exist!");
            }

            if (_userCar.Find(userCar => userCar.CarGuid == carId && userCar.Username == username) != null)
            {
                throw new ArgumentException("This pair already exists!");
            }

            temp = new UserCar(username, carId);
            _userCar.Add(temp);
            return Task.FromResult(temp);
        }

        public Task DeleteUser(string username)
        {
            if (!_users.ContainsKey(username))
            {
                throw new ArgumentOutOfRangeException();
            }
            _users.Remove(username);
            return Task.CompletedTask;
        }

        public Task DeleteUserCar(string username, Guid carId)
        {
            checkIfCarsExists();
            checkIfManufacturersExists();

            if (_userCar.Find(userCar => userCar.CarGuid == carId && userCar.Username == username) == null)
            {
                throw new ArgumentOutOfRangeException();
            }

            _userCar.Remove(_userCar.Find(userCar => userCar.CarGuid == carId && userCar.Username == username));
            return Task.CompletedTask;
        }

        public async Task<List<Car>> GetAllCars()
        {
            checkIfCarsExists();

            return await Task.FromResult(_cars.Values.ToList());
        }

        public Task<IEnumerable<Car>> GetAllCarsOfUser(string username)
        {
            checkIfCarsExists();
            checkIfManufacturersExists();

            if (_userCar == null)
            {
                throw new ArgumentException("List does not exist (car user)!");
            }

            if (!_users.ContainsKey(username))
            {
                throw new ArgumentException("User does not exist yet!");
            }

            if(_userCar.Find(userCar => userCar.Username == username) == null)
            {
                throw new ArgumentException("User does not own any cars!");
            }

            return (Task<IEnumerable<Car>>)_userCar
                .Where(u => u.Username == username)
                .Select(u => _cars[u.CarGuid]);
        }

        public async Task<List<Manufacturer>> GetAllManufacturers(Guid id)
        {

            checkIfManufacturersExists();

            return await Task.FromResult(_manufacturers.Values.ToList());
        }

        public Task<List<UserCar>> GetAllUserCars()
        {
            checkIfCarsExists();
            checkIfManufacturersExists();

            return Task.FromResult(_userCar);
        }

        public async Task<List<User>> GetAllUsers()
        {
            if (_users == null)
            {
                throw new ArgumentException("No users in list!");
            }

            return await Task.FromResult(_users.Values.ToList());
        }

        public Task<IEnumerable<User>> GetAllUsersOfCar(Guid id)
        {
            checkIfCarsExists();

            if (!_cars.ContainsKey(id)) {
                throw new ArgumentException("Car does not exist!");
            }

            return (Task<IEnumerable<User>>)_userCar
                 .Where(u => u.CarGuid == id)
                 .Select(u => _users[u.Username]);
        }

        public Task<Car> GetCar(Guid id)
        {
            checkIfCarsExists();

            if (!_cars.ContainsKey(id))
            {
                throw new ArgumentException("Car does not exist!");
            }

            return Task.FromResult(_cars[id]);
        }

        public Task<Manufacturer> GetManufacturer(string name)
        {
            checkIfManufacturersExists();

            return Task.FromResult(_manufacturers[name]);
        }

        public Task<User> GetUser(string userName)
        {
            if (!_users.ContainsKey(userName))
            {
                throw new ArgumentException("User does not exist!");
            }
            return Task.FromResult(_users[userName]);
        }

        public Task<User> UpdateUser(string userName, User user)
        {
            if (!_users.ContainsKey(userName))
            {
                throw new ArgumentException("User does not exist!");
            }

        }

        private async void checkIfCarsExists()
        {
            if (_cars == null)
            {
               _cars = (await _carService.GetAllCars()).ToDictionary(c => c.Id);
            }
        }

        private async void checkIfManufacturersExists()
        {
            if (_manufacturerService == null)
            {
                _manufacturers = (await _manufacturerService.GetAllManufacturers()).ToDictionary(c => c.Name);
            }
        }
    }
}
