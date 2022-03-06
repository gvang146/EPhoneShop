using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IUserAddressRepository
{
    IList<UserAddressEntity> GetUserAddresses(string userId);
    bool AddUserAddress(UserAddressEntity entity);
    bool UpdateUserAddress(UserAddressEntity entity);
    bool DeleteUserAddress(string id);
}