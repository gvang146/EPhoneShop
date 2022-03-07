using System.Data;
using EPhoneApi.Entities;
using EPhoneApi.Util;
using Microsoft.Extensions.Options;
using MySql.Data.MySqlClient;

namespace EPhoneApi.Repositories;

public class OrderRepository : IOrderRepository
{
    private readonly AppSettings _appSettings;

    public OrderRepository(IOptions<AppSettings> appSettings)
    {
        _appSettings = appSettings.Value;
    }
    
    public IList<OrderEntity> GetUserOrders(string userId)
    {
        IList<OrderEntity> entity = new List<OrderEntity>();

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            
            // Orders by OrderDate descendent to put recent order at the top of the
            // list
            var sql = "select * from orders where userid=@userId order by orderdate desc";
            using var cmd = new MySqlCommand(sql, conn);
            cmd.Parameters.Add("@userId", MySqlDbType.VarChar, 36).Value = userId;

            var table = new DataTable();
            using var adapter = new MySqlDataAdapter(cmd);

            try
            {
                adapter.Fill(table);
            }
            catch (Exception e)
            {
                // log error
            }

            foreach (DataRow row in table.Rows)
            {
                entity.Add(new OrderEntity
                {
                    Id = Convert.ToString(row["id"]),
                    Status = Convert.ToString(row["status"]),
                    OrderDate = Convert.ToDateTime(row["orderdate"]),
                    PaymentDate = Convert.ToDateTime(row["paymentdate"]),
                    ConfirmationNumber = Convert.ToString(row["ConfirmationNumber"])
                });
            }
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return entity;
    }

    public OrderEntity GetOrderDetails(string orderId)
    {
        OrderEntity entity = null;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();

            var sql = 
                @"select
                    o.id order_id,
                    o.status order_status,
                    o.orderdate,
                    o.paymentdate,
                    o.confirmationnumber,
                    shipaddr.id shipping_address_id,
                    shipaddr.address shipping_address,
                    shipaddr.city shipping_city,
                    shipaddr.state shipping_state,
                    shipaddr.zip shipping_zip,
                    billingaddr.id billing_address_id,
                    billingaddr.address billing_address,
                    billingaddr.city billing_city,
                    billingaddr.state billing_state,
                    billingaddr.zip billing_zip,
                    od.id details_id,
                    od.status details_status,
                    od.price,
                    od.quantity,
                    od.shipdate,
                    p.id product_id,
                    p.productname,
                    p.productdesc,
                    p.brand,
                    p.color,
                    p.processors,
                    p.speed
                  from orders o
                    inner join order_details od
                        on od.orderid = o.id
                    inner join user_address shipaddr
                      on shipaddr.id = o.shippingaddressid
                    inner join user_address billingaddr
                      on billingaddr.id = o.billingaddressid
                    inner join product p
                        on p.id = od.productid
                  where o.id=@orderId";

            using var cmd = new MySqlCommand(sql);
            cmd.Parameters.Add("@orderId", MySqlDbType.VarChar, 36).Value = orderId;

            var table = new DataTable();
            using var adapter = new MySqlDataAdapter(cmd);

            try
            {
                adapter.Fill(table);
            }
            catch (Exception e)
            {
                // log error
            }

            if (table.Rows.Count > 0)
            {
                entity = new OrderEntity
                {
                    Id = Convert.ToString(table.Rows[0]["order_id"]),
                    Status = Convert.ToString(table.Rows[0]["order_status"]),
                    OrderDate = Convert.ToDateTime(table.Rows[0]["orderdate"]),
                    PaymentDate = Convert.ToDateTime(table.Rows[0]["paymentdate"]),
                    ConfirmationNumber = Convert.ToString(table.Rows[0]["ConfirmationNumber"]),
                    ShippingAddress = new UserAddressEntity
                    {
                        Id = Convert.ToString(table.Rows[0]["shipping_address_id"]),
                        Address = Convert.ToString(table.Rows[0]["shipping_address"]),
                        City = Convert.ToString(table.Rows[0]["shipping_city"]),
                        State = Convert.ToString(table.Rows[0]["shipping_state"]),
                        Zip = Convert.ToString(table.Rows[0]["shipping_zip"])
                    },
                    BillingAddress = new UserAddressEntity
                    {
                        Id = Convert.ToString(table.Rows[0]["billing_address_id"]),
                        Address = Convert.ToString(table.Rows[0]["billing_address"]),
                        City = Convert.ToString(table.Rows[0]["billing_city"]),
                        State = Convert.ToString(table.Rows[0]["billing_state"]),
                        Zip = Convert.ToString(table.Rows[0]["billing_zip"])
                    },
                    OrderDetails = new List<OrderDetailsEntity>()
                };

                foreach (DataRow row in table.Rows)
                {
                    entity.OrderDetails.Add(new OrderDetailsEntity
                    {
                        Id = Convert.ToString(row["details_id"]),
                        Status = Convert.ToString(row["details_status"]),
                        Price = Convert.ToDouble(row["price"]),
                        Quantity = Convert.ToInt32(row["quantity"]),
                        ShipDate = Convert.ToDateTime(row["shipdate"]),
                        Product = new ProductEntity
                        {
                            Id = Convert.ToString(row["product_id"]),
                            ProductName = Convert.ToString(row["productname"]),
                            ProductDesc = Convert.ToString(row["productdesc"]),
                            Brand = Convert.ToString(row["brand"]),
                            Color = Convert.ToString(row["color"]),
                            Processors = Convert.ToString(row["processors"]),
                            Speed = Convert.ToString(row["speed"])
                        }
                    });
                }
            }
            
            conn.Close();
        }
        catch (Exception e)
        {
            // log error
        }

        return entity;
    }
    
    public bool AddNewOrder(OrderEntity entity)
    {
        var success = false;

        using var conn = new MySqlConnection(_appSettings.DbConnectionString);
        try
        {
            conn.Open();
            var transaction = conn.BeginTransaction();

            try
            {
                InsertOrder(conn, transaction, entity);

                foreach (var orderDetailsEntity in entity.OrderDetails)
                {
                    InsertOrderDetails(conn, transaction, entity.Id, orderDetailsEntity);
                }
                
                transaction.Commit();
                success = true;
            }
            catch (Exception e)
            {
                try
                {
                    transaction.Rollback();
                }
                catch (MySqlException ie)
                {
                    // log error
                }
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
    
    private void InsertOrder(MySqlConnection conn, MySqlTransaction trans, OrderEntity entity)
    {
        var sql = "insert into orders (id, userid, shippingaddressid, billingaddressid, status, orderdate, paymentdate, confirmationnumber) " +
                  "values (@id, @userId, @shippingAddressId, @billingAddressId, @status, @orderDate, @paymentDate, @confirmationNumber)";

        using var cmd = new MySqlCommand(sql, conn, trans);
        cmd.Parameters.Add("@id", MySqlDbType.VarChar, 36).Value = entity.Id;
        cmd.Parameters.Add("@userId", MySqlDbType.VarChar, 36).Value = entity.UserId;
        cmd.Parameters.Add("@shippingAddressId", MySqlDbType.VarChar, 36).Value = entity.ShippingAddress.Id;
        cmd.Parameters.Add("@billingAddressId", MySqlDbType.VarChar, 36).Value = entity.BillingAddress.Id;
        cmd.Parameters.Add("@status", MySqlDbType.VarChar, 25).Value = entity.Status;
        cmd.Parameters.Add("@orderDate", MySqlDbType.DateTime).Value = entity.OrderDate;
        cmd.Parameters.Add("@paymentDate", MySqlDbType.DateTime).Value = entity.PaymentDate;
        cmd.Parameters.Add("@confirmationNumber", MySqlDbType.VarChar, 10).Value = entity.ConfirmationNumber;

        cmd.ExecuteNonQuery();
    }

    private void InsertOrderDetails(MySqlConnection conn, MySqlTransaction trans, string orderId, OrderDetailsEntity entity)
    {
        var sql = "insert into order_details(id, orderid, productid, status, price, quantity, shipdate) " +
                  "values (@id, @orderId, @productId, @status, @price, @quantity, @shipDate)";

        using var cmd = new MySqlCommand(sql, conn, trans);
        cmd.Parameters.Add("@id", MySqlDbType.VarChar, 36).Value = entity.Id;
        cmd.Parameters.Add("@orderId", MySqlDbType.VarChar, 36).Value = orderId;
        cmd.Parameters.Add("@productId", MySqlDbType.VarChar, 36).Value = entity.Product.Id;
        cmd.Parameters.Add("@status", MySqlDbType.VarChar, 25).Value = entity.Status;
        cmd.Parameters.Add("@price", MySqlDbType.Decimal).Value = entity.Price;
        cmd.Parameters.Add("@quantity", MySqlDbType.Int32).Value = entity.Quantity;
        cmd.Parameters.Add("@shipDate", MySqlDbType.DateTime).Value = entity.ShipDate;

        cmd.ExecuteNonQuery();
    }
}