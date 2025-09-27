using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class ProjectMap : IEntityTypeConfiguration<ProjectEntity>
{
    public void Configure(EntityTypeBuilder<ProjectEntity> builder)
    {
        builder.ToTable("Project");
        builder.HasQueryFilter(f => f.IsDelete == false);
        builder.HasMany(m => m.ProjectPictures)
           .WithOne(o => o.Project)
           .HasForeignKey(f => f.ProjectId);
    }
}
