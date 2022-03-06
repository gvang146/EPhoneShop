using System.Data;

namespace EPhoneApi.Entities;

public class UserEntity
{
    public string Id { get; set; }
    public string FirstName { get; set; }
    public string LastName { get; set; }
    public string Email { get; set; }
    public string PasswordHash { get; set; }
    public string PasswordSalt { get; set; }

    public UserEntity()
    {
    }

    public UserEntity(DataRow row)
    {
        Id = Convert.ToString(row["Id"]);
        FirstName = Convert.ToString(row["FirstName"]);
        LastName = Convert.ToString(row["LastName"]);
        Email = Convert.ToString(row["Email"]);
        PasswordHash = Convert.ToString(row["PasswordHash"]);
        PasswordSalt = Convert.ToString(row["PasswordSalt"]);
    }
}