using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using UnicornRanch.Models;

namespace UnicornRanch.Data
{
        public class UnicornFarmDbContext : DbContext
        {
            // extend base class constructor, passing in options
            public UnicornFarmDbContext(DbContextOptions<UnicornFarmDbContext> options) : base(options)
            {
                
            }

            // db set for required models
            public DbSet<UnicornModel> unicorns { get; set; }
            public DbSet<UnicornLocationModel> locations { get; set; }

        }
}
