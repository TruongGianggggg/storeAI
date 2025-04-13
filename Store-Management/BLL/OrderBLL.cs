using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class OrderBLL : BaseBLL
    {
        public OrderBLL() : base() { }
        public List<BillOfflineDTO> GetDataHoaDonChuaThanhToan()
        {
            try
            {
                var query = (from hd in context.HoaDonOfflines
                             where hd.TrangThai == "Chưa thanh toán"
                             join nv in context.NhanViens on hd.MaNhanVien equals nv.MaNhanVien
                             select new BillOfflineDTO
                             {
                                 idhoadon = hd.MaHoaDon,
                                 tennhanvien = nv.HoTen,
                                 ngaylap = (DateTime)hd.NgayLap,
                                 trangthai = hd.TrangThai,
                                 tongtien = (double)hd.TongTien
                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<DetailBillOfflineDTO> GetDataChiTietHoaDon(string mahd)
        {
            try
            {
                var query = (from hd in context.ChiTietHoaDonOfflines
                             join sp in context.SanPhams on hd.MaSanPham equals sp.MaSanPham
                             where hd.MaHoaDon == mahd
                             select new DetailBillOfflineDTO
                             {
                                 MaChiTietHoaDon = hd.MaChiTietHoaDon,
                                 MaHoaDon = hd.MaHoaDon,
                                 TenSanPham = sp.TenSanPham,
                                 SoLuong = hd.SoLuong,
                             }).ToList();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public void ThemHoaDon(int idnv, DateTime ngaylap)
        {
            context.ThemHoaDonOffline(idnv, ngaylap);
            context.SubmitChanges();
        }
        public string getTenNhanVien(int idnv)
        {
            var query = from nv in context.NhanViens where nv.MaNhanVien == idnv select nv.HoTen;
            return query.FirstOrDefault()?.ToString();
        }
        public void ThemChiTietHoaDon(string mahd, int masp, int soluong)
        {
            context.ThemChiTietHoaDonOffline(mahd, masp, soluong);
            context.SubmitChanges();
        }
        public double TinhTongTienHoaDon(string mahd)
        {
            var query = from hoaDon in context.HoaDonOfflines
                        join chiTietHoaDon in context.ChiTietHoaDonOfflines on hoaDon.MaHoaDon equals chiTietHoaDon.MaHoaDon
                        join sanPham in context.SanPhams on chiTietHoaDon.MaSanPham equals sanPham.MaSanPham
                        where hoaDon.MaHoaDon == mahd
                        group new { chiTietHoaDon, sanPham } by new { hoaDon.MaHoaDon, hoaDon.MaNhanVien, hoaDon.NgayLap, hoaDon.TrangThai } into grouped
                        select new
                        {
                            TongTien = grouped.Sum(x => x.chiTietHoaDon.SoLuong * x.sanPham.GiaGiam)
                        };

            var result = query.ToList();
            return result.FirstOrDefault()?.TongTien ?? 0.0;
        }

        public List<string> GetDanhSachTenDanhMuc()
        {
            try
            {
                var query = (from danhMuc in context.DanhMucSanPhams
                             select danhMuc.TenDanhMuc).ToList();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<string> GetDanhSachTenThuongHieu()
        {
            try
            {
                var query = (from danhMuc in context.ThuongHieus select danhMuc.TenThuongHieu).ToList();
                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<string> GetDistinctXuatXuList()
        {
            try
            {
                var query = context.SanPhams
                        .Select(sanPham => sanPham.XuatXu)
                        .Distinct()
                        .ToList();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<string> GetDanhSachGioiTinhSanPham()
        {
            try
            {
                var query = context.SanPhams
                        .Select(sanPham => sanPham.GioiTinh)
                        .Distinct()
                        .ToList();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void XoaChiTietHoaDonOffline(int maChiTietHoaDon)
        {
            try
            {
                var query = context.ChiTietHoaDonOfflines
                        .SingleOrDefault(cthd => cthd.MaChiTietHoaDon == maChiTietHoaDon);

                if (query != null)
                {
                    context.ChiTietHoaDonOfflines.DeleteOnSubmit(query);
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public double LayGiaGiam(string tensp, int macthd)
        {
            try
            {
                var query = (from cthd in context.ChiTietHoaDonOfflines
                             join sp in context.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                             where sp.TenSanPham == tensp && cthd.MaChiTietHoaDon == macthd
                             select sp.GiaGiam).SingleOrDefault();

                return query;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }
        public void SuaSoLuongChiTietHoaDonOffline(int maChiTietHoaDon, int soLuongMoi)
        {
            try
            {
                var query = context.ChiTietHoaDonOfflines
                        .FirstOrDefault(cthd => cthd.MaChiTietHoaDon == maChiTietHoaDon);

                if (query != null)
                {
                    query.SoLuong = soLuongMoi;
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public string GetMaHoaDonDauTienChuaThanhToan()
        {
            try
            {
                var query = context.HoaDonOfflines
                    .Where(hd => hd.TrangThai == "Chưa thanh toán")
                    .OrderBy(hd => hd.MaHoaDon)
                    .FirstOrDefault();

                return query?.MaHoaDon.ToString() ?? string.Empty;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public int GetSoLuongSanPhamTrongKho(string masp)
        {
            var query = from kh in context.KhoHangs where kh.MaSanPham.Equals(masp) select kh.SoLuongTonKho;
            return query.FirstOrDefault() ?? 0;
        }

        public string GetIdSanPhamByTen(string tensp)
        {
            var query = from kh in context.SanPhams where kh.TenSanPham.Equals(tensp) select kh.MaSanPham;
            return query.FirstOrDefault().ToString();
        }

        public void TinhTongTien(string mahd)
        {
            context.TinhTongTienHoaDonOffline(mahd);
        }

        public double GetTongTienHoaDon(string mahd)
        {
            var query = from hd in context.HoaDonOfflines where hd.MaHoaDon.Equals(mahd) select hd.TongTien;
            return query.FirstOrDefault() ?? 0;
        }

        //public decimal TinhTongTienHoaDonOffline(string maHoaDon)
        //{
        //    var query = from ct in context.ChiTietHoaDonOfflines
        //                join sp in context.SanPhams on ct.MaSanPham equals sp.MaSanPham
        //                where ct.MaHoaDon == maHoaDon
        //                select (decimal)(sp.GiaGiam * ct.SoLuong);

        //    decimal tongTien = query.Sum();
        //    var hoaDonOffline = context.HoaDonOfflines.FirstOrDefault(hd => hd.MaHoaDon == maHoaDon);
        //    if (hoaDonOffline != null)
        //    {
        //        hoaDonOffline.TongTien = (double)tongTien;
        //        context.SubmitChanges();
        //    }

        //    return tongTien;
        //}

        public int SoLuongTrongBangHoaDonChiTiet(string tensp)
        {
            var query = from cthd in context.ChiTietHoaDonOfflines
                        where tensp.Equals(tensp)
                        select cthd.SoLuong;
            return query?.FirstOrDefault() ?? 0;
        }

        public int SoLuongTrongKhoHang(string tensp)
        {
            var query = from kh in context.KhoHangs
                        where tensp.Equals(tensp)
                        select kh.SoLuongTonKho;
            return query?.FirstOrDefault() ?? 0;
        }

        public List<PrintBillDTO> InBill(string mahd)
        {
            var query = from cthd in context.ChiTietHoaDonOfflines
                        join sp in context.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                        where cthd.MaHoaDon.Equals(mahd)
                        select new PrintBillDTO
                        {
                            tensp = sp.TenSanPham,
                            giasp = sp.GiaGiam,
                            soluong = cthd.SoLuong
                        };
            return query.ToList();
        }

        public void CapNhatSoLuongSanPhamKhoHangGiamXuong(string mahd)
        {
            var query = from ct in context.ChiTietHoaDonOfflines
                        where ct.MaHoaDon == mahd
                        group ct by ct.MaSanPham into g
                        select new { MaSanPham = g.Key, TongSoLuong = g.Sum(x => x.SoLuong) };

            foreach (var item in query)
            {
                var sanphamtrongkhohang = context.KhoHangs.SingleOrDefault(kh => kh.MaSanPham == item.MaSanPham);
                if (sanphamtrongkhohang != null)
                    sanphamtrongkhohang.SoLuongTonKho -= item.TongSoLuong;
            }

            context.SubmitChanges();
        }

        public void CapNhatSoLuongSanPhamKhoHangTangLen(string mahd)
        {
            var query = from ct in context.ChiTietHoaDonOfflines
                        where ct.MaHoaDon == mahd
                        group ct by ct.MaSanPham into g
                        select new { MaSanPham = g.Key, TongSoLuong = g.Sum(x => x.SoLuong) };

            foreach (var item in query)
            {
                var sanphamtrongkhohang = context.KhoHangs.SingleOrDefault(kh => kh.MaSanPham == item.MaSanPham);
                if (sanphamtrongkhohang != null)
                    sanphamtrongkhohang.SoLuongTonKho += item.TongSoLuong;
            }

            context.SubmitChanges();
        }

        public bool KiemTraBangCTHD(string mahd)
        {
            var query = from cthd in context.ChiTietHoaDonOfflines where cthd.MaHoaDon == mahd select cthd;
            if (query != null)
                return true;
            else
                return false;
        }

        public void XoaHoaDon(string maHoaDon)
        {
            var hoaDonToDelete = context.HoaDonOfflines.SingleOrDefault(hd => hd.MaHoaDon == maHoaDon);

            if (hoaDonToDelete != null)
            {
                context.HoaDonOfflines.DeleteOnSubmit(hoaDonToDelete);
                context.SubmitChanges();
            }
        }

        public void XoaCTHoaDon(string maHoaDon)
        {
            var chiTietToDelete = context.ChiTietHoaDonOfflines.Where(ct => ct.MaHoaDon == maHoaDon);

            if (chiTietToDelete.Any())
            {
                context.ChiTietHoaDonOfflines.DeleteAllOnSubmit(chiTietToDelete);
                context.SubmitChanges();
            }
        }

        public void CapNhatSanPhamTrongKhoHang(string masp, int soluong)
        {
            var newsoluong = context.KhoHangs.SingleOrDefault(kh => kh.MaSanPham == int.Parse(masp));
            if (newsoluong != null)
            {
                newsoluong.SoLuongTonKho = soluong;
                context.SubmitChanges();
            }
        }

        public void CapNhatTrangThaiDonHang(string mahd, double tongtien)
        {
            context.CapNhatHoaDonOffline(mahd, tongtien);
            context.SubmitChanges();
        }
    }
}
