using System.Net;
using System.Web.Mvc;
using Ci.Extension;

namespace Ci.Mvc.Alert
{
    public static class AlertHelper
    {
        public static MvcHtmlString ShowAlert(this HtmlHelper helper)
        {
            var message = helper.ViewContext.Controller.TempData["CiMvcAlertMsg"] as string;
            var title = helper.ViewContext.Controller.TempData["CiMvcAlertTitle"] as string;

            message = WebUtility.HtmlEncode(message);
            message = message?.Replace("&lt;br/&gt;", "<br/>").Replace("&lt;br&gt;", "<br/>");
            title = WebUtility.HtmlEncode(title);

            if (message.IsNullOrWhiteSpace() && title.IsNullOrWhiteSpace())
            {
                return MvcHtmlString.Empty;
            }

            string alert;
            if (!title.IsNullOrWhiteSpace())
            {
                alert = $@"bootbox.alert( 
                            {{
                                title: `{title}`,
                                message: `{message}` 
                            }}
                        ); ";
            }
            else
            {
                alert = $@"bootbox.alert(`{message}`);";

            }

            var script = new TagBuilder("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = $@"
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
            return MvcHtmlString.Create(script.ToString());
        }
    }
}
