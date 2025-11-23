namespace Application.ViewModels;

public sealed record ProjectViewModel
{
    public Guid Id { get; set; }
    public string? LogoPath { get; set; }
    public string? Title { get; set; }
    public string? Owner { get; set; }
}
