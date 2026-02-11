using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Services.Course
{
    public class CourseService : ICourseService
    {
        readonly IContext _context;
        public CourseService(IContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<CourseViewModel>> GetActiveCoursesAsync()
        {
            var query = _context.GetQueryable<CourseEntity>();
            query = query.Where(c => c.PublishDate <= DateTime.Now)
                .OrderByDescending(c => c.PublishDate);

            var result = await query
                 .Select(c => new CourseViewModel
                 {
                     Id = c.Id,
                     InstructorFullName = c.InstructorFullName,
                     CourseTitle = c.CourseTitle,
                     PublishDate = c.PublishDate,
                     Biography = c.Biography,
                     Description = c.Description,
                     TotalDuration = c.TotalDuration,
                     TotalSections = c.TotalSections,
                     Status = c.Status,

                 }).ToListAsync();
            return result;
        }


        public async Task InsertCourseAsync(CourseDto dto)
        {

            var entity = new CourseEntity
            {
               InstructorFullName = dto.InstructorFullName,
               CourseTitle = dto.CourseTitle,
               Biography = dto.Biography,
               Description = dto.Description,
               TotalDuration = dto.TotalDuration,
               TotalSections = dto.TotalSections,
               Status = dto.Status,
                PublishDate = dto.PublishDate.ConvertToGregorian()
            };
                _context.Entity<CourseEntity>().Add(entity);
                await _context.SaveChangesAsync();
            
        }


        public async Task UpdateCourseAsync(CourseDto dto)
        {
            CourseEntity? entity = await _context.Entity<CourseEntity>()
                .FirstOrDefaultAsync(c => c.Id == dto.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.InstructorFullName = dto.InstructorFullName;
            entity.CourseTitle = dto.CourseTitle;
            entity.Biography = dto.Biography;
            entity.Description = dto.Description;
            entity.TotalDuration = dto.TotalDuration;
            entity.TotalSections = dto.TotalSections;
            entity.Status = dto.Status;
            entity.PublishDate = dto.PublishDate.ConvertToGregorian();

            _context.Entity<CourseEntity>().Update(entity);
            await _context.SaveChangesAsync();

        }


        public async Task DeleteCourseAsync(Guid CourseId)
        {
            CourseEntity? entity =
             await _context.Entity<CourseEntity>()
             .FirstOrDefaultAsync(c => c.Id == CourseId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<CourseEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }



        public async Task<CourseDto> GetCourseDtoAsync(Guid CourseId)
        {
            CourseEntity? entity =
        await _context.Entity<CourseEntity>()
        .FirstOrDefaultAsync(c => c.Id == CourseId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            TypeAdapterConfig config = new();
            config.NewConfig<CourseEntity, CourseDto>()
                .Map(c => c.Id, c => c.Id)
                .Map(c => c.InstructorFullName, c => c.InstructorFullName)
                .Map(c => c.CourseTitle, c => c.CourseTitle)
                .Map(c => c.Biography, c => c.Biography)
                .Map(c => c.Description, c => c.Description)
                .Map(c => c.TotalDuration, c => c.TotalDuration)
                .Map(c => c.TotalSections, c => c.TotalSections)
                .Map(c => c.Status, c => c.Status)
                .Map(c => c.PublishDate, c => c.PublishDate)
                
                .Compile();


            return entity.Adapt<CourseDto>(config);

        }


        public async Task<PaginatedList<CourseViewModel>> GetCoursesAsync(Pagination pagination)
        {
            TypeAdapterConfig config = new();
            config.NewConfig<CourseEntity, CourseViewModel>()
                .Map(c => c.Id, c => c.Id)
                .Map(c => c.InstructorFullName, c => c.InstructorFullName)
                .Map(c => c.CourseTitle, c => c.CourseTitle)
                .Map(c => c.Biography, c => c.Biography)
                .Map(c => c.Description, c => c.Description)
                .Map(c => c.TotalDuration, c => c.TotalDuration)
                .Map(c => c.TotalSections, c => c.TotalSections)
                .Map(c => c.Status, c => c.Status)
                .Map(c => c.PublishDate, c => c.PublishDate)
                .Compile();
            IQueryable<CourseEntity> query = _context.GetQueryable<CourseEntity>();

            PaginatedList<CourseViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.CourseTitle!.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<CourseEntity, CourseViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total, config);
            return model;
        }
    }
}
