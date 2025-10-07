using BaiTap_03_23WebC_Nhom10.Models;
using Microsoft.AspNetCore.Mvc;
using BaiTap_03_23WebC_Nhom10.Service;
using PagedList;

namespace WebApplication1.Controllers
{
    public class ProductController : Controller
    {
        public IActionResult Index(int page = 1, int pageSize = 8)
        {
            if (HttpContext.Items.TryGetValue("products", out var productsObj) && productsObj is IEnumerable<Product> products)
            {
                var productList = products.ToList();
                var pagedProduct = productList.Skip((page - 1) * pageSize).Take(pageSize).ToList();

                ViewBag.CurrentPage = page;
                ViewBag.TotalItems = productList.Count;
                ViewBag.PageSize = pageSize;

                return View(pagedProduct);
            }
            return View("~/Views/Home/NotFound.cshtml"); 
        }

        public IActionResult Detail(int id = 1)
        {
            if (HttpContext.Items.TryGetValue("products", out var productsObj) && productsObj is IEnumerable<Product> products)
            {
                var product = products.FirstOrDefault(p => p.MaSp == id);
                if (product == null) return View("~/Views/Home/NotFound.cshtml");
                return View(product);
            }
            return View("~/Views/Home/NotFound.cshtml");
        }

        public IActionResult Cart()
        {
            return View();
        }
    }
}
