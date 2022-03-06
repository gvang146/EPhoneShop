using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IOrderRepository
{
    bool AddNewOrder(OrderEntity entity);
    IList<OrderEntity> GetUserOrders(string userId);
    OrderEntity GetOrderDetails(string orderId);
}