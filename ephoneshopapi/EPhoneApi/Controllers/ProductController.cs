using Microsoft.AspNetCore.Mvc;
using EPhoneApi.Services;
using EPhoneApi.Util;
using Microsoft.AspNetCore.Mvc;
using EPhoneApi.Repositories;
using EPhoneApi.Entities;

namespace EPhoneApi.Controllers;

    
    [ApiController]
    [Route("[controller]")]
public class ProductController : ControllerBase
{
    private IProductRepository _prodRepo;
    public ProductController (IProductRepository proRepo)
    {
        _prodRepo = proRepo;
    }
    [HttpGet]
    public IActionResult GetAllProducts()
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetAllProducts();
        return Ok(prodList);
    }

            


}

