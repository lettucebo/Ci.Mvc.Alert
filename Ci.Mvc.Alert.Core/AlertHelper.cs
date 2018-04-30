using Ci.Extension.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ci.Mvc.Alert.Core
{
    [HtmlTargetElement("CiMvcAlert")]
    public class CiMvcAlertTagHelper : TagHelper
    {
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext ViewContext { get; set; }

        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            if (ViewContext?.TempData != null)
            {
                var tempData = ViewContext.TempData;

                var msg = tempData["CiMvcAlert"]?.ToString();

                if (!msg.IsNullOrWhiteSpace())
                {
                    output.TagName = "script";

                    var script = $@"
                                    // start CiMvcAlert
                                    if (!(typeof bootbox === 'object')) {{
                                        console.log('%c Ci.Mvc.Alert require bootboxJs to run!','color:#FF0000;')
                                    }} else {{
                                        bootbox.alert('{tempData["CiMvcAlert"]}');
                                    }}
                                    // end CiMvcAlert
                                ";
                    output.PostContent.AppendHtml(script);
                }
            }
        }
    }
}
