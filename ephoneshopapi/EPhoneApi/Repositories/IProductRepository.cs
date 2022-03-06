using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IProductRepository
{
    public ProductEntity GetAllProducts();
    public ProductEntity GetProductByBrand(string brand);
    public ProductEntity GetProductByProcessors(string processor);
    public ProductEntity GetProductByPrice(string price);
    public ProductEntity GetProductBySpeed(string speed);

}

