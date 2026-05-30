using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.BlogDetailComponents
{
    public class _BlogDetailBreadCrumbComponentPartial: ViewComponent
    {
        public IViewComponentResult Invoke()
        {
            return View();
        }
    }
}
