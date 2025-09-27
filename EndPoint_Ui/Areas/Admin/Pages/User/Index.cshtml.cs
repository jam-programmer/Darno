using Application.Common;
using Application.Services.User;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.User;
[IgnoreAntiforgeryToken]

public class IndexModel : PageModel
{
    readonly IUserService _userService;
    public IndexModel(IUserService userService)
    {
        _userService = userService;
    }

    public PaginatedList<UserViewModel> PageModel {  get; set; } 
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _userService.GetUsersAsync(pagination,default);
        ViewData["Search"] = pagination.keyword;
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _userService.DeleteUserAsync(Input.Id, default);
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


    public async Task<IActionResult> OnPostSetPasswordAsync([FromBody] PasswordModel Input)
    {
        try
        {
            await _userService.SetUserPasswordAsync(Input.Id,Input.Password!,default);
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
