using Application.DataTransferObject;
using Application.Services.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Slider;
[Authorize]
public class EditModel (ISliderService sliderService): PageModel
{
    readonly ISliderService _sliderService= sliderService;

    [BindProperty]
    public SliderDto Slider { get; set; }
    public async Task OnGet(Guid Id )
    {
        Slider=await _sliderService.GetSliderByIdAsync(Id);
    }
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {
            await _sliderService.UpdateSliderAsync(Slider);
            return RedirectToPage("/Slider/Index");

        }
        catch (Exception ex)
        {
            ViewData["Alert"] = ex.Message;
            return Page();
        }


    }


}
