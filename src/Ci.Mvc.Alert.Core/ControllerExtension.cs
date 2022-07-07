using Microsoft.AspNetCore.Mvc;

namespace Ci.Mvc.Alert.Core
{
    public static class ControllerExtension
    {
        public static void SetAlert(this Controller controller, string message, string title = "")
        {
            controller.TempData["CiMvcAlertMsg"] = message;
            controller.TempData["CiMvcAlertTitle"] = title;
        }

        public static void ClearAlert(this Controller controller)
        {
            controller.TempData["CiMvcAlertMsg"] = string.Empty;
            controller.TempData["CiMvcAlertTitle"] = string.Empty;
        }
    }
}
