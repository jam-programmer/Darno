using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    internal sealed class PlanFeatureMap : IEntityTypeConfiguration<PlanFeatureEntity>
    {
        public void Configure(EntityTypeBuilder<PlanFeatureEntity>builder)
        {
            builder.ToTable("PlanFeature");
            builder.Property(f => f.Name).IsRequired().HasMaxLength(200);
            builder.Property(f => f.IsActive).IsRequired();

        }
    }
}
