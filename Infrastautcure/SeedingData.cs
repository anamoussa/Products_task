using Core.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastautcure
{
    public static class SeedingData
    {
        public static void SeedData(this ModelBuilder builder)
        {
            builder.Entity<Product>()
                .HasData(new Product()
                {
                    ProductId = 1,
                    Name = " Test1",
                    Price = 22,
                    Qauntity =20
                });
            builder.Entity<Product>()
               .HasData(new Product()
               {
                   ProductId = 2,
                   Name = " Test2",
                   Price = 20,
                   Qauntity = 8
               });
            builder.Entity<Product>()
               .HasData(new Product()
               {
                   ProductId = 3,
                   Name = " Test3",
                   Price = 30,
                   Qauntity = 20
               });
            builder.Entity<Order>()
               .HasData(new Order()
               {
                   OrderId = 1,
                   Date = DateTime.Now
                 
               });
            builder.Entity<Order>()
               .HasData(new Order()
               {
                   OrderId = 2,
                   Date = DateTime.Now

               });
            builder.Entity<Order>()
               .HasData(new Order()
               {
                   OrderId = 3,
                   Date = DateTime.Now

               });
   
            builder.Entity<OrderProducts>()
               .HasData(new OrderProducts()
               {
                   Id = 1,
                   ProductId = 1,
                   OrderId = 1,

               });
            builder.Entity<OrderProducts>()
               .HasData(new OrderProducts()
               {
                   Id = 2,
                   ProductId = 3,
                   OrderId = 1,
               });
            builder.Entity<OrderProducts>()
              .HasData(new OrderProducts()
              {
                  Id = 3,
                  ProductId = 1,
                  OrderId = 2,
              });
            builder.Entity<OrderProducts>()
              .HasData(new OrderProducts()
              {
                  Id = 4,
                  ProductId = 2,
                  OrderId = 3,
              });



            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {
     
                    Name = "User",
                    NormalizedName = "USER"
                });
            builder.Entity<IdentityRole>()
                .HasData(new IdentityRole()
                {

                    Name = "Admin",
                    NormalizedName = "ADMIN"
                });
        }
    }
}
