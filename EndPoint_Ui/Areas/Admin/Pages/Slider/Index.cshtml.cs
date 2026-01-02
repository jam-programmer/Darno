using Application.Common;
using Application.Services.Slider;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Slider;
[Authorize]
public class IndexModel (ISliderService sliderService): PageModel
{
    readonly ISliderService _sliderService= sliderService;
    public PaginatedList<SliderViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel=await _sliderService.GetSlidersAsync(pagination);
    }
    public async Task<IActionResult> OnPostDeleteAsync
        ([FromBody] InputModel Input)
    {
        try
        {
            await _sliderService.DeleteSliderAsync(Input.Id);
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
