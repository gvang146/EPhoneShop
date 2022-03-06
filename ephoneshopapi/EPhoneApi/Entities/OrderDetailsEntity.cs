namespace EPhoneApi.Entities;

public class OrderDetailsEntity
{
    public string Id { get; set; }
    //public string OrderId { get; set; }
    //public string ProductId { get; set; }
    public string Status { get; set; }
    public decimal Price { get; set; }
    public int Quantity { get; set; }
    public DateTime ShipDate { get; set; }
    
    public ProductEntity Product { get; set; }
}