using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
    internal sealed class CourseMap : IEntityTypeConfiguration<CourseEntity>
    {
        public void Configure(EntityTypeBuilder<CourseEntity> builder)
        {
            builder.ToTable("Courses");
            builder.Property(c => c.InstructorFullName).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.CourseTitle).HasMaxLength(50).IsRequired();
            builder.Property(c => c.PublishDate).IsRequired();
            builder.Property(c => c.Biography).HasMaxLength(1000).IsRequired(false);
            builder.Property(c => c.Description).HasMaxLength(1000).IsRequired(false);
            builder.Property(c => c.TotalDuration).HasMaxLength(50).IsRequired(false);
            builder.Property(c => c.TotalSections).IsRequired();
            builder.Property(c => c.Status).IsRequired();


        }

    }

}

