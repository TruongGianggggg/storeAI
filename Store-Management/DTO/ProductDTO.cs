using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DTO
{
    public class ProductDTO
    {
        private string tenSanPham;
        private string gioiTinh;
        private string xuatXu;
        private string moTa;
        private double giaGoc;
        private double giaGiam;
        private string tenDanhMuc;
        private string tenThuongHieu;

        public string TenSanPham { get => tenSanPham; set => tenSanPham = value; }
        public string GioiTinh { get => gioiTinh; set => gioiTinh = value; }
        public string XuatXu { get => xuatXu; set => xuatXu = value; }
        public string MoTa { get => moTa; set => moTa = value; }
        public double GiaGoc { get => giaGoc; set => giaGoc = value; }
        public double GiaGiam { get => giaGiam; set => giaGiam = value; }
        public string TenDanhMuc { get => tenDanhMuc; set => tenDanhMuc = value; }
        public string TenThuongHieu { get => tenThuongHieu; set => tenThuongHieu = value; }
    }

}
