using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record UserInformationDto
    {
        public string? UserAgent { get; set; }
        public string? Ip { get; set; }
        public string? UserInformation { get; set; }
        public int Statuscode { get; set; }
        public int Duration { get; set; }
    }
}
