using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.Controllers
{
    public class DefaultController1 : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
