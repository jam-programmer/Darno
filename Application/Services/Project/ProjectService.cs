using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Project;

public class ProjectService : IProjectService
{
    readonly IContext _context;
    public ProjectService(IContext context)
    {
        _context = context;
    }
    public async Task DeleteProjectAsync(Guid ProjectId)
    {
        ProjectEntity? entity =
            await _context.Entity<ProjectEntity>()
            .FirstOrDefaultAsync(f => f.Id == ProjectId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDelete = true;
        _context.Entity<ProjectEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<ProjectDto> GetProjectByIdAsync(Guid ProjectId)
    {
        ProjectEntity? entity =
        await _context.Entity<ProjectEntity>()
        .FirstOrDefaultAsync(f => f.Id == ProjectId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return entity.Adapt<ProjectDto>();
    }

    public async Task<PaginatedList<ProjectViewModel>> GetProjectsAsync(Pagination pagination)
    {
        IQueryable<ProjectEntity> query = _context.GetQueryable<ProjectEntity>();

        PaginatedList<ProjectViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<ProjectEntity, ProjectViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task<IReadOnlyList<ProjectCardViewModel>> GetProjectsWithServiceIdAsync(Guid ServiceId)
    {
        return await _context.Entity<ProjectEntity>()
            .Where(w=>w.ServiceId == ServiceId)
            .Select(s=>new ProjectCardViewModel()
            {
                Id = s.Id,
                ImagePath = s.ImagePath,
                Owner = s.Owner,
                Title=s.Title,
            }).ToListAsync();
    }

    public async Task InsertProjectAsync(ProjectDto project)
    {
        ProjectEntity entity = project.Adapt<ProjectEntity>(); 

        entity.ImagePath = project.ImageFile!.UploadImage("Project");
        entity.LogoPath = project.LogoFile!.UploadImage("Project");
        entity.CertificatePath = project.CertificateFile!.UploadImage("Project");

        await _context.Entity<ProjectEntity>().AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateProjectAsync(ProjectDto project)
    {
        ProjectEntity? entity =
 await _context.Entity<ProjectEntity>()
 .FirstOrDefaultAsync(f => f.Id == project.Id);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        project.Adapt(entity);
        if (project.ImageFile != null)
        {
            entity.ImagePath = project.ImageFile.UploadImage("Project");
            project.ImagePath!.RemoveImage("Project");

        }

        if (project.LogoFile != null)
        {
            entity.LogoPath = project.LogoFile.UploadImage("Project");
            project.LogoPath!.RemoveImage("Project");

        }

        if (project.CertificateFile != null)
        {
            entity.CertificatePath = project.CertificateFile.UploadImage("Project");
            project.CertificatePath!.RemoveImage("Project");

        }
        _context.Entity<ProjectEntity>().Update(entity); 
        await _context.SaveChangesAsync();
    }
}
