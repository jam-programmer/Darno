using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public class UserInformationDto
    {
        public string userAgent { get; set; }
        public string ip { get; set; }
        public string userInformation { get; set; }
        public int statuscode { get; set; }
        public int duration { get; set; }
    }
}
