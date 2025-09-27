using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.Role;
using Application.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.User;
public class CreateModel : PageModel
{
    readonly IRoleService _roleService;
    readonly IUserService _userService;
    public CreateModel(IUserService userService, IRoleService roleService)
    {
        _userService = userService;
        _roleService = roleService;
    }
    [BindProperty]
    public UserDto? User { get; set; }
    public void OnGet()
    {
    }

    public async Task<IActionResult> OnGetFetchRolesAsync([FromQuery] string search)
    {
        Dictionary<string, string> roles = await _roleService.GetRolesAsync(search);
        var model = roles.Select(s => new
        {
            Id = s.Key,
            Name = s.Value,
        }).ToList();
        return new JsonResult(model);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {

            await _userService.InsertUserAsync(User!, default);

            return RedirectToPage("/User/Index");
        }
        catch (InternalException ex)
        {
            ViewData["Alert"]=ex.Message;
            return Page();
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
