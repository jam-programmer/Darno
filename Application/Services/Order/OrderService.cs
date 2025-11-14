using Application.Common.Extension;
using Application.Contract;
using Application.DataTransferObject;
using Domain.Entities;
using Mapster;

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
}
