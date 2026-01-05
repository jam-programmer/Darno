using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums;

namespace Application.ViewModels
{
    public  record OrderViewModel
    {
       
        public Guid Id { set; get; }

        public string? FullName { set; get; }
        public string? Title { set; get; }

        public ProjectType ProjectType { set; get; }

        public DateTime CreatedAt { get; set; }


    }
}
