using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels;

public sealed record DriveInformationViewModel
{
    public string? Name { set; get; }
    public string? DriveType { set; get; }

    public string? VolumeLabel { set; get; }
    public string? DriveFormat { set; get; }

    public string? AvailableFreeSpace { set; get; }

    public string? TotalFreeSpace { set; get; }
    public string? TotalSize { set; get; }


}
