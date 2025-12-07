using System;
using System.Collections.Generic;

namespace Domain.Entities
{
    public class CategoryArticleEntity : BaseEntity, IDelete
    {    
        public string Name { get; set; }
        public string Slug { get; set; }               
        public string? Description { get; set; }       

        public bool IsDelete { get; set; } = false;

        public Guid ParentId { get; set; }
        public CategoryArticleEntity Parent { get; set; }
        
        public ICollection<CategoryArticleEntity>
            Childs
        { set; get; }
        public ICollection<ArticleEntity>? Articles { get; set; }
    }
}

