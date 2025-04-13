using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class AccountCustomerBLL : BaseBLL
    {
        public AccountCustomerBLL() : base() { }

        private string HashPassword(string password)
        {
            using (SHA256 sha256 = SHA256.Create())
            {
                byte[] hashedBytes = sha256.ComputeHash(Encoding.UTF8.GetBytes(password));
                return BitConverter.ToString(hashedBytes).Replace("-", "").ToLower();
            }
        }

        public List<AccountCustomerDTO> LoadData()
        {
            var query = from tk in context.TaiKhoanKhachHangs
                        join kh in context.KhachHangs on tk.MaKhachHang equals kh.MaKhachHang
                        select new AccountCustomerDTO
                        {
                            IDTaiKhoan = tk.MaTaiKhoan,
                            TenTK = tk.TaiKhoan,
                            Pass = HashPassword(tk.MatKhau),
                            IDKhachHang = tk.MaKhachHang,
                            TenKH = kh.HoTenDem + " " + kh.Ten,
                            Email = kh.Email,
                            SDT = kh.SoDienThoai,
                            HoatDong = tk.HoatDong
                        };

            return query.ToList();
        }

        public List<string> LoadKhachHang()
        {
            var query = from kh in context.KhachHangs select kh.HoTenDem + " " + kh.Ten;

            return query.ToList();
        }

        public string LayEmail(string ten)
        {
            var query = from kh in context.KhachHangs
                        where (kh.HoTenDem + " " + kh.Ten).Equals(ten)
                        select kh.Email;
            return query.FirstOrDefault().ToString();
        }

        public string LaySDT(string ten)
        {
            var query = from kh in context.KhachHangs
                        where (kh.HoTenDem + " " + kh.Ten).Equals(ten)
                        select kh.SoDienThoai;
            return query.FirstOrDefault().ToString();
        }

        public int LayIdKhachHang(string ten)
        {
            var query = from kh in context.KhachHangs
                        where (kh.HoTenDem + " " + kh.Ten).Equals(ten)
                        select kh.MaKhachHang;
            return int.Parse(query.FirstOrDefault().ToString());
        }

        public bool KiemTraTonTaiTaiKhoan(string email)
        {
            bool tonTai = context.TaiKhoanKhachHangs.Any(tk => tk.KhachHang.Email == email);
            return tonTai;
        }


        public void ThemTaiKhoanKhachHang(string tentk, int IDKhachHang, string hoatdong)
        {
            TaiKhoanKhachHang newtk = new TaiKhoanKhachHang();
            newtk.TaiKhoan = tentk;
            newtk.MatKhau = "123";
            newtk.MaKhachHang = IDKhachHang;
            newtk.HoatDong = hoatdong;
            context.TaiKhoanKhachHangs.InsertOnSubmit(newtk);
            context.SubmitChanges();
        }

        public void XoaTaiKhoanKhachHang(string email)
        {
            var query = from tk in context.TaiKhoanKhachHangs
                        join kh in context.KhachHangs on tk.MaKhachHang equals kh.MaKhachHang
                        where kh.Email == email
                        select tk;
            if (query != null)
            {
                context.TaiKhoanKhachHangs.DeleteOnSubmit(query.FirstOrDefault());
                context.SubmitChanges();
            }
        }

        public void CapNhatTaiKhoanKhachHang(string email, string tentk, string hoatdong)
        {
            var query = from tk in context.TaiKhoanKhachHangs
                        join kh in context.KhachHangs on tk.MaKhachHang equals kh.MaKhachHang
                        where kh.Email == email
                        select tk;
            if (query != null)
            {
                query.FirstOrDefault().TaiKhoan = tentk;
                query.FirstOrDefault().HoatDong = hoatdong;

                context.SubmitChanges();
            }
        }

        public void ResetPassword(string email)
        {
            var query = from tk in context.TaiKhoanKhachHangs
                        join kh in context.KhachHangs on tk.MaKhachHang equals kh.MaKhachHang
                        where kh.Email == email
                        select tk;
            if (query != null)
            {
                query.FirstOrDefault().MatKhau = "123";

                context.SubmitChanges();
            }
        }
    }
}
