using Domain.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.ViewModels
{
    public sealed record CourseViewModel
    {
        public Guid Id { get; set; }
        public string? InstructorFullName { get; set; }
        public string CourseTitle { get; set; } = null!;
        public DateTime PublishDate { get; set; }
        public string? Biography { get; set; }
        public string? Description { get; set; }
        public string? TotalDuration { get; set; }
        public int TotalSections { get; set; }
        public CourseStatus Status { get; set; }
    }
}
