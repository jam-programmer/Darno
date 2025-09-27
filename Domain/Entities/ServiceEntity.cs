namespace Domain.Entities;

public class ServiceEntity : BaseEntity, IDelete
{
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public bool IsDelete { get; set; } = false;

    public ICollection<ProjectEntity>? Projects { get; set; }
}
