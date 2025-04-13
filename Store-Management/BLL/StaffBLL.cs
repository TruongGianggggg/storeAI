using DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace BLL
{
    public class StaffBLL : BaseBLL
    {
        public StaffBLL() : base() { }

        public List<StaffDTO> getDanhSachNhanVien()
        {
            var lst = context.NhanViens
                           .Select(nv => new StaffDTO
                           {
                               MaNhanVien = nv.MaNhanVien,
                               HoTen = nv.HoTen,
                               Email = nv.Email,
                               NgaySinh = (DateTime)nv.NgaySinh,
                               SoDienThoai = nv.SoDienThoai,
                               CCCD = nv.CCCD,
                               DiaChi = nv.DiaChi,
                           })
                           .ToList();

            return lst;
        }

        public List<StaffDTO> TimKiemNhanVienTheoTen(string str)
        {
            var lst = context.NhanViens
                           .Select(nv => new StaffDTO
                           {
                               MaNhanVien = nv.MaNhanVien,
                               HoTen = nv.HoTen,
                               Email = nv.Email,
                               NgaySinh = (DateTime)nv.NgaySinh,
                               SoDienThoai = nv.SoDienThoai,
                               CCCD = nv.CCCD,
                               DiaChi = nv.DiaChi,
                           })
                           .Where(nv => nv.HoTen.Contains(str))
                           .ToList();

            return lst;
        }

        public List<StaffDTO> TimKiemNhanVienTheoSDT(string str)
        {
            var lst = context.NhanViens
                           .Select(nv => new StaffDTO
                           {
                               MaNhanVien = nv.MaNhanVien,
                               HoTen = nv.HoTen,
                               Email = nv.Email,
                               NgaySinh = (DateTime)nv.NgaySinh,
                               SoDienThoai = nv.SoDienThoai,
                               CCCD = nv.CCCD,
                               DiaChi = nv.DiaChi,
                           })
                           .Where(nv => nv.SoDienThoai.Contains(str))
                           .ToList();

            return lst;
        }

        public List<StaffDTO> TimKiemNhanVienTheoCCCD(string str)
        {
            var lst = context.NhanViens
                           .Select(nv => new StaffDTO
                           {
                               MaNhanVien = nv.MaNhanVien,
                               HoTen = nv.HoTen,
                               Email = nv.Email,
                               NgaySinh = (DateTime)nv.NgaySinh,
                               SoDienThoai = nv.SoDienThoai,
                               CCCD = nv.CCCD,
                               DiaChi = nv.DiaChi,
                           })
                           .Where(nv => nv.CCCD.Contains(str))
                           .ToList();

            return lst;
        }

        public void ThemNhanVien(string hoTen, string email, string soDienThoai, string diaChi, DateTime date, string cccd)
        {
            context.Them_Nhan_Vien(
                hoTen,
                email,
                soDienThoai,
                diaChi,
                date,
                cccd
            );
            context.SubmitChanges();

        }

        public void XoaNhanVien(int MaNhanVien)
        {
            var nhanvienToRemove = context.NhanViens.SingleOrDefault(dv => dv.MaNhanVien == MaNhanVien);
            if (nhanvienToRemove != null)
            {
                context.NhanViens.DeleteOnSubmit(nhanvienToRemove);
                context.SubmitChanges();
            }
        }

        public int LayIDtuEmail(string email)
        {
            // Kiểm tra xem số điện thoại có tồn tại không
            var nhanVien = context.NhanViens.FirstOrDefault(kh => kh.Email == email);

            // Nếu khách hàng tồn tại, trả về MaKhachHang, ngược lại trả về giá trị mặc định
            return nhanVien != null ? nhanVien.MaNhanVien : -1;
        }



        public bool KiemTraEmail(string email)
        {
            var nhanVien = context.NhanViens.SingleOrDefault(kh => kh.Email == email);
            // Nếu tồn tại khách hàng với email này, trả về true, ngược lại trả về false
            return nhanVien != null;
        }

        public void CapNhatNhanVien(string hoTen, string email, DateTime date, string soDienThoai, string cccd, string diaChi, int id_nhanvien)
        {
            var nhanvienToUpdate = context.NhanViens.SingleOrDefault(kh => kh.MaNhanVien == id_nhanvien);
            if (nhanvienToUpdate != null)
            {
                nhanvienToUpdate.HoTen = hoTen;
                nhanvienToUpdate.Email = email;
                nhanvienToUpdate.NgaySinh = date;
                nhanvienToUpdate.SoDienThoai = soDienThoai;
                nhanvienToUpdate.CCCD = cccd;
                nhanvienToUpdate.DiaChi = diaChi;

                context.SubmitChanges();
            }
        }
    }
}
