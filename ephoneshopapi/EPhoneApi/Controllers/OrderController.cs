using EPhoneApi.Attributes;
using EPhoneApi.Models;
using EPhoneApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EPhoneApi.Controllers;

[Authorize]
[ApiController]
[Route("[controller]")]
public class OrderController : ControllerBase
{
    private readonly IOrderRepository _repository;

    public OrderController(IOrderRepository repository)
    {
        _repository = repository;
    }
    
    [HttpGet]
    public IActionResult GetUserOrders()
    {
        var userId = (string) HttpContext.Items["UserId"];
        var orders = _repository.GetUserOrders(userId)
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
        var entity = _repository.GetOrderDetails(orderId);
        if (entity == null)
        {
            return BadRequest(new {Message = "Invalid order id"});
        }
        
        var totalCost = entity.OrderDetails
            .Sum(orderItem => orderItem.Quantity * orderItem.Price);

        var orderDetails = new
        {
            entity.Status,
            entity.OrderDate,
            entity.PaymentDate,
            entity.ConfirmationNumber,
            TotalCost = totalCost,
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
        // Todo get all row from carts for current user
        
        // Todo calculate total price and charge credit card
        
        // Todo create order data and save to database

        return BadRequest(new {Message = "Failed to process order"});
    }
}