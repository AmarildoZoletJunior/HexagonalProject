using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Booking
{
    public class BookingConfiguration : IEntityTypeConfiguration<Domain.Entities.Booking>
    {

        public void Configure(EntityTypeBuilder<Domain.Entities.Booking> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
        }
    }
}
