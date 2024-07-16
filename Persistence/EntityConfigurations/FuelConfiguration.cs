using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.EntityConfigurations
{
    public class FuelConfiguration : IEntityTypeConfiguration<Fuel>
    {
        public void Configure(EntityTypeBuilder<Fuel> builder)
        {
            builder.ToTable("Fuels").HasKey(f => f.Id);

            builder.Property(f => f.Id).HasColumnName("Id").IsRequired();
            builder.Property(f => f.Name).HasColumnName("Name").IsRequired();
            builder.Property(f => f.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(f => f.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(f => f.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(f => f.Cars).WithOne(c => c.Fuel).HasForeignKey(c => c.FuelId);

            builder.HasQueryFilter(f => !f.DeletedDate.HasValue);
        }
    }
}
