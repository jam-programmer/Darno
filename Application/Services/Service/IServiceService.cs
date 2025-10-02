using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;

namespace Application.Services.Service;

public interface IServiceService
{
    Task InsertServiceAsync(ServiceDto Service);
    Task UpdateServiceAsync(ServiceDto Service);
    Task<ServiceDto> GetServiceByIdAsync(Guid ServiceId);
    Task DeleteServiceAsync(Guid ServiceId);
    Task<PaginatedList<ServiceViewModel>> GetServicesAsync(Pagination pagination);
    Task<IReadOnlyDictionary<Guid, string>> GetServicesWithOutPaginationAsync();
    Task<IReadOnlyList<ServiceViewModel>> GetServicesForHomePageAsync();
}
