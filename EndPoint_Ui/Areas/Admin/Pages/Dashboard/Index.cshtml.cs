using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Dashboard;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
    }
}
