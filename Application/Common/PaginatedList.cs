namespace Application.Common;

public class PaginatedList<TModel>
{
    public IReadOnlyList<TModel>? List { set; get; }
    public int CurrentPage { set; get; }
    public int TotalPage { set; get; }
    public int TotalItem {  set; get; }
    public int PageSize { set; get; }
    public string Keyword { set; get; } = string.Empty;
}