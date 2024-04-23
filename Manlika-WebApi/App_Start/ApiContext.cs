using Manlika_WebApi.Controllers;
using Manlika_WebApi.Model;
using Microsoft.EntityFrameworkCore;

namespace Manlika_WebApi.App_Start
{
    public class ApiContext : DbContext
    {
        protected override void OnConfiguring
       (DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseInMemoryDatabase(databaseName: "AuthorDb");
        }
        public DbSet<CustomerOrder>? CustomerOrders { get; set; }
        public DbSet<CustomerFood>? CustomerFood { get; set; }
        public DbSet<Customer>? Customers { get; set; }
        public DbSet<Food>? Foods { get; set; }
    }
}
