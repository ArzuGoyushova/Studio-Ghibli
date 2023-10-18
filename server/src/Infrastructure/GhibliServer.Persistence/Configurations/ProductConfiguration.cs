using GhibliServer.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GhibliServer.Persistence.Configurations
{
    public class ProductConfiguration : IEntityTypeConfiguration<Product>
    {
        public void Configure(EntityTypeBuilder<Product> builder)
        {
            builder.Property(p => p.Name).IsRequired(true).HasMaxLength(50);
            builder.Property(p => p.OldPrice).IsRequired(true).HasDefaultValue(60.0);
            builder.Property(p => p.RegularPrice).IsRequired(true).HasDefaultValue(46.0);
            builder.Property(p => p.OldPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.RegularPrice).HasColumnType("decimal(18,2)");
            builder.Property(p => p.Discount)
            .HasComputedColumnSql("CAST((([RegularPrice] - [OldPrice]) / [OldPrice]) * 100 AS INT)");
            builder.Property(p => p.Count).IsRequired(true).HasDefaultValue(1);
        }
    }
}
