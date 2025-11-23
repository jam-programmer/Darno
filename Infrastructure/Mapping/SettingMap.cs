using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Mapping;

internal sealed class SettingMap : IEntityTypeConfiguration<SettingEntity>
{
    public void Configure(EntityTypeBuilder<SettingEntity> builder)
    {
        builder.ToTable("Setting");
        builder.HasData(new SettingEntity()
        {
            Id=Guid.Parse("20ea895d-b448-4e02-9c8a-cd40f871c372"),
            AboutUs=string.Empty,
            Address=string.Empty,
            Email=string.Empty,
            InstagramUrl=string.Empty,
            LinkedInUrl=string.Empty,
            PhoneNumber=string.Empty,
            TelegramUrl=string.Empty,
        });
    }
}
