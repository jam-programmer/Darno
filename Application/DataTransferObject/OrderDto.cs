using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject;

public sealed record OrderDto
{

    [Required(ErrorMessage ="نام و نام خانوادگی الزامی است")]
    public string? FullName { set; get; }
    [Required(ErrorMessage = "شماره تماس الزامی است")]
    public string? PhoneNumber { set; get; }
    public string? Email { set; get; }
    [Required(ErrorMessage = "توضیحات پروژه الزامی است")]
    public string? Description { set; get; }
    [Required(ErrorMessage = "عنوان پروژه الزامی است")]
    public string? Title { set; get; }
    [Required(ErrorMessage = "نوع سایت را مشخص کنید")]
    public ProjectType ProjectType { set; get; }
    [Required(ErrorMessage = "تکنولوژی لازم جهت پیاده سازی را انتخاب نمائید")]
    public PlatformType PlatformType { set; get; }
    public NeedType IsOnlinePaymentGateway { set; get; }
    public NeedType IsMultilingual { set; get; }
    public NeedType IsSms { set; get; }
    public NeedType IsOnlineChat { set; get; }
    public NeedType IsBlog { set; get; }
    public NeedType IsReport { set; get; }
    public NeedType Price { set; get; }
    public NeedType IsPwa { set; get; }
    public NeedType HaveHost { set; get; }
    public NeedType HaveDomain { set; get; }
    public string? Url { set; get; }
    public IFormFile? File { set; get; }
}
