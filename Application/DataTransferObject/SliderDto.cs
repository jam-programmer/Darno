using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record SliderDto : IValidatableObject
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "عنوان الزامی است")]
        public string? Title { get; set; }
        public string? ImagePath { get; set; }

        public IFormFile? ImageFile { get; set; }
        [Required(ErrorMessage = "تاریخ شروع الزامی است")]
        public string? StartShow { get; set; }
        [Required(ErrorMessage = "تاریخ پایان الزامی است")]
        public string? EndShow { get; set; }
        public string? Link { get; set; }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            List<ValidationResult> validations = [];
            if (string.IsNullOrEmpty(ImagePath) && (ImageFile == null || ImageFile.Length == 0))
            {
                validations.Add(new ValidationResult("آپلود تصویر الزامی است", [nameof(ImageFile)]));
               
            }
            return validations;
        }
    }
}

