﻿
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;



namespace EPhoneAPI.Entities
{
    [Keyless]
    public class Phone
    {
        public int modelNumber { get; set; }
        public string brand { get; set; }
        public string color { get; set; }
        public string features { get; set; }
        public string speed { get; set; }

    }
}
