using DataLayer.Entities;
using Microsoft.AspNetCore.Components.Forms;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.Text;
using System.Threading.Tasks;

namespace AuthoringTagHelpers.TagHelpers
{
    public class TagHelperReviewStar : TagHelper
    {
        //[HtmlAttributeName("stars")]
        //public ModelExpression Review { get; set; }
        //public override void Process(TagHelperContext context, TagHelperOutput output)
        //{
        //    Console.WriteLine(this.Review);
        //    var sb = new StringBuilder();
        //    for (int i = 0; i < this.Review; i++)
        //    {
        //        sb.AppendFormat("* ");
        //    }
        //    output.PreContent.SetHtmlContent(sb.ToString());
        //}
    }
}