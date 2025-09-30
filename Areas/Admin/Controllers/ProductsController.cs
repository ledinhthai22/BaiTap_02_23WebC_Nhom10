using Microsoft.AspNetCore.Mvc;

namespace BaiTap_02_23WebC_Nhom10.Areas.Admin.Controllers
{
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _webHostEnvironment;
        public ProductsController(IWebHostEnvironment webHostEnvironment)
        {
            _webHostEnvironment = webHostEnvironment;
        }
        [Area("Admin")]
        public IActionResult Index()
        {
            return View();
        }
        [Area("Admin")]
        public IActionResult Create()
        {
            return View();
        }
    }
}
