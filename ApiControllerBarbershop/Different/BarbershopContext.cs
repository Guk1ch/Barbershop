using ApiControllerBarbershop.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace ApiControllerBarbershop.Different
{
    public class BarbershopContext : DbContext
    {
        public BarbershopContext() { }
        public DbSet<Client> Client { get; set; }
        public DbSet<Order> Order { get; set; }
        public DbSet<Service> Service { get; set; }
        public DbSet<TypeService> TypeService { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(Startup.Configuration.GetConnectionString("BarbershopConnection"));
        }
    }
}
