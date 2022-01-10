﻿using Microsoft.AspNetCore.Mvc;

namespace Ci.Mvc.Alert.Core
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
