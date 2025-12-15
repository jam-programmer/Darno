using System;

namespace Domain.Entities
{
    public class ArticleEntity : BaseEntity, IDelete
    {
        public string? Title { get; set; }

        public string? Description { get; set; }

        public DateTime PublishDate { get; set; }

        public bool IsPublished { get; set; } = false;

        
        public string? ImagePath { get; set; }

        public bool IsDelete { get; set; } = false;


        public Guid CategoryId { get; set; }
        public CategoryArticleEntity? CategoryArticle { get; set; }

    
    }
}

