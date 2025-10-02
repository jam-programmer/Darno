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

namespace Application.Services.Service;

public class ServiceService : IServiceService
{
    readonly IContext _context;
    public ServiceService(IContext context)
    {
        _context = context;
    }

    public async Task DeleteServiceAsync(Guid ServiceId)
    {
        ServiceEntity? service =
            await _context.Entity<ServiceEntity>()
            .FirstOrDefaultAsync(f => f.Id == ServiceId);

        if (service == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        service.IsDelete = true;
        _context.Entity<ServiceEntity>().Update(service);
        await _context.SaveChangesAsync();
    }

    public async Task<ServiceDto> GetServiceByIdAsync(Guid ServiceId)
    {
        ServiceEntity? service =
          await _context.Entity<ServiceEntity>()
          .FirstOrDefaultAsync(f => f.Id == ServiceId);

        if (service == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return service.Adapt<ServiceDto>();
    }

    public async Task<PaginatedList<ServiceViewModel>> GetServicesAsync(Pagination pagination)
    {
        IQueryable<ServiceEntity> query = _context.GetQueryable<ServiceEntity>();

        PaginatedList<ServiceViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<ServiceEntity, ServiceViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task<IReadOnlyList<ServiceViewModel>> GetServicesForHomePageAsync()
    {
        IQueryable<ServiceEntity> query = _context.GetQueryable<ServiceEntity>();
        return await query.Select(s => new ServiceViewModel()
        {

            Id = s.Id,
            Title = s.Title,
            ImagePath = s.ImagePath,
            ShortDescription = s.ShortDescription
        }).ToListAsync();
    }

    public async Task<IReadOnlyDictionary<Guid, string>> GetServicesWithOutPaginationAsync()
    {
        IQueryable<ServiceEntity> query = _context.GetQueryable<ServiceEntity>();
        IReadOnlyDictionary<Guid, string>? list =
            await query.ToDictionaryAsync(s => s.Id!, s => s.Title!);
        return list;
    }

    public async Task InsertServiceAsync(ServiceDto Service)
    {
        ServiceEntity serviceEntity = Service.Adapt<ServiceEntity>();
        serviceEntity.ImagePath = Service.ImageFile!.UploadImage("Service");
        await _context.Entity<ServiceEntity>().AddAsync(serviceEntity);
        await _context.SaveChangesAsync();
    }

    public async Task UpdateServiceAsync(ServiceDto Service)
    {
        ServiceEntity? serviceEntity =
         await _context.Entity<ServiceEntity>()
         .FirstOrDefaultAsync(f => f.Id == Service.Id);

        if (serviceEntity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        Service.Adapt(serviceEntity);
        if (Service.ImageFile != null)
        {
            serviceEntity.ImagePath = Service.ImageFile.UploadImage("Service");
            Service.ImagePath!.RemoveImage("Service");
        }
        _context.Entity<ServiceEntity>().Update(serviceEntity);
        await _context.SaveChangesAsync();
    }
}
