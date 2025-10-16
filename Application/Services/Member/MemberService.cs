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

namespace Application.Services.Member;

public class MemberService : IMemberService
{
    readonly IContext _context;
    public MemberService(IContext context)
    {
        _context = context;   
    }

    public async Task DeleteMemberAsync(Guid MemberId)
    {
        MemberEntity? entity =
            await _context.Entity<MemberEntity>()
            .FirstOrDefaultAsync(f => f.Id == MemberId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDelete = true;
        _context.Entity<MemberEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<MemberDto> GetMemberByIdAsync(Guid MemberId)
    {
        MemberEntity? entity =
        await _context.Entity<MemberEntity>()
        .FirstOrDefaultAsync(f => f.Id == MemberId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return entity.Adapt<MemberDto>();
    }

    public async Task<PaginatedList<MemberViewModel>> GetMembersAsync(Pagination pagination)
    {
        IQueryable<MemberEntity> query = _context.GetQueryable<MemberEntity>();

        PaginatedList<MemberViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.FullName!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<MemberEntity, MemberViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task<IReadOnlyList<MemberForMainPageViewModel>>
        GetMembersForMainPageAsync()
    {
        IQueryable<MemberEntity> query = _context.GetQueryable<MemberEntity>();
        return await query.Select(s=>new MemberForMainPageViewModel()
        {
            Email = s.Email,
            FullName = s.FullName,  
            GitHub = s.GitHub,
            Id = s.Id,
            ImagePath = s.ImagePath,
            Instagram = s.Instagram,
            JobTitle = s.JobTitle,
            Linkedin    =s.Linkedin
        }).ToListAsync();
    }

    public async Task InsertMemberAsync(MemberDto Member)
    {
        MemberEntity entity = Member.Adapt<MemberEntity>();

        entity.ImagePath = Member.ImageFile!.UploadImage("Member");


        await _context.Entity<MemberEntity>().AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateMemberAsync(MemberDto Member)
    {
        MemberEntity? entity =
 await _context.Entity<MemberEntity>()
 .FirstOrDefaultAsync(f => f.Id == Member.Id);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        Member.Adapt(entity);
        if (Member.ImageFile != null)
        {
            entity.ImagePath = Member.ImageFile.UploadImage("Member");
            Member.ImagePath!.RemoveImage("Member");

        }

       
        _context.Entity<MemberEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
