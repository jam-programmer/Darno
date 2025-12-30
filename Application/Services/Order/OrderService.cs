using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Domain.Enums;
using Mapster;
using Microsoft.AspNetCore.Http;
using Microsoft.EntityFrameworkCore;


namespace Application.Services.Order;

public class OrderService : IOrderService
{
    readonly IContext _context;
    public OrderService(IContext context)
    {
        _context = context;
    }
    public async Task InsertOrderAsync(OrderDto order)
    {
        OrderEntity entity = order.Adapt<OrderEntity>();
        if (order.File is not null)
        {
            entity.File = await order.File.UploadFileAsync("Order");
        }
        await _context.Entity<OrderEntity>().AddAsync(entity);
        await _context.SaveChangesAsync();
    }

   public async Task<PaginatedList<OrderViewModel>> GetOrdersAsync(Pagination pagination)

    {
        IQueryable<OrderEntity> query = _context.GetQueryable<OrderEntity>();
        PaginatedList<OrderViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(pagination!.keyword));
        }

        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();
        var list = await query

        .Select(o => new OrderViewModel
        {    Id=o.Id,
            FullName = o.FullName,
            Title = o.Title,
            ProjectType = o.ProjectType
        })
        .ToListAsync();

        return new PaginatedList<OrderViewModel>
        {
            List = list,
            TotalItem = total,
            TotalPage = count,
            CurrentPage = pagination.currentPage
        };
    }

    public async Task<OrderDetailsViewModel?> GetOrderDetailsAsync(Guid orderId)
    {
        IQueryable<OrderEntity> query = _context.GetQueryable<OrderEntity>();
      

        var orderDetailsObject = await query
            .Where(o => o.Id == orderId).Select(
            o => new OrderDetailsViewModel
            {
                FullName = o.FullName,
                Title = o.Title,
                ProjectType = o.ProjectType,
                PhoneNumber = o.PhoneNumber,
                Email = o.Email,
                Description = o.Description,

                PlatformType = o.PlatformType,
                IsOnlinePaymentGateway = o.IsOnlinePaymentGateway,
                IsMultilingual = o.IsMultilingual,
                IsSms = o.IsSms,
                IsOnlineChat = o.IsOnlineChat,
                IsBlog = o.IsBlog,
                IsReport = o.IsReport,
                Price = o.Price,
                IsPwa = o.IsPwa,
                HaveHost = o.HaveHost,
                HaveDomain = o.HaveDomain,
                Url = o.Url,
                File = o.File,



            }


            ).FirstOrDefaultAsync();

        return orderDetailsObject;

        


    }






}
