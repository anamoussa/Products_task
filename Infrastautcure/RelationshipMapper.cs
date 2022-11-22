using Core.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastautcure
{
    public static class RelationshipMapper
    {
        public static void MapRelationships(this ModelBuilder builder)
        {

            builder.Entity<OrderProducts>()
                .HasOne(i => i.Product)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(x => x.ProductId);

            builder.Entity<OrderProducts>()
                .HasOne(i => i.Order)
                .WithMany(e => e.OrderProducts)
                .HasForeignKey(x => x.OrderId);

        }
    }
}
