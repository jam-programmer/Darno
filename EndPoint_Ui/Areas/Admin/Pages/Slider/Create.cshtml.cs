using Application.DataTransferObject;
using Application.Services.Slider;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Slider;
[Authorize]

public class CreateModel(ISliderService sliderService) : PageModel
{
    readonly ISliderService _sliderService = sliderService;

    [BindProperty]
    public SliderDto Slider { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {
                await _sliderService.InsertSliderAsync(Slider);
            return RedirectToPage("/Slider/Index");

        }
        catch (Exception ex) 
        {
            ViewData["Alert"]=ex.Message;
            return Page();
        }


    }
}
