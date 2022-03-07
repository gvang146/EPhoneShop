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
    private ICartsRepository _cartRepo;

    public CartsController(ICartsRepository cartRepo)
    {
        _cartRepo = cartRepo;
    }

    //This will add to cart
    //add to cart and update base on productId
    [HttpPost]
    public IActionResult AddItemToCart(CartInfo cartinfo)
    {
        bool success = false;
        var userId = (string) HttpContext.Items["UserId"]; //get user id from token   
        var cartEntity = _cartRepo.GetCart(userId, cartinfo.ProductId);
        if (cartEntity == null)
        {
            cartEntity = new CartsEntity
            {
                Id = Guid.NewGuid().ToString().ToLower(),
                ProductId = cartinfo.ProductId,
                UserId = userId,
                Quantity = 1
            };
            success = _cartRepo.AddItemToCart(cartEntity);
        }
        else
        {
            cartEntity.Quantity += 1;
            success = _cartRepo.UpdateCartItem(cartEntity);
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
    [Route("{id}")]
    public IActionResult GetCartDetails(string id)
    {
        var entity = _cartRepo.GetCartDetail(id);
        return Ok(entity);
    }

    //This delete cart items
    [HttpDelete]
    public IActionResult DeleteItemFromCart(CartsEntity entity)
    {
        if (_cartRepo.DeleteCartItem(entity.Id))
        {
            return Ok();
        }

        return BadRequest(new {Message = "Error Removing Item from Cart"});
    }
}