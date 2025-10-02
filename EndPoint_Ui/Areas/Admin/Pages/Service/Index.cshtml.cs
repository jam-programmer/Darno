using Application.Common;
using Application.Services.Service;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Service;
[IgnoreAntiforgeryToken]

public class IndexModel (IServiceService service): PageModel
{
    readonly IServiceService _service = service;
    public PaginatedList<ServiceViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _service.GetServicesAsync(pagination);
        ViewData["Search"] = pagination.keyword;
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _service.DeleteServiceAsync(Input.Id);
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
