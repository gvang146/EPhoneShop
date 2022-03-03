using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace EPhoneAPI.Models
{
    public class CustomerCart
    {
        public int OrderNum { get; set; }
        public int AccountNum { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public int ItemNum { get; set; }
        public string Price { get; set; }
    }
}