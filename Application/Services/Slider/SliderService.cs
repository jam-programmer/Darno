using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Common;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Slider;

public class SliderService : ISliderService
{

    readonly IContext _context;
    public SliderService(IContext context)
    {
        _context = context;
    }

    public async Task<IReadOnlyList<SliderViewModel>> GetActiveSlidersAsync()
    {

        return await _context.GetQueryable<SliderEntity>()
            .Where(S => S.StartShow <= DateTime.Now &&
            S.EndShow >= DateTime.Now)
            .Select(S => new SliderViewModel
            {
                ImagePath = S.ImagePath,
                Link = S.Link,

            })
            .ToListAsync();


    }



    public async Task DeleteSliderAsync(Guid SliderId)
    {
        SliderEntity? entity =
            await _context.Entity<SliderEntity>()
            .FirstOrDefaultAsync(f => f.Id == SliderId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDelete = true;
        _context.Entity<SliderEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<SliderDto> GetSliderByIdAsync(Guid SliderId)
    {
        SliderEntity? entity =
        await _context.Entity<SliderEntity>()
        .FirstOrDefaultAsync(f => f.Id == SliderId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }

        TypeAdapterConfig config = new();
        config.NewConfig<SliderEntity, SliderDto>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Title, s => s.Title)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.Link, s => s.Link)
            .Map(d => d.StartShow, s => s.StartShow.PersianDateWithOutTime())
            .Map(d => d.EndShow, s => s.EndShow.PersianDateWithOutTime())
            .Compile();


        return entity.Adapt<SliderDto>(config);
    }

    public async Task<PaginatedList<SliderViewModel>> GetSlidersAsync(Pagination pagination)
    {
        TypeAdapterConfig config = new();
        config.NewConfig<SliderEntity, SliderViewModel>()
            .Map(d => d.Id, s => s.Id)
            .Map(d => d.Title, s => s.Title)
            .Map(d => d.ImagePath, s => s.ImagePath)
            .Map(d => d.Link, s => s.Link)
            .Map(d => d.StartShow, s => s.StartShow.PersianDateWithOutTime())
            .Map(d => d.EndShow, s => s.EndShow.PersianDateWithOutTime())
            .Compile();
        IQueryable<SliderEntity> query = _context.GetQueryable<SliderEntity>();

        PaginatedList<SliderViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<SliderEntity, SliderViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total, config);
        return model;
    }



    public async Task InsertSliderAsync(SliderDto Slider)
    {
        SliderEntity entity = new();

        entity.StartShow = Slider.StartShow.ConvertToGregorian();
        entity.EndShow = Slider.EndShow.ConvertToGregorian();
        entity.Title = Slider.Title;
        entity.Link = Slider.Link;
        entity.ImagePath = Slider.ImageFile.UploadImage("Slider");

        await _context.Entity<SliderEntity>().AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateSliderAsync(SliderDto Slider)
    {
        SliderEntity? entity =
         await _context.Entity<SliderEntity>()
         .FirstOrDefaultAsync(f => f.Id == Slider.Id);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.StartShow = Slider.StartShow.ConvertToGregorian();
        entity.EndShow = Slider.EndShow.ConvertToGregorian();
        entity.Title = Slider.Title;
        entity.Link = Slider.Link;

        if(Slider.ImageFile != null)
        {
            entity.ImagePath = Slider.ImageFile.UploadImage("Slider");
            Slider.ImagePath.RemoveImage("Slider");
        }

        _context.Entity<SliderEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
