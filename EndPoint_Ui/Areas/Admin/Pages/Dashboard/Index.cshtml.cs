using Application.ViewModels;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Dashboard;

[Authorize]
public class IndexModel : PageModel
{

   


    public List<DriveInformationViewModel> Informations = [];
    public void OnGet()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();
        if (allDrives is not null && allDrives.Any())
        {
            foreach (DriveInfo d in allDrives)
            {

                Informations.Add(new DriveInformationViewModel()
                {
                    Name = d?.Name,
                    DriveType = d?.DriveType.ToString(),
                    VolumeLabel = d?.VolumeLabel,
                    DriveFormat = d?.DriveFormat,
                    AvailableFreeSpace = d?.AvailableFreeSpace.ToString(),
                    TotalFreeSpace = d?.TotalFreeSpace.ToString(),

                    TotalSize = d?.TotalSize.ToString()
                });




            }


        }
    }

}



