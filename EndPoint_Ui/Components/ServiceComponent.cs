using Application.Services.Service;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class ServiceComponent(IServiceService service) : ViewComponent
{
    readonly IServiceService _service = service;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<ServiceViewModel> model =
            await _service.GetServicesForHomePageAsync();
        return View("/Pages/Shared/ViewComponent/ServiceComponent.cshtml", model);
    }
}
