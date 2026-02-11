using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public interface ICourseService
    {
        Task InsertCourseAsync(CourseDto dto);
        Task UpdateCourseAsync(CourseDto dto);
        Task DeleteCourseAsync(Guid CourseId);
        Task<IReadOnlyList<CourseViewModel>> GetActiveCoursesAsync();
        Task<CourseDto> GetCourseDtoAsync(Guid CourseId);
        Task<PaginatedList<CourseViewModel>> GetCoursesAsync(Pagination pagination);


    }
}
