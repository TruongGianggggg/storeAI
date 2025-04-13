using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountStaffBLL : BaseBLL
    {
        public AccountStaffBLL() : base() { }
        public List<AccountStaffDTO> LoadData()
        {
            var query = from tk in context.TaiKhoanNhanViens
                        join nv in context.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                        select new AccountStaffDTO
                        {
                            tennv = nv.HoTen,
                            taikhoan = tk.TaiKhoan,
                            matkhau = HashPassword(tk.MatKhau),
                            hoatdong = tk.HoatDong,
                            quyen = tk.Quyen,
                        };

            return query.ToList();
        }
        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }
        public List<string> LoadListNhanVien()
        {
            var query = from nv in context.NhanViens select nv.HoTen;
            return query.ToList();
        }
        public void XoaTaiKhoan(int manv, string taikhoan)
        {
            var query = context.TaiKhoanNhanViens.FirstOrDefault(tk => tk.MaNhanVien == manv && tk.TaiKhoan == taikhoan);
            if (query != null)
            {
                context.TaiKhoanNhanViens.DeleteOnSubmit(query);
                context.SubmitChanges();
            }
        }
        public int LayMaNhanVien(string str)
        {
            var query = from nv in context.NhanViens where nv.HoTen == str select nv.MaNhanVien;
            return int.Parse(query.FirstOrDefault().ToString());
        }
        public void ThemTaiKhoan(int manv, string taikhoan, string pass, string hoatdong, string quyen)
        {
            TaiKhoanNhanVien newtk = new TaiKhoanNhanVien
            {
                MaNhanVien = manv,
                TaiKhoan = taikhoan,
                MatKhau = pass,
                HoatDong = hoatdong,
                Quyen = quyen
            };
            context.TaiKhoanNhanViens.InsertOnSubmit(newtk);
            context.SubmitChanges();
        }
        public void CapNhatTaiKhoan(int manv, string taikhoan, string hoatdong, string quyen)
        {
            var query = context.TaiKhoanNhanViens.FirstOrDefault(tk => tk.MaNhanVien == manv);
            if (query != null)
            {
                query.TaiKhoan = taikhoan;
                query.HoatDong = hoatdong;
                query.Quyen = quyen;

                context.SubmitChanges();
            }
        }
        public void ResetPassword(int manv, string taikhoan)
        {
            var query = context.TaiKhoanNhanViens.FirstOrDefault(tk => tk.MaNhanVien == manv && tk.TaiKhoan == taikhoan);
            if (query != null)
            {
                query.MatKhau = "123";
                context.SubmitChanges();
            }    
        }
        public string GetMatKhau(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);

            if (account != null)
            {
                return account.MatKhau;
            }
            else
            {
                return "Không tìm thấy tài khoản";
            }
        }
        public string GetTenDangNhap(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);

            if (account != null)
            {
                return account.TaiKhoan;
            }
            else
            {
                return "Không tìm thấy tài khoản";
            }
        }
        public void ChangePassword(string user, string pass)
        {
            var acc = context.TaiKhoanNhanViens.SingleOrDefault(tk => tk.TaiKhoan == user);
            acc.MatKhau = pass;
            context.SubmitChanges();
        }
    }
}
