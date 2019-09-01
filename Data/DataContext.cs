using API.Models;
using Microsoft.EntityFrameworkCore;

namespace API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) {}
				public DbSet<Address> Addresses { get; set; }
				public DbSet<Client> Clients { get; set; }
				public DbSet<Product> Products { get; set; }
				public DbSet<Provider> Providers { get; set; }
				public DbSet<Service> Services { get; set; }
				public DbSet<ServiceOrder> ServiceOrders { get; set; }
				public DbSet<Telephone> Telephones { get; set; }
				public DbSet<User> Users { get; set; }
    }
}