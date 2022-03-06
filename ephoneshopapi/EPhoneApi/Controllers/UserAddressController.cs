using EPhoneApi.Attributes;
using EPhoneApi.Entities;
using EPhoneApi.Models;
using EPhoneApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EPhoneApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class UserAddressController : ControllerBase
{
    private readonly IUserAddressRepository _repository;
    
    public UserAddressController(IUserAddressRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetAddresses()
    {
        if (HttpContext.Items["UserId"] is string userId)
        {
            var addresses = _repository.GetUserAddresses(userId);
            return Ok(addresses.Select(a =>
                new
                {
                    a.Id,
                    a.Address,
                    a.City,
                    a.State,
                    a.Zip
                }).ToList());
        }
        
        return Ok(new List<object>());
    }

    [HttpPost]
    public IActionResult AddNewAddress(UserAddressInfo userAddress)
    {
        var userId = (string) HttpContext.Items["UserId"];
        var addressEntity = new UserAddressEntity
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            UserId = userId,
            Address = userAddress.Address,
            City = userAddress.City,
            State = userAddress.State,
            Zip = userAddress.Zip
        };

        if (_repository.AddUserAddress(addressEntity))
        {
            return Ok();
        }

        return BadRequest(new {Message = "Error adding new address"});
    }

    [HttpPut]
    public IActionResult UpdateAddress(UserAddressInfo userAddress)
    {
        var addressEntity = new UserAddressEntity
        {
            Id = userAddress.Id,
            Address = userAddress.Address,
            City = userAddress.City,
            State = userAddress.State,
            Zip = userAddress.Zip
        };

        if (_repository.UpdateUserAddress(addressEntity))
        {
            return Ok();
        }

        return BadRequest(new {Message = "Error updating user address"});
    }

    [HttpDelete]
    public IActionResult DeleteAddress(UserAddressDeleteReq req)
    {
        if (_repository.DeleteUserAddress(req.Id))
        {
            return Ok();
        }

        return BadRequest(new {Message = "Error removing user address"});
    }
}