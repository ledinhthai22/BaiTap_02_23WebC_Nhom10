using Newtonsoft.Json;

namespace BaiTap_02_23WebC_Nhom10.Models
{
    public class ProductData
    {
        [JsonProperty("products")]
        public List<Product> Products { get; set; }
    }
    public class Product
    {
        public int MaSp { get; set; }
        public string TenSp { get; set; }
        public double DonGia { get; set; }
        public double DonGiaKhuyenMai { get; set; }
        public string HinhAnh { get; set; }
        public string MoTa { get; set; }
        public string LoaiSp { get; set; }
    }
}
