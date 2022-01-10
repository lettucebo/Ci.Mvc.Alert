using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Ci.Mvc.Alert.Net.Example.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc", "CiMvcAlert");
            return View();
        }
    }
}