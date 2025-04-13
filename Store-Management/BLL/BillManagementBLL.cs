using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class BillManagementBLL : BaseBLL
    {
        public BillManagementBLL() : base() { }

        public List<HoaDonOfflineBillManagementDTO> LoadHoaDonOffline()
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán"
                        select new HoaDonOfflineBillManagementDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tenv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Trangthai = hd.TrangThai,
                            Tongtien = (double)hd.TongTien,
                        };
            return query.ToList();
        }

        public List<ChiTietHoaDonOfflineBillManagementDTO> LoadChiTietHoaDonOffline(string mahd)
        {
            var query = from hd in context.ChiTietHoaDonOfflines
                        join sp in context.SanPhams on hd.MaSanPham equals sp.MaSanPham
                        where hd.MaHoaDon == mahd
                        select new ChiTietHoaDonOfflineBillManagementDTO
                        {
                            Stt = hd.MaChiTietHoaDon,
                            Mahd = hd.MaHoaDon,
                            Tensp = sp.TenSanPham,
                            Soluong = hd.SoLuong,
                        };
            return query.ToList();
        }

        public int TinhTongSoLuongByMaHoaDon(string maHoaDon)
        {
            var tongSoLuong = context.ChiTietHoaDonOfflines
                                    .Where(ct => ct.MaHoaDon == maHoaDon)
                                    .Sum(ct => ct.SoLuong);
            return tongSoLuong;
        }

        public List<HoaDonOfflineBillManagementDTO> SearchHoaDonOffline(string str)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.MaHoaDon.Contains(str)
                        select new HoaDonOfflineBillManagementDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tenv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Trangthai = hd.TrangThai,
                            Tongtien = (double)hd.TongTien,
                        };
            return query.ToList();
        }

        public List<HoaDonOfflineBillManagementDTO> SearchHoaDonOfflineTenNV(string str)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where nv.HoTen.Contains(str)
                        select new HoaDonOfflineBillManagementDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tenv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Trangthai = hd.TrangThai,
                            Tongtien = (double)hd.TongTien,
                        };
            return query.ToList();
        }

        public List<HoaDonBillManagementDTO> LayDanhSachHoaDonOnline()
        {
            var query = from hd in context.HoaDons
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        select new HoaDonBillManagementDTO
                        {
                            Mahoadon = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Trangthai = hd.TrangThai,
                            Tongtien = (decimal)hd.TongTien,
                        };
            return query.ToList();
        }

        public List<ChiTietHoaDonOnlineBillManagementDTO> LayDanhSachCTHDOnline(string mahd)
        {
            var query = from hd in context.ChiTietHoaDons
                        join nv in context.SanPhams on hd.MaSanPham equals nv.MaSanPham
                        where hd.MaHoaDon == mahd
                        select new ChiTietHoaDonOnlineBillManagementDTO
                        {
                            MaCTHD = hd.MaChiTietHoaDon,
                            MaHD = hd.MaHoaDon,
                            Tensp = nv.TenSanPham,
                            Soluong = hd.SoLuong
                        };
            return query.ToList();
        }
    }
}
