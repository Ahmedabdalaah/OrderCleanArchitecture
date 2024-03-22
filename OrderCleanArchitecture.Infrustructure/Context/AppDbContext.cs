using Microsoft.EntityFrameworkCore;
using OrderCleanArchitecture.Data.Entities;

namespace OrderCleanArchitecture.Infrustructure.Context
{
    public class AppDbContext : DbContext
    {
        public AppDbContext()
        {

        }
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }
        public DbSet<Employee> Employees { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Order> orders { get; set; }
    }
}
