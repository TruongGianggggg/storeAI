using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class ImportBLL : BaseBLL
    {
        public ImportBLL() : base() { }

        public List<ImportDTO> GetDataNhapKho()
        {
            try
            {
                var importList = (from nk in context.NhapKhos
                                  join nv in context.NhanViens on nk.MaNhanVien equals nv.MaNhanVien
                                  where nk.TrangThai == "Đang nhập kho  "
                                  select new ImportDTO
                                  {
                                      idnhapkho = nk.MaNhapKho.ToString(),
                                      tennhanvien = nv.HoTen,
                                      ngaynhapkho = nk.NgayNhapKho,
                                      trangthai = nk.TrangThai
                                  }).ToList();

                return importList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<ImportDTO> GetDataNhapKhoHoanThanh()
        {
            try
            {
                var importList = (from nk in context.NhapKhos
                                  join nv in context.NhanViens on nk.MaNhanVien equals nv.MaNhanVien
                                  where nk.TrangThai == "Hoàn thành"
                                  select new ImportDTO
                                  {
                                      idnhapkho = nk.MaNhapKho.ToString(),
                                      tennhanvien = nv.HoTen,
                                      ngaynhapkho = nk.NgayNhapKho,
                                      trangthai = nk.TrangThai
                                  }).ToList();

                return importList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }



        public void ThemNhapKho(int idnk, DateTime ngaylap)
        {
            context.ThemNhapKho(idnk, ngaylap);
            context.SubmitChanges();
        }

        public void XoaNhapKho(string mank)
        {
            try
            {
                var nhapkhodelete = context.NhapKhos
                        .SingleOrDefault(cthd => cthd.MaNhapKho.ToString() == mank);

                if (nhapkhodelete != null)
                {
                    context.NhapKhos.DeleteOnSubmit(nhapkhodelete);
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void ThemChiTietNhapKho(int idnk, int idsp, int solg)
        {
            var existingDetail = context.ChiTietNhapKhos
                .FirstOrDefault(detail => detail.MaNhapKho == idnk && detail.MaSanPham == idsp);

            if (existingDetail != null)
            {
                // Product already exists, update the quantity
                existingDetail.SoLuongNhapKho += solg;
            }
            else
            {
                // Product does not exist, add a new entry
                context.ThemChiTietNhapKho(idnk, idsp, solg);
            }

            // Cập nhật số lượng tồn kho
            CapNhatSoLuongTonKho(idsp, solg);

            context.SubmitChanges();
        }



        public void XoaChiTietNhapKho(string mank)
        {
            try
            {
                var ctnhapkhodelete = context.ChiTietNhapKhos
                        .SingleOrDefault(cthd => cthd.MaChiTietNhapKho.ToString() == mank);

                if (ctnhapkhodelete != null)
                {
                    int soLuongGiam = ctnhapkhodelete.SoLuongNhapKho;

                    CapNhatSoLuongTonKho((int)ctnhapkhodelete.MaSanPham, -soLuongGiam);

                    context.ChiTietNhapKhos.DeleteOnSubmit(ctnhapkhodelete);
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public void SuaSoLuongChiTietNhapKho(int maChiTietNhapKho, int soLuongMoi)
        {
            try
            {
                var chiTietNhapKho = context.ChiTietNhapKhos
                    .FirstOrDefault(cthd => cthd.MaChiTietNhapKho == maChiTietNhapKho);

                if (chiTietNhapKho != null)
                {
                    // Lấy số lượng cũ trong chi tiết nhập kho
                    int soLuongCu = chiTietNhapKho.SoLuongNhapKho;

                    // Cập nhật số lượng trong chi tiết nhập kho
                    chiTietNhapKho.SoLuongNhapKho = soLuongMoi;
                    context.SubmitChanges();

                    // Cập nhật số lượng tồn kho
                    CapNhatSoLuongTonKho((int)chiTietNhapKho.MaSanPham, soLuongMoi - soLuongCu);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }


        public List<DeatailImportDTO> GetDataChiTietNhapKho(int mank)
        {
            try
            {

                var detailImportList = (from nk in context.ChiTietNhapKhos
                                        join sp in context.SanPhams on nk.MaSanPham equals sp.MaSanPham
                                        where nk.MaNhapKho == mank
                                        select new DeatailImportDTO
                                        {
                                            MaChiTietNhapKho = nk.MaChiTietNhapKho,
                                            MaNhapKho = (int)nk.MaNhapKho,
                                            TenSanPham = sp.TenSanPham,
                                            SoLuong = nk.SoLuongNhapKho
                                        }).ToList();

                return detailImportList;
            }
            catch (FormatException ex)
            {
                throw new ArgumentException("Không thể chuyển đổi mã nhập kho sang kiểu int.", ex);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<string> GetDanhSachTenDanhMuc()
        {
            try
            {
                var lst = (from danhMuc in context.DanhMucSanPhams
                           select danhMuc.TenDanhMuc).ToList();

                return lst;
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
                var lst = (from danhMuc in context.ThuongHieus select danhMuc.TenThuongHieu).ToList();
                return lst;
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
                var xuatXuList = context.SanPhams
                        .Select(sanPham => sanPham.XuatXu)
                        .Distinct()
                        .ToList();

                return xuatXuList;
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
                var xuatXuList = context.SanPhams
                        .Select(sanPham => sanPham.GioiTinh)
                        .Distinct()
                        .ToList();

                return xuatXuList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void CapNhatTrangThaiNhapKho(int maNhapKho, string trangThaiMoi)
        {
            try
            {
                var phieuNhapKho = context.NhapKhos
                    .SingleOrDefault(nk => nk.MaNhapKho == maNhapKho);

                if (phieuNhapKho != null)
                {
                    phieuNhapKho.TrangThai = trangThaiMoi;
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public void CapNhatSoLuongTonKho(int maSanPham, int soLuongNhapKho)
        {
            try
            {
                var khoHang = context.KhoHangs
                    .FirstOrDefault(kh => kh.MaSanPham == maSanPham);

                if (khoHang != null)
                {
                    khoHang.SoLuongTonKho += soLuongNhapKho;
                    context.SubmitChanges();
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        // In ImportBLL class
        public DeatailImportDTO GetDetailImportById(int maChiTietNhapKho)
        {
            try
            {
                var detailImport = context.ChiTietNhapKhos
                    .Where(ct => ct.MaChiTietNhapKho == maChiTietNhapKho)
                    .Select(ct => new DeatailImportDTO
                    {
                        MaChiTietNhapKho = ct.MaChiTietNhapKho,
                        MaNhapKho = (int)ct.MaNhapKho,
                        // Add other properties as needed
                    })
                    .FirstOrDefault();

                return detailImport;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw;
            }
        }

        public List<PrintBillDTO> InBill(string mahd)
        {
            var query = from cthd in context.ChiTietNhapKhos
                        join sp in context.SanPhams on cthd.MaSanPham equals sp.MaSanPham
                        where cthd.MaNhapKho.Equals(mahd)
                        select new PrintBillDTO
                        {
                            tensp = sp.TenSanPham,
                            soluong = cthd.SoLuongNhapKho
                        };
            return query.ToList();
        }

        public List<ChiTietNhapKho> GetDataChiTietNhapKho1(int mank)
        {
            var query = context.ChiTietNhapKhos.Where(nk => nk.MaNhapKho == mank).ToList();
            return query.ToList();
        }

        //Kiểm tra sản phẩm có trong kho
        public bool KiemTraSanPhamCoTrongKho(int masp)
        {
            var query = context.KhoHangs.Where(kh => kh.MaSanPham == masp);
            if (query == null)
                return false;
            else 
                return true;
        }

        //Sản phẩm có sẵn, cập nhật số lượng
        public void UpdateSoLuongSanPham(int masp, int soluong)
        {
            var query = context.KhoHangs.Where(sp => sp.MaSanPham == masp).ToList();
            if (query != null)
            {
                query.FirstOrDefault().SoLuongTonKho = soluong;
                context.SubmitChanges();
            }
        }

        public int LaySoLuongSanPhamTrongKho(int masp)
        {
            var query = from kh in context.KhoHangs where kh.MaSanPham == masp select kh.SoLuongTonKho;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        //Sản phẩm mới, thêm vào kho hàng
        public void ThemSanPhamMoiVaoKhoHang(int masp, int soluong)
        {
            KhoHang khoHang = new KhoHang();
            khoHang.MaSanPham = masp;
            khoHang.SoLuongTonKho = soluong;
            context.KhoHangs.InsertOnSubmit(khoHang);
            context.SubmitChanges();
        }
    }
}
