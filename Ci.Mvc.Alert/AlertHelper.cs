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
            var message = helper.ViewContext.Controller.TempData["CiMvcAlertMsg"] as string;
            var title = helper.ViewContext.Controller.TempData["CiMvcAlertTitle"] as string;

            if (message.IsNullOrWhiteSpace() && title.IsNullOrWhiteSpace())
            {
                return MvcHtmlString.Empty;
            }

            string alert;
            if (!title.IsNullOrWhiteSpace())
            {
                alert = $@"bootbox.alert( 
                            {{
                                title: '{title}',
                                message: '{message}' 
                            }}
                        ); ";
            }
            else
            {
                alert = $@"bootbox.alert('{message}');";

            }

            var script = new TagBuilder("script");
            script.Attributes.Add("type", "text/javascript");
            script.InnerHtml = $@"
                                    // start CiMvcAlert
                                    if (!(typeof bootbox === 'object')) {{
                                        throw('Ci.Mvc.Alert require bootboxJs to run!')
                                    }} else {{
                                        {alert}
                                    }}
                                    // end CiMvcAlert
                                ";
            return MvcHtmlString.Create(script.ToString());
        }
    }
}
