﻿using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;
using System.Data;

namespace EPhoneApi.Repositories;

public class CartsRepository : ICartsRepository
{
    private readonly AppSettings _appSettings;

    public CartsRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    public Boolean AddItemToCart(CartsEntity entity)
    {
        var success = false;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            //creating the string
            var sql = "insert into Cart(Id, UserId, ProductId, quantity) values (@Id, @UserId, @ProductId, @quantity)";

            using var cmd = new MySqlCommand(sql, conn);
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

            cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = entity.Quantity;

            cmd.ExecuteNonQuery();
            success = true;

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }
        return success;
    }

    //Delete from cart
    public Boolean DeleteCartItem(string id)
    {
        var success = false;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            //creating the string
            var sql = "delete from carts where id=@id";

            using var cmd = new MySqlCommand(sql, conn);
            var idParam = new MySqlParameter("@id", MySqlDbType.VarChar, 36)
            {
                Value = id
            };
            cmd.Parameters.Add(idParam);
            cmd.ExecuteNonQuery();

            success = true;
            
            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return success;
    }
    //GetCartDetails
    public CartsEntity GetCartDetail(string id)
    {
        CartsEntity entity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            //creating the string
            var sql = "select * from carts where id=@id";

            using var cmd = new MySqlCommand(sql, conn);
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

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return entity;
    }
    //Update the cart's quantity per item
    public Boolean UpdateCartItem(CartsEntity entity)
    {
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            //create query string
            var sql = "update carts set Quantity=@quantity where id=@id";
            using var cmd = new MySqlCommand(sql, conn);
            var quantity = new MySqlParameter("@quantity", MySqlDbType.Int32)
            {
                Value = entity.Quantity
            };
            cmd.Parameters.Add(quantity);
            var id = new MySqlParameter("@id", MySqlDbType.VarChar, 32)
            {
                Value = entity.Id
            };
            cmd.Parameters.Add(id);
            cmd.ExecuteNonQuery();

            conn.Close();

        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return true;
    }

    //Get cart to check if exists
    public CartsEntity GetCart(string userId, string productId)
    {
        CartsEntity entity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            var sql = "select * from carts where UserId = @userId and ProductId=@productId";
            using var cmd = new MySqlCommand(sql, conn);
            var userIdParam = new MySqlParameter("@userId", MySqlDbType.VarChar, 32)
            {
                Value = userId
            };
            cmd.Parameters.Add(userIdParam);
            var pIdParam = new MySqlParameter("@productId", MySqlDbType.VarChar, 32)
            {
                Value = productId
            };
            cmd.Parameters.Add(pIdParam);
            using var adapter = new MySqlDataAdapter(cmd);
            var table = new DataTable();
            try
            {
                adapter.Fill(table);
            }
            catch(Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
            if (table.Rows.Count > 0)
            {
                entity = new CartsEntity(table.Rows[0]);
            }
            conn.Close();
        }
        catch (Exception ex)
        {
            Console.WriteLine(ex.Message);
        }
        return entity;
    }

    public IList<CartsEntity> GetAllCartItems(string userId)
    {
        IList<CartsEntity> entities = new List<CartsEntity>();

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            
            var sql = "select * from carts where userid=@userId";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@userId", MySqlDbType.VarChar, 36).Value = userId;

            var table = new DataTable();
            using var adapter = new MySqlDataAdapter(cmd);

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
                entities.Add(new CartsEntity(row));
            }
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return entities;
    }

    public bool DeleteAllCartItems(string userId)
    {
        var success = false;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "delete from carts where userid=@userId";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@userId", MySqlDbType.VarChar, 36).Value = userId;

            cmd.ExecuteNonQuery();
            success = true;
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }
        
        return success;
    }
}

