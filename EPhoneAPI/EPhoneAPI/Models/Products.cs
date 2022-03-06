using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPhoneAPI.Models
{
    public class Products
    {
        public int ItemNum { get; set; }
        public int serialNum { get; set; }
        public string ProductName { get; set; }
        public string Colors { get; set; }
        public string Features { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Speed { get; set; }
    }
}