namespace EPhoneApi.Entities;

public class OrderEntity
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Status { get; set; }
    public DateTime OrderDate { get; set; }
    public DateTime PaymentDate { get; set; }
    public string ConfirmationNumber { get; set; }
    
    public UserAddressEntity ShippingAddress { get; set; }
    public UserAddressEntity BillingAddress { get; set; }
    public IList<OrderDetailsEntity> OrderDetails { get; set; }
}