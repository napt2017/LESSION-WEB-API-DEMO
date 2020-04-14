using LESSION_WEB_API_DEMO.Models;
using System.Data.Entity;

namespace LESSION_WEB_API_DEMO.DataAccess
{
    public class ProductManagementDbContext : DbContext
    {
        public ProductManagementDbContext() : base("name=MyDatabaseConnection")
        {

        }

        public DbSet<Product> Products { get; set; }
        public DbSet<Manufacturer> Manufacturers { get; set; }
    }
}