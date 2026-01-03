using Application.Common;
using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Domain.Entities.Identity;
using Mapster;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Dapper.SqlMapper;

namespace Application.Services.Club
{
    public class ClubService : IClubService
    {
        readonly IContext _context;
        public ClubService(IContext context)
        {
            _context = context;

        }
        public async Task InsertClubAsync(ClubDto club)
        {
            bool existingEmail = await _context.Entity<ClubEntity>()
                                    .AnyAsync(c => c.Email == club.Email);
            if (existingEmail)
            {
                throw new InvalidOperationException("این ایمیل قبلاً ثبت شده است.");
            }
            ClubEntity entity = club.Adapt<ClubEntity>();

            await _context.Entity<ClubEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

        }
       
        public async Task<ClubDto> GetClubByIdAsync(Guid ClubId)
        {
            ClubEntity? entity =
            await _context.Entity<ClubEntity>()
            .FirstOrDefaultAsync(f => f.Id == ClubId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            return entity.Adapt<ClubDto>();
        }
        public async Task<PaginatedList<ClubViewModel>> GetEmailsAsync(Pagination pagination)
        {
            IQueryable<ClubEntity> query = _context.GetQueryable<ClubEntity>();

            PaginatedList<ClubViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.Email!.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<ClubEntity, ClubViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total);
            return model;
        }
    }
}
