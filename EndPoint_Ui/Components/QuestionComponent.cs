using Application.Services.Question;
using Application.Services.Service;
using Application.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace EndPoint_Ui.Components;

public class QuestionComponent(IQuestionService question) :ViewComponent
{
    readonly IQuestionService _question = question;
    public async Task<IViewComponentResult> InvokeAsync()
    {
        IReadOnlyList<QuestionForMainPageViewModel> model =
            await _question.GetQuestionsForMainPageAsync();
        return View("/Pages/Shared/ViewComponent/QuestionComponent.cshtml", model);
    }
}
