using System.Data;
using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.AspNetCore.Mvc;
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

    public List<ProductEntity> GetAllProducts()
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
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
                Console.WriteLine(e.Message);  
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);   

                }

            }

            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }

        return prodList;
    }

    public List<ProductEntity> GetProductByBrand(string brand)
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from product where brand=@brand";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            //inserting params
            var brandParam = new MySqlParameter("@brand", MySqlDbType.VarChar, 36)
            { 
                Value = brand
            };
            cmd.Parameters.Add(brandParam);
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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }

            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }

    public List<ProductEntity> GetProductBySpeed(string speed)
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from product where speed=@speed";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            //inserting params
            var speedParam = new MySqlParameter("@speed", MySqlDbType.VarChar, 36)
            {
                Value = speed
            };
            cmd.Parameters.Add(speedParam);
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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }

            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }
    public List<ProductEntity> GetProductByProcessors(string processor)
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from product where processors=@processors";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            //inserting params
            var procParam = new MySqlParameter("@processors", MySqlDbType.VarChar, 36)
            {
                Value = processor
            };
            cmd.Parameters.Add(procParam);
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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }
            }
            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }
    public List<ProductEntity> GetProductByPrice(string price)
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from product where price=@price";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            //inserting params
            var priceParam = new MySqlParameter("@price", MySqlDbType.VarChar, 36)
            {
                Value = price
            };
            cmd.Parameters.Add(priceParam);
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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }
            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }
    /*-----------------------------------------------------*/
    
    public List<ProductEntity> GetProductByPriceMin()
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            //sql query to order by descending price
            var sql = "select * from product order by price DESC";

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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }
            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }

   
    public List<ProductEntity> GetProductByPriceMax()
    {
        var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();
            //sql query to order by descending price
            var sql = "select * from product order by price ASC";

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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }
            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }


    public List<ProductEntity> GetProductByPriceSpecfic(string price)
    {
         var prodList = new List<ProductEntity>();
        //establishing the connection
        using var connect = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            connect.Open();

            var sql = "select * from products where Price >= @price order by price ASC";

            // creating command
            using var cmd = new MySqlCommand(sql, connect);
            //inserting params
            var priceParam = new MySqlParameter("@price", MySqlDbType.VarChar, 36)
            {
                Value = price
            };
            cmd.Parameters.Add(priceParam);
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
                Console.WriteLine(e.Message);
            }

            if (table.Rows.Count > 0)
            {
                foreach (DataRow row in table.Rows)
                {
                    var entity = new ProductEntity(row);
                    prodList.Add(entity);

                }

            }
            connect.Close();
        }
        catch (Exception ex)
        {
            // Log error
        }
        return prodList;
    }
}