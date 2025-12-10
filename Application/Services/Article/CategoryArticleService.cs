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


namespace Application.Services.Article
{
    public class CategoryArticleService :ICategoryArticleService
    {
        readonly IContext _context;
        public CategoryArticleService(IContext context)
        {
            _context = context;

        }

        public async Task InsertCategoryArticleAsync(CategoryArticleDto Article)
        {
            CategoryArticleEntity entity = Article.Adapt<CategoryArticleEntity>();

           
            await _context.Entity<CategoryArticleEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteCategoryArticleAsync(Guid CategoryArticleId)
        {
            CategoryArticleEntity? entity =
                await _context.Entity<CategoryArticleEntity>()
                .FirstOrDefaultAsync(f => f.Id == CategoryArticleId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<CategoryArticleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<CategoryArticleDto> GetCategoryArticleByIdAsync(Guid CategoryArticleId)
        {
            CategoryArticleEntity? entity =
            await _context.Entity<CategoryArticleEntity>()
            .FirstOrDefaultAsync(f => f.Id == CategoryArticleId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            return entity.Adapt<CategoryArticleDto>();
        }
        public async Task UpdateCategoryArticleAsync(CategoryArticleDto CategoryArticle)
        {
           CategoryArticleEntity? entity =
     await _context.Entity<CategoryArticleEntity>()
     .FirstOrDefaultAsync(f => f.Id == CategoryArticle.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            CategoryArticle.Adapt(entity);
          


            _context.Entity<CategoryArticleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<CategoryArticleViewModel>> GetCategoryArticleAsync(Pagination pagination)
        {
            IQueryable<CategoryArticleEntity> query = _context.GetQueryable<CategoryArticleEntity>();

            PaginatedList<CategoryArticleViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.Name.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<CategoryArticleEntity, CategoryArticleViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total);
            return model;
        }




    }
}

