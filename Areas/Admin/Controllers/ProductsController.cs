// Bổ sung đầy đủ các using cần thiết ở đầu file
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using System.Text.Json.Serialization;
using BaiTap_02_23WebC_Nhom10.Models;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http; // Cần thiết cho IFormFile
using Microsoft.AspNetCore.Mvc;
using BaiTap_02_23WebC_Nhom10.Service;

namespace BaiTap_02_23WebC_Nhom10.Areas.Admin.Controllers
{
    [Area("Admin")]
    [Route("Admin/[controller]")]
    public class ProductsController : Controller
    {
        private readonly IWebHostEnvironment _env;
        private readonly ProductService _productService;

        public ProductsController(IWebHostEnvironment env, ProductService productService)
        {
            _env = env;
            _productService = productService;
        }
        [HttpGet("")]
        public IActionResult Index()
        {
            var list = _productService.GetAll();
            return View(list);
        }
        [HttpGet("tao-san-pham")]

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost("tao-san-pham")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(Product product, IFormFile? HinhAnhFile)
        {
            if (!ModelState.IsValid)
            {
                return View(product);
            }

            if (HinhAnhFile != null && HinhAnhFile.Length > 0)
            {
                var uploads = Path.Combine(_env.WebRootPath, "img");
                if (!Directory.Exists(uploads)) Directory.CreateDirectory(uploads);

                var fileName = $"{Guid.NewGuid()}{Path.GetExtension(HinhAnhFile.FileName)}";
                var filePath = Path.Combine(uploads, fileName);

                using var stream = new FileStream(filePath, FileMode.Create);
                await HinhAnhFile.CopyToAsync(stream);

                product.HinhAnh = Path.Combine(fileName).Replace("\\", "/");

            }

            _productService.Add(product);
            return RedirectToAction("Index");
        }
    }
}