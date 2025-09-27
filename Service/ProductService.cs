using BaiTap_02_23WebC_Nhom10.Models;

namespace BaiTap_02_23WebC_Nhom10.Service
{
    public class ProductService
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductService() { }

        public ProductService(List<Product> products)
        {
            Products = products;
        }
    }
}
