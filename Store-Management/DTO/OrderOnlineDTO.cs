using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class OrderOnlineDTO
    {
        public int MaDonHang {  get; set; }
        public int MaKhachHang { get; set; }
        public string TenKhachHang { get; set; }
        public DateTime NgayDatHang { get; set; }
        public decimal TongTien { get; set; }
        public string TrangThai { get; set; }
    }
}
