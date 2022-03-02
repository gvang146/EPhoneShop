using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Data;
using MySql.Data;
using MySql.Data.MySqlClient;
using System.Configuration;
using EPhoneAPI.Models;

namespace EPhoneAPI.Controllers
{
    public class EmployeeController : ApiController
    {
        // GET: Employee
        public HttpResponseMessage Get()
        {
            //Creating A connection to the MySQL sever and sending a directly implemented query
            string query = @"
                    select * from ephone.employee
                    ";
            DataTable table = new DataTable();
            using (var con = new MySqlConnection(ConfigurationManager.ConnectionStrings["EPhone"].ConnectionString))
            using (var cmd = new MySqlCommand(query,con))
            using (var da = new MySqlDataAdapter(cmd))
            {
                cmd.CommandType = CommandType.Text;
                da.Fill(table);
            }

            return Request.CreateResponse(HttpStatusCode.OK, table);
        }

        public string Post(Employee emp)
        {
            try
            {
                string query = @"
                    insert into ephone.employee (Id) values
                    ('"+emp.Id + @"')
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

        public string Put(Employee emp)
        {
            try
            {
                string query = @"
                    update ephone.employee set firstName =
                    '" + emp.FirstName + @"'
                    where Id="+emp.Id+@"
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

        public string Delete(int id)
        {
            try
            {
                string query = @"
                    delete from ephone.employee
                    where Id=" + id + @"
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

        [Route("api/Employee/GetAllEmployees")]
        [HttpGet]
        public HttpResponseMessage GetAllEmployees()
        {
            string query = @"
                    select * from ephone.employee
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