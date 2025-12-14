using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;
using System.IO;

namespace EndPoint_Ui.Areas.Admin.Pages.Dashboard;

[Authorize]
public class IndexModel : PageModel
{
    public List<DriveInformationViewModel> Informations = [];

    public void OnGet()
    {
        foreach (DriveInfo d in DriveInfo.GetDrives())
        {
            if (!d.IsReady)
                continue;

            try
            {
                Informations.Add(new DriveInformationViewModel
                {
                    Name = d.Name,
                    DriveType = d.DriveType.ToString(),
                    VolumeLabel = d.VolumeLabel,
                    DriveFormat = d.DriveFormat,
                    AvailableFreeSpace = d.AvailableFreeSpace.ToString(),
                    TotalFreeSpace = d.TotalFreeSpace.ToString(),
                    TotalSize = d.TotalSize.ToString()
                });
            }
            catch (IOException)
            {
                continue;
            }
        }
    }
}