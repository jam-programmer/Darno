using Application.DataTransferObject;
using Application.Services.Question;
using Application.Services.Role;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.RazorPages;

namespace EndPoint_Ui.Areas.Admin.Pages.Question;

public class EditModel : PageModel
{
    readonly IQuestionService _questionService;
    public EditModel(IQuestionService questionService)
    {
        _questionService = questionService;
    }
    [BindProperty]
    public QuestionDto Question { get; set; }
    public async Task OnGetAsync(Guid Id)
    {
        Question = await _questionService.GetQuestionByIdAsync(Id);
    }
    public async Task<IActionResult> OnPostAsync()
    {
        if (ModelState.IsValid is false)
        {
            return Page();
        }
        try
        {

            await _questionService.UpdateQuestionAsync(Question);

            return RedirectToPage("/Question/Index");
        }
        catch (Exception ex)
        {
            return RedirectToPage("Exception");
        }
    }
}
