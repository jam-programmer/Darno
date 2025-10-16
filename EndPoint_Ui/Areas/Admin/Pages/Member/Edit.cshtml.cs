using Application.DataTransferObject;
using Application.Services.Member;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Member;

public class EditModel : PageModel
{
    readonly IMemberService _memberService;
    public EditModel(IMemberService memberService)
    {
        _memberService = memberService;
    }
    [BindProperty]
    public MemberDto Member { get; set; }
    public async Task OnGet(Guid Id)
    {
        Member=await _memberService.GetMemberByIdAsync(Id);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
           
            return Page();
        }
        try
        {

            await _memberService.UpdateMemberAsync(Member); 

            return RedirectToPage("/Member/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
