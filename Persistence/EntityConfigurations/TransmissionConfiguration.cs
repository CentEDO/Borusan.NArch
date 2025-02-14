﻿using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using Domain.Entities;

namespace Persistence.EntityConfigurations
{
    public class TransmissionConfiguration : IEntityTypeConfiguration<Transmission>
    {
        public void Configure(EntityTypeBuilder<Transmission> builder)
        {
            builder.ToTable("Transmissions").HasKey(t => t.Id);

            builder.Property(t => t.Id).HasColumnName("Id").IsRequired();
            builder.Property(t => t.Name).HasColumnName("Name").IsRequired();
            builder.Property(t => t.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(t => t.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(t => t.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(t => t.Cars).WithOne(c => c.Transmission).HasForeignKey(c => c.TransmissionId);

            builder.HasQueryFilter(t => !t.DeletedDate.HasValue);
        }
    }
}
