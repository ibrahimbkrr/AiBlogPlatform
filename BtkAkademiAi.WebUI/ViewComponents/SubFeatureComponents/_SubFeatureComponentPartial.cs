using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.ViewComponents.SubFeatureComponents
{
    public class _SubFeatureComponentPartial:ViewComponent
    {
        public IViewComponentResult Invoke() 
        {
            return View();
        }
    }
}
