using Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace Application.DataTransferObject
{
    public sealed record CourseDto
    {
        public Guid Id { get; set; }
        [Required(ErrorMessage = "نام و نام خانوادگی الزامی است")]
        public string? InstructorFullName { get; set; }
        [Required(ErrorMessage = "عنوان دوره الزامی است")]
        public string CourseTitle { get; set; } = null!;
        [Required(ErrorMessage = "تاریخ انتشار الزامی است")]
        public string PublishDate { get; set; }
        [Required(ErrorMessage = "بیوگرافی الزامی است")]
        public string? Biography { get; set; }
        [MaxLength(1000, ErrorMessage = "توضیحات نمی‌تواند بیشتر از ۱۰۰۰ کاراکتر باشد")]
        public string? Description { get; set; }
        [Required(ErrorMessage = "مدت زمان کل دوره الزامی است")]
        public string? TotalDuration { get; set; }
        public int TotalSections { get; set; }
        public CourseStatus Status { get; set; }
    }
}
