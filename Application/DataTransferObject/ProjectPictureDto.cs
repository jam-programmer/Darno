using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record ProjectPictureDto
{
    public Guid Id { get; set; }
    public Guid ProjectId { get; set; }
    [Required(ErrorMessage ="آپلود تصویر الزامی است")]
    public IFormFile? ImageFile { get; set; }
}
