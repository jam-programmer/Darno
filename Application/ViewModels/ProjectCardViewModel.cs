using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public sealed record ProjectCardViewModel
{
    public Guid Id { get; set; }
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? Owner { get; set; }
}
