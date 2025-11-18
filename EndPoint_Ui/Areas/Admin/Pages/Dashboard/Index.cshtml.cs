using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Dashboard;

[Authorize]
public class IndexModel : PageModel
{
    public void OnGet()
    {
        DriveInfo[] allDrives = DriveInfo.GetDrives();

        foreach (DriveInfo d in allDrives)
        {
            System.Diagnostics.Debug.WriteLine( d.Name);
            System.Diagnostics.Debug.WriteLine("  Drive type:" + d.DriveType);
            if (d.IsReady)
            {
                System.Diagnostics.Debug.WriteLine("  Volume label: "+ d.VolumeLabel);
                System.Diagnostics.Debug.WriteLine("  File system: "+d.DriveFormat);
                System.Diagnostics.Debug.WriteLine(
                    "  Available space to current user:"+
                    d.AvailableFreeSpace+ "bytes");

                System.Diagnostics.Debug.WriteLine(
                    "  Total available space:"+
                    d.TotalFreeSpace+ "bytes");

                System.Diagnostics.Debug.WriteLine(
                    "  Total size of drive:"+
                    d.TotalSize+ "bytes");
            }
        }
    }
}
    

