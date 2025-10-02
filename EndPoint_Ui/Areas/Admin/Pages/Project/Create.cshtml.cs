using Application.DataTransferObject;
using Application.Services.Project;
using Application.Services.Service;
using EndPoint_Ui.Areas.Admin.Pages.Shared;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Project;

public class CreateModel : UploadModel
{
    readonly IServiceService _service;
    readonly IProjectService _projectService;
    public CreateModel(IProjectService projectService, IServiceService service)
    {
        _projectService = projectService;
        _service = service;
    }
    [BindProperty]
    public ProjectDto Project { get; set; }
    public async Task OnGet()
    {
        await FetchServiceAsync();
    }
    
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            await FetchServiceAsync();
            return Page();
        }
        try
        {

            await _projectService.InsertProjectAsync(Project);

            return RedirectToPage("/Project/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
    async Task FetchServiceAsync()
    {
        ViewData["Services"] = await _service.GetServicesWithOutPaginationAsync();

    }
}
