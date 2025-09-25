using System.Diagnostics;
using BaiTap_02_23WebC_Nhom10.Models;
using Microsoft.AspNetCore.Mvc;

namespace BaiTap_02_23WebC_Nhom10.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;

        public HomeController(ILogger<HomeController> logger)
        {
            _logger = logger;
        }

        public IActionResult Index()
        {
            if (HttpContext.Items.TryGetValue("product", out var productStoreObj) && productStoreObj is ProductStore productStore)
            {
                var products = productStore.Products;
                return View(products);
            }
            return View(new List<Product>());
        }

        public IActionResult Privacy()
        {
            if (HttpContext.Items.TryGetValue("product", out var productStoreObj) && productStoreObj is ProductStore productStore)
            {
                var latestProducts = productStore.Products;
                return View(latestProducts);
            }
            return View();
        }
        public IActionResult Checkout()
        {
            return View();
        }

        public IActionResult Contact()
        {
            return View();
        }
        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
