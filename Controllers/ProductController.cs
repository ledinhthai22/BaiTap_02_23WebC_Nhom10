using BaiTap_02_23WebC_Nhom10.Models;
using Microsoft.AspNetCore.Mvc;
using BaiTap_02_23WebC_Nhom10.Service;
using PagedList;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 8)
        {
            if (HttpContext.Items.TryGetValue("product", out var productServiceObj) && productServiceObj is ProductService productService)
            {
                var product = productService.Products.ToList();
                var pagedProduct = product.Skip((page - 1) * pageSize).Take(pageSize).ToList();
                ViewBag.CurrentPage = page;
                ViewBag.TotalItems = product.Count;
                ViewBag.PageSize = pageSize;
                return View(pagedProduct);
            }
            return View("~/Views/Home/NotFound");
        }
        public IActionResult Detail(int id = 1)
        {
            if (HttpContext.Items.TryGetValue("product", out var productServiceObj) && productServiceObj is ProductService productService)
            {
                var product = productService.Products.FirstOrDefault(p => p.MaSp == id);
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
