using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IUserRepository
{
    public UserEntity GetUserById(string id);
    public UserEntity GetUserByEmail(string email);
    public bool AddUser(UserEntity entity);
    public bool UpdateUser(UserEntity entity);
}