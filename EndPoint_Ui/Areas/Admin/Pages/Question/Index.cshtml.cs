using Application.Common;
using Application.Services.Question;
using Application.ViewModels;
using EndPoint_Ui.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;
namespace EndPoint_Ui.Areas.Admin.Pages.Question;
[IgnoreAntiforgeryToken]

public class IndexModel : PageModel
{
    readonly IQuestionService _questionService;
    public IndexModel(IQuestionService questionService)
    {
        _questionService    = questionService;
    }
    public PaginatedList<QuestionViewModel> PageModel { get; set; }
    public async Task OnGet([FromQuery] Pagination pagination)
    {
        PageModel=await _questionService.GetQuestionsAsync(pagination);
    }
    public async Task<IActionResult> OnPostDeleteAsync([FromBody] InputModel Input)
    {
        try
        {
            await _questionService.DeleteQuestionAsync(Input.Id);
            return new JsonResult(new
            {
                IsSuccess = true,
                Message = string.Empty,
            });
        }
        catch (Exception ex)
        {
            return new JsonResult(new
            {
                IsSuccess = false,
                Message = ex.Message,
            });
        }
    }

}
