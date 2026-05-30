using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutHeadComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
