using Application.DataTransferObject;
using Application.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Role;

public class EditModel : PageModel
{
    readonly IRoleService _roleService;
    public EditModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [BindProperty]
    public RoleDto Role { get; set; }
    public async Task OnGetAsync(Guid Id)
    {
        Role = await _roleService.GetRoleByIdAsync(Id);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {

            await _roleService.UpdateRoleAsync(Role);

            return RedirectToPage("/Role/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
