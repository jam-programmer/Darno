using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Enums; 


namespace Domain.Entities
{
    public class CourseEntity:BaseEntity
    {
        public string? InstructorFullName { get; set; }
        public string CourseTitle { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string Biography { get; set; }
        public string? Description { get; set; }
        public string? TotalDuration { get; set; }
        public int TotalSections { get; set; }
        public CourseStatus Status { get; set; }
        public bool IsDelete { get; set; } = false;



    }
}
