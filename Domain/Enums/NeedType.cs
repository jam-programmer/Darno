using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

public enum NeedType
{
    [Display(Name = "نیاز دارد")]
    Yes=1,
    [Display(Name = "نیاز ندارد")]
    No=2,
    [Display(Name = "مشخص نیست")]
    Unknown=0
}
