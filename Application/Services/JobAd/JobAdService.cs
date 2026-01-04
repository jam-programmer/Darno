using System;
using System.Collections.Generic;
using Application.Common.Extension;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Application.Contract;
using Application.ViewModels;
using Microsoft.EntityFrameworkCore;
using Application.DataTransferObject;
using Domain.Entities;
using Application.Common.CustomException;
using Application.Common.Messages;
using Mapster;
using Application.Common;


namespace Application.Services.JobAd
{
    public class JobAdService : IJobAdService
    {
        readonly IContext _context;
        public JobAdService(IContext context)
        {
            _context = context;
        }

        public async Task<IReadOnlyList<JobAdViewModel>> GetActiveJobAdsAsync()
        {
            var query = _context.GetQueryable<JobAdEntity>();
            query = query.Where(j => j.PostedDate <= DateTime.Now);

           var result = await query
                .Select(j => new JobAdViewModel
                {
                    Id = j.Id,
                    Name = j.Name,
                    LastName = j.LastName,
                    Age = j.Age,
                    JobCity = j.JobCity,
                    JobRole = j.JobRole,
                    JobTitle = j.JobTitle,
                    EmploymentType = j.EmploymentType,
                    PostedDate = j.PostedDate,
                    Description = j.Description,
                }).ToListAsync();
            return result;
        }

        public async Task InsertJobAdAsync(JobAdDto dto)
        {

            JobAdEntity entity = new();
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Age = dto.Age;
            entity.JobCity = dto.JobCity;
            entity.JobRole = dto.JobRole;
            entity.JobTitle = dto.JobTitle;
            entity.EmploymentType = dto.EmploymentType;
            entity.PostedDate = dto.PostedDate.ConvertToGregorian();
            entity.Description = dto.Description;

             _context.Entity<JobAdEntity>().Add(entity);
            await _context.SaveChangesAsync();
        }

        public async Task UpdateJobAdAsync(JobAdDto dto)
        {
            JobAdEntity? entity = await _context.Entity<JobAdEntity>()
                .FirstOrDefaultAsync(j => j.Id == dto.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.Name = dto.Name;
            entity.LastName = dto.LastName;
            entity.Age = dto.Age;
            entity.JobCity = dto.JobCity;
            entity.JobRole = dto.JobRole;
            entity.JobTitle = dto.JobTitle;
            entity.EmploymentType = dto.EmploymentType;
            entity.PostedDate = dto.PostedDate.ConvertToGregorian();
            entity.Description = dto.Description;

            _context.Entity<JobAdEntity>().Update(entity);
            await _context.SaveChangesAsync();

        }
        public async Task DeleteJobAdAsync(Guid jobId)
        {
          JobAdEntity? entity =
           await _context.Entity<JobAdEntity>()
           .FirstOrDefaultAsync(j => j.Id == jobId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<JobAdEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<JobAdDto> GetJobAdDtoAsync(Guid jobId)
        {
            JobAdEntity? entity =
        await _context.Entity<JobAdEntity>()
        .FirstOrDefaultAsync(j => j.Id == jobId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            TypeAdapterConfig config = new();
            config.NewConfig<JobAdEntity, JobAdDto>()
                .Map(d => d.Id, j => j.Id)
                .Map(d => d.Name, j => j.Name)
                .Map(d => d.LastName, j => j.LastName)
                .Map(d => d.Age, j => j.Age)
                .Map(d => d.JobCity, j => j.JobCity)
                .Map(d => d.JobRole, j => j.JobRole)
                .Map(d => d.JobTitle, j => j.JobTitle)
                .Map(d => d.EmploymentType, j => j.EmploymentType)
                .Map(d => d.PostedDate, s => s.PostedDate.PersianDateWithOutTime())
                .Map(d => d.Description, j => j.Description)
                .Compile();


            return entity.Adapt<JobAdDto>(config);

        }

        public async Task<PaginatedList<JobAdViewModel>> GetJobAdsAsync(Pagination pagination)
        {
            TypeAdapterConfig config = new();
            config.NewConfig<JobAdEntity, JobAdViewModel>()
                .Map(d => d.Id, j => j.Id)
                .Map(d => d.Name, j => j.Name)
                .Map(d => d.LastName, j => j.LastName)
                .Map(d => d.Age, j => j.Age)
                .Map(d => d.JobCity, j => j.JobCity)
                .Map(d => d.JobRole, j => j.JobRole)
                .Map(d => d.JobTitle, j => j.JobTitle)
                .Map(d => d.EmploymentType, j => j.EmploymentType)
                .Map(d => d.PostedDate, s => s.PostedDate.PersianDateWithOutTime())
                .Map(d => d.Description, j => j.Description)
                .Compile();
            IQueryable<JobAdEntity> query = _context.GetQueryable<JobAdEntity>();

            PaginatedList<JobAdViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.JobTitle!.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<JobAdEntity, JobAdViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total, config);
            return model;
        }

    }
}
