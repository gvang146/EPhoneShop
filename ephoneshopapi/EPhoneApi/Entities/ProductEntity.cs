using System.Data;

namespace EPhoneApi.Entities;

public class ProductEntity
{
    public string Id { get; set; }
    public string ProductName { get; set; }
    public string ProductDesc { get; set; }
    public string Brand { get; set; }
    public string Color { get; set; }
    public string Processors { get; set; }
    public string Speed { get; set; }
    public double Price { get; set; }

    public ProductEntity()
    {
    }

    public ProductEntity(DataRow row)
    {
        Id = Convert.ToString(row["Id"]);
        ProductName = Convert.ToString(row["ProductName"]);
        ProductDesc = Convert.ToString(row["ProductDesc"]);
        Brand = Convert.ToString(row["Brand"]);
        Color = Convert.ToString(row["Color"]);
        Processors = Convert.ToString(row["Processors"]);
        Speed = Convert.ToString(row["Speed"]);
        Price = Convert.ToDouble(row["Price"]);
    }
}