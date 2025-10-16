using Application.DataTransferObject;
using Application.Services.ProjectPicture;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.ProjectPicture;


public class CreateModel (IProjectPictureService projectPictureService): PageModel
{

    readonly IProjectPictureService _projectPictureService=projectPictureService;

    [BindProperty]
    public ProjectPictureDto ProjectPicture { get; set; }
    public void OnGet(Guid ProjectId)
    {
        ViewData["ProjectId"] =ProjectId;
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
           
            return Page();
        }
        try
        {

            await _projectPictureService.InsertProjectPictureAsync(ProjectPicture);

            return RedirectToPage("/ProjectPicture/Index",new {ProjectId= ProjectPicture .ProjectId});
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
