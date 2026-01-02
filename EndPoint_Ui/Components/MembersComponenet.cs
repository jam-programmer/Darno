using Application.Services.Member;
using Application.Services.Question;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class MembrsComponenet(IMemberService memberService):ViewComponent
{
    readonly IMemberService _memberService = memberService;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<MemberForMainPageViewModel> model =
            await _memberService.GetMembersForMainPageAsync();
        return View("/Pages/Shared/ViewComponent/MembrsComponenet.cshtml", model);
    }
}
