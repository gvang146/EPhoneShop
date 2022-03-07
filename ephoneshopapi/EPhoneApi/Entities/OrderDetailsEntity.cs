namespace EPhoneApi.Entities;

public class OrderDetailsEntity
{
    public string Id { get; set; }
    public string Status { get; set; }
    public double Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ShipDate { get; set; }
    
    public ProductEntity Product { get; set; }
}