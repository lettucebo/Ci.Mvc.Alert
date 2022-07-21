using System.Text;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;

namespace Ci.Mvc.Alert.Core.Example.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            this.SetAlert("A quick way to show alert message for aspnet mvc and aspnetcore mvc <br>", "CiMvcAlert");
            return View();
        }

        public IActionResult AddAlert()
        {
            this.AddAlert("Line01<br/>");
            this.AddAlert("Line02<br/>");
            return View();
        }

        public IActionResult Redirect()
        {
            // this.SetAlert("Redirect message", "Redirect alert");

            var sb = new StringBuilder();
            sb.AppendLine("Test1<br/>");
            sb.AppendLine("Test2<br/>");
            this.SetAlert(sb.ToString(), "Redirect alert");
            return RedirectToAction("Result", "Home");
        }

        public IActionResult Result()
        {
            return View();
        }
    }
}
