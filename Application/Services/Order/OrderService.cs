using Application.Common;
using Application.Common.Extension;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
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
        {
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






}
