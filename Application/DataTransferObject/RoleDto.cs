using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject;

public sealed record RoleDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "نام انگلیسی الزامی است")]
    public string? Name { get; set; }
    [Required(ErrorMessage = "نام فارسی الزامی است")]
    public string? PersianName { get; set; }
}
