using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.LayoutComponents
{
    public class _LayoutFooterComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
