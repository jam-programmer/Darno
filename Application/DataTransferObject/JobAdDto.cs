using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DataTransferObject
{
    public sealed record JobAdDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "نام الزامی است")]
        public string? Name { get; set; }
        [Required(ErrorMessage = "نام خانوادگی الزامی است")]
        public string? LastName { get; set; }
        [Range(18, 65, ErrorMessage = "سن باید بین ۱۸ تا ۶۵ باشد")]
        public int Age { get; set; }
        [Required(ErrorMessage = "عنوان شغلی الزامی است")]
        public string? JobTitle { get; set; }
        [Required(ErrorMessage = "شهر مورد نظر الزامی است")]
        public string? JobCity { get; set; }
        public string? JobRole { get; set; }
        [Required(ErrorMessage = "نوع همکاری الزامی است")]
        public WorkType EmploymentType { get; set; }
        [Required(ErrorMessage = "تاریخ ثبت آگهی الزامی است")]
        public string PostedDate { get; set; }
        [MaxLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیشتر از ۱۰۰۰ کاراکتر باشد")]
        public string? Description { get; set; }

    }
}
