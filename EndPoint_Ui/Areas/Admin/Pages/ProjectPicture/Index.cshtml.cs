using Application.Common;
using Application.Services.Project;
using Application.Services.ProjectPicture;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.ProjectPicture;
[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    readonly IProjectPictureService _projectPictureService;
    public IndexModel(IProjectPictureService projectPictureService)
    {
        _projectPictureService = projectPictureService;
    }
    public IReadOnlyList <ProjectPictureViewModel> PageModel { get; set; }
    public async Task OnGet(Guid ProjectId)
    {
        ViewData["ProjectId"]= ProjectId;
        PageModel = await _projectPictureService.GetProjectPicturesAsync(ProjectId);
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _projectPictureService.DeleteProjectPictureAsync(Input.Id);
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
