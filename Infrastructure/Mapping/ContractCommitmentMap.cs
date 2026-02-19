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
    internal sealed class ContractCommitmentMap : IEntityTypeConfiguration<ContractMapCommitment>
    {
        public void Configure(EntityTypeBuilder<ContractMapCommitment> builder)
        {
            builder.ToTable("ContractMapCommitment");
            builder.HasKey(c => new { c.ContractId, c.CommitmentId });
            builder.HasOne(c => c.Contract).WithMany(c => c.ContractCommitments)
                .HasForeignKey(c => c.ContractId);
            builder.HasOne(c => c.Commitment).WithMany(c => c.ContractCommitments)
               .HasForeignKey(c => c.CommitmentId);
        }
    }
}
