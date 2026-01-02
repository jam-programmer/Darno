using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
   internal sealed class SliderMap : IEntityTypeConfiguration<SliderEntity>
    {
        public void Configure(EntityTypeBuilder<SliderEntity> builder)
        {
            builder.HasQueryFilter(f=>f.IsDelete==false);
            builder.ToTable("Slider");
            builder.HasKey(S => S.Id);
            builder.Property(S => S.ImagePath).IsRequired().HasMaxLength(1000);
            builder.Property(S => S.Link).IsRequired().HasMaxLength(500);
            builder.Property(S => S.StartShow).IsRequired();
            builder.Property(S => S.EndShow).IsRequired();


        }
    }
}
