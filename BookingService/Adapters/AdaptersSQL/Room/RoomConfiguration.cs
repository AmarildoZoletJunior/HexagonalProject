using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Room
{
    public class RoomConfiguration : IEntityTypeConfiguration<Domain.Entities.Room>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Room> builder)
        {
            builder.HasKey(x => x.Id);
            builder.Property(x => x.Id).IsRequired().ValueGeneratedOnAdd();
            builder.OwnsOne(x => x.PriceRoom).Property(x => x.Currency);
            builder.OwnsOne(x => x.PriceRoom).Property(x => x.Value);
        }
    }
}
