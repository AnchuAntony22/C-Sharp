using Microsoft.EntityFrameworkCore;

namespace WebApplicationEF.Models
{
    public class InsurerDbContext : DbContext
    {
        public InsurerDbContext(DbContextOptions<InsurerDbContext> options) : base(options) 
        { 

        }
        public DbSet<Holder> Holders { get; set; }
        public DbSet<Insurance> Insurances { get; set; }
    }
}
