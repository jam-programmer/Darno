using Application.Services.Slider;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class SliderComponent(ISliderService sliderService):ViewComponent
{
    readonly ISliderService _sliderService=sliderService;

    public async Task<IViewComponentResult> InvokeAsync()
    {
        var model=await _sliderService.GetActiveSlidersAsync();
        return View("/Pages/Shared/ViewComponent/SliderComponent.cshtml", model);

    }
}
