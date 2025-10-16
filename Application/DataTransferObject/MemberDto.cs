using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record MemberDto : IValidatableObject
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
    public string? FullName { set; get; }
    [Required(ErrorMessage = "عنوان شغلی الزامی است")]
    public string? JobTitle { set; get; }
    public string? ImagePath { set; get; }
    public IFormFile? ImageFile { set; get; }
    public string? GitHub { set; get; }
    public string? Linkedin { set; get; }
    public string? Email { set; get; }
    public string? Instagram { set; get; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var validations = new List<ValidationResult>();
        if (string.IsNullOrWhiteSpace(ImagePath) && ImageFile == null)
        {
            validations.Add(new 
                ValidationResult("آپلود تصویر الزامی است", new[] {nameof(ImageFile)}));
        }
        return validations;

    }
}
