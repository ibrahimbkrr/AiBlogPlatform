using BtkAkademiAi.WebUI.Dtos.CategoryDtos;
using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.Controllers
{
    public class AdminLayoutController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }

   
    }
}