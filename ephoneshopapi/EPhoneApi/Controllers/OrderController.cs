using EPhoneApi.Attributes;
using EPhoneApi.Entities;
using EPhoneApi.Models;
using EPhoneApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EPhoneApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _orderRepository;
    private readonly ICartsRepository _cartsRepository;

    public OrderController(IOrderRepository orderRepository, ICartsRepository cartsRepository)
    {
        _orderRepository = orderRepository;
        _cartsRepository = cartsRepository;
    }
    
    [HttpGet]
    public IActionResult GetUserOrders()
    {
        var userId = (string) HttpContext.Items["UserId"];
        var orders = _orderRepository.GetUserOrders(userId)
            .Select(o => new
            {
                o.Id,
                o.Status,
                o.OrderDate,
                o.PaymentDate,
                o.ConfirmationNumber
            });

        return Ok(orders);
    }

    [HttpGet]
    [Route("{orderId}")]
    public IActionResult GetOrderDetails(string orderId)
    {
        var entity = _orderRepository.GetOrderDetails(orderId);
        if (entity == null)
        {
            return BadRequest(new {Message = "Invalid order id"});
        }
        
        // var totalCost = entity.OrderDetails
        //     .Sum(orderItem => orderItem.Quantity * orderItem.Price);

        var orderDetails = new
        {
            entity.Status,
            entity.OrderDate,
            entity.PaymentDate,
            entity.ConfirmationNumber,
            entity.TotalCost,
            ShippingAddress = new
            {
                entity.ShippingAddress.Address,
                entity.ShippingAddress.City,
                entity.ShippingAddress.State,
                entity.ShippingAddress.Zip
            },
            BillingAddress = new
            {
                entity.BillingAddress.Address,
                entity.BillingAddress.City,
                entity.BillingAddress.State,
                entity.BillingAddress.Zip
            },
            OrderItems = entity.OrderDetails.Select(i => new
            {
                i.Product.ProductName,
                i.Product.ProductDesc,
                i.Product.Brand,
                i.Product.Color,
                i.Product.Processors,
                i.Product.Speed,
                i.Price,
                i.Quantity
            }).ToList()
        };

        return Ok(orderDetails);
    }

    [HttpPost]
    public IActionResult ProcessOrder(PlaceOrderInfo placeOrderInfo)
    {
        var userId = (string)HttpContext.Items["UserId"];
        
        var cartEntities = _cartsRepository.GetCartDetails(userId);
        if (cartEntities.Count == 0)
        {
            return BadRequest(new {Message = "Card is emptied"});
        }
        
        // Todo calculate total price and charge credit card
        
        var orderEntity = new OrderEntity
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            UserId = userId,
            Status = "Confirmed",
            OrderDate = DateTime.Now,
            PaymentDate = DateTime.Now,
            ConfirmationNumber = Guid.NewGuid().ToString("N").Substring(0,10),
            OrderDetails = new List<OrderDetailsEntity>(),
            ShippingAddress = new UserAddressEntity
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Address = placeOrderInfo.ShippingAddress.Address,
                City = placeOrderInfo.ShippingAddress.City,
                State = placeOrderInfo.ShippingAddress.State,
                Zip = placeOrderInfo.ShippingAddress.Zip
            },
            BillingAddress = new UserAddressEntity
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Address = placeOrderInfo.BillingAddress.Address,
                City = placeOrderInfo.BillingAddress.City,
                State = placeOrderInfo.BillingAddress.State,
                Zip = placeOrderInfo.BillingAddress.Zip
            }
        };
        
        foreach (var entity in cartEntities)
        {
            orderEntity.TotalCost += entity.Quantity * entity.Product.Price;
            orderEntity.OrderDetails.Add(new OrderDetailsEntity
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                Price = entity.Product.Price,
                Product = entity.Product,
                Quantity = entity.Quantity,
                Status = "Processing"
            });
        }

        var success = _orderRepository.AddNewOrder(orderEntity);
        if (!success)
        {
            return BadRequest(new {Message = "Could not process order"});
        }

        _cartsRepository.DeleteAllCartItems(userId);

        return Ok();
    }
}