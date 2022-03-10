using EPhoneApi.Attributes;
using EPhoneApi.Entities;
using EPhoneApi.Models;
using EPhoneApi.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace EPhoneApi.Controllers;

[Authorize] //Everything requires login
[ApiController]
[Route("[controller]")]
public class CartsController : ControllerBase
{
    private readonly ICartsRepository _repository;

    public CartsController(ICartsRepository repository)
    {
        _repository = repository;
    }

    //This will add to cart
    //add to cart and update base on productId
    [HttpPost]
    public IActionResult AddItemToCart(AddCartInfo addCartInfo)
    {
        bool success;
        var userId = (string) HttpContext.Items["UserId"]; //get user id from token   
        var cartEntity = _repository.GetCart(userId, addCartInfo.ProductId);
        if (cartEntity == null)
        {
            cartEntity = new CartsEntity
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                UserId = userId,
                Quantity = 1,
                Product = new ProductEntity
                {
                    Id = addCartInfo.ProductId
                }
            };
            success = _repository.AddItemToCart(cartEntity);
        }
        else
        {
            cartEntity.Quantity += 1;
            success = _repository.UpdateCartItem(cartEntity);
        }

        if (success)
        {
            return Ok();
        }
        else
        {
            return BadRequest(new {Message = "Error Updating and Adding to Cart"});
        }
    }

    [HttpGet]
    public IActionResult GetCartDetails()
    {
        var userId = (string) HttpContext.Items["UserId"];
        var cartDetails = _repository.GetCartDetails(userId)
            .Select(c => new
            {
                c.Id,
                c.Product.ProductName,
                c.Quantity,
                c.Product.Price
            });
        return Ok(cartDetails);
    }

    [HttpPut]
    public IActionResult UpdateCartItem(IList<UpdateCartInfo> cartInfoList)
    {
        foreach (var cartInfo in cartInfoList)
        {
            if (cartInfo.Quantity < 1 || cartInfo.RequestDelete)
            {
                _repository.DeleteCartItem(cartInfo.Id);
            }
            else
            {
                var cartEntity = _repository.GetCartById(cartInfo.Id);
                cartEntity.Quantity = cartInfo.Quantity;
                _repository.UpdateCartItem(cartEntity);
            }
        }
        return Ok();
    }
}