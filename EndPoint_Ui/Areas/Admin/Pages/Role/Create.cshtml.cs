using Application.DataTransferObject;
using Application.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Role;

public class CreateModel : PageModel
{
    readonly IRoleService _roleService;
    public CreateModel(IRoleService roleService)
    {
        _roleService = roleService;
    }
    [BindProperty]
    public RoleDto Role { get; set; }
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

            await _roleService.InsertRoleAsync(Role);

            return RedirectToPage("/Role/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
