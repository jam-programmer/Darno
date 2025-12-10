using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;
using static Application.ViewModels.ArticleViewModel;

namespace Application.Services.Article;

public interface IArticleService
{
    Task InsertArticleAsync(ArticleDto article);
    Task UpdateArticleAsync(ArticleDto article);
    Task<ArticleDto> GetArticleByIdAsync(Guid articleId);
    Task DeleteArticleAsync(Guid articleId);

    Task<PaginatedList<ArticleViewModel>> GetArticlesAsync(Pagination pagination);

    
}

