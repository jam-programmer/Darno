using Application.DataTransferObject;
using Application.Services.Service;
using EndPoint_Ui.Areas.Admin.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Service;

public class EditModel : UploadModel
{
    readonly IServiceService _service;
    public EditModel(IServiceService service) :base()
    {
        _service = service;
    }
    [BindProperty]
    public ServiceDto ServiceDto { get; set; }
    public async Task OnGet(Guid Id)
    {
        ServiceDto=await _service.GetServiceByIdAsync(Id);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {

            await _service.UpdateServiceAsync(ServiceDto);

            return RedirectToPage("/Service/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }

}
