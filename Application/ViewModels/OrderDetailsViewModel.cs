using Domain.Enums;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
     public record OrderDetailsViewModel:OrderViewModel
    {

        
        public string? PhoneNumber { set; get; }
        public string? Email { set; get; }
       
        public string? Description { set; get; }
      
        public PlatformType PlatformType { set; get; }
        public NeedType IsOnlinePaymentGateway { set; get; }
        public NeedType IsMultilingual { set; get; }
        public NeedType IsSms { set; get; }
        public NeedType IsOnlineChat { set; get; }
        public NeedType IsBlog { set; get; }
        public NeedType IsReport { set; get; }
        public long Price { set; get; }
        public NeedType IsPwa { set; get; }
        public NeedType HaveHost { set; get; }
        public NeedType HaveDomain { set; get; }
        public string? Url { set; get; }
        public string File { set; get; }
    }

}
