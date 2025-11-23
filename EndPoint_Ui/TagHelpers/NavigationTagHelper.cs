using Microsoft.AspNetCore.Razor.Runtime.TagHelpers;
using Microsoft.AspNetCore.Razor.TagHelpers;
using System.Text;

namespace EndPoint_Ui.TagHelpers;
[HtmlTargetElement("Navigation")]
public class NavigationTagHelper : TagHelper
{
    public IReadOnlyList<NavigationRouteModel>? Routes { get; set; }

    public override void Process(TagHelperContext context, TagHelperOutput output)
    {
        output.TagName = "nav";
        output.Attributes.Add("aria-label", "breadcrumb");

        StringBuilder content = new StringBuilder();

        if (Routes is not null && Routes.Any())
        {
            content.Append("<ol class=\"lh-1-85 breadcrumb\">");

            foreach (NavigationRouteModel route in Routes)
            {
                content.Append("<li class=\"breadcrumb-item\">");

                if (route.IsActive)
                {
                    content.Append($"<span class=\"text-muted\">{route.title}</span>");
                }
                else
                {
                    string url = BuildUrl(route);
                    content.Append($"<a href=\"{url}\">{route.title}</a>");
                }

                content.Append("</li>");
            }

            content.Append("</ol>");
        }

        output.Content.SetHtmlContent(content.ToString());
    }

    private string BuildUrl(NavigationRouteModel route)
    {
        StringBuilder urlBuilder = new StringBuilder();

        if (!string.IsNullOrEmpty(route.areaName))
        {
            urlBuilder.Append($"/{route.areaName}");
        }

        if (!string.IsNullOrEmpty(route.pageName))
        {
            urlBuilder.Append($"/{route.pageName}");
        }

    
        if (!string.IsNullOrEmpty(route.actionName))
        {
            urlBuilder.Append($"/{route.actionName}");
        }

        if (route.QueryParameters != null && route.QueryParameters.Any())
        {
            bool isFirstParameter = true;

            foreach (var param in route.QueryParameters)
            {
                if (isFirstParameter)
                {
                    urlBuilder.Append($"?{param.Key}={Uri.EscapeDataString(param.Value)}");
                    isFirstParameter = false;
                }
                else
                {
                    urlBuilder.Append($"&{param.Key}={Uri.EscapeDataString(param.Value)}");
                }
            }
        }

        return urlBuilder.ToString();
    }
}

public class NavigationRouteModel
{
    public string areaName { get; set; } = string.Empty;
    public string? pageName { get; set; }
    public string? actionName { get; set; }
    public string? title { get; set; }
    public bool IsActive { get; set; }
    public Dictionary<string, string>? QueryParameters { get; set; }
}