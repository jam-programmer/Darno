using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping;

internal sealed class UserInformationMap : IEntityTypeConfiguration<UserInformationEntity>
{
    public void Configure(EntityTypeBuilder<UserInformationEntity> builder)
    {
        builder.ToTable("UserInformation");
        builder.Property(u => u.UserAgent).IsRequired();
        builder.Property(u => u.Ip).HasMaxLength(50);
        builder.Property(u => u.UserInformation).HasMaxLength(200);
        builder.Property(u => u.Statuscode);
        builder.Property(u => u.Duration);


    }

}




