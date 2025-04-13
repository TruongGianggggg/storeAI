using DTO;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ProductBLL : BaseBLL
    {
        public ProductBLL() : base() { }

        public List<ProductDTO> getDanhSachSanPham()
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> getDanhSachSanPhamDescending()
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        orderby sp.MaSanPham descending
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham()
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham_TimKiem(string tensp)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        where sp.TenSanPham.Equals(tensp)
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham_ThuongHieu(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        where th.TenThuongHieu == str
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham_DanhMuc(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        where dm.TenDanhMuc == str
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham_XuatXu(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        where sp.XuatXu == str
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ImageProductDTO> getHinhAnhSanPham_GioiTinh(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        join ha in context.ImageSanPhams on sp.MaSanPham equals ha.MaSanPham
                        where sp.GioiTinh == str
                        group ha by new { sp.MaSanPham, sp.TenSanPham } into grouped
                        select new ImageProductDTO
                        {
                            imglink = grouped.FirstOrDefault().ImageURL,
                            masp = grouped.Key.MaSanPham.ToString(),
                            tensp = grouped.Key.TenSanPham,
                        };

            return query.ToList();
        }

        public List<ProductDTO> getDanhSachSanPham(string tensp)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.TenSanPham.Contains(tensp)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public void insertSanPhamMoi(string tensp, string gtinh, string xxu, string mota, double giagoc, double giagiam, int soluong, int danhmuc, int thuonghieu)
        {
            //context.ThemSanPham();
            //context.SubmitChanges();
        }

        public int GetIdSanPham(string tensp)
        {
            var query = from sp in context.SanPhams
                        where sp.TenSanPham == tensp
                        select sp.MaSanPham;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public int GetSoLuongCoTrongKho(string masp)
        {
            var query = from kh in context.KhoHangs
                        where kh.MaSanPham == int.Parse(masp)
                        select kh.SoLuongTonKho;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public List<ProductDTO> TimKiemSanPhamTheoThuongHieu(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where th.TenThuongHieu == str
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamTheoDanhMuc(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where dm.TenDanhMuc == str
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamTheoXuatXu(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.XuatXu == str
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamTheoGioiTinh(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.GioiTinh == str
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamTheoTenSanPham(string str)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.TenSanPham == str
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public string getGioiTinhSP(string masp)
        {
            var query = from sp in context.SanPhams
                        where sp.MaSanPham == int.Parse(masp)
                        select sp.GioiTinh;

            return query.FirstOrDefault().ToString();
        }

        public string getXuatXuSP(string masp)
        {
            var query = from sp in context.SanPhams
                        where sp.MaSanPham == int.Parse(masp)
                        select sp.XuatXu;

            return query.FirstOrDefault().ToString();
        }

        public string getThuongHieuSP(string masp)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.MaSanPham == int.Parse(masp)
                        select th.TenThuongHieu;

            return query.FirstOrDefault().ToString();
        }

        public string getDanhMucSP(string masp)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.MaSanPham == int.Parse(masp)
                        select dm.TenDanhMuc;

            return query.FirstOrDefault().ToString();
        }

        public double getGiaGocSP(string masp)
        {
            var query = from sp in context.SanPhams
                        where sp.MaSanPham == int.Parse(masp)
                        select sp.GiaGoc;

            return query.FirstOrDefault();
        }

        public double getGiaGiamSP(string masp)
        {
            var query = from sp in context.SanPhams
                        where sp.MaSanPham == int.Parse(masp)
                        select sp.GiaGiam;

            return query.FirstOrDefault();
        }

        public void CapNhatSoLuongSanPhamTrongKho(string masp, int soluong)
        {
            var khohangsp = context.KhoHangs.SingleOrDefault(kh => kh.MaSanPham == int.Parse(masp));
            if (khohangsp != null)
            {
                khohangsp.SoLuongTonKho = soluong;
                context.SubmitChanges();
            }
        }

        //-------------Form Product

        public List<string> LayDanhSachDanhMuc()
        {
            var query = context.DanhMucSanPhams.Select(dm => dm.TenDanhMuc).Distinct().ToList();
            return query;
        }

        public List<string> LayDanhSachThuongHieu()
        {
            var query = context.ThuongHieus.Select(dm => dm.TenThuongHieu).Distinct().ToList();
            return query;
        }

        public List<string> LayDanhSachGioiTinh()
        {
            var query = context.SanPhams.Select(dm => dm.GioiTinh).Distinct().ToList();
            return query;
        }

        public int LayMaDanhMuc(string str)
        {
            var query = from dm in context.DanhMucSanPhams where dm.TenDanhMuc == str select dm.MaDanhMuc;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public int LayMaThuongHieu(string str)
        {
            var query = from dm in context.ThuongHieus where dm.TenThuongHieu == str select dm.MaThuongHieu;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public int LayMaSanPham(string str)
        {
            var query = from dm in context.SanPhams where dm.TenSanPham == str select dm.MaSanPham;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public void ThemSanPhamMoi(string tensp, string gt, string xx, string mota, double giagoc, double giagiam, int dm, int th)
        {
            context.ThemSanPham(tensp, gt, xx, mota, giagoc, giagiam, dm, th);
            context.SubmitChanges();
        }

        public void XoaSanPham(string tensp)
        {
            var query = context.SanPhams.FirstOrDefault(sp => sp.TenSanPham.Equals(tensp));
            if (query != null)
            {
                context.SanPhams.DeleteOnSubmit(query);
                context.SubmitChanges();
            }
        }

        public void CapNhatSanPham(string tensp, string gt, string xx, string mota, double giagoc, double giagiam, int dm, int th)
        {
            var query = context.SanPhams.FirstOrDefault(sp => sp.TenSanPham.Equals(tensp));
            if (query != null)
            {
                query.TenSanPham = tensp;
                query.GioiTinh = gt;
                query.XuatXu = xx;
                query.MoTa = mota;
                query.GiaGoc = giagoc;
                query.GiaGiam = giagiam;
                query.MaDanhMuc = dm;
                query.MaThuongHieu = th;

                context.SubmitChanges();
            }
        }

        public List<ImageProductDTO> getHinhAnhSanPham(int masp)
        {
            var query = context.ImageSanPhams
                .Where(sp => sp.MaSanPham == masp)
                .Select(sp => new ImageProductDTO
                {
                    imglink = sp.ImageURL,
                    masp = sp.MaSanPham.ToString(),
                    tensp = sp.SanPham.TenSanPham
                })
                .ToList();

            return query;
        }

        public void ThemHinhAnhChoSanPham(int masp, string url)
        {
            SanPham sanPham = context.SanPhams.FirstOrDefault(sp => sp.MaSanPham == masp);
            if (sanPham != null)
            {
                ImageSanPham imageSanPham = new ImageSanPham
                {
                    MaSanPham = masp,
                    ImageURL = url
                };
                context.ImageSanPhams.InsertOnSubmit(imageSanPham);
                context.SubmitChanges();
            }
        }

        public void XoaHinhAnhChoSanPham(string url)
        {
            var query = from img in context.ImageSanPhams where img.ImageURL == url select img;
            if (query.Any())
            {
                context.ImageSanPhams.DeleteOnSubmit(query.FirstOrDefault());
                context.SubmitChanges();
            }    
        }

        public void XoaTatCaHinhAnhCuaSanPham(int masp)
        {
            var query = from img in context.ImageSanPhams where img.MaSanPham == masp select img;
            if (query.Any())
            {
                context.ImageSanPhams.DeleteAllOnSubmit(query);
                context.SubmitChanges();
            }
        }

        public List<string> LayDanhSachLinkAnhTheoMaSP(int masp)
        {
            var query = from img in context.ImageSanPhams where img.MaSanPham == masp select img.ImageURL;
            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamTheoTenSP(string tensp)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.TenSanPham.Contains(tensp)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamXuatXu(string xxu)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.XuatXu.Contains(xxu)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamGioiTinh(string gt)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where sp.GioiTinh.Contains(gt)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamDanhMuc(string gt)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where dm.TenDanhMuc.Contains(gt)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public List<ProductDTO> TimKiemSanPhamThuongHieu(string gt)
        {
            var query = from sp in context.SanPhams
                        join dm in context.DanhMucSanPhams on sp.MaDanhMuc equals dm.MaDanhMuc
                        join th in context.ThuongHieus on sp.MaThuongHieu equals th.MaThuongHieu
                        where th.TenThuongHieu.Contains(gt)
                        select new ProductDTO
                        {
                            TenSanPham = sp.TenSanPham,
                            GioiTinh = sp.GioiTinh,
                            XuatXu = sp.XuatXu,
                            MoTa = sp.MoTa,
                            GiaGoc = sp.GiaGoc,
                            GiaGiam = sp.GiaGiam,
                            TenDanhMuc = dm.TenDanhMuc,
                            TenThuongHieu = th.TenThuongHieu
                        };

            return query.ToList();
        }

        public int DemSoLuongSanPham()
        {
            var soLuong = context.SanPhams.Count();
            return soLuong;
        }

        public bool KiemTraTonKho(int maSanPham)
        {
            var tonKho = context.KhoHangs.SingleOrDefault(kh => kh.MaSanPham == maSanPham);
            if (tonKho != null)
                return true;
            return false;
        }
    }
}
