using System.Text.Json;
using BaiTap_03_23WebC_Nhom10.Models;

namespace BaiTap_03_23WebC_Nhom10.Middleware
{
    public class ProductMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly IWebHostEnvironment _env;

        public ProductMiddleware(RequestDelegate next, IWebHostEnvironment env)
        {
            _next = next;
            _env = env;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            var dbPath = Path.Combine(_env.WebRootPath, "data", "db.json");
            List<Product> products = new();

            if (File.Exists(dbPath))
            {
                try
                {
                    var json = await File.ReadAllTextAsync(dbPath);
                    using var doc = JsonDocument.Parse(json);

                    if (doc.RootElement.TryGetProperty("products", out var productsEl))
                    {
                        products = JsonSerializer.Deserialize<List<Product>>(productsEl.GetRawText(),
                            new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Product>();
                    }
                }
                catch
                {
                    products = new List<Product>();
                }
            }

            // Lưu danh sách sản phẩm
            context.Items["products"] = products;

            await _next(context);
        }

    }
}
