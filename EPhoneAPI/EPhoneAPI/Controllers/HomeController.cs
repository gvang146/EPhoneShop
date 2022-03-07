using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
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
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public string Post(Home info)
        {
            try
            {
                string query = @"
                    insert into ephone.contact (Name,Email,Message) values
                    ('" + info.Name +"," +info.Email + "," + info.Message + @"')
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
    }
}
