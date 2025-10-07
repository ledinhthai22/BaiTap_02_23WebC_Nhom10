using System.Text.Json;
using BaiTap_03_23WebC_Nhom10.Models;

namespace BaiTap_03_23WebC_Nhom10.Service
{
    public class ProductService
    {
        private readonly string _dbPath;
        private readonly object _lock = new object();

        public List<Product> Products { get; private set; } = new List<Product>();

        public ProductService(string dbPath)
        {
            _dbPath = dbPath;
            LoadFromFile();
        }

        private void LoadFromFile()
        {
            if (!File.Exists(_dbPath))
            {
                
                Products = new List<Product>();
                SaveToFile();
                return;
            }

            var json = File.ReadAllText(_dbPath);
            try
            {
                if (string.IsNullOrWhiteSpace(json))
                {
                    Products = new List<Product>();
                    return;
                }

                using var doc = JsonDocument.Parse(json);
                if (doc.RootElement.TryGetProperty("products", out var productsEl))
                {
                    Products = JsonSerializer.Deserialize<List<Product>>(productsEl.GetRawText(),
                        new JsonSerializerOptions { PropertyNameCaseInsensitive = true }) ?? new List<Product>();
                }
                else
                {
                    Products = new List<Product>();
                }
            }
            catch
            {
                
                Products = new List<Product>();
            }
        }
        private void SaveToFile()
        {
            lock (_lock)
            {
                var wrapper = new { products = Products };
                var options = new JsonSerializerOptions { WriteIndented = true };
                File.WriteAllText(_dbPath, JsonSerializer.Serialize(wrapper, options));
            }
        }

        public IEnumerable<Product> GetAll() => Products;

        public Product? GetById(int id) => Products.FirstOrDefault(p => p.MaSp == id);

        public void Add(Product p)
        {
            p.MaSp = Products.Any() ? Products.Max(x => x.MaSp) + 1 : 1;
            Products.Add(p);
            SaveToFile();
        }
    }
}
