using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace EndPoint_Ui.TagHelpers;

[HtmlTargetElement("basic-table")]
public class BasicTableTagHelper : TagHelper
{
    [HtmlAttributeName("table-title")]
    public string? TableTitle { get; set; }

    [HtmlAttributeName("button-title")]
    public string? ButtonTitle { get; set; }

    [HtmlAttributeName("button-link")]
    public string? ButtonLink { get; set; }

    [HtmlAttributeName("area")]
    public string? Area { get; set; }

    [HtmlAttributeName("page")]
    public string? Page { get; set; }

    [HtmlAttributeName("action")]
    public string? Action { get; set; }

    [HtmlAttributeName("search-value")]
    public string? SearchValue { get; set; }

    [HtmlAttributeName("total-pages")]
    public int TotalPages { get; set; }

    [HtmlAttributeName("current-page")]
    public int CurrentPage { get; set; }


    public override async Task ProcessAsync(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "div";
        output.Attributes.Add("class", "row");

        // دریافت محتوای داخلی (جدول)
        var tableContent = await output.GetChildContentAsync();

        var content = $"""
            <div class="card">
                <div class="card-header">
                    <h5 class="heading-color">{TableTitle}</h5>
                    {GenerateButton()}
                    {GenerateSearchForm()}
                </div>
                <div class="card-body">
                    <div class="table-responsive text-nowrap">
                        {tableContent.GetContent()}
                    </div>
                </div>
                {GenerateFooter()}
            </div>
        """;

        output.Content.SetHtmlContent(content);
    }

    private string GenerateButton()
    {
        if (string.IsNullOrEmpty(ButtonTitle) || string.IsNullOrEmpty(ButtonLink))
            return string.Empty;

        return $"""
            <a href="{ButtonLink}" class="btn btn-sm btn-success text-white">
                {ButtonTitle}
            </a>
        """;
    }

    private string GenerateSearchForm()
    {
        string refreshLink = $"/{Area}/{Page}";
        return $"""
            <form asp-area="{Area}" asp-page="{Page}"  method="get" class="input-group mt-3 w-25">
                <input class="form-control form-control-sm" name="keyword" type="search"
                    placeholder="یک عبارت جستجو کنید" value="{SearchValue}" />
                <button class="btn btn-sm btn-primary" type="submit">
                    <i class="fa-solid fa-magnifying-glass"></i>
                </button>
                <a href="{refreshLink}"
                    class="btn btn-sm btn-warning text-white">
                    <i class="fa-solid fa-rotate-right"></i>
                </a>
            </form>
        """;
    }

    private string GenerateFooter()
    {
        if (TotalPages <= 1)
            return string.Empty;

        return $"""
            <div class="card-footer">
                <div id="pagination-body"
                     data-page-index="{CurrentPage}"
                     data-total-pages="{TotalPages}"
                     data-search="{SearchValue}"
                     data-path="/{Area}/{Page}/{Action}">
                </div>
            </div>
        """;
    }
}