using Ci.Mvc.Alert.Core;
using Microsoft.AspNetCore.Mvc;

namespace Ci.Mvc.Alert.Core2.Example.Controllers
{
    public class HomeController : Controller
    {
        public IActionResult Index()
        {
            this.SetAlert("A quick way to show alert message for aspnet mvc and aspnetcore mvc", "CiMvcAlert");
            return View();
        }
    }
}
