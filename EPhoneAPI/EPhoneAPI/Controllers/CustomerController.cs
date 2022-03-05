﻿using System;
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
    public class CustomerController : ApiController
    {
        // GET: Customer
        public HttpResponseMessage Get()
        {
            //Creating A connection to the MySQL sever and sending a directly implemented query
            string query = @"
                    select * from ephonedb.customer
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

        public string Post(Customer cus)
        {
            try
            {
                string query = @"
                    insert into ephonedb.customer (LastName,FirstName,Email,pass) values
                    (
                    '" + cus.LastName + @"' 
                    ,'" + cus.FirstName + @"' 
                    ,'" + cus.Email + @"' 
                    ,'" + cus.Password + @"')
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

        public string Put(Customer cus)
        {
            try
            {
                string query = @"
                    update ephonedb.customer set firstName =
                    '" + cus.FirstName + @"'
                    where Id=" + cus.AccountNum + @"
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

        public string Delete(int AccountNum)
        {
            try
            {
                string query = @"
                    delete from ephonedb.customer
                    where Id=" + AccountNum + @"
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

        [Route("api/Customer/GetAllCustomers")]
        [HttpGet]
        public HttpResponseMessage GetAllCustomers()
        {
            string query = @"
                    select * from ephonedb.customers
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