using Domain.Enums;

namespace Domain.Entities;

public class OrderEntity : BaseEntity, IDelete
{
    public string? FullName { set; get; }
    public string? PhoneNumber { set; get; }
    public string? Email { set; get; }
    public string? Title { set; get; }
    public ProjectType ProjectType { set; get; }
    public PlatformType PlatformType { set; get; }
    public NeedType IsOnlinePaymentGateway { set; get; }
    public NeedType IsMultilingual { set; get; }
    public NeedType IsSms { set; get; }
    public NeedType IsOnlineChat { set; get; }
    public NeedType IsBlog { set; get; }
    public NeedType IsReport { set; get; }
    public NeedType IsPwa { set; get; }
    public NeedType HaveHost { set; get; }
    public NeedType HaveDomain { set; get; }
    public long Price { set; get; }
    public string? Url { set; get; }
    public string? Description { set; get; }
    public string? File { set; get; }
    public bool IsDelete { get; set; } = false;
}
