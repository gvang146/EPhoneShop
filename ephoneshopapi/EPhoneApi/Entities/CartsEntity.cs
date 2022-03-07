using System.Data;

namespace EPhoneApi.Entities;

public class CartsEntity
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string ProductId { get; set; }
    public int Quantity { get; set; }

    public CartsEntity()
    {
    }

    public CartsEntity(DataRow row)
    {
        Id = Convert.ToString(row["id"]);
        UserId = Convert.ToString(row["userid"]);
        ProductId = Convert.ToString(row["productid"]);
        Quantity = Convert.ToInt32(row["quantity"]);
    }
}