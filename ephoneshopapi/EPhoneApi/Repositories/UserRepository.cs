using System.Data;
using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace EPhoneApi.Repositories;

public class UserRepository : IUserRepository
{
    private readonly AppSettings _appSettings;
    
    public UserRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    public UserEntity GetUserById(string id)
    {
        UserEntity userEntity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            
            var sql = "select * from users where id=@id";
            
            using var cmd = new MySqlCommand(sql, conn);
            var userId = new MySqlParameter("@id", MySqlDbType.VarChar, 36)
            {
                Value = id
            };
            cmd.Parameters.Add(userId);
            
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

            if (table.Rows.Count > 0)
            {
                userEntity = new UserEntity(table.Rows[0]);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return userEntity;
    }

    public UserEntity GetUserByEmail(string email)
    {
        UserEntity userEntity = null;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            
            var sql = "select * from users where email=@email";
            
            using var cmd = new MySqlCommand(sql, connect);
            //Paramter binding
            var userEmail = new MySqlParameter("@email", MySqlDbType.VarChar, 36)
            {
                Value = email
            };
            cmd.Parameters.Add(userEmail);
            
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

            if (table.Rows.Count > 0)
            {
                userEntity = new UserEntity(table.Rows[0]);
            }
            
            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return userEntity;
    }

    public bool AddUser(UserEntity entity)
    {
        bool success = false;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            
            var sql = "insert into users (id, firstname, lastname, email, passwordhash, passwordsalt) " +
                      "values (@id, @firstName, @lastName, @email, @passwordHash, @passwordSalt)";
            
            using var cmd = new MySqlCommand(sql, connect);
            
            var userId = new MySqlParameter("@id", MySqlDbType.VarChar, 36) { Value = entity.Id };
            cmd.Parameters.Add(userId);
            
            var firstName = new MySqlParameter("@firstName", MySqlDbType.VarChar, 100) {Value = entity.FirstName};
            cmd.Parameters.Add(firstName);

            var lastName = new MySqlParameter("@lastName", MySqlDbType.VarChar, 100) {Value = entity.LastName};
            cmd.Parameters.Add(lastName);

            var email = new MySqlParameter("@email", MySqlDbType.VarChar, 100) {Value = entity.Email};
            cmd.Parameters.Add(email);

            var passwordHash = new MySqlParameter("@passwordHash", MySqlDbType.VarChar, 100)
                {Value = entity.PasswordHash};
            cmd.Parameters.Add(passwordHash);

            var passwordSalt = new MySqlParameter("@passwordSalt", MySqlDbType.VarChar, 36)
                {Value = entity.PasswordSalt};
            cmd.Parameters.Add(passwordSalt);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (InvalidOperationException e)
            {
                // log error
            }

            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return success;
    }

    public bool UpdateUser(UserEntity entity)
    {
        bool success = false;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "update users set firstname=@firstName, lastname=@lastName, passwordHash=@passwordHash, passwordSalt=@passwordSal " +
                      "where id=@id";

            using var cmd = new MySqlCommand(sql, connect);

            var firstName = new MySqlParameter("@firstName", MySqlDbType.VarChar, 100) {Value = entity.FirstName};
            cmd.Parameters.Add(firstName);

            var lastName = new MySqlParameter("@lastName", MySqlDbType.VarChar, 100) {Value = entity.LastName};
            cmd.Parameters.Add(lastName);

            //var email = new MySqlParameter("@email", MySqlDbType.VarChar, 100) {Value = entity.Email};
            //cmd.Parameters.Add(email);

            var passwordHash = new MySqlParameter("@passwordHash", MySqlDbType.VarChar, 100)
                {Value = entity.PasswordHash};
            cmd.Parameters.Add(passwordHash);

            var passwordSalt = new MySqlParameter("@passwordSalt", MySqlDbType.VarChar, 36)
                {Value = entity.PasswordSalt};
            cmd.Parameters.Add(passwordSalt);
            
            var userId = new MySqlParameter("@id", MySqlDbType.VarChar, 36) { Value = entity.Id };
            cmd.Parameters.Add(userId);

            try
            {
                cmd.ExecuteNonQuery();
                success = true;
            }
            catch (InvalidOperationException e)
            {
                // log error
            }

            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return success;
    }
}