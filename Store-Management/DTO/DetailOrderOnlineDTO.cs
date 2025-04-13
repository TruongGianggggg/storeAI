using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class DetailOrderOnlineDTO
    {
        public int MaChiTietDonHang {  get; set; }  
        public int MaDonHang { get; set; }
        public int MaSanPham {  get; set; }
        public string TenSanPham {  set; get; }
        public float GiaSanPham { set; get; }
        public int SoLuong { get; set; }
    }
}
