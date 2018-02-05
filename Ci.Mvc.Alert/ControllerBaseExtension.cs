using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace Ci.Mvc.Alert
{
    public static class ControllerBaseExtension
    {
        public static void SetAlert(this ControllerBase controller, string message)
        {
            controller.TempData["CiMvcAlert"] = message;
        }
    }
}
