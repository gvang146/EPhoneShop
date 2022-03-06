namespace EPhoneApi.Models;

public class PlaceOrderInfo
{
    public string ShippingAddressId { get; set; }
    public string BillingAddressId { get; set; }
    public string CardHolderName { get; set; }
    public string CardNumber { get; set; }
    public string CardExpirationDate { get; set; }
    public string CardCode { get; set; }
    public string CardZipCode { get; set; }
}