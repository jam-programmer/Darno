using Application.DataTransferObject;
using Application.Services.Order;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Pages;
[IgnoreAntiforgeryToken]
public class OrderModel (IOrderService orderService): PageModel
{
    readonly IOrderService _orderService=orderService;
    public void OnGet()
    {
    }
    public async Task<IActionResult> OnPostSendOrderAsync([FromForm] OrderDto Order)
    {
        try
        {
            await _orderService.InsertOrderAsync(Order);

            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }
   
}
