using System.Linq;

namespace BLL
{
    public class LoginBLL : BaseBLL
    {
        public LoginBLL() : base() { }
        public string LayTenDangNhap(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);
            if (account != null)
                return account.TaiKhoan;
            else
                return "Không tìm thấy tài khoản";
        }
        public string LayMatKhau(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);
            if (account != null)
                return account.MatKhau;
            else
                return "Không tìm thấy tài khoản";
        }
        public string LayQuyen(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);
            if (account != null)
                return account.Quyen;
            else
                return "Không tìm thấy tài khoản";
        }
        public int LayMaNhanVien(string taiKhoan)
        {
            var query = from tk in context.TaiKhoanNhanViens
                        join nv in context.NhanViens on tk.MaNhanVien equals nv.MaNhanVien
                        where tk.TaiKhoan == taiKhoan
                        select nv.MaNhanVien;

            int manv = query.FirstOrDefault();

            return manv;
        }
        public int LayHoatDong(string tendangnhap)
        {
            var account = context.TaiKhoanNhanViens.FirstOrDefault(nv => nv.TaiKhoan == tendangnhap);
            if (account != null)
                return int.Parse(account.HoatDong.ToString());
            else
                return 0;
        }
    }
}
