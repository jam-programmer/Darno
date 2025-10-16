using Application.Services.Service;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Pages.Service;

public class DetailModel : PageModel
{
    readonly IServiceService _service;
    public DetailModel(IServiceService service)
    {
        _service = service;
    }
    public ServiceDetailViewModel ServiceDetail {  get; set; }
    public async Task OnGet(string UniqueName)
    {
        ServiceDetail=await _service.GetServiceDetailByUniqueNameAsync(UniqueName);
    }
}
