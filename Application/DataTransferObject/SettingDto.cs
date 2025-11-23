using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject;

public sealed record SettingDto
{
    public string? Address { get; set; } 
    public string? PhoneNumber { get; set; }
    public string? Email { get; set; } 
    public string? InstagramUrl { get; set; }
    public string? LinkedInUrl { get; set; } 
    public string? TelegramUrl { get; set; } 

    public string? AboutUs { get; set; }
    public string? Image { get; set; }
    public IFormFile? ImageFile { get; set; }
    public string? Title { get; set; }

}
