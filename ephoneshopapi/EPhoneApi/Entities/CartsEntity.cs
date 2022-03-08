using System.Data;

namespace EPhoneApi.Entities;

public class CartsEntity
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public int Quantity { get; set; }
    public ProductEntity Product { get; set; }
}