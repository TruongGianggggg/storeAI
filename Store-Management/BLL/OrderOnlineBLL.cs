using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OrderOnlineBLL : BaseBLL
    {
        public OrderOnlineBLL() : base() { }

        public List<OrderOnlineDTO> GetData()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<DetailOrderOnlineDTO> GetDataDetail(string madh)
        {
            var query = from o in context.ChiTietDonHangs
                        join k in context.SanPhams
                        on o.MaSanPham equals k.MaSanPham
                        where o.MaDonHang.Equals(madh)
                        select new DetailOrderOnlineDTO
                        {
                            MaChiTietDonHang = o.MaChiTietDonHang,
                            MaDonHang = (int)o.MaDonHang,
                            MaSanPham = k.MaSanPham,
                            TenSanPham = k.TenSanPham,
                            GiaSanPham = (float)k.GiaGiam,
                            SoLuong = o.SoLuong,
                        };
            return query.ToList();
        }
        public void CapNhatDaXacNhan(int str, int manv)
        {
            var query = context.DonHangs.FirstOrDefault(q => q.MaDonHang == str);
            if (query != null)
            {
                query.TrangThai = "Đã Xác Nhận Đơn Hàng";
                query.MaNhanVien = manv;
                context.SubmitChanges();
            }
        }
        public void CapNhatChoLayHang(int str)
        {
            var query = context.DonHangs.FirstOrDefault(q => q.MaDonHang == str);
            if (query != null)
            {
                query.TrangThai = "Đang Lấy Hàng";
                context.SubmitChanges();
            }
        }
        public void CapNhatChoGiaoHang(int str)
        {
            var query = context.DonHangs.FirstOrDefault(q => q.MaDonHang == str);
            if (query != null)
            {
                query.TrangThai = "Đang Giao Hàng";
                context.SubmitChanges();
            }
        }
        public void CapNhatHoanTat(int str)
        {
            var query = context.DonHangs.FirstOrDefault(q => q.MaDonHang == str);
            if (query != null)
            {
                query.TrangThai = "Giao Hàng Thành Công";
                context.SubmitChanges();
            }
        }
        public List<OrderOnlineDTO> LocDangChoXuLy()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang chờ xử lý")
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDaXacNhanDonHang()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đã Xác Nhận Đơn Hàng")
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDangLayHang()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang Lấy Hàng")
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDangGiaoHang()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang Giao Hàng")
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocGiaoHangThanhCong()
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Giao Hàng Thành Công")
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> GetDataTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDangChoXuLyTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang chờ xử lý") && o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDaXacNhanDonHangTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đã Xác Nhận Đơn Hàng") && o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDangLayHangTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang Lấy Hàng") && o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocDangGiaoHangTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Đang Giao Hàng") && o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<OrderOnlineDTO> LocGiaoHangThanhCongTheoNgay(DateTime date)
        {
            var query = from o in context.DonHangs
                        join k in context.KhachHangs
                        on o.MaKhachHang equals k.MaKhachHang
                        where o.TrangThai.Equals("Giao Hàng Thành Công") && o.NgayDatHang.Day == date.Day
                        select new OrderOnlineDTO
                        {
                            MaDonHang = o.MaDonHang,
                            MaKhachHang = (int)o.MaKhachHang,
                            TenKhachHang = k.HoTenDem + " " + k.Ten,
                            NgayDatHang = o.NgayDatHang,
                            TongTien = o.TongTien,
                            TrangThai = o.TrangThai.Trim(),
                        };
            return query.ToList();
        }
        public List<PrintDetailOrderDTO> PrintDetailOrder(int madh)
        {
            var query = from o in context.ChiTietDonHangs
                        join k in context.SanPhams
                        on o.MaSanPham equals k.MaSanPham
                        where o.MaDonHang == madh
                        select new PrintDetailOrderDTO
                        {
                            Masp = k.MaSanPham,
                            Tensp = k.TenSanPham,
                            Gia = (float)k.GiaGiam,
                            Soluong = o.SoLuong,
                        };
            return query.ToList();
        }
        public string LayTenKhachHang(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select k.HoTenDem + " " + k.Ten).FirstOrDefault();

            return query ?? "Không tìm thấy";
        }
        public int LayMaKhachHang(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select k.MaKhachHang).FirstOrDefault();

            return query;
        }
        public string LaySdt(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select k.SoDienThoai).FirstOrDefault();

            return query ?? "Không tìm thấy";
        }
        public string LayDiaChi(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select k.DiaChi).FirstOrDefault();

            return query ?? "Không tìm thấy";
        }
        public DateTime LayNgayDat(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select o.NgayDatHang).FirstOrDefault();

            return query;
        }
        public decimal LayTongTien(int madh)
        {
            var query = (from o in context.DonHangs
                         join k in context.KhachHangs on o.MaKhachHang equals k.MaKhachHang
                         where o.MaDonHang == madh
                         select o.TongTien).FirstOrDefault();
            return query;
        }
        public string LayMaHoaDon(int madh)
        {
            var query = (from o in context.HoaDons
                         where o.MaDonHang == madh
                         select o.MaHoaDon).FirstOrDefault();
            return query;
        }
        public void ThemHoaDon(int madh, int manv, int makh, DateTime ngaylap, string tt, double tongtien)
        {
            context.ThemHoaDon(madh, manv, makh, ngaylap, tt, tongtien);
            context.SubmitChanges();
        }
        public List<ChiTietDonHang> ListCTDonHangToAddCTHoaDon(int madh)
        {
            return context.ChiTietDonHangs.Where(ct => ct.MaDonHang == madh).ToList();
        }
        public void ThemChiTietHoaDon(string mahd, int masp, int soluong)
        {
            ChiTietHoaDon cthdnew = new ChiTietHoaDon
            {
                MaHoaDon = mahd,
                MaSanPham = masp,
                SoLuong = soluong,
            };
            context.ChiTietHoaDons.InsertOnSubmit(cthdnew);
            context.SubmitChanges();
        }
    }
}
