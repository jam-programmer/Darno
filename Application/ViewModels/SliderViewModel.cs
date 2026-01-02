using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public sealed record SliderViewModel
{
    public Guid Id { get; set; }
    public string ImagePath { get; set; }
    public string StartShow { get; set; }
    public string EndShow { get; set; }
    public string Link { get; set; }
    public string Title { get; set; }
}
