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
    public class AboutConfiguration : IEntityTypeConfiguration<About>
    {
        public void Configure(EntityTypeBuilder<About> builder)
        {
            builder.Property(a => a.OriginTitle).IsRequired(true).HasMaxLength(120);
            builder.Property(a => a.FutureTitle).IsRequired(true).HasMaxLength(120);
            builder.Property(a => a.GhibliTitle).IsRequired(true).HasMaxLength(120);
            builder.Property(a => a.HeightTitle).IsRequired(true).HasMaxLength(120);
            builder.Property(a => a.MessageTitle).IsRequired(true).HasMaxLength(120);
            builder.Property(a => a.GlobalTitle).IsRequired(true).HasMaxLength(120);
        }
    }
}
