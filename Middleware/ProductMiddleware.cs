using System.Text.Json;
using BaiTap_02_23WebC_Nhom10.Models;

namespace BaiTap_02_23WebC_Nhom10.Middleware
{
    public class ProductMiddleware
    {
        private readonly RequestDelegate _next;

        public ProductMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            string filePath = Path.Combine(Directory.GetCurrentDirectory(), "db.json");
            List<Product> products = new List<Product>();

            if (File.Exists(filePath))
            {
                string json = await File.ReadAllTextAsync(filePath);
                using var doc = JsonDocument.Parse(json);
                var root = doc.RootElement;

                if (root.TryGetProperty("products", out JsonElement productsElement))
                {
                    products = JsonSerializer.Deserialize<List<Product>>(productsElement.GetRawText()) ?? new List<Product>();
                }

                context.Items["product"] = new ProductStore(products);
            }

            await _next(context);
        }
    }
}
