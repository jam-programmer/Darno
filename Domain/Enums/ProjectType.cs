using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums;

public enum ProjectType
{
    [DisplayAttribute(Name ="سایت شرکتی")]
    CorporateSite,
    [Display(Name = "سایت فروشگاهی")]
    ShoppingSite,
    [Display(Name = "سایت پزشکی")]
    MedicalSite,
    [Display(Name = "سایت خدماتی")]
    ServiceSite,
    [Display(Name = "سایت املاک")]
    RealEstateSite,
    [Display(Name = "سایت استارت آپ")]
    StartupSite,
    [Display(Name = "سایت کافه و رستوران")]
    CafeRestaurantSite,
    [Display(Name = "سایت سالن زیبایی")]
    BeautySalonSite,
    [Display(Name = "سایت شخصی")]
    PersonalSite,
    [Display(Name = "سایت آموزشی")]
    EducationalSite,
    [Display(Name = "سایت خبری")]
    NewsSite,
}
