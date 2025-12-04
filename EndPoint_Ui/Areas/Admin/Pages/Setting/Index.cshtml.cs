using Application.DataTransferObject;
using Application.Services.Setting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Setting;

public class IndexModel (ISettingService settingService): PageModel
{
    readonly ISettingService _settingService=settingService;
    [BindProperty]
    public SettingDto? Setting { get; set; }
    public async Task OnGet()
    {
        Setting=await _settingService.GetSettingAsync();
    }




    public async Task<IActionResult> OnPost()
    {
        await _settingService.UpdateSettingAsync(Setting);
        return RedirectToPage();
    }
}
