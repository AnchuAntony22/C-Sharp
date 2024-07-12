using Console_core_project.Models;
using Microsoft.EntityFrameworkCore;
namespace Console_core_project.DataAccess
{
    public class TodoDbContext : DbContext
    {
        public TodoDbContext(DbContextOptions<TodoDbContext> options) : base(options)
        {

        }
        public DbSet<Person> People { get; set; }
        public DbSet<Todo> Todos { get; set; }


        
          
    }
}
