using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ProjectEntity:BaseEntity,IDelete
{
    public string? ImagePath { get; set; }
    public string? LogoPath { get; set; }
    public string? CertificatePath { get; set; }
    public string? Title { get; set; }
    public string? Description { get; set; }
    public string? Url {  get; set; }
    public string? Aparat {  get; set; }
    public string? Owner {  get; set; }
    public string? Opinion {  get; set; }
    public bool IsDelete { get; set; } = false;

    public Guid ServiceId { get; set; }
    public ServiceEntity? Service { get; set; }  
    public ICollection<ProjectPictureEntity>? ProjectPictures { get; set; }
}
