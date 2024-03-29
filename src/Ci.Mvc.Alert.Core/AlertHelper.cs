﻿using System.Net;
using Ci.Extension.Core;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;

namespace Ci.Mvc.Alert.Core
{
    [HtmlTargetElement("cimvcalert")]
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

                var msg = tempData["CiMvcAlertMsg"]?.ToString();
                var title = tempData["CiMvcAlertTitle"]?.ToString();

                msg = WebUtility.HtmlEncode(msg);
                msg = msg?.Replace("&lt;br/&gt;", "<br/>").Replace("&lt;br&gt;", "<br/>");
                title = WebUtility.HtmlEncode(title);

                if (!msg.IsNullOrWhiteSpace() || !title.IsNullOrWhiteSpace())
                {
                    output.TagName = "script";
                    output.TagMode = TagMode.StartTagAndEndTag;
                    output.Attributes.Add("type", "text/javascript");

                    string alert;
                    if (!title.IsNullOrWhiteSpace())
                    {
                        alert = $@"bootbox.alert( 
                            {{
                                title: `{title}`,
                                message: `{msg}` 
                            }}
                        ); ";
                    }
                    else
                    {
                        alert = $@"bootbox.alert(`{msg}`);";

                    }

                    var script = $@"
                                    window.onload = function() {{
                                        // start CiMvcAlert
                                        if (!(typeof bootbox === 'object')) {{
                                            throw('Ci.Mvc.Alert require bootboxJs to run!');
                                        }} else {{
                                            {alert}
                                        }}
                                        // end CiMvcAlert
                                    }};
                                ";

                    output.Content.SetHtmlContent(script);
                }
            }
        }


    }
}
