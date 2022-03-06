using System.Data;
using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace EPhoneApi.Repositories;

public class UserAddressRepository : IUserAddressRepository
{
    private readonly AppSettings _appSettings;

    public UserAddressRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    public IList<UserAddressEntity> GetUserAddresses(string userId)
    {
        IList<UserAddressEntity> userAddressEntities = new List<UserAddressEntity>();
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            
            var sql = "select * from user_address where userid=@userId";
            
            using var cmd = new MySqlCommand(sql, conn);
            var userIdParam = new MySqlParameter("@userId", MySqlDbType.VarChar, 36) {Value = userId};
            cmd.Parameters.Add(userIdParam);
            
            using var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();

            try
            {
                adapter.Fill(table);
            }
            catch (InvalidOperationException e)
            {
                // log error
            }

            foreach (DataRow row in table.Rows)
            {
                userAddressEntities.Add(new UserAddressEntity(row));
            }

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return userAddressEntities;
    }

    public bool AddUserAddress(UserAddressEntity entity)
    {
        var success = false;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "insert into user_address(id, userid, address, city, state, zip) " +
                      "values (@id, @userId, @address, @city, @state, @zip)";

            using var cmd = new MySqlCommand(sql, conn);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36) {Value = entity.Id};
            cmd.Parameters.Add(idParam);
            var userIdParam = new MySqlParameter("@userId", MySqlDbType.VarChar, 36) {Value = entity.UserId};
            cmd.Parameters.Add(userIdParam);
            var addressParam = new MySqlParameter("@address", MySqlDbType.VarChar, 256) {Value = entity.Address};
            cmd.Parameters.Add(addressParam);
            var cityParam = new MySqlParameter("@city", MySqlDbType.VarChar, 120) {Value = entity.City};
            cmd.Parameters.Add(cityParam);
            var stateParam = new MySqlParameter("@state", MySqlDbType.VarChar, 2) {Value = entity.State};
            cmd.Parameters.Add(stateParam);
            var zipParam = new MySqlParameter("@zip", MySqlDbType.VarChar, 25) {Value = entity.Zip};
            cmd.Parameters.Add(zipParam);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                // log error
            }
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return success;
    }

    public bool UpdateUserAddress(UserAddressEntity entity)
    {
        var success = false;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "update user_address set address=@address, city=@city, state=@state, zip=@zip " +
                      "where id=@id";
            
            using var cmd = new MySqlCommand(sql, conn);
            var addressParam = new MySqlParameter("@address", MySqlDbType.VarChar, 256) {Value = entity.Address};
            cmd.Parameters.Add(addressParam);
            var cityParam = new MySqlParameter("@city", MySqlDbType.VarChar, 120) {Value = entity.City};
            cmd.Parameters.Add(cityParam);
            var stateParam = new MySqlParameter("@state", MySqlDbType.VarChar, 2) {Value = entity.State};
            cmd.Parameters.Add(stateParam);
            var zipParam = new MySqlParameter("@zip", MySqlDbType.VarChar, 25) {Value = entity.Zip};
            cmd.Parameters.Add(zipParam);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36) {Value = entity.Id};
            cmd.Parameters.Add(idParam);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                // log error
            }
            

            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return success;
    }

    public bool DeleteUserAddress(string id)
    {
        var success = false;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "delete from user_address where id=@id";

            using var cmd = new MySqlCommand(sql, conn);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36) {Value = id};
            cmd.Parameters.Add(idParam);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (Exception e)
            {
                // log error
            }
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return success;
    }
}