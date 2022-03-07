using EPhoneApi.Entities;

namespace EPhoneApi.Models;

public class AuthenticateResponse
{
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string Token { get; set; }

    public AuthenticateResponse(UserEntity userEntity, string token)
    {
        FirstName = userEntity.FirstName;
        LastName = userEntity.LastName;
        Email = userEntity.Email;
        Token = token;
    }
}