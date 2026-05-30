using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.Controllers
{
    public class UILayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
    }
}
