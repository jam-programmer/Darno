using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Application.Common.CustomException;
using Application.Common.Messages;
using Application.Common.Extension;
namespace Application.Services.ProjectPicture;

public class ProjectPictureService : IProjectPictureService
{
    readonly IContext _context;
    public ProjectPictureService(IContext context)
    {
        _context = context;
    }
    public async Task DeleteProjectPictureAsync(Guid ProjectPictureId)
    {
        ProjectPictureEntity? projectPicture =
            await _context.Entity<ProjectPictureEntity>()
            .SingleOrDefaultAsync(g=>g.Id== ProjectPictureId);
        if (projectPicture == null) 
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        projectPicture.IsDelete = true;
         _context.Entity<ProjectPictureEntity>().Update(projectPicture);
        await _context.SaveChangesAsync();  
    }

    public async Task<IReadOnlyList<ProjectPictureViewModel>> GetProjectPicturesAsync(Guid ProjectId)
    {
       return await _context.Entity<ProjectPictureEntity>()
            .Where(w=>w.ProjectId== ProjectId).
            Select(s=>new ProjectPictureViewModel()
            {
                Id = s.Id,
                ImagePath=s.ImagePath
            }).ToListAsync();   
    }

    public async Task InsertProjectPictureAsync(ProjectPictureDto ProjectPicture)
    {
        ProjectPictureEntity projectPicture = new();
        projectPicture.ProjectId= ProjectPicture.ProjectId;
        projectPicture.ImagePath = ProjectPicture.ImageFile!.UploadImage("Project");
      await  _context.Entity<ProjectPictureEntity>().AddAsync(projectPicture);
        await _context.SaveChangesAsync();
    }
}
