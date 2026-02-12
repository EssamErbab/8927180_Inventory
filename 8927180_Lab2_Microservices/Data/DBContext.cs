using _8927180_Lab2_Microservices.Model;
using Microsoft.EntityFrameworkCore;

namespace _8927180_Lab2_Microservices.Data
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }
        public DbSet<Inventory> Inventory { get; set; }
    }
}
