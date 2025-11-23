using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ServiceMap : IEntityTypeConfiguration<ServiceEntity>
{
    public void Configure(EntityTypeBuilder<ServiceEntity> builder)
    {

        builder.ToTable("Service");
        builder.HasQueryFilter(f=>f.IsDelete==false);
        builder.HasIndex(p => p.UniqueName).IsUnique();

        builder.HasMany(m => m.Projects)
            .WithOne(o => o.Service)
            .HasForeignKey(f => f.ServiceId);
    }
}
