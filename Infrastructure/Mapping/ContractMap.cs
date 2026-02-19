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
    internal sealed class ContractMap : IEntityTypeConfiguration<ContractEntity>
    {
        public void Configure(EntityTypeBuilder<ContractEntity> builder)
        {
            builder.ToTable("Contract");
            builder.HasKey(c => c.Id);
            builder.Property(c => c.ContractNumber).IsRequired().HasMaxLength(20);
            builder.Property(c => c.Subject).IsRequired().HasMaxLength(500);
            builder.Property(c => c.EmployerName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.EmployerId).IsRequired();
            builder.Property(c => c.ContractorName).IsRequired().HasMaxLength(50);
            builder.Property(c => c.ContractorId).IsRequired();
            builder.Property(c => c.Status).IsRequired();
            builder.Property(c => c.StartDate).IsRequired();
            builder.Property(c => c.EndDate).IsRequired();
            builder.Property(c => c.CreatedAt).IsRequired();

        }

    }
}
