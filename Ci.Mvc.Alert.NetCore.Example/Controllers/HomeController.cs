using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;

namespace Ci.Mvc.Alert.NetCore.Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.SetAlert("A quick way to show alert mseeage for aspnet mvc and aspnetcore mvc", "CiMvcAlert");
            return View();
        }
    }
}
