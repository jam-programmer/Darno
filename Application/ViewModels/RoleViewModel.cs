using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public sealed record RoleViewModel
{
    public Guid Id { get; set; }
    public string? Name { get; set; }
    public string? PersianName { get; set; }
}
