using Application.Common;
using Application.DataTransferObject;
using Application.ViewModels;

namespace Application.Services.Question;

public interface IQuestionService
{
    Task InsertQuestionAsync(QuestionDto Question);
    Task UpdateQuestionAsync(QuestionDto Question);
    Task<QuestionDto> GetQuestionByIdAsync(Guid QuestionId);
    Task DeleteQuestionAsync(Guid QuestionId);
    Task<PaginatedList<QuestionViewModel>> GetQuestionsAsync(Pagination pagination);
    Task<IReadOnlyList<QuestionForMainPageViewModel>>
        GetQuestionsForMainPageAsync();
}
