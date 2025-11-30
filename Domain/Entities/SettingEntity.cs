namespace Domain.Entities;

public class SettingEntity : BaseEntity
{
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string InstagramUrl { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
    public string TelegramUrl { get; set; } = string.Empty;

    public string? AboutUs { get; set; }
<<<<<<< HEAD
=======
    public string? Image { get; set; }
    public string? Title { get; set; }
>>>>>>> b902ca26a3f54e6157eb71cd1a1a6b04250bed34

 
}
