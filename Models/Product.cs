using System.ComponentModel.DataAnnotations;
using System.Text.Json.Serialization;
using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;


namespace BaiTap_03_23WebC_Nhom10.Models
{
    public class Product
    {
        public int MaSp { get; set; }

        [Required]
        public string? TenSp { get; set; }

        [Range(0, double.MaxValue)]
        public double DonGia { get; set; }

        [Range(0, 1)]
        public double DonGiaKhuyenMai { get; set; }

        public string? HinhAnh { get; set; }

        public string? MoTa { get; set; }

        public string? LoaiSp { get; set; }
    }
}
