using Core.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastautcure
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.ToTable("Product");
            builder.HasKey(i => i.ProductId);
            builder.Property(i => i.ProductId).ValueGeneratedOnAdd();
            builder.Property(i => i.Name).IsRequired().HasMaxLength(150);
            builder.Property(i => i.Price).IsRequired();
            builder.Property(i => i.Qauntity).IsRequired();
           

        }
    }
}
