using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Internal;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    internal sealed class CommitmentMap : IEntityTypeConfiguration<CommitmentEntity>
    {
        public void Configure(EntityTypeBuilder<CommitmentEntity> builder)
        {

            builder.ToTable("Commitment");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.Text).IsRequired().HasMaxLength(1000);
          
                
                
        }
    }
}
