using System.ComponentModel.DataAnnotations;

namespace Domain.Enums;

public enum PlatformType
{
    [Display(Name = "وردپرس")]
    WordPress,
    [Display(Name = "اختصاصی")]
    Custom
}
