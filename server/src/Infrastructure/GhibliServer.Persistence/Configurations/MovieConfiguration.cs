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
    public class MovieConfiguration : IEntityTypeConfiguration<Movie>
    {
        public void Configure(EntityTypeBuilder<Movie> builder)
        {
            builder.Property(m => m.Title).IsRequired(true).HasMaxLength(120);
            builder.Property(m => m.Genre).IsRequired(true).HasMaxLength(30);
            builder.Property(m => m.Director).IsRequired(true).HasMaxLength(30);
        }
    }
}
