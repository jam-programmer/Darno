namespace Application.ViewModels;

public record QuestionViewModel
{
    public Guid Id { get; set; }
    public string? Title { get; set; }

}

public sealed record QuestionForMainPageViewModel: QuestionViewModel
{
    public string? Description { get; set; }

}