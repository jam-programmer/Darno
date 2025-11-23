using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record ProjectDto:IValidatableObject
{
    public Guid Id { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? ImagePath { get; set; }
    public IFormFile? LogoFile { get; set; }
    public string? LogoPath { get; set; }
    public IFormFile? CertificateFile { get; set; }
    public string? CertificatePath { get; set; }
    [Required(ErrorMessage ="عنوان را وارد کنید")]
    public string? Title { get; set; }
    [Required(ErrorMessage = "توضیحات را وارد کنید")]
    public string? Description { get; set; }
    [Required(ErrorMessage = "لینک را وارد کنید")]
    public string? Url { get; set; }
    public string? Aparat { get; set; }
    public string? Owner { get; set; }
    public string? Opinion { get; set; }
    [Required(ErrorMessage = "خدمت را انتخاب کنید")]
    public Guid ServiceId { get; set; }

    public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
    {
        var results = new List<ValidationResult>();
        if (string.IsNullOrEmpty(ImagePath) && ImageFile == null)
        {
            results.Add(new ValidationResult("تصویر را آپلود نمائید", new[] { nameof(ImageFile) }));
        }
        if (string.IsNullOrEmpty(LogoPath) && LogoFile == null)
        {
            results.Add(new ValidationResult("لوگو را آپلود نمائید", new[] { nameof(LogoFile) }));
        }
        return results;
    }
}
