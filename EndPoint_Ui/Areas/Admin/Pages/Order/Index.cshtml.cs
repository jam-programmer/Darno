using Application.Common;
using Application.DataTransferObject;
using Application.Services.Order;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;


namespace EndPoint_Ui.Areas.Admin.Pages.Order;

public class IndexModel (IOrderService orderService) : PageModel
{
    readonly IOrderService _orderService = orderService;

    public PaginatedList<OrderViewModel> PageModel { get; set; }

    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _orderService.GetOrdersAsync(pagination);
        ViewData["Search"] = pagination.keyword;
    }






}
