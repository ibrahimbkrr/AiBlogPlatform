using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeaderComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
