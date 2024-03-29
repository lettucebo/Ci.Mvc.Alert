﻿using System.Globalization;
using Microsoft.AspNetCore.Mvc;

namespace Ci.Mvc.Alert.Core
{
    public static class ControllerExtension
    {
        /// <summary>
        /// Set a new alert
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="message"></param>
        /// <param name="title"></param>
        public static void SetAlert(this Controller controller, string message, string title = "")
        {
            controller.TempData["CiMvcAlertMsg"] = message;
            controller.TempData["CiMvcAlertTitle"] = title;
        }

        /// <summary>
        /// Set a new error alert
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="message"></param>
        /// <param name="cultureInfo"></param>
        public static void SetErrorAlert(this Controller controller, string message, CultureInfo cultureInfo = null)
        {
            controller.TempData["CiMvcAlertMsg"] = message;
            if (cultureInfo != null && cultureInfo.Name.ToLower() == "en-us")
                controller.TempData["CiMvcAlertTitle"] = "Error";
            else
                controller.TempData["CiMvcAlertTitle"] = "錯誤";
        }

        /// <summary>
        /// Add alert message to existing message, create a new one if message does not exist.
        /// </summary>
        /// <param name="controller"></param>
        /// <param name="message"></param>
        public static void AddAlert(this Controller controller, string message)
        {
            if (controller.TempData["CiMvcAlertMsg"] == null)
                controller.TempData["CiMvcAlertMsg"] = string.Empty;

            controller.TempData["CiMvcAlertMsg"] += message;
        }

        public static void ClearAlert(this Controller controller)
        {
            controller.TempData["CiMvcAlertMsg"] = string.Empty;
            controller.TempData["CiMvcAlertTitle"] = string.Empty;
        }
    }
}
