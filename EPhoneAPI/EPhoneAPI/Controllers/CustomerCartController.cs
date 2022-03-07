using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using EPhoneAPI.Models;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;

namespace EPhoneAPI.Controllers
{
    public class CustomerCartController : ApiController
    {
        // GET: Customer
        public HttpResponseMessage Get()
        {
            //Creating A connection to the MySQL sever and sending a directly implemented query
            string query = @"
                    select * from ephone.customercart
                    ";
            DataTable table = new DataTable();
            using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
            using (var cmd = new MySqlCommand(query, con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(CustomerCart cart)
        {
            try
            {
                string query = @"
                    insert into ephone.customercart (Id) values
                    ('" + cart.OrderNum + @"')
                    ";
                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Added Successfully!!";
            }
            catch (Exception ex)
            {
                return "Failed to Add!!";
            }
        }

        public string Put(CustomerCart cart)
        {
            try
            {
                string query = @"
                    update ephone.customercart set firstName =
                    '" + cart.FirstName + @"'
                    where Id=" + cart.OrderNum + @"
                    ";
                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Updated Successfully!!";
            }
            catch (Exception ex)
            {
                return "Failed to Update!!";
            }
        }

        public string Delete(int OrderNum)
        {
            try
            {
                string query = @"
                    delete from ephone.customercart
                    where Id=" + OrderNum + @"
                    ";
                DataTable table = new DataTable();
                using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
                using (var cmd = new MySqlCommand(query, con))
                using (var da = new MySqlDataAdapter(cmd))
                {
                    cmd.CommandType = CommandType.Text;
                    da.Fill(table);
                }

                return "Deleted Successfully!!";
            }
            catch (Exception ex)
            {
                return "Failed to Delete!!";
            }
        }

        [Route("api/Customer/GetAllCustomerCart")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            string query = @"
                    select * from ephone.customercart
                    ";
            DataTable table = new DataTable();
            using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
            using (var cmd = new MySqlCommand(query, con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }
    }
}