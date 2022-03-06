using EPhoneApi.Models;
using EPhoneApi.Repositories;

namespace EPhoneApi.Services;

public interface IUserAuthenticationService
{
    AuthenticateResponse Authenticate(AuthenticateRequest model);
    IUserRepository Repos { get; }
}