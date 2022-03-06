using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace EPhoneApi.Repositories;

public class CartsRepository
{
    private readonly AppSettings _appSettings;

    public CartsRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    public boolean AddItemToCart(CartsEntity entity)
    {
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            //creating the string
            var sql = "insert into Cart(Id, UserId, ProductId) values (@Id, @UserId, @ProductId)";

            using var cmd = new MySqlCommand(sql, connect);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36)
            {
                Value = entity.Id
            };
            cmd.Parameters.Add(idParam);
            var userIdParam = new MySqlParameter("@UserId", MySqlDbType.VarChar, 36)
            {
                Value = entity.UserId
            };
            cmd.Parameters.Add(userIdParam);
            var productIdParam = new MySqlParameter("@ProductId", MySqlDbType.VarChar, 36)
            {
                Value = entity.ProductId
            };
            cmd.Parameters.Add(productIdParam);

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
                entity = new CartsEntity(table.Rows[0]);
            }

            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }
        return true;
    }

    //Delete from cart
    public CartsEntity DeleteCartItem(string id)
    {
        CartsEntity entity = null;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            //creating the string
            var sql = "delete from carts where id=@id";

            using var cmd = new MySqlCommand(sql, connect);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36)
            {
                Value = id
            };
            cmd.Parameters.Add(idParam);
            

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
               entity  = new CartsEntity(table.Rows[0]);
            }

            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return entity;
    }
    //GetCartDetails
    public CartsEntity GetCartDetails(string id)
    {
        CartsEntity entity = null;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            //creating the string
            var sql = "select * from carts where id=@id";

            using var cmd = new MySqlCommand(sql, connect);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36)
            {
                Value = id
            };
            cmd.Parameters.Add(idParam);


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
                entity = new CartsEntity(table.Rows[0]);
            }

            connect.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return entity;
    }
}

