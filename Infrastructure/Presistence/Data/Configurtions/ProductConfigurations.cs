using Domain.Entities.ProductModule; 
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Presistence.Data.Configurtions
{
    internal class ProductConfigurations : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.HasOne(p => p.productBrand)
                .WithMany()
                .HasForeignKey(p => p.BrandId);
            builder.HasOne(p => p.productType)
                .WithMany()
                .HasForeignKey(p => p.TypeId);
            builder.Property(p => p.Price)
                .HasColumnType("decimal(15,2)");


        }
    }
}
