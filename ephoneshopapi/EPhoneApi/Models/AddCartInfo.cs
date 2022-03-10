namespace EPhoneApi.Models;

public class AddCartInfo
{
    public string ProductId { get; set; }
}

public class UpdateCartInfo
{
    public string Id { get; set; }
    public int Quantity { get; set; }
    public bool RequestDelete { get; set; }
}
