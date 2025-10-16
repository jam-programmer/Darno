using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Project;

public interface IProjectService
{
    Task InsertProjectAsync(ProjectDto project);
    Task UpdateProjectAsync(ProjectDto project);
    Task<ProjectDto> GetProjectByIdAsync(Guid ProjectId);
    Task DeleteProjectAsync(Guid ProjectId);
    Task<PaginatedList<ProjectViewModel>> GetProjectsAsync(Pagination pagination);
    Task<IReadOnlyList<ProjectCardViewModel>>
        GetProjectsWithServiceIdAsync(Guid ServiceId);
}
