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
    internal sealed class JobAdMap :IEntityTypeConfiguration<JobAdEntity>
    {
        public void Configure(EntityTypeBuilder<JobAdEntity> builder)
        {
            builder.ToTable("JobAdvertisement");
            builder.Property(j => j.Name).HasMaxLength(50).IsRequired(false);
            builder.Property(j => j.LastName).HasMaxLength(50).IsRequired(false);
            builder.Property(j => j.Age).IsRequired();
            builder.Property(j => j.JobTitle).HasMaxLength(50).IsRequired(false);
            builder.Property(j => j.JobCity).HasMaxLength(50).IsRequired(false);
            builder.Property(j => j.JobRole).HasMaxLength(50).IsRequired(false);
            builder.Property(j => j.EmploymentType).IsRequired();
            builder.Property(j => j.PostedDate).IsRequired();
            builder.Property(j => j.Description).IsRequired(false);

        }
    }
}
