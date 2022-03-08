using EPhoneApi.Entities;

namespace EPhoneApi.Repositories;

public interface IProductRepository
{
    public List<ProductEntity> GetAllProducts();
    public List<ProductEntity> GetProductByBrand(string brand);
    public List<ProductEntity> GetProductByProcessors(string processor);
    public List<ProductEntity> GetProductByPrice(string price);
    public List<ProductEntity> GetProductBySpeed(string speed);
    public List<ProductEntity> GetProductByPriceMin();
    public List<ProductEntity> GetProductByPriceMax();
    public List<ProductEntity> GetProductByPriceSpecfic(string price);

}

