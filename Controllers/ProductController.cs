using BaiTap_02_23WebC_Nhom10.Models;
using Microsoft.AspNetCore.Mvc;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index()
        {
            if (HttpContext.Items.TryGetValue("product", out var productStoreObj) && productStoreObj is ProductStore productStore)
            {
                var product = productStore.Products;
                return View(product);
            }
            return View("~/Views/Home/NotFound");
        }
        public IActionResult Detail(int id = 1)
        {
            if (HttpContext.Items.TryGetValue("product", out var productStoreObj) && productStoreObj is ProductStore productStore)
            {
                var product = productStore.Products.FirstOrDefault(p => p.MaSp == id);
                return View(product);
            }
            return View("~/Views/Home/NotFound");
        }
        public IActionResult Cart()
        {
            return View();
        }
    }
}
