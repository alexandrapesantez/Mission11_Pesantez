using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion.Internal; // This namespace seems unnecessary and can be removed.
using Mission11_Pesante.Models.ViewModels;

namespace Mission11_Pesante.Infrastructure
{
    // Specifies that this Tag Helper targets <div> elements with the "page-model" attribute
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory urlHelperFactory;

        // Constructor to inject the IUrlHelperFactory
        public PaginationTagHelper(IUrlHelperFactory temp)
        {
            urlHelperFactory = temp;
        }

        // Properties

        // Provides access to the ViewContext
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext? ViewContext { get; set; }

        // Specifies the action method for pagination links
        public string PageAction { get; set; }

        // Represents the pagination information
        public PaginationInfo PageModel { get; set; }

        // Indicates whether to apply CSS classes for pagination elements
        public bool PageClassEnabled { get; set; } = false;

        // CSS class for pagination elements
        public string PageClass { get; set; } = string.Empty;

        // CSS class for normal pagination elements
        public string PageClassNormal { get; set; } = string.Empty;

        // CSS class for selected pagination element
        public string PageClassSelected { get; set; } = string.Empty;

        // Overrides the Process method to generate pagination HTML
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext != null && PageModel != null)
            {
                IUrlHelper urlHelper = urlHelperFactory.GetUrlHelper(ViewContext);
                TagBuilder result = new TagBuilder("div");

                // Loop through each page and generate pagination links
                for (int i = 1; i <= PageModel.TotalNumPages; i++)
                {
                    TagBuilder tag = new TagBuilder("a");
                    tag.Attributes["href"] = urlHelper.Action(PageAction, new { pageNum = i });

                    // Apply CSS classes if enabled
                    if (PageClassEnabled)
                    {
                        tag.AddCssClass(PageClass);
                        tag.AddCssClass(i == PageModel.CurrentPage ? PageClassSelected : PageClassNormal);
                    }

                    // Set the page number as the link text
                    tag.InnerHtml.Append(i.ToString());

                    // Append the pagination link to the result
                    result.InnerHtml.AppendHtml(tag);
                }

                // Append the generated pagination HTML to the output
                output.Content.AppendHtml(result.InnerHtml);
            }
        }
    }
}
