using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore.Storage;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Mapping
{
internal sealed class CategoryArticleMap :
        IEntityTypeConfiguration<CategoryArticleEntity>
    {

        public void Configure(EntityTypeBuilder<CategoryArticleEntity> builder)
        {
            builder.ToTable("CategoryArticle");
            builder.HasQueryFilter(f => f.IsDelete 
            == false);
            builder.HasMany(m => m.Articles)
                .WithOne(o => o.CategoryArticle).
                HasForeignKey(f => f.CategoryId);
            builder.HasOne(o => o.Parent)
                .WithMany(m => m.Childs)
                .HasForeignKey(f => f.ParentId).
                OnDelete(DeleteBehavior.ClientSetNull);
        }


    }
}
