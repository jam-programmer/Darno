using Application.Common;
using Application.Services.Project;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Project;
[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    readonly IProjectService _projectService;
    public IndexModel(IProjectService projectService)
    {
        _projectService=projectService;
    }
    public PaginatedList<ProjectViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _projectService.GetProjectsAsync(pagination);
        ViewData["Search"] = pagination.keyword;
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _projectService.DeleteProjectAsync(Input.Id);
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
