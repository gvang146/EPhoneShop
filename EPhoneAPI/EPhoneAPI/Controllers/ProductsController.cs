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
    public class ProductsController : ApiController
    {
        // GET: Products
        public HttpResponseMessage Get()
        {
            //Creating A connection to the MySQL server and sending a directly implemented query
            string query = @"
                    select * from ephonedb.product
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

        public string Post(Products pro)
        {
            try
            {
                string query = @"
                    insert into ephonedb.product (serialNum) values
                    ('" + pro.ItemNum + @"')
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

        public string Put(Products pro)
        {
            try
            {
                string query = @"
                    update ephonedb.product set name =
                    '" + pro.Name + @"'
                    where serialNum=" + pro.ItemNum + @"
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

        public string Delete(int ItemNum)
        {
            try
            {
                string query = @"
                    delete from ephonedb.product
                    where ItemNum=" + ItemNum + @"
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

        [Route("api/Products/GetAllProducts")]
        [HttpGet]
        public HttpResponseMessage GetAllProducts()
        {
            string query = @"
                    select * from ephonedb.product
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

        [Route("api/Products/GetSumOfProducts")]
        [HttpGet]
        public HttpResponseMessage GetSumOfProducts()
        {
            string query = @"
                    select SUM(price) price from ephonedb.product
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

        [Route("api/Products/GetCount")]
        [HttpGet]
        public HttpResponseMessage GetCount()
        {
            string query = @"
                    select COUNT(ItemNum) count from ephonedb.product
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