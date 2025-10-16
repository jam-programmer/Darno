using Application.Common;
using Application.Contract;
using Application.Services.Member;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Member;
[IgnoreAntiforgeryToken]
public class IndexModel : PageModel
{
    readonly IMemberService _memberService;
    public IndexModel(IMemberService memberService)
    {
        _memberService = memberService;
    }
    public PaginatedList<MemberViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel = await _memberService.GetMembersAsync(pagination);
        ViewData["Search"] = pagination.keyword;
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _memberService.DeleteMemberAsync(Input.Id);
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
