using Microsoft.AspNetCore.Mvc;

namespace BtkAkademiAi.WebUI.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class AdminCommentController : Controller
    {
        public IActionResult CommentList()
        {
            return View();
        }
    }
}
