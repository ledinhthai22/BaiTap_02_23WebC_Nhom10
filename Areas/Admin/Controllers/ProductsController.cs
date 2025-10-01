using Microsoft.AspNetCore.Mvc;

namespace BaiTap_02_23WebC_Nhom10.Areas.Admin.Controllers
{
    [Area("Admin")]
    public class ProductsController : Controller
    {  
        public IActionResult Index()
        {
            return View();
        }
    }
}
