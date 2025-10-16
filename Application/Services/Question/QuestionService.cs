using Application.Common.CustomException;
using Application.Common.Extension;
using Application.Common.Messages;
using Application.Common;
using Application.Contract;
using Application.DataTransferObject;
using Application.ViewModels;
using Domain.Entities;
using Mapster;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Application.Services.Question;

public class QuestionService: IQuestionService
{
    readonly IContext _context;
    public QuestionService(IContext context)
    {
        _context = context;
    }

    public async Task DeleteQuestionAsync(Guid QuestionId)
    {
        QuestionEntity? entity =
            await _context.Entity<QuestionEntity>()
            .FirstOrDefaultAsync(f => f.Id == QuestionId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        entity.IsDelete = true;
        _context.Entity<QuestionEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }

    public async Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId)
    {
        QuestionEntity? entity =
        await _context.Entity<QuestionEntity>()
        .FirstOrDefaultAsync(f => f.Id == QuestionId);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        return entity.Adapt<QuestionDto>();
    }

    public async Task<PaginatedList<QuestionViewModel>> GetQuestionsAsync(Pagination pagination)
    {
        IQueryable<QuestionEntity> query = _context.GetQueryable<QuestionEntity>();

        PaginatedList<QuestionViewModel> model = new();
        if (!string.IsNullOrEmpty(pagination!.keyword))
        {
            query = query.Where(w => w.Title!.Contains(pagination!.keyword));
        }
        int count = query.Count().PageCount(pagination!.pageSize);
        int total = query.Count();

        model = await query.MappingedAsync<QuestionEntity, QuestionViewModel>
        (pagination.currentPage,
                pagination!.pageSize, count, total);
        return model;
    }

    public async Task<IReadOnlyList<QuestionForMainPageViewModel>> GetQuestionsForMainPageAsync()
    {
        IQueryable<QuestionEntity> query = _context.GetQueryable<QuestionEntity>();
        return await query.Select(s => new QuestionForMainPageViewModel()
        {
            Title = s.Title,
            Description = s.Description,
            Id = s.Id
        }).ToListAsync();
    }

    public async Task InsertQuestionAsync(QuestionDto Question)
    {
        QuestionEntity entity = Question.Adapt<QuestionEntity>();



        await _context.Entity<QuestionEntity>().AddAsync(entity);

        await _context.SaveChangesAsync();
    }

    public async Task UpdateQuestionAsync(QuestionDto Question)
    {
        QuestionEntity? entity =
 await _context.Entity<QuestionEntity>()
 .FirstOrDefaultAsync(f => f.Id == Question.Id);

        if (entity == null)
        {
            throw new InternalException(CustomMessage.NotFoundOnDb);
        }
        Question.Adapt(entity);
       

        _context.Entity<QuestionEntity>().Update(entity);
        await _context.SaveChangesAsync();
    }
}
