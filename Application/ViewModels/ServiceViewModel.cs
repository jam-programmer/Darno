using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.ViewModels;

public sealed record ServiceViewModel
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }

}
