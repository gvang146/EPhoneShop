using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySql.Data.MySqlClient;
using EPhoneAPI.Entities;
using EPhoneAPI.Repositories;

namespace EPhoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ILogger<UserController> _logger;
        private readonly IConfiguration _configuration;
        public UserController(IConfiguration configuration, IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository ?? throw new ArgumentNullException(nameof(userRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            var Users = _userRepository.GetAllUsers();
            return Users;
        }

        [HttpGet]
        public IEnumerable<User> GetUser(int AccountNumber)
        {
            var user = _userRepository.GetUser(AccountNumber);
            if (user == null)
            {
                _logger.LogError($"User with AccountNumber: {AccountNumber}, not found.");
                return Enumerable.Empty<User>(); 
            }
            return user;
        }

        [HttpGet]
        public IEnumerable<User> GetUserByName(string firstName)
        {
            var user = _userRepository.GetUserByName(firstName);
            if(user == null)
            {
                _logger.LogError($"User with Name: {firstName}, not found.");
                return Enumerable.Empty<User>();
            }
            return user;
        }

        [HttpPost]
        public void CreateUser([FromBody] User user)
        {
            _userRepository.CreateUser(user);
        }

        [HttpPut]
        public void UpdateUser([FromBody] User user)
        {
            _userRepository.UpdateUser(user);
        }

        [HttpDelete]
        public void DeleteUser(int AccountNumber)
        {
            _userRepository.DeleteUser(AccountNumber);
        }
    }
}
