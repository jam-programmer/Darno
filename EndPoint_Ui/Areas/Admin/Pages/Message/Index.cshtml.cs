using Application.Common;
using Application.Services.Message;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Message;
[Authorize]

public class IndexModel (IMessageService messageService) : PageModel
{
    private readonly IMessageService _messageService = messageService;
    public PaginatedList<MessageViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _messageService.GetMessagesAsync(pagination);
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _messageService.DeleteMessageAsync(Input.Id);
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
