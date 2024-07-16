using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Entities;

namespace Persistence.EntityConfigurations
{
    public class ColorConfiguration : IEntityTypeConfiguration<Color>
    {
        public void Configure(EntityTypeBuilder<Color> builder)
        {
            builder.ToTable("Colors").HasKey(c => c.Id);

            builder.Property(c => c.Id).HasColumnName("Id").IsRequired();
            builder.Property(c => c.Name).HasColumnName("Name").IsRequired();
            builder.Property(c => c.CreatedDate).HasColumnName("CreatedDate").IsRequired();
            builder.Property(c => c.UpdatedDate).HasColumnName("UpdatedDate");
            builder.Property(c => c.DeletedDate).HasColumnName("DeletedDate");

            builder.HasMany(c => c.Cars).WithOne(c => c.Color).HasForeignKey(c => c.ColorId);

            builder.HasQueryFilter(c => !c.DeletedDate.HasValue);
        }
    }
}
