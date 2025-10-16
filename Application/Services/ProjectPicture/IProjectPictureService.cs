using Application.DataTransferObject;
using Application.ViewModels;

namespace Application.Services.ProjectPicture;

public interface IProjectPictureService
{
    Task<IReadOnlyList<ProjectPictureViewModel>> GetProjectPicturesAsync(Guid ProjectId);
    Task InsertProjectPictureAsync(ProjectPictureDto ProjectPicture);
    Task DeleteProjectPictureAsync(Guid ProjectPictureId);
}
