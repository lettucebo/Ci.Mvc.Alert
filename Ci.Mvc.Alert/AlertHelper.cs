using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using System.Web.Routing;
using Ci.Extension;

namespace Ci.Mvc.Alert
{
    public static class AlertHelper
    {
        public static MvcHtmlString ShowAlert(this HtmlHelper helper)
        {
            var message = helper.ViewContext.Controller.TempData["CiMvcAlert"];

            if (message == null || message.ToString().IsNullOrWhiteSpace())
            {
                return MvcHtmlString.Empty;
            }

            var script = new TagBuilder("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = $@"
                                    // start CiMvcAlert
                                    if (!(typeof bootbox === 'object')) {{
                                        throw('Ci.Mvc.Alert require bootboxJs to run!')
                                    }} else {{
                                        bootbox.alert('{message}');
                                    }}
                                    // end CiMvcAlert
                                ";
            return MvcHtmlString.Create(script.ToString());
        }
    }
}
