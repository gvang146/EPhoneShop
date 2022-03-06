namespace EPhoneApi.Models;

public record UserAddressDeleteReq(string Id);

public class UserAddressInfo
{
    public string Id { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }
}