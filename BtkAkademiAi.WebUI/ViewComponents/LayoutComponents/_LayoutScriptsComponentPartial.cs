using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;

namespace BtkAkademiAi.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutScriptsComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
