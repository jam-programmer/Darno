using Application.DataTransferObject;
using Application.Services.Member;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Member;

public class CreateModel : PageModel
{
    readonly IMemberService _memberService;
    public CreateModel(IMemberService memberService)
    {
        _memberService = memberService;
    }
    [BindProperty]
    public MemberDto Member { get; set; }
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

            await _memberService.InsertMemberAsync(Member);

            return RedirectToPage("/Member/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
