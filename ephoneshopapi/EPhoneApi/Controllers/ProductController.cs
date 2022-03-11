using Microsoft.AspNetCore.Mvc;
using EPhoneApi.Repositories;
using EPhoneApi.Entities;

namespace EPhoneApi.Controllers;

[ApiController]
[Route("[controller]")] //how we defined URL
public class ProductController : ControllerBase
{
    private IProductRepository _prodRepo;

    public ProductController(IProductRepository proRepo)
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

    [HttpGet]
    [Route("brand/{value}")]
    public IActionResult GetProductByBrand(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByBrand(value);
        return Ok(prodList);
    }

    [HttpGet]
    [Route("processor/{value}")]
    public IActionResult GetProductByProcessors(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByProcessors(value);
        return Ok(prodList);
    }
    [HttpGet]
    [Route("speed/{value}")]
    public IActionResult GetProductBySpeed(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductBySpeed(value);
        return Ok(prodList);
    }

    [HttpGet]
    [Route("price/{value}")]
    public IActionResult GetProductByPrice(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByPrice(value);
        return Ok(prodList);
    }
}