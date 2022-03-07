using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface ICartsRepository
{
    public Boolean AddItemToCart(CartsEntity entity);
    public Boolean DeleteCartItem(string id);
    public CartsEntity GetCartDetail(string id);
    public Boolean UpdateCartItem(CartsEntity entity);
    public CartsEntity GetCart(string userId, string productId);

    IList<CartsEntity> GetAllCartItems(string userId);
    bool DeleteAllCartItems(string userId);
}
