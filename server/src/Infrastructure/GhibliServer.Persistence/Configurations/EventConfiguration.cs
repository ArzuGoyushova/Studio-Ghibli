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
    public class EventConfiguration : IEntityTypeConfiguration<Event>
    {
        public void Configure(EntityTypeBuilder<Event> builder)
        {
            builder.Property(e => e.Title).IsRequired(true).HasMaxLength(50);
            builder.Property(b => b.Description).IsRequired(true).HasMaxLength(160);
            builder.Property(b => b.Location).IsRequired(true);
            builder.Property(e => e.EventDate).IsRequired(true);
        }
    }
}
