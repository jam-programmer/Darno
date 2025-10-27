namespace Application.ViewModels;

public sealed record MessageViewModel
{
    public Guid Id { get; set; }
    public string? FullName { get; set; }
    public string? PhoneNumber { get; set; }
    public string? CompanyName { get; set; }
    public string? Position { get; set; }
    public string? Message { get; set; }
}
