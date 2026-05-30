using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.DefaultComponents
{
    public class _DefaultLatestPostComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
