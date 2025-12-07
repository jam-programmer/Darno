using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using System;
using System.Threading.Tasks;

namespace Application.Services.Article
{
    public interface ICategoryArticleService
    {
        Task InsertCategoryArticleAsync(CategoryArticleDto categoryArticle);
        Task UpdateCategoryArticleAsync(CategoryArticleDto categoryArticle);
        Task DeleteCategoryArticleAsync(Guid categoryArticleId);
        Task<CategoryArticleDto> GetCategoryArticleByIdAsync(Guid categoryArticleId);
        Task<PaginatedList<CategoryArticleViewModel>> GetCategoryArticleAsync(Pagination pagination);
    }
}
