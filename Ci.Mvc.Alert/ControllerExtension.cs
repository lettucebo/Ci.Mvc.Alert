using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ci.Mvc.Alert
{
    public static class ControllerExtension
    {
        public static void SetAlert(this Controller controller, string message, string title = "")
        {
            controller.TempData["CiMvcAlertMsg"] = message;
            controller.TempData["CiMvcAlertTitle"] = title;
        }

    }
}
