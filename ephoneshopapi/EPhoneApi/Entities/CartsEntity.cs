using System.Data;

namespace EPhoneApi.Entities;

public class CartsEntity
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string ProductId { get; set; }
    public string Quantity { get; set; }

    public CartsEntity()
    {
    }

    public CartsEntity(DataRow row)
    {
        Id = Convert.ToString(row["Id"]);
        UserId = Convert.ToString(row["UserId"]);
        ProductId = Convert.ToString(row["ProductId"]);
        Quantity = Convert.ToString(row["Quantity"]);
        
    }
}