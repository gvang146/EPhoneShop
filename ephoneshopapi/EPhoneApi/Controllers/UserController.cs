using EPhoneApi.Attributes;
using EPhoneApi.Entities;
using EPhoneApi.Models;
using EPhoneApi.Services;
using EPhoneApi.Util;
using Microsoft.AspNetCore.Mvc;

namespace EPhoneApi.Controllers;

[ApiController]
[Route("[controller]")]
public class UserController : ControllerBase
{
    private readonly IUserAuthenticationService _authenticationService;
    
    public UserController(IUserAuthenticationService authenticationService)
    {
        _authenticationService = authenticationService;
    }

    [Authorize]
    [HttpGet]
    public IActionResult Profile()
    {
        if (HttpContext.Items["UserId"] is string userId)
        {
            var customerEntity = _authenticationService.Repos.GetUserById(userId);
            if (customerEntity != null)
            {
                return Ok(new
                {
                    customerEntity.Id,
                    customerEntity.Email,
                    customerEntity.FirstName,
                    customerEntity.LastName
                });
            }
        }

        return BadRequest(new {Message = "User profile doesn't exist"});
    }

    [HttpPost("authenticate")]
    public IActionResult Authenticate(AuthenticateRequest authRequest)
    {
        var response = _authenticationService.Authenticate(authRequest);

        if (response == null)
        {
            return BadRequest(new { Message = "Username or password is incorrect" });
        }

        return Ok(response);
    }

    [HttpPost("create")]
    public IActionResult AddNewCustomer(UserInfo userInfo)
    {
        if (_authenticationService.Repos.GetUserByEmail(userInfo.Email) != null)
        {
            return BadRequest(new {Message = "Email is already used by another user"});
        }

        var passwordSalt = PasswordUtil.GenerateSalt();
        var passwordHash = PasswordUtil.ComputerPasswordHash(userInfo.Password, passwordSalt);

        var userEntity = new UserEntity
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            FirstName = userInfo.FirstName,
            LastName = userInfo.LastName,
            Email = userInfo.Email,
            PasswordHash = passwordHash,
            PasswordSalt = passwordSalt
        };
        
        bool success = _authenticationService.Repos.AddUser(userEntity);
        if (success)
        {
            return StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return BadRequest(new { Message = "Error adding user to database" });
        }
    }
}