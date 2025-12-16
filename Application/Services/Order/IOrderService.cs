using Application.Common;
using Application.DataTransferObject;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.ViewModels;

namespace Application.Services.Order;

public interface IOrderService
{
    Task InsertOrderAsync(OrderDto order);

    Task<PaginatedList<OrderViewModel>> GetOrdersAsync(Pagination pagination);

   
}

