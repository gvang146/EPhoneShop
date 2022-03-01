using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using EPhoneAPI.Entities;

namespace EPhoneAPI.Data
{
    public class EPhoneShopDBContext : DbContext
    {
        public EPhoneShopDBContext(DbContextOptions<EPhoneShopDBContext> options)
            : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<EPhoneAPI.Entities.Phone> Phone { get; set; }

        public DbSet<EPhoneAPI.Entities.User> User { get; set; }

    }
}
