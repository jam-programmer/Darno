using Application.Common.CustomException;
using Application.DataTransferObject;
using Application.Services.User;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Pages;

public class SignInModel (IUserService userService): PageModel
{
    readonly IUserService _userService= userService;
    public IActionResult OnGet()
    {
        if (User.Identity!.IsAuthenticated)
        {

            return Redirect("/");
        }
        ViewData["Alert"]=null;
        return Page();
    }
    public async Task<IActionResult> OnPost()
    {
        if (ModelState.IsValid)
        {
            try
            {
                await _userService.SignInAsync(SignIn);
                return Redirect("/Admin/Dashboard/Index");
            }
            catch (InternalException ex)
            {
                ViewData["Alert"] = ex.Message;
                return Page();
            }
        }
        return Page();
    }

    [BindProperty]
    public SignInDto SignIn { get; set; }
}
