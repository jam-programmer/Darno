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
    public class ArticleService 
    { readonly IContext _context;
        public ArticleService(IContext context)
        {
            _context = context;

        }

        public async Task InsertArticleAsync(ArticleDto Article)
        {
            ArticleEntity entity = Article.Adapt<ArticleEntity>();

            entity.ImagePath = Article.ImageFile!.UploadImage("Article");
            await _context.Entity<ArticleEntity>().AddAsync(entity);

            await _context.SaveChangesAsync();

        }

        public async Task DeleteArticleAsync(Guid ArticleId)
        {
            ArticleEntity? entity =
                await _context.Entity<ArticleEntity>()
                .FirstOrDefaultAsync(f => f.Id == ArticleId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            entity.IsDelete = true;
            _context.Entity<ArticleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<ArticleDto> GetArticleByIdAsync(Guid ArticleId)
        {
            ArticleEntity? entity =
            await _context.Entity<ArticleEntity>()
            .FirstOrDefaultAsync(f => f.Id == ArticleId);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            return entity.Adapt<ArticleDto>();
        }
        public async Task UpdateArticleAsync(ArticleDto Article)
        {
            ArticleEntity? entity =
     await _context.Entity<ArticleEntity>()
     .FirstOrDefaultAsync(f => f.Id == Article.Id);

            if (entity == null)
            {
                throw new InternalException(CustomMessage.NotFoundOnDb);
            }
            Article.Adapt(entity);
            if (Article.ImageFile != null)
            {
                entity.ImagePath = Article.ImageFile.UploadImage("Article");
               

            }


            _context.Entity<ArticleEntity>().Update(entity);
            await _context.SaveChangesAsync();
        }

        public async Task<PaginatedList<ArticleViewModel>> GetArticleAsync(Pagination pagination)
        {
            IQueryable<ArticleEntity> query = _context.GetQueryable<ArticleEntity>();

            PaginatedList<ArticleViewModel> model = new();
            if (!string.IsNullOrEmpty(pagination!.keyword))
            {
                query = query.Where(w => w.Title.Contains(pagination!.keyword));
            }
            int count = query.Count().PageCount(pagination!.pageSize);
            int total = query.Count();

            model = await query.MappingedAsync<ArticleEntity, ArticleViewModel>
            (pagination.currentPage,
                    pagination!.pageSize, count, total);
            return model;
        }




    }
}
