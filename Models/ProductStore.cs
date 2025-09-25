namespace BaiTap_02_23WebC_Nhom10.Models
{
    public class ProductStore
    {
        public List<Product> Products { get; set; } = new List<Product>();

        public ProductStore() { }

        public ProductStore(List<Product> products)
        {
           Products = products;
        }

    }
}

