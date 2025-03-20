using Microsoft.EntityFrameworkCore;
using WebApplication1.Models;

namespace WebApplication1.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options) { }


        public DbSet<Category> categories { get; set; }
        public DbSet<User> users { get; set; }
        public DbSet<Role> roles { get; set; }
        public DbSet<Service> services { get; set; }
        public DbSet<Promotion> promotions { get; set; }
        public DbSet<ClientGroup> clientGroups { get; set; }
        public DbSet<Employee> employees { get; set; }
        public DbSet<RoomType> roomTypes { get; set; }
    
    }
}
