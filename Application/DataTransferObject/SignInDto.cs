using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record SignInDto
{
    [Required(ErrorMessage ="نام کاربری الزامی است")]
    public string? UserName {  get; set; }
    [Required(ErrorMessage = "گذرواژه الزامی است")]

    public string? Password {  get; set; }
    public bool RememberMe {  get; set; }
}
