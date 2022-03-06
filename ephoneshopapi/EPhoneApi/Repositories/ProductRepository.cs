using System.Data;
using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace EPhoneApi.Repositories;

public class ProductRepository : IProductRepository
{
    private readonly AppSettings _appSettings;

    public ProductRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }

    public ProductEntity GetAllProducts()
    {
        //establishing the connection
        ProductEntity productEntity = null;
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from product";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            // execute command when called and populates to the table
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
                productEntity = new ProductEntity(table.Rows[0]);
            }

            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }

        return productEntity;
    }

    public ProductEntity GetProductByBrand(string brand)
    {
        ProductEntity productEntity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "select * from product where brand=@brand";

            using var cmd = new MySqlCommand(sql, conn);
            var productBrand = new MySqlParameter("@brand", MySqlDbType.VarChar, 36)
            {
                Value = brand
            };
            cmd.Parameters.Add(productBrand);

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
                productEntity = new ProductEntity(table.Rows[0]);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return productEntity;
    }

    public ProductEntity GetProductBySpeed(string speed)
    {
        ProductEntity productEntity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "select * from product where speed=@speed";

            using var cmd = new MySqlCommand(sql, conn);
            var userEmail = new MySqlParameter("@speed", MySqlDbType.VarChar, 36)
            {
                Value = speed
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
                productEntity = new ProductEntity(table.Rows[0]);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return productEntity;
    }
    public ProductEntity GetProductByProcessor(string processor)
    {
        ProductEntity productEntity = null;
        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = "select * from product where processor=@processor";

            using var cmd = new MySqlCommand(sql, conn);
            var userEmail = new MySqlParameter("@processor", MySqlDbType.VarChar, 36)
            {
                Value = processor
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
                productEntity = new ProductEntity(table.Rows[0]);
            }

            conn.Close();
        }
        catch (Exception e)
        {
            // Log error
        }

        return productEntity;
    }

}