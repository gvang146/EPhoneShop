namespace EPhoneApi.Models;

public class PlaceOrderInfo
{
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string CardExpirationDate { get; set; }
    public string CardCode { get; set; }
    public UserAddressInfo BillingAddress { get; set; }
    public UserAddressInfo ShippingAddress { get; set; }
}