using Application.DataTransferObject;
using Application.Services.Service;
using EndPoint_Ui.Areas.Admin.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Service;

public class CreateModel : UploadModel
{
    readonly IServiceService _service;
    [BindProperty]
    public ServiceDto ServiceDto { get; set; }  
    public CreateModel(IServiceService service) :base()
    {
        _service    = service;
    }
    public void OnGet()
    {
    }
   
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {

            await _service.InsertServiceAsync(ServiceDto);

            return RedirectToPage("/Service/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }


}
