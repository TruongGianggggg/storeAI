using DTO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BLL
{
    public class CustomerBLL : BaseBLL
    {
        public CustomerBLL() : base() { }
        public List<CustomerDTO> getDanhSachKhachHang()
        {
            var lst = context.KhachHangs
                           .Select(kh => new CustomerDTO
                           {
                               ID = kh.MaKhachHang,
                               HoTenDem = kh.HoTenDem,
                               Ten = kh.Ten,
                               Email = kh.Email,
                               SoDienThoai = kh.SoDienThoai,
                               DiaChi = kh.DiaChi
                           })
                           .ToList();

            return lst;
        }

        public void ThemKhachHang(string hoTenDem, string ten, string email, string soDienThoai, string diaChi)
        {
            // Thêm khách hàng mới vào cơ sở dữ liệu
            context.ThemKhachHang(
                hoTenDem,
                ten,
                email,
                soDienThoai,
                diaChi
            );

            // Lưu thay đổi vào cơ sở dữ liệu
            context.SubmitChanges();


        }

        public void XoaKhachHang(int MaKhachHang)
        {
            var khachhangToRemove = context.KhachHangs.SingleOrDefault(dv => dv.MaKhachHang == MaKhachHang);
            if (khachhangToRemove != null)
            {
                context.KhachHangs.DeleteOnSubmit(khachhangToRemove);
                context.SubmitChanges();
            }
        }

        public int LayIDtuEmail(string email)
        {
            // Kiểm tra xem số điện thoại có tồn tại không
            var khachHang = context.KhachHangs.FirstOrDefault(kh => kh.Email == email);

            // Nếu khách hàng tồn tại, trả về MaKhachHang, ngược lại trả về giá trị mặc định
            return khachHang != null ? khachHang.MaKhachHang : -1;
        }



        public bool KiemTraEmail(string email)
        {
            // Kiểm tra xem có khách hàng nào có email giống với email truyền vào hay không
            var khachHang = context.KhachHangs.SingleOrDefault(kh => kh.Email == email);

            // Nếu tồn tại khách hàng với email này, trả về true, ngược lại trả về false
            return khachHang != null;
        }

        public void CapNhatKhachHang(string hoTenDem, string ten, string email, string soDienThoai, string diaChi, int id_khachhang)
        {
            var khachhangToUpdate = context.KhachHangs.SingleOrDefault(kh => kh.MaKhachHang == id_khachhang);
            if (khachhangToUpdate != null)
            {
                khachhangToUpdate.HoTenDem = hoTenDem;
                khachhangToUpdate.Ten = ten;
                khachhangToUpdate.Email = email;
                khachhangToUpdate.SoDienThoai = soDienThoai;
                khachhangToUpdate.DiaChi = diaChi;

                context.SubmitChanges();
            }
        }


        //kh
        public List<CustomerDTO> GetKhachHangList_MaKhachHang(string texttimkiem)
        {
            try
            {
                var khachhangList = (from p in context.KhachHangs
                                  where p.MaKhachHang == int.Parse(texttimkiem)
                                     select new CustomerDTO
                                  {
                                      ID = p.MaKhachHang,
                                      HoTenDem = p.HoTenDem,
                                      Ten = p.Ten,
                                      Email = p.Email,
                                      SoDienThoai = p.SoDienThoai,
                                      DiaChi = p.DiaChi
                                      
                                  }).ToList();

                return khachhangList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<CustomerDTO> GetKhachHangList_SoDienThoai(string texttimkiem)
        {
            try
            {
                var khachhangList = (from p in context.KhachHangs
                                     where p.SoDienThoai == texttimkiem
                                     select new CustomerDTO
                                     {
                                         ID = p.MaKhachHang,
                                         HoTenDem = p.HoTenDem,
                                         Ten = p.Ten,
                                         Email = p.Email,
                                         SoDienThoai = p.SoDienThoai,
                                         DiaChi = p.DiaChi

                                     }).ToList();

                return khachhangList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

        public List<CustomerDTO> GetKhachHangList_Email(string texttimkiem)
        {
            try
            {
                var khachhangList = (from p in context.KhachHangs
                                     where p.Email == texttimkiem
                                     select new CustomerDTO
                                     {
                                         ID = p.MaKhachHang,
                                         HoTenDem = p.HoTenDem,
                                         Ten = p.Ten,
                                         Email = p.Email,
                                         SoDienThoai = p.SoDienThoai,
                                         DiaChi = p.DiaChi

                                     }).ToList();

                return khachhangList;
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
                throw ex;
            }
        }

    }
}
