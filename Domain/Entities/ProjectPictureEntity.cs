using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities;

public class ProjectPictureEntity:BaseEntity ,IDelete
{
    public string? ImagePath { get; set; }
    public bool IsDelete { get; set; } = false;
    public Guid ProjectId { get; set; }
    public ProjectEntity? Project { get; set; }
}
