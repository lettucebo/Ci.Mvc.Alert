using System.Web.Mvc;

namespace Ci.Mvc.Alert
{
    public static class ControllerBaseExtension
    {
        public static void SetAlert(this ControllerBase controller, string message, string title = "")
        {
            controller.TempData["CiMvcAlertMsg"] = message;
            controller.TempData["CiMvcAlertTitle"] = title;
        }
    }
}
