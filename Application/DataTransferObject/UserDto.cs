using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject;

public sealed record UserDto
{
    public Guid Id { get; set; }
    [Required(ErrorMessage = "نام کاربری(انگلیسی) الزامی است")]
    public string? UserName { get; set; }
    [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
    public string? FullName { get; set; }
    [Required(ErrorMessage = "پست الکترونیک الزامی است")]
    public string? Email { get; set; }
    [Required(ErrorMessage = "شماره موبایل الزامی است")]
    public string? PhoneNumber { get; set; }


    [Required(ErrorMessage = "انتخاب یک یا چند نقش الزامی است")]
    public IReadOnlyList<string>? Roles { get; set; }

  
}
