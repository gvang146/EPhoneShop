using System.Data;

namespace EPhoneApi.Entities;

public class UserAddressEntity
{
    public string Id { get; set; }
    public string UserId { get; set; }
    public string Address { get; set; }
    public string City { get; set; }
    public string State { get; set; }
    public string Zip { get; set; }

    public UserAddressEntity()
    {
    }

    public UserAddressEntity(DataRow row)
    {
        Id = Convert.ToString(row["Id"]);
        UserId = Convert.ToString(row["UserId"]);
        Address = Convert.ToString(row["Address"]);
        City = Convert.ToString(row["City"]);
        State = Convert.ToString(row["State"]);
        Zip = Convert.ToString(row["Zip"]);
    }
}