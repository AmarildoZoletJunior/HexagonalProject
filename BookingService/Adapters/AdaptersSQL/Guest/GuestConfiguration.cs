using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaptersSQL.Guest
{
    public class GuestConfiguration : IEntityTypeConfiguration<Domain.Entities.Guest>
    {
        public void Configure(EntityTypeBuilder<Domain.Entities.Guest> builder)
        {
            builder.HasKey(prop => prop.Id);
            builder.Property(prop => prop.Id).IsRequired().ValueGeneratedOnAdd();
            builder.OwnsOne(prop => prop.DocumentId).Property(props => props.IdNumber);

            builder.OwnsOne(prop => prop.DocumentId).Property(props => props.DocumentType);
        }
    }
}
