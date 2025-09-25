using Microsoft.AspNetCore.Mvc;

namespace BaiTap_02_23WebC_Nhom10.Areas.Admin.Controllers
{
    public class HomeController : Controller
    {
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
    }
}
