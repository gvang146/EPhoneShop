using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface ICartsRepository
{
    public Boolean AddItemToCart(CartsEntity entity);
    public Boolean DeleteCartItem(string id);
    public CartsEntity GetCartDetail(string id);
}
