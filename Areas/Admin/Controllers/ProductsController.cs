// Bổ sung đầy đủ các using cần thiết ở đầu file
using Microsoft.AspNetCore.Mvc;
using System.Text.Json;
using BaiTap_02_23WebC_Nhom10.Models;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Hosting;
using System.IO;
using System.Linq;
using System;
using System.Collections.Generic;
using Microsoft.AspNetCore.Http; // Cần thiết cho IFormFile

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