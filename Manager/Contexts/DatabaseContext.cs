using Microsoft.EntityFrameworkCore;
using WebApiApp.Entities;

namespace WebApiApp.Manager.Contexts
{
    public class DatabaseContext:DbContext
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options):base(options)
        {

        }
        public DbSet<Car> Cars { get; set; }
        public DbSet<Boat> Boats { get; set; }
        public DbSet<Bus> Buses { get; set; }
    }
}
