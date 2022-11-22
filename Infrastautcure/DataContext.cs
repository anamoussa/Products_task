using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastautcure
{
    public class DataContext : IdentityDbContext<IdentityUser>
    {

        public DbSet<Product> Products { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderProducts> OrderProducts { get; set; }
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            new ProductConfiguration().Configure
               (modelBuilder.Entity<Product>());

            new OrderConfiguration().Configure
               (modelBuilder.Entity<Order>());

            new OderProductsConfiguration().Configure
               (modelBuilder.Entity<OrderProducts>());

          
            modelBuilder.MapRelationships();
            modelBuilder.SeedData();
            base.OnModelCreating(modelBuilder);
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder
                .UseLazyLoadingProxies().UseSqlServer
                ("Data Source =.; Initial Catalog= ProductsTask; Integrated Security = True;");
            base.OnConfiguring(optionsBuilder);
        }




    }
}
