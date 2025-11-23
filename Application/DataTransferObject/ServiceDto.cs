using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record ServiceDto : IValidatableObject
{
    public Guid Id { get; set; }
    public IFormFile? ImageFile { set; get; }
    public string? ImagePath { get; set; }



    [Required(ErrorMessage = "نام یکتا الزامی است")]
    public string? UniqueName { get; set; }

    [Required(ErrorMessage = "عنوان الزامی است")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "توضیحات الزامی است")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "توضیح کوتاه الزامی است")]
    public string? ShortDescription { get; set; }
    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (string.IsNullOrEmpty(ImagePath) && ImageFile == null)
        {
            results.Add(new ValidationResult("تصویر را آپلود نمائید", new[] { nameof(ImageFile) }));
        }
        return results;
    }
}
