namespace Domain.Entities;

public class MemberEntity : BaseEntity, IDelete
{
    public string? FullName { set; get; }
    public string? JobTitle { set; get; }
    public string? ImagePath { set; get; }
    public string? GitHub { set; get; }
    public string? Linkdin { set; get; }
    public string? Email { set; get; }
    public string? Instagram { set; get; }

    public bool IsDelete { get; set; } = false;

}
