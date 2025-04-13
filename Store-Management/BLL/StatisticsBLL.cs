using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class StatisticsBLL : BaseBLL
    {
        public StatisticsBLL() : base() { }

        public string LayHoTenNhanVienTuTaiKhoan(string taiKhoan)
        {
            string hoTen = context.TaiKhoanNhanViens
                .Where(tk => tk.TaiKhoan == taiKhoan)
                .Join(context.NhanViens, tk => tk.MaNhanVien, nv => nv.MaNhanVien, (tk, nv) => nv.HoTen)
                .FirstOrDefault();

            return hoTen ?? "Không tìm thấy";
        }

        public List<HoaDonOnlineDTO> GetDataHoaDonOnline()
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán"
                        select new HoaDonOnlineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public List<HoaDonOfflineDTO> GetDataHoaDonOffline()
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán"
                        select new HoaDonOfflineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }

        //-----------------------------------Theo ngày

        public List<HoaDonOnlineDTO> SearchHoaDonOnlineTheoNgay(DateTime date)
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Day == date.Day
                        select new HoaDonOnlineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public List<HoaDonOfflineDTO> SearchHoaDonOfflineTheoNgay(DateTime date)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Day == date.Day
                        select new HoaDonOfflineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public int SoLuongHoaDonOnline(DateTime date)
        {
            int soLuongHoaDon = context.HoaDons
                .Where(hd => hd.NgayLap.Value.Day == date.Day)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOnline(DateTime date)
        {
            decimal tongGiaTri = context.HoaDons
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Day == date.Day)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }
        public int SoLuongHoaDonOffline(DateTime date)
        {
            int soLuongHoaDon = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.Value.Day == date.Day)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOffline(DateTime date)
        {
            decimal tongGiaTri = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Day == date.Day)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }


        //-----------------------------------Theo tháng

        public List<HoaDonOnlineDTO> SearchHoaDonOnlineTheoThang(int month)
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Month == month
                        select new HoaDonOnlineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public List<HoaDonOfflineDTO> SearchHoaDonOfflineTheoThang(int month)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Month == month
                        select new HoaDonOfflineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public int SoLuongHoaDonOnlineTheoThang(int month)
        {
            int soLuongHoaDon = context.HoaDons
                .Where(hd => hd.NgayLap.Value.Month == month)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOnlineTheoThang(int month)
        {
            decimal tongGiaTri = context.HoaDons
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Month == month)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }
        public int SoLuongHoaDonOfflineTheoThang(int month)
        {
            int soLuongHoaDon = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.Value.Month == month)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOfflineTheoThang(int month)
        {
            decimal tongGiaTri = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Month == month)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }

        //-----------------------------------Theo quý

        public List<HoaDonOnlineDTO> SearchHoaDonOnlineTheoQuy(int quarter)
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" &&
                        (hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                        select new HoaDonOnlineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public List<HoaDonOfflineDTO> SearchHoaDonOfflineTheoQuy(int quarter)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" &&
                        (hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                        select new HoaDonOfflineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public int SoLuongHoaDonOnlineTheoQuy(int quarter)
        {
            int soLuongHoaDon = context.HoaDons
                .Where(hd => hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOnlineTheoQuy(int quarter)
        {
            decimal tongGiaTri = context.HoaDons
                .Where(hd => hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }
        public int SoLuongHoaDonOfflineTheoQuy(int quarter)
        {
            int soLuongHoaDon = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOfflineTheoQuy(int quarter)
        {
            decimal tongGiaTri = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.Value.Month >= (quarter - 1) * 3 + 1 && hd.NgayLap.Value.Month <= quarter * 3)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }

        //-----------------------------------Theo năm

        public List<HoaDonOnlineDTO> SearchHoaDonOnlineTheoNam(int year)
        {
            var query = from hd in context.HoaDons
                        join kh in context.KhachHangs on hd.MaKhachHang equals kh.MaKhachHang
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Year == year
                        select new HoaDonOnlineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Tenkh = kh.HoTenDem + " " + kh.Ten,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public List<HoaDonOfflineDTO> SearchHoaDonOfflineTheoNam(int year)
        {
            var query = from hd in context.HoaDonOfflines
                        join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                        where hd.TrangThai == "Đã Thanh Toán" && hd.NgayLap.Value.Year == year
                        select new HoaDonOfflineDTO
                        {
                            Mahd = hd.MaHoaDon,
                            Tennv = nv.HoTen,
                            Ngaylap = (DateTime)hd.NgayLap,
                            Tongtien = (decimal)hd.TongTien,
                            Trangthai = hd.TrangThai
                        };
            return query.ToList();
        }
        public int SoLuongHoaDonOnlineTheoNam(int year)
        {
            int soLuongHoaDon = context.HoaDons
                .Where(hd => hd.NgayLap.Value.Year == year)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOnlineTheoNam(int year)
        {
            decimal tongGiaTri = context.HoaDons
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Year == year)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }
        public int SoLuongHoaDonOfflineTheoNam(int year)
        {
            int soLuongHoaDon = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.Value.Year == year)
                .Count();
            return soLuongHoaDon;
        }
        public decimal DoanhThuOfflineTheoNam(int year)
        {
            decimal tongGiaTri = context.HoaDonOfflines
                .Where(hd => hd.NgayLap.HasValue && hd.NgayLap.Value.Year == year)
                .Sum(hd => (decimal?)hd.TongTien) ?? 0;

            return tongGiaTri;
        }
    }
}
