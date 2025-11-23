using Application.Services.Project;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class ProjectsComponent(IProjectService projectService): ViewComponent
{
    readonly IProjectService _projectService=projectService;


    public async Task<IViewComponentResult> InvokeAsync(Guid ServiceId)
    {
        IReadOnlyList<ProjectCardViewModel> model =
            await _projectService.GetProjectsWithServiceIdAsync(ServiceId);
        return View("/Pages/Shared/ViewComponent/ProjectsComponent.cshtml", model);
    }
}
