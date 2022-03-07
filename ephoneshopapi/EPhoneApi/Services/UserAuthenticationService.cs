using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;
using EPhoneApi.Entities;
using EPhoneApi.Models;
using EPhoneApi.Repositories;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;

namespace EPhoneApi.Services;

public class UserAuthenticationService : IUserAuthenticationService
{
    private readonly IUserRepository _repository;
    private readonly AppSettings _appSettings;

    public UserAuthenticationService(IUserRepository repository, IOptions<AppSettings> appSettings)
    {
        _repository = repository;
        _appSettings = appSettings.Value;
    }

    public AuthenticateResponse Authenticate(AuthenticateRequest model)
    {
        var userEntity = _repository.GetUserByEmail(model.Username);
        if (userEntity == null) return null;

        if (!PasswordUtil.VerifyPassword(model.Password, userEntity.PasswordSalt, userEntity.PasswordHash))
        {
            return null;
        }
        var token = GenerateJwtToken(userEntity);

        return new AuthenticateResponse(userEntity, token);
    }

    public IUserRepository Repos => _repository;

    private string GenerateJwtToken(UserEntity user)
    {
        // generate token that is valid for 24 hours
        var tokenHandler = new JwtSecurityTokenHandler();
        var key = Encoding.ASCII.GetBytes(_appSettings.Secret);
        var tokenDescriptor = new SecurityTokenDescriptor
        {
            Subject = new ClaimsIdentity(new[] { new Claim("id", user.Id) }),
            Expires = DateTime.UtcNow.AddDays(1),
            SigningCredentials = new SigningCredentials(new SymmetricSecurityKey(key), SecurityAlgorithms.HmacSha256Signature)
        };
        var token = tokenHandler.CreateToken(tokenDescriptor);
        return tokenHandler.WriteToken(token);
    }
}