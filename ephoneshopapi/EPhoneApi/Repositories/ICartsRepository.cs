using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface ICartsRepository
{
    bool AddItemToCart(CartsEntity entity);
    bool DeleteCartItem(string id);
    IList<CartsEntity> GetCartDetails(string userId);
    bool UpdateCartItem(CartsEntity entity);
    CartsEntity GetCart(string userId, string productId);
    CartsEntity GetCartById(string id);
    bool DeleteAllCartItems(string userId);
}
