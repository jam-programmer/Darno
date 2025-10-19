namespace Domain.Entities;

public class SettingEntity : BaseEntity, IDelete
{
    public string Address { get; set; } = string.Empty;
    public string PhoneNumber { get; set; } = string.Empty;
    public string Email { get; set; } = string.Empty;

    public string InstagramUrl { get; set; } = string.Empty;
    public string LinkedInUrl { get; set; } = string.Empty;
    public string TelegramUrl { get; set; } = string.Empty;

    public string? AboutUs { get; set; }

    public bool IsDelete { get; set; } = false;
}
