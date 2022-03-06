using EPhoneApi.Attributes;
using EPhoneApi.Entities;
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
    [HttpPost]
    public IActionResult AddItemToCart(CartsEntity entity)
    {
        var userId = (string)HttpContext.Items["UserId"]; //get user id from token   
        var cartEntity = new CartsEntity()
        {
            Id = Guid.NewGuid().ToString().ToLower(),
            UserId = userId,
            ProductId = entity.ProductId,
            Quantity = entity.Quantity
        };
        bool success = _cartRepo.AddItemToCart(cartEntity);
        if (success)
        {
            return StatusCode(StatusCodes.Status201Created);
        }
        else
        {
            return BadRequest(new { Message = "Unable to add to cart!" });
        }
        
            
    }

}
