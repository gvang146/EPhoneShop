using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using EPhoneAPI.Repositories;
using EPhoneAPI.Entities;


namespace EPhoneAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PhoneController : ControllerBase
    {
        private readonly IPhoneRepository _phoneRepository;
        private readonly ILogger<PhoneController> _logger;
        private readonly IConfiguration _configuration;
        public PhoneController(IConfiguration configuration, IPhoneRepository phoneRepository, ILogger<PhoneController> logger)
        {
            _phoneRepository = phoneRepository ?? throw new ArgumentNullException(nameof(phoneRepository));
            _logger = logger ?? throw new ArgumentNullException(nameof(logger));
            _configuration = configuration ?? throw new ArgumentNullException(nameof(configuration));
        }

        [HttpGet]
        public IEnumerable<Phone> GetAllPhones()
        {
            var phones = _phoneRepository.GetAllPhones();
            return phones;
        }

        [HttpGet]
        public IEnumerable<Phone> GetPhoneByModel(int modelNumber)
        {
            var phone = _phoneRepository.GetPhoneByModel(modelNumber);
            if (phone == null)
            {
                _logger.LogError($"Phone with modelNumber: {modelNumber}, not found.");
                return Enumerable.Empty<Phone>();
            }
            return phone;
        }

        [HttpGet]
        public IEnumerable<Phone> GetPhonesByBrand(string brand)
        {
            var phone = _phoneRepository.GetPhonesByBrand(brand);
            if (phone == null)
            {
                _logger.LogError($"Phones with brand: {brand}, not found.");
                return Enumerable.Empty<Phone>();
            }
            return phone;
        }

        [HttpGet]
        public IEnumerable<Phone> GetPhonesByColor(string color)
        {
            var phone = _phoneRepository.GetPhonesByColor(color);
            if (phone == null)
            {
                _logger.LogError($"Phones with color: {color}, not found.");
                return Enumerable.Empty<Phone>();
            }
            return phone;
        }

        [HttpGet]
        public IEnumerable<Phone> GetPhonesByFeatures(string features)
        {
            var phone = _phoneRepository.GetPhonesByFeatures(features);
            if (phone == null)
            {
                _logger.LogError($"Phones with features: {features}, not found.");
                return Enumerable.Empty<Phone>();
            }
            return phone;
        }

        [HttpGet]
        public IEnumerable<Phone> GetPhonesBySpeed(string speed)
        {
            var phone = _phoneRepository.GetPhonesBySpeed(speed);
            if (phone == null)
            {
                _logger.LogError($"Phones with speed: {speed}, not found.");
                return Enumerable.Empty<Phone>();
            }
            return phone;
        }

        [HttpPost]
        public void CreatePhone([FromBody] Phone phone)
        {
            _phoneRepository.CreatePhone(phone);
        }

        [HttpPut]
        public void UpdatePhone([FromBody] Phone phone)
        {
            _phoneRepository.UpdatePhone(phone);
        }

        [HttpDelete]
        public void DeletePhone(int ModelNumber)
        {
            _phoneRepository.DeletePhone(ModelNumber);
        }

    }
}
