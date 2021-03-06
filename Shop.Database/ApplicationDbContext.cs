using System;
using System.Linq;
using System.Net.Sockets;
using Microsoft.EntityFrameworkCore;
using Shop.Domain.Models;

namespace Shop.Database
{
    
    public class ApplicationDbContext : DbContext
    {
        public DbSet<Product> Products { get; set; }
        public DbSet<File> Files { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Rating> Ratings { get; set; }
        public DbSet<Producer> Producers { get; set; }
        
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options): base (options)
        {
            
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            
            // Rating
            modelBuilder.Entity<Rating>().HasOne(r => r.Product)
                .WithMany(p => p.Ratings)
                .HasForeignKey(r => r.ProductId)
                .OnDelete(DeleteBehavior.NoAction);

            // Products
            modelBuilder.Entity<Product>().HasOne(p => p.Producer)
                .WithMany(produces => produces.Products)
                .HasForeignKey(p => p.ProducerId)
                .OnDelete(DeleteBehavior.NoAction); // Cascade this manually, EF forced me to NoAction

            modelBuilder.Entity<Product>().HasOne(p => p.File)
                .WithOne(f => f.Product)
                .HasForeignKey<Product>(p => p.FileId)
                .OnDelete(DeleteBehavior.SetNull);

            modelBuilder.Entity<Product>().HasOne(p => p.Category)
                .WithMany(c => c.Producets)
                .HasForeignKey(p => p.CategoryId)
                .OnDelete(DeleteBehavior.Cascade);
            
            // Producer
            modelBuilder.Entity<Producer>().HasOne(p => p.File)
                .WithOne(f => f.Producer)
                .HasForeignKey<Producer>(p => p.FileId)
                .OnDelete(DeleteBehavior.Cascade);
        }
    }
}