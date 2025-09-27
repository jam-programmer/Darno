using Application.Common;
using Application.Services.Role;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Role;
[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    readonly IRoleService _roleService;
    public IndexModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    public PaginatedList<RoleViewModel> PageModel { get; set; }

    public async Task OnGetAsync([FromQuery] Pagination Pagination)
    {
        PageModel = await _roleService.GetRolesAsync(Pagination);
        ViewData["Search"] = Pagination.keyword;
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _roleService.DeleteRoleAsync(Input.Id);
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
