using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IUserRepository
{
    UserEntity GetUserById(string id);
    UserEntity GetUserByEmail(string email);
    bool AddUser(UserEntity entity);
    bool UpdateUser(UserEntity entity);
}