using Microsoft.AspNetCore.Mvc;
namespace Ci.Mvc.Alert.Core
{
    public static class ControllerExtension
    {
        public static void SetAlert(this Controller controller, string message)
        {
            controller.TempData["CiMvcAlert"] = message;
        }
    }
}
