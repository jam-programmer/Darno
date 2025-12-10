using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject;

public sealed record ArticleDto 
{public Guid Id { get; set; }

    public string Title { get; set; }
    public string Description { get; set; }


    public DateTime PublishDate { get; set; }
    public bool IsPublished { get; set; }

    public Guid CategoryId { get; set; }

    public string? ImagePath { get; set; }
    public IFormFile? ImageFile { get; set; }

}



