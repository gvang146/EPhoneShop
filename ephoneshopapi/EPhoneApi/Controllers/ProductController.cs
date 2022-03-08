using Microsoft.AspNetCore.Mvc;
using EPhoneApi.Repositories;
using EPhoneApi.Entities;

namespace EPhoneApi.Controllers;

[ApiController]
[Route("[controller]")]
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
    [HttpGet("brand")]
    public IActionResult GetProductByBrand(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByBrand(value);
        return Ok(prodList);
    }
    [HttpGet("processors")]
    public IActionResult GetProductByProcessors(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByProcessors(value);
        return Ok(prodList);
    }
    [HttpGet("speed")]
    public IActionResult GetProductBySpeed(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductBySpeed(value);
        return Ok(prodList);
    }
    [HttpGet("price")]
    public IActionResult GetProductByPrice(string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByPrice(value);
        return Ok(prodList);
    }
    [HttpGet]
     public IActionResult GetProductByPriceMin()
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByPriceMin();
        return Ok(prodList);

    }
    [HttpGet]
    public IActionResult GetProductByPriceMax()
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByPriceMax();
        return Ok(prodList);

    }
    [HttpGet("price")]
    public IActionResult GetProductByPriceSpecfic( string value)
    {
        List<ProductEntity> prodList = new List<ProductEntity>();
        prodList = _prodRepo.GetProductByPriceSpecfic(value);
        return Ok(prodList);
    }
    
}