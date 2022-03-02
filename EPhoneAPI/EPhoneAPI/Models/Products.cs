using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPhoneAPI.Models
{
    public class Products
    {
        public int SerialNum { get; set; }
        public string ModelNum { get; set; }
        public string Name { get; set; }
        public string Color { get; set; }
        public string Processor { get; set; }
        public int Price { get; set; }
        public string Brand { get; set; }
        public string Speed { get; set; }
    }
}