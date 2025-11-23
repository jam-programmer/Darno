using Application.Common.Extension;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Shared;
[IgnoreAntiforgeryToken]

public  class UploadModel : PageModel
{
    // Constructor بدون پارامتر برای UploadModel
    public UploadModel()
    {
    }

    public virtual async Task<IActionResult> OnPostUploadAsync(IFormFile upload)
    {
        if (upload == null)
        {
            return null;
        }
        string fileName = upload.UploadImage("common");
        string url = $"/gallery/common/{fileName}";
        return new JsonResult(new { uploaded = true, url });
    }
}
