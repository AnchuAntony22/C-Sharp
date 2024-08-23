using silver_order_api.Models;
using System.Collections.Generic;
using Microsoft.EntityFrameworkCore;
using silver_order_api.Models;

namespace silver_order_api.Data
{
    public class SilverDb : DbContext
    {
        public SilverDb(DbContextOptions<SilverDb> options) : base(options) { }

        public DbSet<MenuItem> MenuItems { get; set; }
    }
}
