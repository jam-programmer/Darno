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
    internal sealed class PricingPlanMap :IEntityTypeConfiguration<PricingPlanEntity>
    {
        public void Configure(EntityTypeBuilder<PricingPlanEntity> builder)
        {
            builder.ToTable("PricingPlan");
            builder.Property(p => p.Name).IsRequired().HasMaxLength(100);
            builder.Property(p => p.Price).IsRequired();
            builder.Property(p => p.IsActive).IsRequired();

            builder.HasMany(f => f.Features).WithOne(p => p.PricingPlan)
                .HasForeignKey(f => f.PricingPlanId);
        }
    }
}



