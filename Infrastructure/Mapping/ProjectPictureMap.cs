using Microsoft.EntityFrameworkCore;
using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class ProjectPictureMap :
    IEntityTypeConfiguration<ProjectPictureEntity>
{
    public void Configure(EntityTypeBuilder<ProjectPictureEntity> builder)
    {
        builder.ToTable("ProjectPicture");
        builder.HasQueryFilter(f => f.IsDelete == false);
    }
}
