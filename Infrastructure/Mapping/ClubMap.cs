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
    internal sealed class ClubMap: IEntityTypeConfiguration<ClubEntity>
    {
        public void Configure(EntityTypeBuilder<ClubEntity> builder)
        {
            builder.ToTable("Club");
        }
    }
}
