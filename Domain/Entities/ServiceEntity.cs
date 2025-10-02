namespace Domain.Entities;

public class ServiceEntity : BaseEntity, IDelete
{
    public string? ImagePath { get; set; }
    public string? Title { get; set; }
    public string? ShortDescription { get; set; }
    public string? Description { get; set; }
    public bool IsDelete { get; set; } = false;

    public ICollection<ProjectEntity>? Projects { get; set; }
}
