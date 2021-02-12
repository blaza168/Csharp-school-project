using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;

namespace Shop.Database
{
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {
            
        }
    }
}