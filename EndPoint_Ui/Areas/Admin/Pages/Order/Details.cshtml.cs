using Application.Services.Order;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Order
{
    public class Details : PageModel
    {
        readonly IOrderService _orderService;

        public Details(IOrderService orderService)
        {
            _orderService = orderService;
        }

      public OrderDetailsViewModel Order = new OrderDetailsViewModel();
      public async Task OnGet(Guid id)
        {
            if (id == Guid.Empty)
            {
                return;
            }
            Order = await _orderService.GetOrderDetailsAsync(id);

           


        }


    }
}
