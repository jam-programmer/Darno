using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public  record MemberViewModel
{
    public Guid Id { get; set; }
    public string? FullName { set; get; }
    public string? JobTitle { set; get; }
    public string? ImagePath { set; get; }
}
public record MemberForMainPageViewModel: MemberViewModel
{
    public string? GitHub { set; get; }
    public string? Linkedin { set; get; }
    public string? Email { set; get; }
    public string? Instagram { set; get; }
}